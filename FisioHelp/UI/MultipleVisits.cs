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
  public partial class MultipleVisits : Form
  {
    public event EventHandler VisitCreated;
    private DataModels.Therapist _therapist { get; set; }
    private DataModels.Customer _customer;
    private List<DataModels.Treatment> _treatments;
    private int _visitNr;
    private int _visitTot;
    public MultipleVisits(DataModels.Customer customer)
    {
      InitializeComponent();
      using(var db = new Db.PhisioDB())
      {
        _visitNr = 10;
        _therapist = db.Therapists.FirstOrDefault();
        _treatments = db.Treatments.ToList();
        _customer = customer;
        foreach (var treatment in _treatments)
        {
          this.checkedListBox1.DisplayMember = "DescriptionIt";
          if (_customer.Language == "german")
            this.checkedListBox1.DisplayMember = "DescriptionDe";
          this.checkedListBox1.Items.Add(treatment, false);
        }
      }
      ChangeVisitiTot();
    }

    private void MultipleVisits_Load(object sender, EventArgs e)
    {
      var firstItem = this.checkedListBox1.Items[0];
      numericUpDown1.Value = _visitNr;
      if (firstItem != null)
      {
        checkedListBox1.SetItemChecked(0, true);
        var treat = (DataModels.Treatment)firstItem;
        _visitTot = _visitNr * 70;
        textBoxPrice.Text = _visitTot.ToString();
        ChangeVisitiTot();
      }
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
      _visitNr = (int)numericUpDown1.Value;
      ChangeVisitiTot();
    }

    private void textBoxPrice_TextChanged(object sender, EventArgs e)
    {
      int.TryParse(textBoxPrice.Text, out _visitTot);
      ChangeVisitiTot();
    }

    private void ChangeVisitiTot()
    {
      var tot = _visitNr == 0 ? "0" : (_visitTot / _visitNr).ToString("#.00");
      labelSingleVisit.Text = $"( {tot} € a visita )";
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private DataModels.Visit ManageChecking(DataModels.Visit visit)
    {
      var items = checkedListBox1.CheckedItems;
      visit.Treatmentsvisitidfkeys = Enumerable.Empty<DataModels.VisitsTreatment>();
      List<DataModels.VisitsTreatment> a = new List<DataModels.VisitsTreatment>();

      foreach (var item in items)
      {
        a.Add(new DataModels.VisitsTreatment
        {
          Treatment = (DataModels.Treatment)item,
          TreatmentId = ((DataModels.Treatment)item).Id,
          Visit = visit,
          VisitId = visit.Id
        });
      }
      visit.Treatmentsvisitidfkeys = a;
      return visit;
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      double tot = _visitNr == 0 ? 0.0 : (_visitTot / _visitNr);
      if (tot == 0)
      {
        MessageBox.Show("Non è possiblie salvare visite a costo 0", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      for( int i=0; i < _visitNr; i++)
      {
        var visit = new DataModels.Visit();
        visit.Date = new NpgsqlTypes.NpgsqlDate(2060,1,1);
        visit.Customer = _customer;
        visit.CustomerId = _customer.Id;
        visit.Price = tot;
        visit.StartTime = "08:00";
        visit.Future = true;
        visit.TherapistId = _therapist.Id;
        visit.SaveToDB();
        visit = ManageChecking(visit);
        visit.SaveToDB();
      }

      MessageBox.Show($"Sono state create {_visitNr} visite future", "Terminato", MessageBoxButtons.OK, MessageBoxIcon.Information);

      VisitCreated?.Invoke(this, e);
    }
  }
}
