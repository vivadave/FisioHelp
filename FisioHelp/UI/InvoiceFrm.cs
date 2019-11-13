using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioHelp.UI
{
  public partial class InvoiceFrm : Form
  {
    private DataModels.ProformaInvoice _proformaInvoice;
    public InvoiceFrm(DataModels.ProformaInvoice invoice)
    {
      InitializeComponent();
      _proformaInvoice = invoice;
      if (invoice == null)
        this.Close();
    }

    private void InvoiceFrm_Load(object sender, EventArgs e)
    {
      var invoiceCtrl = new UI.InvoiceCtrl(_proformaInvoice);
      invoiceCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      panel1.Controls.Add(invoiceCtrl);
    }
  }
}
