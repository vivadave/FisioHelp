using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Npgsql;
using FisioHelp.DataModels;
using System.Configuration;
using System.Net;

namespace FisioHelp.Helper
{
  public static class Helper
  {
    public static DataModels.Invoice CreateNewInvoice(List<DataModels.Visit> visits, out string message)
    {
      if (visits.Any(x => x.Invoiced))
      {
        message = "Una delle visite selezionate è già stata fatturata!";
        return null;
      }

      if (visits.Any(x => x.Payed) && !visits.All(x=>x.Payed))
      {
        message = "Non è possibile fatturare un insieme di visite dove solo alcune sono state già pagate";
        return null;
      }
      var invoiceTile = "";
      Therapist therapist = null;
      using (var db = new Db.PhisioDB())
      {
        var invoices = db.Invoices.Where(x => x.Date >= new NpgsqlTypes.NpgsqlDate(DateTime.Now.Year, 1, 1)).ToList();
        invoiceTile = $"{(invoices.Count + 1).ToString("0000")}/{DateTime.Now.Year}";
        therapist = db.Therapists.FirstOrDefault();
      }

      var newInvoice = new DataModels.Invoice
      {
        Date = new NpgsqlTypes.NpgsqlDate(DateTime.Now),
        Discount = 0,
        Payed = false,
        Text = "",
        Visitsinvoiceidfkeys = visits,
        Title = invoiceTile,
        TaxStamp = false,
        TherapistId = therapist.Id
      };

      message = "";
      return newInvoice;
    }

    public static DataModels.ProformaInvoice CreateNewProformaInvoice(List<DataModels.Visit> visits, out string message)
    {
      if (visits.Any(x => x.Invoiced))
      {
        message = "Una delle visite selezionate è già stata fatturata!";
        return null;
      }

      if (visits.Any(x => x.Payed) && !visits.All(x => x.Payed))
      {
        message = "Non è possibile fatturare un insieme di visite dove solo alcune sono state già pagate";
        return null;
      }
      var invoiceTile = "";
      Therapist therapist = null;
      using (var db = new Db.PhisioDB())
      {
        var proformaInvoices = db.ProformaInvoices.Where(x => x.Date >= new NpgsqlTypes.NpgsqlDate(DateTime.Now.Year, 1, 1)).ToList();
        invoiceTile = $"{(proformaInvoices.Count + 1).ToString("0000")}/{DateTime.Now.Year}";
        therapist = db.Therapists.FirstOrDefault();
      }

      var newProformaInvoice = new DataModels.ProformaInvoice
      {
        Date = new NpgsqlTypes.NpgsqlDate(DateTime.Now),
        Discount = 0,
        Payed = false,
        Text = "",
        Visitsproformainvoiceidfkeys = visits,
        Title = invoiceTile,
        TaxStamp = false,
        TherapistId = therapist.Id,
        Deleted = false,
        GroupVisits = false
      };

      message = "";
      return newProformaInvoice;
    }

    public static List<string> GetTratmensByIdS(List<Guid> ids, string language)
    {
      using (var db = new Db.PhisioDB())
      {
        var treatments = db.Treatments.Where(x => ids.Contains(x.Id)).ToList();

        if (language == "german")
          return treatments.Select(x => x.DescriptionDe).ToList();

        return treatments.Select(x => x.DescriptionIt).ToList();
      }
    }

    public static DataModels.Therapist GetTherapist()
    {
      using (var db = new Db.PhisioDB())
      {
        return db.Therapists.FirstOrDefault();
      }
    }

    public static void GenerateDB()
    {
      var dbFiles = Directory.GetFiles("sql");

      foreach( var fileName in dbFiles.OrderBy(x=>x))
      {
        FileInfo file = new FileInfo(fileName);
        string script = file.OpenText().ReadToEnd();
        var connstring = ConfigurationManager.ConnectionStrings["Phisio"].ConnectionString;
        NpgsqlConnection _connPg = new NpgsqlConnection(connstring);
        var m_createdb_cmd = new NpgsqlCommand(script, _connPg);
        _connPg.Open();
        m_createdb_cmd.ExecuteNonQuery();
        _connPg.Close();
      }
    }

    public static string ReplaceInvoicePlaceHolder(string template, Customer customer, Invoice invoice, bool groupVisits)
    {
      double rivalsa = 0;
      double prezPrieno = 1 - rivalsa;

      var therapist = GetTherapist();

      var pivaTxt = customer.Language == "german" ? "MwSt.-Nr: " : "Part.IVA : ";
      var cfTxt = customer.Language == "german" ? "Steuercodex: " : "Cod.fisc.: ";

      template = template.Replace("{{ragione_sociale}}", therapist.FullName);
      template = template.Replace("{{indirizzo}}", customer.Language == "german" ? therapist.AddressDe.Replace("-", "<br>") : therapist.Address.Replace("-", "<br>"));
      template = template.Replace("{{partita_iva}}", therapist.TaxNumber);
      template = template.Replace("{{cf}}", therapist.FiscalCode);
      template = template.Replace("{{iban}}", therapist.Iban);

      template = template.Replace("{{invoice_number}}", invoice.Title);
      template = template.Replace("{{date}}", ((DateTime)invoice.Date).ToShortDateString());

      template = template.Replace("{{customer_name}}", customer.FullName);
      template = template.Replace("{{customer_address}}", $"{customer.Address?.Address_Column}");
      template = template.Replace("{{address_display}}", $"{(string.IsNullOrEmpty(customer.Address?.Address_Column) ? "none" : "inherit")}");
      template = template.Replace("{{customer_cap}}", $"{customer.Address?.Cap}");
      template = template.Replace("{{cap_display}}", $"{(string.IsNullOrEmpty(customer.Address?.Cap) ? "none" : "inherit")}");
      template = template.Replace("{{customer_city}}", $"{customer.Address?.City}");
      template = template.Replace("{{city_display}}", $"{(string.IsNullOrEmpty(customer.Address?.City) ? "none" : "inherit")}");
      template = template.Replace("{{customer_piva}}", string.IsNullOrEmpty(customer.Vat) ? "" : pivaTxt + customer.Vat);
      template = template.Replace("{{piva_display}}", $"{(string.IsNullOrEmpty(customer.Vat) ? "none" : "inherit")}");
      template = template.Replace("{{customer_cf}}", string.IsNullOrEmpty(customer.Fiscalcode) ? "" : cfTxt + customer.Fiscalcode);
      template = template.Replace("{{cf_display}}", $"{(string.IsNullOrEmpty(customer.Fiscalcode) ? "none" : "inherit")}");
      template = template.Replace("{{group_display}}", $"{(groupVisits ? "inline-block" : "none" )}");
      var prestazioniHtml = @"<div style=""display: block; padding: 15px 0 15px 0px;"">";

      if (groupVisits)
      {
        var prestPriceList = new List<Tuple<string, double>>();
        foreach (var prestazioni in invoice.Visitsinvoiceidfkeys)
        {
          var prestazioniHtm = "";
          var treatments = Helper.GetTratmensByIdS(prestazioni.Treatmentsvisitidfkeys.Select(x => x.TreatmentId).ToList(), customer.Language);
          foreach (var treatment in treatments)
            prestazioniHtm += $@"<div>{treatment}</div>";

          prestPriceList.Add(new Tuple<string, double>(prestazioniHtm, prestazioni.Price.Value));
        }

        var list = prestPriceList.Distinct();

        foreach (var el in list)
        {
          var qt = prestPriceList.Count(pl => pl.Item1 == el.Item1);
          prestazioniHtml += $@"<div style=""width: 350px; display:inline-block;""> {el.Item1}</div>";
          prestazioniHtml += $@"<div style=""width: 100px; display:inline-block; text-align: right;""> {qt}</div>";
          prestazioniHtml += $@"<div style=""width: 100px; display:inline-block; text-align: right;""> {el.Item2.ToString("#.00")} €</div>";
          prestazioniHtml += $@"<div style=""width: 150px; text-align:right; display:inline-block;""> {(el.Item2 * qt).ToString("#.00")} €</div>";
        }
      }
      else
      {
        foreach (var prestazioni in invoice.Visitsinvoiceidfkeys)
        {
          prestazioniHtml += $@"<div style=""width: 200px; display:inline-block;"">{((DateTime)prestazioni.Date).ToShortDateString()}</div>";

          var treatments = Helper.GetTratmensByIdS(prestazioni.Treatmentsvisitidfkeys.Select(x => x.TreatmentId).ToList(), customer.Language);

          prestazioniHtml += $@"<div style=""display:inline-block; width: 350px; vertical-align: middle;"">";
          foreach (var treatment in treatments)
            prestazioniHtml += $@"<div>{treatment}</div>";
          prestazioniHtml += $@"</div><div style=""width: 150px; text-align:right; display:inline-block;"">{(prestazioni.Price.Value * prezPrieno).ToString("#.00")} €</div>";
        }
      }

      prestazioniHtml += "</div>";
      template = template.Replace("{{prestazioni}}", prestazioniHtml);

      var sconto = invoice.Discount ?? 0;
      var total = invoice.Visitsinvoiceidfkeys.Sum(x => x.Price * prezPrieno) - (sconto * prezPrieno);
      var bollo = invoice.TaxStamp ? 2 : 0;
      var bolloDisplay = bollo > 0 ? "block" : "none";

      template = template.Replace("{{bollo}}", bollo.ToString());
      template = template.Replace("{{bollo_display}}", bolloDisplay.ToString());

      template = template.Replace("{{sconto}}", (sconto * -prezPrieno).ToString("#.00"));
      template = template.Replace("{{sconto_display}}", sconto > 0 ? "block" : "none");

      template = template.Replace("{{total}}", total.Value.ToString("#.00"));
      template = template.Replace("{{total_with_inps}}", (total + bollo).Value.ToString("#.00"));

      return template;
    }

    public static string ReplaceProformaInvoicePlaceHolder(string template, Customer customer, ProformaInvoice invoice, bool groupVisits)
    {
      double rivalsa = 0;
      double prezPrieno = 1 - rivalsa;

      var therapist = GetTherapist();

      var pivaTxt = customer.Language == "german" ? "MwSt.-Nr: " : "Part.IVA : ";
      var cfTxt = customer.Language == "german" ? "Steuercodex: " : "Cod.fisc.: ";

      template = template.Replace("{{ragione_sociale}}", therapist.FullName);
      template = template.Replace("{{indirizzo}}", customer.Language == "german" ? therapist.AddressDe.Replace("-", "<br>") : therapist.Address.Replace("-", "<br>"));
      template = template.Replace("{{partita_iva}}", therapist.TaxNumber);
      template = template.Replace("{{cf}}", therapist.FiscalCode);
      template = template.Replace("{{iban}}", therapist.Iban); 

       template = template.Replace("{{invoice_number}}", invoice.Title);
      template = template.Replace("{{date}}", ((DateTime)invoice.Date).ToShortDateString());

      template = template.Replace("{{customer_name}}", customer.FullName);
      template = template.Replace("{{customer_address}}", $"{customer.Address?.Address_Column}");
      template = template.Replace("{{address_display}}", $"{(string.IsNullOrEmpty(customer.Address?.Address_Column) ? "none" : "inherit")}");
      template = template.Replace("{{customer_cap}}", $"{customer.Address?.Cap}");
      template = template.Replace("{{cap_display}}", $"{(string.IsNullOrEmpty(customer.Address?.Cap) ? "none" : "inherit")}");
      template = template.Replace("{{customer_city}}", $"{customer.Address?.City}");
      template = template.Replace("{{city_display}}", $"{(string.IsNullOrEmpty(customer.Address?.City) ? "none" : "inherit")}");
      template = template.Replace("{{customer_piva}}", string.IsNullOrEmpty(customer.Vat) ? "" : pivaTxt + customer.Vat);
      template = template.Replace("{{piva_display}}", $"{(string.IsNullOrEmpty(customer.Vat) ? "none" : "inherit")}");
      template = template.Replace("{{customer_cf}}", string.IsNullOrEmpty(customer.Fiscalcode) ? "" : cfTxt + customer.Fiscalcode);
      template = template.Replace("{{cf_display}}", $"{(string.IsNullOrEmpty(customer.Fiscalcode) ? "none" : "inherit")}");
      template = template.Replace("{{group_display}}", $"{(groupVisits ? "inline-block" : "none")}");

      var prestazioniHtml = @"<div style=""display: block; padding: 15px 0 15px 0px;"">";

      if (groupVisits)
      {
        var prestPriceList = new List<Tuple<string, double>>();
        foreach (var prestazioni in invoice.Visitsproformainvoiceidfkeys)
        {
          var prestazioniHtm = "";
          var treatments = Helper.GetTratmensByIdS(prestazioni.Treatmentsvisitidfkeys.Select(x => x.TreatmentId).ToList(), customer.Language);
          foreach (var treatment in treatments)
            prestazioniHtm += $@"<div>{treatment}</div>";

          prestPriceList.Add(new Tuple<string, double>(prestazioniHtm, prestazioni.Price.Value));
        }

        var list = prestPriceList.Distinct();

        foreach (var el in list)
        {
          var qt = prestPriceList.Count(pl => pl.Item1 == el.Item1);
          prestazioniHtml += $@"<div style=""width: 350px; display:inline-block;""> {el.Item1}</div>";
          prestazioniHtml += $@"<div style=""width: 100px; display:inline-block; text-align: right;""> {qt}</div>";
          prestazioniHtml += $@"<div style=""width: 100px; display:inline-block; text-align: right;""> {el.Item2.ToString("#.00")} €</div>";
          prestazioniHtml += $@"<div style=""width: 150px; text-align:right; display:inline-block;""> {(el.Item2 * qt).ToString("#.00")} €</div>";
        }
      }
      else
      {
        foreach (var prestazioni in invoice.Visitsproformainvoiceidfkeys)
        {
          prestazioniHtml += $@"<div style=""width: 200px; display:inline-block;"">{((DateTime)prestazioni.Date).ToShortDateString()}</div>";

          var treatments = Helper.GetTratmensByIdS(prestazioni.Treatmentsvisitidfkeys.Select(x => x.TreatmentId).ToList(), customer.Language);

          prestazioniHtml += $@"<div style=""display:inline-block; width: 350px; vertical-align: middle;"">";
          foreach (var treatment in treatments)
            prestazioniHtml += $@"<div>{treatment}</div>";
          prestazioniHtml += $@"</div><div style=""width: 150px; text-align:right; display:inline-block;"">{(prestazioni.Price.Value * prezPrieno).ToString("#.00")} €</div>";
        }
      }

      prestazioniHtml += "</div>";
      template = template.Replace("{{prestazioni}}", prestazioniHtml);

      var sconto = invoice.Discount ?? 0;
      var total = invoice.Visitsproformainvoiceidfkeys.Sum(x => x.Price * prezPrieno) - (sconto * prezPrieno);
      var bollo = invoice.TaxStamp ? 2 : 0;
      var bolloDisplay = bollo > 0 ? "block" : "none";

      template = template.Replace("{{bollo}}", bollo.ToString());
      template = template.Replace("{{bollo_display}}", bolloDisplay.ToString());

      template = template.Replace("{{sconto}}", (sconto * -prezPrieno).ToString("#.00"));
      template = template.Replace("{{sconto_display}}", sconto > 0 ? "block" : "none");

      template = template.Replace("{{total}}", total.Value.ToString("#.00"));

      template = template.Replace("{{total_with_inps}}", (total + bollo).Value.ToString("#.00"));

      return template;
    }

    public static string ReplacePrivacyPlaceHolder(string template, Customer customer)
    {
      var therapist = GetTherapist();
      
      template = template.Replace("{{ragione_sociale}}", therapist.FullName);
      template = template.Replace("{{indirizzo}}", customer.Language == "german" ? therapist.AddressDe.Replace("-", ", ") : therapist.Address.Replace("-", ", "));
      template = template.Replace("{{partita_iva}}", therapist.TaxNumber);
      template = template.Replace("{{tessera_aifi}}", therapist.Aifi);

      template = template.Replace("{{data}}", DateTime.Today.ToShortDateString());

      template = template.Replace("{{customer_name}}", customer.FullName);
      template = template.Replace("{{customer_address}}", $"{customer.Address?.Address_Column}");
      template = template.Replace("{{customer_cap}}", $"{customer.Address?.Cap}");
      template = template.Replace("{{customer_city}}", $"{customer.Address?.City}");
      template = template.Replace("{{customer_tel}}", $"{customer.Tel1}");
      template = template.Replace("{{customer_email}}", $"{customer.Email}");
      template = template.Replace("{{customer_rappresentante_legale}}", $"{customer.LegalRepresentative}");
      template = template.Replace("{{customer_cf}}", string.IsNullOrEmpty(customer.Fiscalcode) ? "" : customer.Fiscalcode);
      
      return template;
    }

    public static bool CheckForInternetConnection()
    {
      try
      {
        using (var client = new WebClient())
        using (client.OpenRead("http://google.com/generate_204"))
          return true;
      }
      catch
      {
        return false;
      }
    }
    
    public static void OpenIncognito()
    {
      var process = new System.Diagnostics.Process();
      process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
      var chrome = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)"), @"Google\Chrome\Application\chrome.exe");

      process.StartInfo.FileName = chrome;
      process.StartInfo.Arguments = $@"https://drive.google.com/drive/u/1/folders/1XqwQ6b48DmewlAqFH0-o_xR-gG1RNEHm --incognito";
      process.Start();
    }
  }
}
