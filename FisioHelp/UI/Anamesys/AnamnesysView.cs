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
  public partial class AnamnesysView : Form
  {
    public RemoteAnamnesy _remoteAnamnesy;
    public RecentAnamnesy _recentAnamnesy;

    public AnamnesysView(Customer customer)
    {
      InitializeComponent();

      if (customer != null)
      {
        using (var db = new Db.PhisioDB())
        {
          _remoteAnamnesy = db.RemoteAnamnesys.FirstOrDefault(ra => ra.CustomerId == customer.Id);
          _recentAnamnesy = db.RecentAnamnesys.FirstOrDefault(ra => ra.CustomerId == customer.Id);
        }
      }
    }

    private void AddDescritpionField(string title, string text, Panel father)
    {
      if (string.IsNullOrEmpty(text))
        return;

      Label label = new Label
      {
        Dock = DockStyle.Top,
        Padding = new Padding(8),
        Width = father.Width,
        Font = new Font("Segoe UI Historic", 10F)
      };

      Label label1 = new Label
      {
        Text = title.ToUpper() + ": ",
        AutoSize = true,
        Padding = new Padding(5, 0, 0, 0),
        Dock = DockStyle.Left
      };

      Label label2 = new Label
      {
        Text = text,
        AutoSize = true,
        Dock = DockStyle.Left
      };

      label.Controls.Add(label2);
      label.Controls.Add(label1);
      label.Height = Math.Max(label1.Height, label2.Height) + 5;

      father.Controls.Add(label);
    }

    private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
    {
      ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
    }

    private void AnamnesysView_Load(object sender, EventArgs e)
    {
      var panel1 = this.panel1;
            var mainDiseaseDate = _recentAnamnesy?.MainDiseaseDate != null ? ((DateTime)_recentAnamnesy?.MainDiseaseDate).ToShortDateString() : "";
      AddDescritpionField("Altri disturbi", _recentAnamnesy?.OtherDiseases, panel1); 
      AddDescritpionField("Fattori leagati alla professione", _recentAnamnesy?.DiseaseInWork?.ToString(), panel1);
      AddDescritpionField("Fattori legati alla posizione sociale", _recentAnamnesy?.DiseaseInSocial?.ToString(), panel1);
      AddDescritpionField("Fattori legati alla famiglia", _recentAnamnesy?.DiseaseInFamily?.ToString(), panel1);
      AddDescritpionField("Incidenza sulla vita quotidiana", _recentAnamnesy?.DiseaseInLife?.ToString(), panel1);
      AddDescritpionField("Postura Lavorativa", _recentAnamnesy?.Posture, panel1);
      AddDescritpionField("Farmaci", _recentAnamnesy?.Medicine, panel1);
      AddDescritpionField("Trattamenti precedenti", _recentAnamnesy?.PreTreatment, panel1);
      AddDescritpionField("SINTOMO DOMINANTE", "---", panel1);
      AddDescritpionField("Descrizione", _recentAnamnesy?.MainDiseaseDescription, panel1);
      AddDescritpionField("Data insorgenza", mainDiseaseDate, panel1);
      AddDescritpionField("Modalità insorgenza", _recentAnamnesy?.MainDiseaseModality, panel1);
      AddDescritpionField("Decorso", _recentAnamnesy?.MainDiseaseCourse, panel1);
      AddDescritpionField("Fattori Aggravanti", _recentAnamnesy?.MainDiseaseFactorPlus, panel1);
      AddDescritpionField("Fattori Allevianti", _recentAnamnesy?.MainDiseaseFactorMinor, panel1);
      AddDescritpionField("Sintomi sistema nervoso", _recentAnamnesy?.MainDiseaseNervousSystem, panel1);
      AddDescritpionField("Sintomi ultime 24 ore", _recentAnamnesy?.MainDiseaseSymptoms24, panel1);
      AddDescritpionField("Intensità", _recentAnamnesy?.MainDiseaseIntensity?.ToString(), panel1);
      AddDescritpionField("Diagnostica per immagini", _recentAnamnesy?.ImagesDiagnostics, panel1);
      AddDescritpionField("Salute generale", _recentAnamnesy?.GlobalHealth, panel1);
      var mainDeseaes = new List<string> { _recentAnamnesy?.MainDisease1, _recentAnamnesy?.MainDisease2, _recentAnamnesy?.MainDisease3, _recentAnamnesy?.MainDisease4, _recentAnamnesy?.MainDisease5 };
      AddDescritpionField("Disturbi Principali", string.Join(Environment.NewLine, mainDeseaes), panel1);

      var panel2 = this.panel2;
      AddDescritpionField("Altro", _remoteAnamnesy?.Other, panel2);
      AddDescritpionField("Trattamenti precedenti", _remoteAnamnesy?.RecentTreatments, panel2);
      AddDescritpionField("Episodi precedenti", _remoteAnamnesy?.RecentEpisodes, panel2);
      AddDescritpionField("Traumi", _remoteAnamnesy?.Traumas, panel2);
      AddDescritpionField("Gravidanze", _remoteAnamnesy?.Pregnancy, panel2);
      AddDescritpionField("Anestesie generali", _remoteAnamnesy?.Anesthesias, panel2);
      AddDescritpionField("Chirurgie", _remoteAnamnesy?.Surgery, panel2);
      AddDescritpionField("Malattie Psichiatriche", _remoteAnamnesy?.PsychicDisease, panel2);
      AddDescritpionField("Malattie Fisiche", _remoteAnamnesy?.PhisicalDisease, panel2);

    }

  }
}
