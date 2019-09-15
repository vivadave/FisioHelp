using System;
using System.Windows.Forms;
using LinqToDB;
using System.Linq;
namespace FisioHelp.UI
{
  public partial class InvoiceListItem : UserControl
  {
    public event EventHandler OnOpenInvoice;
    public event EventHandler ChangePayed;
    public DataModels.Invoice Invoice { get; set; }
    private bool _loaded = false;

    public InvoiceListItem(DataModels.Invoice invoice)
    {
      InitializeComponent();
      this.Invoice = invoice;
    }
    private void VisitEconomicCtrl_Load(object sender, EventArgs e)
    {
      if (Invoice == null) return;
      label1.Text = ((DateTime)Invoice.Date).ToShortDateString();
      label2.Text = Invoice.Visitsinvoiceidfkeys.ToList().Count.ToString();
      label5.Text = $"{Invoice.Total} €";
      checkBox2.Checked = Invoice.Payed ?? false;
      _loaded = true;
    }
    private void button1_Click(object sender, EventArgs e)
    {
      OnOpenInvoice?.Invoke(this, e);
    }
    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (!_loaded) return;
      
      using (var db = new Db.PhisioDB())
      {
        if (Invoice.Id > 0)
        {
          Invoice.Payed = checkBox2.Checked;
          foreach (var visit in Invoice.Visitsinvoiceidfkeys)
          {
            visit.Payed = checkBox2.Checked;
            db.Update(visit);
          }

          db.Update(Invoice);
          ChangePayed?.Invoke(this, e);
        }
      }
    }

    private void checkBox2_Click(object sender, EventArgs e)
    {
      _loaded = true;
    }
  }
}
