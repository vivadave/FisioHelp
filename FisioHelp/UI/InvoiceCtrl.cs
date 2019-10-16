using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.IO;
using LinqToDB;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Pdf;
using PdfSharp;

namespace FisioHelp.UI
{
  public partial class InvoiceCtrl : UserControl
  {
    public DataModels.Invoice Invoice { get; set; }
    private DataModels.Customer _customer { get; set; }
    private const int LineHeight = 20;
    private bool _edit = false;
    public InvoiceCtrl(DataModels.Invoice invoice, bool edit = false)
    {
      InitializeComponent();
      Invoice = invoice;
      _edit = edit;
    }

    private void InvoiceCtrl_Load(object sender, EventArgs e)
    {
      textBoxDiscount.Text = "0";
      labelName.Text = Invoice.Title;
      var aVisit = Invoice.Visitsinvoiceidfkeys.FirstOrDefault();
      if (_edit)
      {
        buttonSave.Text = "Cancella";
      }
      if (aVisit != null)
      {
        _customer = aVisit.Customer;
        labelCustomerName.Text = aVisit.Customer.FullName;
        labelFiscalCode.Text = aVisit.Customer.Fiscalcode;
      }
      var y = 0;
      foreach ( var visit in Invoice.Visitsinvoiceidfkeys)
      {
        Panel panelIn = new Panel();
        Label labelVisit = new Label();
        labelVisit.Location = new Point(0, 0);
        labelVisit.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
        labelVisit.Text = $"•  {((DateTime)visit.Date).ToShortDateString()}";
        panelIn.Controls.Add(labelVisit);;        

        var treatments = Helper.Helper.GetTratmensByIdS(visit.Treatmentsvisitidfkeys.Select(x => x.TreatmentId).ToList(), aVisit.Customer.Language);

        Label lableTreatment = new Label();
        lableTreatment.Location = new Point((int)(panel1.Width * .2) , 0);
        lableTreatment.AutoSize = false;
        lableTreatment.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
        lableTreatment.Text = string.Join(Environment.NewLine, treatments);
        lableTreatment.Size = new Size(panel1.Width - (int)(panel1.Width * .2) - 80, LineHeight * treatments.Count());
        lableTreatment.Padding = new Padding(20, 0, 0, 0);
        panelIn.Controls.Add(lableTreatment);

        Label labelPrice = new Label();
        labelPrice.Location = new Point((int)(panel1.Width - 80), 0);
        labelPrice.Font = new Font("Segoe UI Historic", 11.25F);
        labelPrice.Text = $"{visit.Price} €";
        panelIn.Controls.Add(labelPrice);

        panelIn.Location = new Point(0, y);
        panelIn.Size = new Size(panel1.Width, Math.Max(labelVisit.Height, lableTreatment.Height) + 10);
        panel1.Controls.Add(panelIn);

        y += panelIn.Height;
      }
      labelTotal.Text = CalculateTotal().ToString() + " €";
    }

    private double CalculateTotal()
    {
      var sconto = 0.0;
      if (double.TryParse(textBoxDiscount.Text, out double sc))
        sconto = sc;

      double tot = Invoice.Visitsinvoiceidfkeys.Sum(x => x.Price != null ? (double)x.Price : 0.0) - sconto;
      return tot;
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
      labelTotal.Text = CalculateTotal().ToString();
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      if (_edit)
      {
        DeleteInvoice();
      }
      else
      {
        CreateInvoice();
      }
    }

    private void CreateInvoice()
    {
      if (Invoice.Id > 0)
      {
        MessageBox.Show("Fattura già salvata!");
        return;
      }

      using (var db = new Db.PhisioDB())
      {
        var invoiceId = db.InsertWithInt32Identity(Invoice);
        Invoice.Id = invoiceId;
        if (invoiceId > 0)
        {
          foreach (var visit in Invoice.Visitsinvoiceidfkeys)
          {
            visit.Invoiced = true;
            visit.InvoiceId = invoiceId;
            db.Update(visit);
          }

          MessageBox.Show("Fattura Salvata!");
        }
      }
    }

    private void DeleteInvoice()
    {
      if (Invoice.Id <= 0)
      {
        MessageBox.Show("Errore la fattura non è stata caricata correttamente!");
        return;
      }

      using (var db = new Db.PhisioDB())
      {
        var invoiceId = Invoice.Id;
        if (invoiceId > 0)
        {
          foreach (var visit in Invoice.Visitsinvoiceidfkeys)
          {
            visit.Payed = false;
            visit.InvoiceId = null;
            visit.Invoice = null;
            visit.Invoiced = false;
            db.Update(visit);
          }

          db.Delete(Invoice);
          
          MessageBox.Show("Fattura Eliminata!");
        }
      }
    }

    private void buttonPrinter_Click(object sender, EventArgs e)
    {
      DataModels.Therapist therapist = null;
      using (var db = new Db.PhisioDB())
      {
        therapist = db.Therapists.FirstOrDefault();
      }

      if (therapist == null)
      {
        MessageBox.Show("Qualcosa è andato storto non trovo i parametri generali");
        return;
      }

      if (string.IsNullOrEmpty(therapist.InvoicesFolder))
      {
        MessageBox.Show("Prima di proseguire bisogna impostare la cartella di salvataggio delle fatture");
        return;
      }

      string html = "";

      if (_customer.Language == "german")
        html = File.ReadAllText("Template/templateInvoice_de.html");
      else
        html = File.ReadAllText("Template/templateInvoice_it.html");

      html = Helper.Helper.ReplaceInvoicePlaceHolder(html, _customer, Invoice);
      var basePath = therapist.InvoicesFolder;
      var date = $"{Invoice.Date.Year}{Invoice.Date.Month}";
      basePath = Path.Combine(basePath, date);

      Directory.CreateDirectory(basePath);      
      var Renderer = new IronPdf.HtmlToPdf();
      var PDF = Renderer.RenderHtmlAsPdf(html);
      var OutputPath = $@"{basePath}\{Invoice.Title}_{_customer.FullName.Replace(" ","_")}.pdf";
      PDF.SaveAs(OutputPath);

      System.Diagnostics.Process.Start(OutputPath);
     
    }
  }
}
