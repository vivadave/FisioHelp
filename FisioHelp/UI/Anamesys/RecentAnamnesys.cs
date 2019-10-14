using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FisioHelp.DataModels;

namespace FisioHelp.UI.Anamesys
{
  public partial class RecentAnamnesys : UserControl
  {
    public RecentAnamnesy RecentAnamnesy;

    public RecentAnamnesys(Customer customer)
    {
      InitializeComponent();

      if (customer != null)
      {
        using (var db = new Db.PhisioDB())
        {
          RecentAnamnesy = db.RecentAnamnesys.FirstOrDefault(ra => ra.CustomerId == customer.Id);
        }

        if (RecentAnamnesy == null)
        {
          RecentAnamnesy = new RecentAnamnesy
          {
            Customer = customer,
            CustomerId = customer.Id
          };
        }
      }
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {

    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    public void Save()
    {
      RecentAnamnesy.MainDisease1 = textBoxMainDisease1.Text;
      RecentAnamnesy.MainDisease2 = textBoxMainDisease2.Text;
      RecentAnamnesy.MainDisease3 = textBoxMainDisease3.Text;
      RecentAnamnesy.MainDisease4 = textBoxMainDisease4.Text;
      RecentAnamnesy.MainDisease5 = textBoxMainDisease5.Text;

      RecentAnamnesy.GlobalHealth = textBoxGlobalHealth.Text;
      RecentAnamnesy.OtherDiseases = richTextBoxOtherDisease.Text;

      RecentAnamnesy.DiseaseInLife = trackBarLifeNormal.Value;
      RecentAnamnesy.DiseaseInFamily = trackBarFamily.Value;
      RecentAnamnesy.DiseaseInSocial = trackBarSocialPosition.Value;
      RecentAnamnesy.DiseaseInWork = trackBarWork.Value;

      RecentAnamnesy.Posture = richTextBoxWorkPostue.Text;
      RecentAnamnesy.Medicine = richTextBoxMedicinsRecent.Text;
      RecentAnamnesy.PreTreatment = richTextBoxTreatmentsBefore.Text;

      RecentAnamnesy.MainDiseaseIntensity = trackBarIntensity.Value;

      RecentAnamnesy.MainDiseaseDescription = richTextBoxDescription.Text;

      RecentAnamnesy.MainDiseaseDate = new NpgsqlTypes.NpgsqlDate(dateTimePicker1.Value);

      RecentAnamnesy.MainDiseaseModality = richTextBoxModality.Text;
      RecentAnamnesy.MainDiseaseCourse = richTextBoxStory.Text;
      RecentAnamnesy.MainDiseaseFactorPlus = richTextBoxFactorPlus.Text;
      RecentAnamnesy.MainDiseaseFactorMinor = richTextBoxFactorMinus.Text;
      RecentAnamnesy.MainDiseaseNervousSystem = richTextBoxNervousSintoms.Text;
      RecentAnamnesy.MainDiseaseSymptoms24 = richTextBox24hSyntoms.Text;

      RecentAnamnesy.ImagesDiagnostics = richTextBoxImageDiafnostic.Text;
    }

    private void RecentAnamnesys_Load(object sender, EventArgs e)
    {
      if (RecentAnamnesy == null)
        return;

      textBoxMainDisease1.Text = RecentAnamnesy.MainDisease1;
      textBoxMainDisease2.Text = RecentAnamnesy.MainDisease2;
      textBoxMainDisease3.Text = RecentAnamnesy.MainDisease3;
      textBoxMainDisease4.Text = RecentAnamnesy.MainDisease4;
      textBoxMainDisease5.Text = RecentAnamnesy.MainDisease5;

      textBoxGlobalHealth.Text = RecentAnamnesy.GlobalHealth;
      richTextBoxOtherDisease.Text = RecentAnamnesy.OtherDiseases;

      trackBarLifeNormal.Value = RecentAnamnesy.DiseaseInLife ?? 0;
      trackBarFamily.Value = RecentAnamnesy.DiseaseInFamily ?? 0;
      trackBarSocialPosition.Value = RecentAnamnesy.DiseaseInSocial ?? 0;
      trackBarWork.Value = RecentAnamnesy.DiseaseInWork ?? 0;

      richTextBoxWorkPostue.Text = RecentAnamnesy.Posture;
      richTextBoxMedicinsRecent.Text = RecentAnamnesy.Medicine;
      richTextBoxTreatmentsBefore.Text = RecentAnamnesy.PreTreatment;

      trackBarIntensity.Value = RecentAnamnesy.MainDiseaseIntensity ?? 0;

      richTextBoxDescription.Text = RecentAnamnesy.MainDiseaseDescription;

      dateTimePicker1.Value = RecentAnamnesy.MainDiseaseDate != null ? (DateTime)RecentAnamnesy.MainDiseaseDate : DateTime.Now;

      richTextBoxModality.Text = RecentAnamnesy.MainDiseaseModality;
      richTextBoxStory.Text = RecentAnamnesy.MainDiseaseCourse;
      richTextBoxFactorPlus.Text = RecentAnamnesy.MainDiseaseFactorPlus;
      richTextBoxFactorMinus.Text = RecentAnamnesy.MainDiseaseFactorMinor;
      richTextBoxNervousSintoms.Text = RecentAnamnesy.MainDiseaseNervousSystem;
      richTextBox24hSyntoms.Text = RecentAnamnesy.MainDiseaseSymptoms24;

      richTextBoxImageDiafnostic.Text = RecentAnamnesy.ImagesDiagnostics;
    }
  }
}
