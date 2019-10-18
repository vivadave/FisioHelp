using System;
using LinqToDB;
using System.Windows.Forms;
using FisioHelp.DataModels;

namespace FisioHelp.UI.Anamesys
{
  public partial class Anamnesys : Form
  {
    private Customer _customer;

    public Anamnesys(Customer customer)
    {
      _customer = customer;
      InitializeComponent();
    }

    private void Anamnesys_Load(object sender, EventArgs e)
    {
      this.Text = $"Schede vaslutazione {_customer.FullName}";
      var recentAnamnesys = new RecentAnamnesys(_customer);
      recentAnamnesys.Location = new System.Drawing.Point(0, 0);
      //recentAnamnesys.Size = new System.Drawing.Size(655, 1381);
      tabPageAnaRecent.Controls.Add(recentAnamnesys);

      var remoteAnamnesys = new RemoteAnamnesys(_customer);
      remoteAnamnesys.Location = new System.Drawing.Point(0, 0);
      //remoteAnamnesys.Size = new System.Drawing.Size(655, 834);
      tabPageAnaRemota.Controls.Add(remoteAnamnesys);

      var stomatognathic = new Stomatognathic(_customer);
      stomatognathic.Location = new System.Drawing.Point(0, 0);
      tabPageStomato.Controls.Add(stomatognathic);

    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      var selectedTab = tabControl1.SelectedTab;
      if (selectedTab == tabPageAnaRecent)
      {
        var anaCtrl = (RecentAnamnesys)selectedTab.Controls[0];
        anaCtrl.Save();
        var anamnesys = anaCtrl.RecentAnamnesy;
        anamnesys.SaveToDB();
      } else if (selectedTab == tabPageAnaRemota)
      {
        var anaCtrl = (RemoteAnamnesys)selectedTab.Controls[0];
        anaCtrl.Save();
        var anamnesys = anaCtrl.RemoteAnamnesy;
        anamnesys.SaveToDB();
      }
    }

    private void Anamnesys_ResizeEnd(object sender, EventArgs e)
    {
    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }
  }
}
