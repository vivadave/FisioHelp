using System;
using System.Windows.Forms;
using LinqToDB;

namespace FisioHelp.UI
{
  public partial class VisitEconomicCtrl : UserControl
  {
    public event EventHandler OpenVisit;
    public event EventHandler ChangePayed;
    public event EventHandler ChangeInvoiced;
    public DataModels.Visit Visit { get; set; }
    public bool Invoiced { get; private set; }
    private bool _loaded = false;
    private bool _autoClick = false;

    public VisitEconomicCtrl(DataModels.Visit visit)
    {
      InitializeComponent();
      this.Visit = visit;
    }

    private void VisitEconomicCtrl_Load(object sender, EventArgs e)
    {
      if (Visit == null) return;

      label1.Text = ((DateTime)Visit.Date).ToShortDateString();
      label2.Text = Visit.StartTime.ToString();
      label4.Text = Visit.Customer != null ? Visit.Customer.FullName : "";
      label5.Text = $"{Visit.Price} €";
      checkBox2.Checked = Visit.Payed;
      checkBox1.Checked = Visit.Invoiced;
      checkBoxProforma.Checked = Visit.ProformaInvoiced;
      Invoiced = checkBoxProforma.Checked;
      _loaded = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      OpenVisit?.Invoke(this, e);
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (!_loaded) return;

      if (_autoClick)
      {
        _autoClick = false;
        return;
      }

      if ((bool)Visit.Invoiced)
      {
        _autoClick = true;
        MessageBox.Show("La visita può essere pagata solo attraverso il pagamento della fattura", "Fatturazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        checkBox2.Checked = !checkBox2.Checked;        
        return;
      }
      using (var db = new Db.PhisioDB())
      {
        if (Visit.Id != null)
        {
          Visit.Payed = checkBox2.Checked;
          db.Update(Visit);
          ChangePayed?.Invoke(this, e);
        }
      }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (!_loaded) return;
      if (_autoClick)
      {
        _autoClick = false;
        return;
      }
      if (Visit.Invoiced)
      {
        _autoClick = true;
        MessageBox.Show("Eliminare la fattura per questa visita dalla lista fatture", "Fatturazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        checkBox1.Checked = true;
        return;
      }

    }

    private void checkBoxProforma_CheckedChanged(object sender, EventArgs e)
    {
      if (!_loaded) return;
      if (_autoClick)
      {
        _autoClick = false;
        return;
      }
      if (Visit.Invoiced)
      {
        _autoClick = true;
        MessageBox.Show("Eliminare la fattura per questa visita dalla lista fatture", "Fatturazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        checkBoxProforma.Checked = true;
        return;
      }

      Invoiced = checkBoxProforma.Checked;
      ChangeInvoiced?.Invoke(this, e);
      if (Invoiced)
        checkBoxProforma.ForeColor = System.Drawing.Color.Coral;
      else
        checkBoxProforma.ForeColor = System.Drawing.Color.Black;

    }
  }
}
