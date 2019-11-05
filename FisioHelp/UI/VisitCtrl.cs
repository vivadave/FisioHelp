using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LinqToDB;
using LinqToDB.Expressions;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FisioHelp.UI
{
  public partial class VisitCtrl : UserControl
  {
    public event EventHandler DeleteVisit;
    private List<DataModels.Treatment> _treatments;
    private DataModels.Visit _visit;
    private DataModels.Therapist _therapist { get; set; }
    private DataModels.Customer _customer;
    private bool _saveEnabled = false;

    public VisitCtrl(DataModels.Customer customer, DataModels.Visit visit)
    {
      InitializeComponent();
      _visit = visit;
      _customer = customer;

      if (_visit == null || _visit.Id == null || _visit.Id == Guid.Empty)
        button1.Visible = false;
      else
        button1.Visible = true;

      using (var db = new Db.PhisioDB())
      {
        _therapist = db.Therapists.FirstOrDefault();
        _treatments = db.Treatments.ToList();
        foreach (var treatment in _treatments)
        {
          this.checkedListBox1.DisplayMember = "DescriptionIt";
          if (_customer.Language == "german")
            this.checkedListBox1.DisplayMember = "DescriptionDe";
          this.checkedListBox1.Items.Add(treatment, false);
        }
      }
      FillVisitFields();
    }

    private void FillVisitFields()
    {
      dateTimePicker1.Value = (DateTime)_visit?.Date <= DateTime.MinValue ? DateTime.Now : (DateTime)_visit.Date;
      textBoxTime.Text = string.IsNullOrEmpty(_visit?.StartTime) ? $"{DateTime.Now.Hour}:00" : _visit.StartTime;
      textBoxPrice.Text = _visit.Price != null ? _visit.Price.ToString() : _customer.Pricelist?.Price.ToString();
      richTextBoxExFinal.Rtf = _visit.FinalEvaluetion;
      richTextBoxExInitial.Rtf = _visit.InitialEvaluetion;
      if (_visit.Treatmentsvisitidfkeys == null) return;

      foreach(var treatmeent in _treatments.Where(t => _visit.Treatmentsvisitidfkeys.Select(x=>x.TreatmentId).Contains(t.Id)))
      {
        var text = treatmeent.DescriptionIt;
        if (_customer.Language == "german")
          text = treatmeent.DescriptionDe;

          var index = checkedListBox1.Items.IndexOf(treatmeent);
        if (index >= 0)
          checkedListBox1.SetItemChecked(index, true);
      }
    }

    private void SetVisit()
    {
      _visit.Date = new NpgsqlTypes.NpgsqlDate(dateTimePicker1.Value);
      _visit.Customer = _customer;
      _visit.CustomerId = _customer.Id;
      _visit.FinalEvaluetion = richTextBoxExFinal.Rtf;
      _visit.InitialEvaluetion = richTextBoxExInitial.Rtf;
      _visit.Price = double.Parse(textBoxPrice.Text);
      _visit.StartTime = textBoxTime.Text;

    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      if (_saveEnabled == false)
      {
        MessageBox.Show("Controllare che tutti i campi siano compilati correttamente", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      SetVisit();
      _visit.TherapistId = _therapist.Id;
      _visit.SaveToDB();
      MessageBox.Show("Salvato Correttamente", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void textBoxTime_Validated(object sender, EventArgs e)
    {

    }

    private void textBoxTime_Validating(object sender, CancelEventArgs e)
    {
      Regex checktime = new Regex(@"^(0[0-9]|1[0-9]|2[0-3]|[0-9]):[0-5][0-9]$");
      if(!checktime.IsMatch(textBoxTime.Text))
      {
        errorProvider1.SetError(textBoxTime, @"la durata deve avere la forma ""hh:mm""");
        _saveEnabled = false;
      }
      else
      {
        _saveEnabled = true;
      }
    }

    private void textBoxPrice_TextChanged(object sender, EventArgs e)
    {
      if (!double.TryParse(textBoxPrice.Text, out double val)) {
        errorProvider1.SetError(textBoxPrice, @"la devi inserire un numero!");
        _saveEnabled = false;
      }
      else
      {
        _saveEnabled = true;
      }
    }

    private void VisitCtrl_Load(object sender, EventArgs e)
    {
      buttonSave.Enabled = false;
      if (this.ValidateChildren())
        buttonSave.Enabled = true;

      buttonSave.Focus();
      textBoxPrice.Text = string.IsNullOrEmpty(textBoxPrice.Text) ? "0" : textBoxPrice.Text;
    }

    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      var items = checkedListBox1.CheckedItems;
      _visit.Treatmentsvisitidfkeys = Enumerable.Empty<DataModels.VisitsTreatment>();
        List<DataModels.VisitsTreatment> a = new List<DataModels.VisitsTreatment>();

      foreach(var item in items)
      {
        a.Add(new DataModels.VisitsTreatment
        {
          Treatment = (DataModels.Treatment)item,
          TreatmentId = ((DataModels.Treatment)item).Id,
          Visit = _visit,
          VisitId = _visit.Id
        });
      }
        _visit.Treatmentsvisitidfkeys = a;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (_visit.Invoiced)
      {
        MessageBox.Show("E' già stata emessa fattura per questa visita, impossibile cancellarla", "Cancellazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        return;
      }

      if (MessageBox.Show("Sicura di voler  cancellare questa visita?", "Cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;

      _visit.Deleted = true;
      _visit.SaveToDB();
      DeleteVisit?.Invoke(this, e);
    }
  }
}
