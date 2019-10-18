using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Npgsql;
using FisioHelp.DataModels;
using System.Configuration;

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
        var invoices = db.Invoices.Where(x => x.Date >= new NpgsqlTypes.NpgsqlDate(DateTime.Now.Year, DateTime.Now.Month, 1)).ToList();
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
        Deleted = false,
        Title = invoiceTile,
        TaxStamp = false,
        TherapistId = therapist.Id
      };

      message = "";
      return newInvoice;
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

    public static string ReplaceInvoicePlaceHolder (string template, Customer customer, Invoice invoice)
    {
      var therapist = GetTherapist();

      template = template.Replace("{{ragione_sociale}}", therapist.FullName);
      template = template.Replace("{{indirizzo}}", customer.Language == "german" ? therapist.AddressDe.Replace("-","<br>") : therapist.Address.Replace("-", "<br>"));
      template = template.Replace("{{partita_iva}}", therapist.TaxNumber);
      template = template.Replace("{{iban}}", therapist.Iban);
      
      template = template.Replace("{{invoice_number}}", invoice.Title);
      template = template.Replace("{{date}}", ((DateTime)invoice.Date).ToShortDateString());

      template = template.Replace("{{customer_name}}", customer.FullName);
      template = template.Replace("{{customer_address}}", $"{customer.Address?.Address_Column}<br>{customer.Address?.Cap}<br>{customer.Address?.City}" );
      template = template.Replace("{{customer_piva}}", customer.Fiscalcode);

      var prestazioniHtml = @"<div style=""display: block; padding: 15px 0 15px 0px;"">";

      foreach (var prestazioni in invoice.Visitsinvoiceidfkeys)
      {
        prestazioniHtml += $@"<div style=""width: 200px; display:inline-block;"">{((DateTime)prestazioni.Date).ToShortDateString()}</div>";

        var treatments = Helper.GetTratmensByIdS(prestazioni.Treatmentsvisitidfkeys.Select(x => x.TreatmentId).ToList(), customer.Language);

        prestazioniHtml += $@"<div style=""display:inline-block; width: 350px; vertical-align: middle;"">";
        foreach ( var treatment in treatments)
          prestazioniHtml += $@"<div>{treatment}</div>";
        prestazioniHtml += $@"</div><div style=""width: 150px; text-align:right; display:inline-block;"">{(prestazioni.Price.Value*0.96).ToString("#.00")} €</div>";
      }

      prestazioniHtml += "</div>";
      template = template.Replace("{{prestazioni}}", prestazioniHtml);

      var sconto = invoice.Discount??0;
      var total = invoice.Visitsinvoiceidfkeys.Sum(x => x.Price * 0.96) - (sconto * 0.96);
      var bollo = invoice.TaxStamp ? 2 : 0;
      var inps = (invoice.Visitsinvoiceidfkeys.Sum(x => x.Price) - sconto) * .04;
      template = template.Replace("{{bollo}}", bollo.ToString());
      var scontoTxt = sconto > 0 ? $@"
              <div style=""display: block; padding: 15px 0 15px 0px; "">
                  <div style = ""width: 400px; display: inline-block;""><strong> Sconto:</strong ></div>          
                  <div style = ""width: 295px; display: inline-block; text-align: right;"">-{(sconto * 0.96).ToString("#.00")} €</div>                 
              </div>" : "";

      template = template.Replace("{{sconto}}", scontoTxt);
      template = template.Replace("{{total}}", total.Value.ToString("#.00"));
      template = template.Replace("{{inps}}", inps.Value.ToString("#.00"));
      template = template.Replace("{{total_with_inps}}", (inps+total+bollo).Value.ToString("#.00"));

      return template;
    }
  }
}
