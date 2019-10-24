using System;
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
    public DataModels.Invoice Invoice { get; set; }
    private DataModels.Customer _customer { get; set; }
    private DataModels.Therapist _therapist { get; set; }
    private const int LineHeight = 20;
    private bool _edit = false;
    private ToolTip _printInvoiceTT = new ToolTip();

    public InvoiceCtrl(DataModels.Invoice invoice, bool edit = false)
    {
      InitializeComponent();
      Invoice = invoice;
      _edit = edit;
      _printInvoiceTT.SetToolTip(this.buttonPrinter, "Stampa la fattura");
      
      using (var db = new Db.PhisioDB())
      {
        _therapist = db.Therapists.FirstOrDefault();
      }
    }

    private void InvoiceCtrl_Load(object sender, EventArgs e)
    {
      textBoxDiscount.Text = "0";
      labelName.Text = Invoice.Title;  

      var aVisit = Invoice.Visitsinvoiceidfkeys.FirstOrDefault();
      
      if (_edit)
      {
        buttonSave.Text = "Cancella";
        textBoxDiscount.ReadOnly = true;
        checkBox1.Enabled = false;
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
      foreach ( var visit in Invoice.Visitsinvoiceidfkeys)
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

        Label lableTreatment = new Label();
        lableTreatment.Location = new Point((int)(panel1.Width * .2) , 0);
        lableTreatment.AutoSize = false;
        lableTreatment.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
        lableTreatment.Text = string.Join(Environment.NewLine, treatments);
        lableTreatment.Size = new Size(panel1.Width - (int)(panel1.Width * .2) - 200, LineHeight * treatments.Count());
        lableTreatment.Padding = new Padding(20, 0, 0, 0);
        panelIn.Controls.Add(lableTreatment);

        Label labelPrice = new Label();
        labelPrice.Location = new Point((int)(panel1.Width - 198), 0);
        labelPrice.Font = new Font("Segoe UI Historic", 11.25F);
        labelPrice.Text = $"{visit.Price} €";
        labelPrice.AutoSize = false;
        labelPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        labelPrice.Size = new Size(60, LineHeight * treatments.Count());
        panelIn.Controls.Add(labelPrice);

        Label labelPriceRivalsa = new Label();
        labelPriceRivalsa.Location = new Point((int)(panel1.Width - 106), 0);
        labelPriceRivalsa.Font = new Font("Segoe UI Historic", 11.25F);
        labelPriceRivalsa.Text = $"{((double)visit.Price * 0.96).ToString("#.00")} €";
        labelPriceRivalsa.AutoSize = false;
        labelPriceRivalsa.Size = new Size(60, LineHeight * treatments.Count());
        labelPriceRivalsa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        panelIn.Controls.Add(labelPriceRivalsa);

        panelIn.Location = new Point(0, y);
        panelIn.Size = new Size(panel1.Width, Math.Max(labelVisit.Height, lableTreatment.Height) + 10);
        

        checkBox1.Checked = Invoice.TaxStamp;

        y += panelIn.Height;
      }
      var total = CalculateTotal(false);
      labelRivalsa.Text = (total*0.04).ToString("#.00");
      labelRivalsaSconto.Text = "0";
      if (total > 77.47)
        checkBox1.Checked = true;
      else
        checkBox1.Checked = false;

      labelTotal.Text = CalculateTotal(true).ToString();
    }

    private double CalculateTotal(bool withStamp)
    {
      var sconto = 0.0;
      if (double.TryParse(textBoxDiscount.Text, out double sc))
        sconto = sc;

      var bollo = checkBox1.Checked ? 2 : 0;

      double tot = Invoice.Visitsinvoiceidfkeys.Sum(x => x.Price != null ? (double)x.Price : 0.0) - sconto;
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

      labelRivalsaSconto.Text = "- " + (sconto * .96).ToString("#.00");
      labelRivalsa.Text = (CalculateTotal(false) * 0.04).ToString("#.00");
      labelTotal.Text = CalculateTotal(true).ToString();

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
      if (MessageBox.Show("Una volta salvata la fattura non potrà essere modificata!", "Salvataggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      if (Invoice.Id != null && Invoice.Id != Guid.Empty)
      {
        MessageBox.Show("Fattura già salvata", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      Invoice.TaxStamp = checkBox1.Checked;
      if (double.TryParse(textBoxDiscount.Text, out double disc))
        Invoice.Discount = disc;

      using (var db = new Db.PhisioDB())
      {
        Invoice.TherapistId = _therapist.Id;
        var invoiceID = Invoice.SaveToDB();
        foreach (var visit in Invoice.Visitsinvoiceidfkeys)
        {
          visit.Invoiced = true;
          visit.InvoiceId = invoiceID;
          visit.SaveToDB();
        }
        MessageBox.Show("Salvato Correttamente", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
      }
    }

    private void DeleteInvoice()
    {
      if (MessageBox.Show("Sei sicura di voler cancellare la fattura?", "Cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      if (Invoice.Id == null)
      {
        MessageBox.Show("Errore la fattura non è stata caricata correttamente!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      using (var db = new Db.PhisioDB())
      {
        if (Invoice.Id != null)
        {
          Invoice.Deleted = true;
          foreach (var visit in Invoice.Visitsinvoiceidfkeys)
          {
            visit.Payed = false;
            visit.InvoiceId = null;
            visit.Invoice = null;
            visit.Invoiced = false;
            visit.SaveToDB();
          }

          Invoice.SaveToDB();
          
          MessageBox.Show("Fattura Eliminata!", "Cancellazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
          DeletedInvoice?.Invoke(this, new EventArgs());
        }
      }
    }

    private void buttonPrinter_Click(object sender, EventArgs e)
    {

      if (Invoice.Id == null || Invoice.Id == Guid.Empty)
      {
        Invoice.TaxStamp = checkBox1.Checked;

        if (double.TryParse(textBoxDiscount.Text, out double disc))
          Invoice.Discount = disc;

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
        html = File.ReadAllText("Template/templateInvoice_de.html");
      else
        html = File.ReadAllText("Template/templateInvoice_it.html");

      html = Helper.Helper.ReplaceInvoicePlaceHolder(html, _customer, Invoice);
      var basePath = therapist.InvoicesFolder;
      var date = $"{Invoice.Date.Year}{Invoice.Date.Month}";
      basePath = Path.Combine(basePath, date);

      Directory.CreateDirectory(basePath);      
      var pdfPath = $@"{basePath}\{Invoice.Title.Replace(@"/", "_")}_{_customer.FullName.Replace(" ", "_")}.pdf";
      var htmlPath = $@"{basePath}\{Invoice.Title.Replace("/", "_")}_{_customer.FullName.Replace(" ", "_")}.html";
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

      System.Diagnostics.Process.Start(pdfPath);
     
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      Invoice.TaxStamp = checkBox1.Checked;
      labelBollo.Text = checkBox1.Checked ? "2" : "0";
      labelTotal.Text = CalculateTotal(true).ToString();
    }

    private void textBoxDiscount_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
