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
  public partial class RemoteAnamnesys : UserControl
  {
    public RemoteAnamnesy RemoteAnamnesy;

    public RemoteAnamnesys(Customer customer)
    {
      InitializeComponent();

      if (customer != null)
      {
        using (var db = new Db.PhisioDB())
        {
          RemoteAnamnesy = db.RemoteAnamnesys.FirstOrDefault(ra => ra.CustomerId == customer.Id);
        }

        if (RemoteAnamnesy == null)
        {
          RemoteAnamnesy = new RemoteAnamnesy
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
      RemoteAnamnesy.Anesthesias = richTextBoxAnestesia.Text;
      RemoteAnamnesy.Other = richTextBoxOther.Text;
      RemoteAnamnesy.RecentTreatments = richTextBoxPastTreatments.Text;
      RemoteAnamnesy.Pregnancy = richTextBoxPregnancy.Text;
      RemoteAnamnesy.PhisicalDisease = richTextBoxPsichicalDisease.Text;
      RemoteAnamnesy.RecentEpisodes = richTextBoxPastEpisodes.Text;
      RemoteAnamnesy.Surgery = richTextBoxSurgery.Text;
      RemoteAnamnesy.Traumas = richTextBoxTraumas.Text;
      RemoteAnamnesy.PsychicDisease = richTextBoxPsichicalDisease.Text;
    }

    private void RecentAnamnesys_Load(object sender, EventArgs e)
    {
      if (RemoteAnamnesy == null)
        return;

      richTextBoxAnestesia.Text = RemoteAnamnesy.Anesthesias;
      richTextBoxOther.Text = RemoteAnamnesy.Other;
      richTextBoxPastTreatments.Text = RemoteAnamnesy.RecentTreatments;
      richTextBoxPregnancy.Text = RemoteAnamnesy.Pregnancy;
      textBoxPhisicalDisease.Text = RemoteAnamnesy.PhisicalDisease;
      richTextBoxPastEpisodes.Text = RemoteAnamnesy.RecentEpisodes;
      richTextBoxSurgery.Text = RemoteAnamnesy.Surgery;
      richTextBoxTraumas.Text = RemoteAnamnesy.Traumas;
      richTextBoxPsichicalDisease.Text = RemoteAnamnesy.PsychicDisease;
    }

    private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
