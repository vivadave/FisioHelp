using System;
using System.Windows.Forms;
using LinqToDB;
using System.Linq;
namespace FisioHelp.UI
{
  using DataModels;

  public partial class InvoiceListItem : UserControl
  {
    public event EventHandler OnOpenInvoice;
    public event EventHandler ChangePayed;
    public DataModels.ProformaInvoice ProformaInvoice { get; set; }
    private bool _loaded = false;
    public Customer Customer;

    public InvoiceListItem(DataModels.ProformaInvoice invoice, Customer customer)
    {
      InitializeComponent();
      this.ProformaInvoice = invoice;
      Customer = customer;
    }
    private void VisitEconomicCtrl_Load(object sender, EventArgs e)
    {
      if (ProformaInvoice == null) return;
      label1.Text = ((DateTime)ProformaInvoice.Date).ToShortDateString();
      labelName.Text = ProformaInvoice.CustomerName;
      labelTitle.Text = ProformaInvoice.Title;
      labelInvoice.Text = ProformaInvoice.Invoice != null ? ProformaInvoice.Invoice.Title : "NO";
      label2.Text = $"{ProformaInvoice.Visitsproformainvoiceidfkeys.ToList().Count.ToString()} visite";
      label5.Text = $"{ProformaInvoice.Total} €";
      checkBox2.Checked = ProformaInvoice.Payed;
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
        if (ProformaInvoice.Id != null)
        {
          ProformaInvoice.Payed = checkBox2.Checked;
          foreach (var visit in ProformaInvoice.Visitsproformainvoiceidfkeys)
          {
            visit.Payed = checkBox2.Checked;
            db.Update(visit);
          }

          db.Update(ProformaInvoice);
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
