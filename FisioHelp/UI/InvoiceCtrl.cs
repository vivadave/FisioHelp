﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.IO;
using LinqToDB;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp;

namespace FisioHelp.UI
{
  public partial class InvoiceCtrl : UserControl
  {
    public event EventHandler DeletedInvoice;
    public event EventHandler SavedInvoice;
    public DataModels.ProformaInvoice ProformaInvoice { get; set; }
    private DataModels.Customer _customer { get; set; }
    private DataModels.Therapist _therapist { get; set; }
    private const int LineHeight = 20;
    private bool _edit = false;
    private ToolTip _printInvoiceTT = new ToolTip();
    private ToolTip _printProInvoiceTT = new ToolTip();
    private bool _initialization = true;

    public InvoiceCtrl(DataModels.ProformaInvoice proformaInvoice, bool edit = false)
    {
      InitializeComponent();
      ProformaInvoice = proformaInvoice;
      _edit = edit;
      _printProInvoiceTT.SetToolTip(this.buttonPrintProformaInvoice, "Stampa la fattura proforma");
      _printInvoiceTT.SetToolTip(this.buttonPrintInvoice, "Stampa la fattura");

       ProformaInvoice.Visitsproformainvoiceidfkeys = ProformaInvoice.Visitsproformainvoiceidfkeys.Where(x=>x.Deleted == false).ToList();
      GetDbData();
    }

    private void GetDbData()
    {
      using (var db = new Db.PhisioDB())
      {
        ProformaInvoice.Invoice = db.Invoices.LoadWith(e1 => e1.Visitsinvoiceidfkeys.First().Treatmentsvisitidfkeys.First().Treatment).LoadWith(e1 => e1.Visitsinvoiceidfkeys.First().Customer.Address).FirstOrDefault(inv => inv.ProformaInvoiceId == ProformaInvoice.Id);
        if (ProformaInvoice.Invoice?.Visitsinvoiceidfkeys != null)
          ProformaInvoice.Invoice.Visitsinvoiceidfkeys = ProformaInvoice.Invoice.Visitsinvoiceidfkeys.Where(x => x.Deleted == false);
        _therapist = db.Therapists.FirstOrDefault();
      }
    }
    private void InitializePage ()
    {
      bool invoiced = ProformaInvoice.Invoice != null;
      labelInviceName.Text = invoiced ? ProformaInvoice.Invoice.Title : "Non ancora fatturato";

      textBoxDiscount.Text = "0";
      labelName.Text = ProformaInvoice.Title;
      if (ProformaInvoice?.Id != null && ProformaInvoice.Id != Guid.Empty)
      {
        labelProformaData.Text = $"del {((DateTime)ProformaInvoice.Date).ToShortDateString()}";
        dateTimePickerProfData.Visible = false;
        labelInviceDate.Text = "del";
        dateTimePickerInvoiceDate.Value = DateTime.Today;
        dateTimePickerInvoiceDate.Visible = true;
      }
      else
      {
        labelProformaData.Text = "del";
        dateTimePickerProfData.Value = (DateTime)ProformaInvoice.Date;
        dateTimePickerProfData.Visible = true;
        labelInviceDate.Text = "del";
        dateTimePickerInvoiceDate.Value = (DateTime)ProformaInvoice.Date;
        dateTimePickerInvoiceDate.Visible = false;

      }

      if (invoiced)
      {
        dateTimePickerInvoiceDate.Visible = false;
        labelInviceDate.Text = $"del {((DateTime)ProformaInvoice.Invoice.Date).ToShortDateString()}";
        dateTimePickerInvoiceDate.Value = (DateTime)ProformaInvoice.Invoice.Date;
        dateTimePickerProfData.Value = (DateTime)ProformaInvoice.Date;
        checkBoxChangeDates.Visible = true;
      } else
      {
        labelInviceDate.Text = "";
        checkBoxChangeDates.Visible = false;
      }

      var aVisit = ProformaInvoice.Visitsproformainvoiceidfkeys.FirstOrDefault();
      checkBoxGroup.Checked = ProformaInvoice.GroupVisits;
      textBoxCustomText.Text = ProformaInvoice.Invoice == null ? ProformaInvoice.CustomText : ProformaInvoice.Invoice.CustomText;
      buttonDeleteProforma.Visible = false;

      if (_edit)
      {
        textBoxDiscount.ReadOnly = true;
        checkBox1.Enabled = false;
        checkBoxPayed.Enabled = true;

        if (invoiced)
        {
          buttonSave.Visible = false;
        }
        else
        {
          buttonDeleteProforma.Visible = true;
          buttonSave.Text = "Genera Fattura";
        }
      }
      else
      {
        checkBoxPayed.Enabled = false;
      }

      if (aVisit != null)
      {
        using (var db = new Db.PhisioDB())
        {
          var cust = db.Customers.LoadWith(e1 => e1.Address).LoadWith(e1 => e1.Pricelist).FirstOrDefault(x => x.Id == aVisit.Customer.Id);
          aVisit.Customer = cust;
        }
        _customer = aVisit.Customer;
        labelCustomerName.Text = aVisit.Customer.FullName;
        labelFiscalCode.Text = aVisit.Customer.Fiscalcode;
      }
      var y = 0;
      panel1.Controls.Clear();
      foreach (var visit in ProformaInvoice.Visitsproformainvoiceidfkeys)
      {
        Panel panelIn = new Panel();
        panelIn.Dock = DockStyle.Top;
        panel1.Controls.Add(panelIn);

        Label labelVisit = new Label();
        labelVisit.Location = new Point(0, 0);
        labelVisit.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
        labelVisit.Text = $"•  {((DateTime)visit.Date).ToShortDateString()}";


        panelIn.Controls.Add(labelVisit);

        var treatments = Helper.Helper.GetTratmensByIdS(visit.Treatmentsvisitidfkeys.Select(x => x.TreatmentId).ToList(), aVisit.Customer.Language);

        if (treatments.Count == 0)
        {
          treatments = Helper.Helper.GetATreatment(aVisit.Customer.Language);
        }


        Label lableTreatment = new Label();
        lableTreatment.Location = new Point((int)(panel1.Width * .2), 0);
        lableTreatment.AutoSize = false;
        lableTreatment.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
        lableTreatment.Text = string.Join(Environment.NewLine, treatments);
        lableTreatment.Size = new Size(panel1.Width - (int)(panel1.Width * .2) - 200, LineHeight * treatments.Count());
        lableTreatment.Padding = new Padding(20, 0, 0, 0);
        panelIn.Controls.Add(lableTreatment);

        Label labelPrice = new Label();
        labelPrice.Location = new Point((int)(panel1.Width - 106), 0);
        labelPrice.Font = new Font("Segoe UI Historic", 11.25F);
        labelPrice.Text = $"{visit.Price} €";
        labelPrice.AutoSize = false;
        labelPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        labelPrice.Size = new Size(60, LineHeight * treatments.Count());
        panelIn.Controls.Add(labelPrice);
        /*
        Label labelPriceRivalsa = new Label();
        labelPriceRivalsa.Location = new Point((int)(panel1.Width - 106), 0);
        labelPriceRivalsa.Font = new Font("Segoe UI Historic", 11.25F);
        labelPriceRivalsa.Text = $"{((double)visit.Price * 1).ToString("#.00")} €";
        labelPriceRivalsa.AutoSize = false;
        labelPriceRivalsa.Size = new Size(60, LineHeight * treatments.Count());
        labelPriceRivalsa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        panelIn.Controls.Add(labelPriceRivalsa);
        */
        panelIn.Location = new Point(0, y);
        panelIn.Size = new Size(panel1.Width, Math.Max(labelVisit.Height, lableTreatment.Height) + 10);
        checkBox1.Checked = ProformaInvoice.TaxStamp;
        checkBoxContanti.Checked = ProformaInvoice.Contanti;

        y += panelIn.Height;
      }
      var total = CalculateTotal(false);
      labelRivalsaSconto.Text = "0";

      if (!ProformaInvoice.IsInitialized())
        if (total > 77.47)
          checkBox1.Checked = true;
        else
          checkBox1.Checked = false;

      labelTotal.Text = CalculateTotal(true).ToString();


      checkBoxPayed.Checked = ProformaInvoice.Payed;
      if (ProformaInvoice.Payed == true)
      {
        dateTimePickerPayed.Enabled = true;
        dateTimePickerPayed.Value = (DateTime)ProformaInvoice.PayedDate;
        dateTimePickerPayed.Format = DateTimePickerFormat.Short;
      }
      else
      {
        dateTimePickerPayed.Enabled = false;
        dateTimePickerPayed.Format = DateTimePickerFormat.Custom;
        dateTimePickerPayed.CustomFormat = " ";
      }

      _initialization = false;
    }

    private void InvoiceCtrl_Load(object sender, EventArgs e)
    {
      InitializePage();
    }

    private double CalculateTotal(bool withStamp)
    {
      var sconto = 0.0;
      if (double.TryParse(textBoxDiscount.Text, out double sc))
        sconto = sc;

      var bollo = checkBox1.Checked ? 2 : 0;

      double tot = ProformaInvoice.Visitsproformainvoiceidfkeys.Sum(x => x.Price != null ? (double)x.Price : 0.0) - sconto;
      tot = withStamp ? tot + bollo: tot;

      return tot ;
    }

    private void textBoxDiscount_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void textBoxDiscount_Validating(object sender, CancelEventArgs e)
    {
      double d = 0.0;
      if (!double.TryParse(textBoxDiscount.Text, out d))
      {
        errorProvider1.SetError(textBoxDiscount, "Il campo deve essere un numero");
      }
      else
      {
        errorProvider1.Clear();
      }
    }

    private void textBoxDiscount_KeyUp(object sender, KeyEventArgs e)
    {
      this.ValidateChildren();
      var sconto = 0.0;
      if (double.TryParse(textBoxDiscount.Text, out double sc))
        sconto = sc;

      labelRivalsaSconto.Text = "- " + (sconto * 1).ToString("#.00");
      labelTotal.Text = CalculateTotal(true).ToString();

    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      if (_edit)
      {
        //DeleteInvoice();
        CreateInvoice();
      }
      else
      {
        CreateProformaInvoice();
      }
    }

    private void CreateInvoice()
    {
      if (MessageBox.Show("Una volta salvata la fattura non potrà essere modificata!", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      if (ProformaInvoice.Invoice != null && ProformaInvoice.Invoice.Id != null && ProformaInvoice.Invoice.Id != Guid.Empty)
      {
        MessageBox.Show("Fattura già salvata", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }


      if (ProformaInvoice.Payed == false)
      {
        if (MessageBox.Show("La fattura proforma non è ancora stata pagata, continuare?", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
          return;
      }

      var invoice = Helper.Helper.CreateNewInvoice(ProformaInvoice.Visitsproformainvoiceidfkeys.ToList(), out string errors);
      if (!string.IsNullOrEmpty(errors))
      {
        MessageBox.Show("errors", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      invoice.Date = new NpgsqlTypes.NpgsqlDate(dateTimePickerInvoiceDate.Value);
      invoice.TaxStamp = ProformaInvoice.TaxStamp;
      invoice.Discount = ProformaInvoice.Discount;
      invoice.CustomText = string.IsNullOrWhiteSpace(textBoxCustomText.Text) ? ProformaInvoice.CustomText : textBoxCustomText.Text;

      using (var db = new Db.PhisioDB())
      {
        invoice.TherapistId = ProformaInvoice.TherapistId;
        invoice.ProformaInvoiceId = ProformaInvoice.Id;
        ProformaInvoice.Invoice = invoice;
        ProformaInvoice.InvoiceId = invoice.SaveToDB();
        ProformaInvoice.SaveToDB();
        foreach (var visit in ProformaInvoice.Visitsproformainvoiceidfkeys)
        {
          visit.Invoiced = true;
          visit.InvoiceId = ProformaInvoice.Invoice.Id;
          visit.SaveToDB();
        }
        MessageBox.Show("Salvato Correttamente", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        GetDbData();
        InitializePage();
        SavedInvoice?.Invoke(this, new EventArgs());
      }
    }

    private void CreateProformaInvoice()
    {
      if (MessageBox.Show("Una volta salvata la fattura non potrà essere modificata!", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      if (ProformaInvoice.Id != null && ProformaInvoice.Id != Guid.Empty)
      {
        MessageBox.Show("Fattura già salvata", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      ProformaInvoice.Date = new NpgsqlTypes.NpgsqlDate(dateTimePickerProfData.Value);
      ProformaInvoice.TaxStamp = checkBox1.Checked;
      ProformaInvoice.GroupVisits = checkBoxGroup.Checked;

      if (double.TryParse(textBoxDiscount.Text, out double disc))
        ProformaInvoice.Discount = disc;

      ProformaInvoice.CustomText = textBoxCustomText.Text;

      using (var db = new Db.PhisioDB())
      {
        ProformaInvoice.TherapistId = _therapist.Id;
        var proformaInvoiceID = ProformaInvoice.SaveToDB();
        foreach (var visit in ProformaInvoice.Visitsproformainvoiceidfkeys)
        {
          visit.ProformaInvoiced = true;
          visit.ProformaInvoiceId = proformaInvoiceID;
          visit.SaveToDB();
        }
        MessageBox.Show("Salvato Correttamente", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        _edit = true;
        GetDbData();
        InitializePage();
        SavedInvoice?.Invoke(this, new EventArgs());
      }
    }

    private void DeleteInvoice()
    {
      if (MessageBox.Show("Sei sicura di voler cancellare la fattura?", "Cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      if (ProformaInvoice.Id == null)
      {
        MessageBox.Show("Errore la fattura non è stata caricata correttamente!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      using (var db = new Db.PhisioDB())
      {
        if (ProformaInvoice.Id != null)
        {
          //Invoice.Deleted = true;
          foreach (var visit in ProformaInvoice.Visitsproformainvoiceidfkeys)
          {
            visit.Payed = false;
            visit.InvoiceId = null;
            visit.Invoice = null;
            visit.Invoiced = false;
            visit.ProformaInvoice = null;
            visit.ProformaInvoiced = false;
            visit.SaveToDB();
          }
          ProformaInvoice.Deleted = true;
          ProformaInvoice.SaveToDB();
          
          MessageBox.Show("Fattura Eliminata!", "Cancellazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
          DeletedInvoice?.Invoke(this, new EventArgs());
        }
      }
    }

    private void PrintInvoice(DataModels.Invoice invoice)
    {

      if (invoice.Id == null || invoice.Id == Guid.Empty)
      {
        invoice.TaxStamp = checkBox1.Checked;

        if (double.TryParse(textBoxDiscount.Text, out double disc))
          invoice.Discount = disc;

        MessageBox.Show("Si sta visualizzando un anteprima, ricordarsi di salvare la fattura!", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      DataModels.Therapist therapist = null;
      using (var db = new Db.PhisioDB())
      {
        therapist = db.Therapists.FirstOrDefault();
      }

      invoice.CustomText = textBoxCustomText.Text;

      if (therapist == null)
      {
        MessageBox.Show("Qualcosa è andato storto non trovo i parametri generali", "Stampa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (string.IsNullOrEmpty(therapist.InvoicesFolder))
      {
        MessageBox.Show("Prima di proseguire bisogna impostare la cartella di salvataggio delle fatture", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      string html = "";

      var groupVisits = checkBoxGroup.Checked;

      if (_customer.Language == "german")
        html = File.ReadAllText("Template/templateInvoice_de.html");
      else
        html = File.ReadAllText("Template/templateInvoice_it.html");

      html = Helper.Helper.ReplaceInvoicePlaceHolder(html, _customer, invoice, groupVisits);

      var basePath = therapist.InvoicesFolder;
      var date = $"{invoice.Date.Year}{invoice.Date.Month}";
      basePath = Path.Combine(basePath, date);

      Directory.CreateDirectory(basePath);
      var pdfPath = $@"{basePath}\{invoice.Title.Replace(@"/", "_")}_{_customer.FullName.Replace(" ", "_")}.pdf";
      var htmlPath = $@"{basePath}\{invoice.Title.Replace("/", "_")}_{_customer.FullName.Replace(" ", "_")}.html";

            pdfPath = pdfPath.Replace("'", "_");
            htmlPath = htmlPath.Replace("'", "_");
      try
      {
        File.WriteAllText(htmlPath, html);
        Helper.PdfManager.CreatePdf(pdfPath, htmlPath);
      }
      catch (Exception ee)
      {
        MessageBox.Show("Il file è già aperto, chiuderlo", "Stampa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      //Helper.DriveManagement.InsertFilePdf(pdfPath, new List<string> { "Invoice", date });
      File.Delete(htmlPath);
      if (File.Exists(pdfPath))
      {
          System.Diagnostics.Process.Start(pdfPath);
      }
      else
      {
          MessageBox.Show("Il pdf non è stato creato!", "Stampa", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void PrintProforma(DataModels.ProformaInvoice invoice )
    {

      if (invoice.Id == null || invoice.Id == Guid.Empty)
      {
        invoice.TaxStamp = checkBox1.Checked;

        if (double.TryParse(textBoxDiscount.Text, out double disc))
          invoice.Discount = disc;

        invoice.CustomText = textBoxCustomText.Text;

        MessageBox.Show("Si sta visualizzando un anteprima, ricordarsi di salvare la fattura!", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      DataModels.Therapist therapist = null;
      using (var db = new Db.PhisioDB())
      {
        therapist = db.Therapists.FirstOrDefault();
      }

      if (therapist == null)
      {
        MessageBox.Show("Qualcosa è andato storto non trovo i parametri generali", "Stampa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (string.IsNullOrEmpty(therapist.InvoicesFolder))
      {
        MessageBox.Show("Prima di proseguire bisogna impostare la cartella di salvataggio delle fatture", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      string html = "";

      if (_customer.Language == "german")
        html = File.ReadAllText("Template/templateProformaInvoice_de.html");
      else
        html = File.ReadAllText("Template/templateProformaInvoice_it.html");

      var groupVisits = checkBoxGroup.Checked;
      html = Helper.Helper.ReplaceProformaInvoicePlaceHolder(html, _customer, invoice, groupVisits);

      var basePath = therapist.InvoicesFolder + "_Proforma";
      var date = $"{ProformaInvoice.Date.Year}{ProformaInvoice.Date.Month}";
      basePath = Path.Combine(basePath, date);

      Directory.CreateDirectory(basePath);      
      var pdfPath = $@"{basePath}\{invoice.Title.Replace(@"/", "_")}_{_customer.FullName.Replace(" ", "_").Replace("'", "")}.pdf";
      var htmlPath = $@"{basePath}\{invoice.Title.Replace("/", "_")}_{_customer.FullName.Replace(" ", "_").Replace("'", "")}.html";
      try
      {
        File.WriteAllText(htmlPath, html);
        Helper.PdfManager.CreatePdf(pdfPath, htmlPath);
      }
      catch (Exception ee)
      {
        MessageBox.Show("Il file è già aperto, chiuderlo", "Stampa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      //Helper.DriveManagement.InsertFilePdf(pdfPath, new List<string> { "Invoice", date });
      File.Delete(htmlPath);
      if (File.Exists(pdfPath))
      {
        System.Diagnostics.Process.Start(pdfPath);
      } else
      {
        MessageBox.Show("ERRORE! Non risco a visualizzare il PDF per il file: " + Environment.NewLine + pdfPath + Environment.NewLine + "Dillo a Davide");
      }
     
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      ProformaInvoice.TaxStamp = checkBox1.Checked;
      labelBollo.Text = checkBox1.Checked ? "2" : "0";
      labelTotal.Text = CalculateTotal(true).ToString();
    }

    private void textBoxDiscount_TextChanged(object sender, EventArgs e)
    {

    }

    private void buttonPrintProformaInvoice_Click(object sender, EventArgs e)
    {
      PrintProforma(ProformaInvoice);
    }

    private void buttonPrintInvoice_Click(object sender, EventArgs e)
    {
      if (ProformaInvoice.Invoice == null)
      {
        MessageBox.Show("La fattura non è ancora stata generata", "Stampa", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      PrintInvoice(ProformaInvoice.Invoice);
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (_initialization)
        return;

      if (checkBoxPayed.Checked == true)
      {
        dateTimePickerPayed.Enabled = true;
        dateTimePickerPayed.Value = DateTime.Now;
        dateTimePickerPayed.Format = DateTimePickerFormat.Short;
      }
      else
      {
        dateTimePickerPayed.Enabled = false;
        dateTimePickerPayed.Format = DateTimePickerFormat.Custom;
        dateTimePickerPayed.CustomFormat = " ";
      }

      if (ProformaInvoice.IsInitialized())
      {
        ProformaInvoice.Payed = checkBoxPayed.Checked;
        ProformaInvoice.SaveToDB();

        if (ProformaInvoice.Invoice != null && ProformaInvoice.Invoice.IsInitialized())
        {
          ProformaInvoice.Invoice.Payed = checkBoxPayed.Checked;
          ProformaInvoice.Invoice.SaveToDB();
        }
      }
    }

    private void dateTimePickerPayed_ValueChanged(object sender, EventArgs e)
    {
      if (_initialization)
        return;

      ProformaInvoice.PayedDate = new NpgsqlTypes.NpgsqlDate(dateTimePickerPayed.Value);
      ProformaInvoice.SaveToDB();
    }

    private void checkBoxGroup_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void checkBoxContanti_CheckedChanged(object sender, EventArgs e)
    {
      if (_initialization)
        return;

      if (ProformaInvoice.IsInitialized())
      {
        ProformaInvoice.Contanti = checkBoxContanti.Checked;
        ProformaInvoice.SaveToDB();

        if (ProformaInvoice.Invoice != null && ProformaInvoice.Invoice.IsInitialized())
        {
          ProformaInvoice.Invoice.Contanti = checkBoxContanti.Checked;
          ProformaInvoice.Invoice.SaveToDB();
        }
      }
    }

    private void buttonDeleteProforma_Click(object sender, EventArgs e)
    {
      bool invoiced = ProformaInvoice.Invoice != null;
      if (!invoiced)
      {
        DeleteInvoice();
      }
    }

    private void checkBoxChangeDates_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBoxChangeDates.Checked == true)
      {
        dateTimePickerInvoiceDate.Visible = true;
        dateTimePickerProfData.Visible = true;
        labelInviceDate.Visible = false;
        labelProformaData.Visible = false;
        buttonUpdateDates.Visible = true;
      } else
      {
        dateTimePickerInvoiceDate.Visible = false;
        dateTimePickerProfData.Visible = false;
        labelInviceDate.Visible = true;
        labelProformaData.Visible = true;
        buttonUpdateDates.Visible = false;

      }
    }

    private void buttonUpdateDates_Click(object sender, EventArgs e)
    {
      if (_initialization)
        return;

      if (dateTimePickerProfData.Value > dateTimePickerInvoiceDate.Value) 
      {
        MessageBox.Show("Attenzione la data della fattura proforma è maggiore di quella della fattura, salvataggio annullato", "Date Errate", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      if (ProformaInvoice.IsInitialized())
      {
        ProformaInvoice.Date = new NpgsqlTypes.NpgsqlDate(dateTimePickerProfData.Value);
        ProformaInvoice.SaveToDB();

        if (ProformaInvoice.Invoice != null && ProformaInvoice.Invoice.IsInitialized())
        {
          ProformaInvoice.Invoice.Date = new NpgsqlTypes.NpgsqlDate(dateTimePickerInvoiceDate.Value);
          ProformaInvoice.Invoice.SaveToDB();
        }
      }

      checkBoxChangeDates.Checked = false;
      InitializePage();

    }
  }
}
