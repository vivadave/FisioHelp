using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioHelp
{
  using DataModels;
  using LinqToDB;

  public partial class Form1 : Form
  {
    List<FisioHelp.DataModels.Customer> customers;
    public Form1()
    {
      Helper.Helper.GenerateDB();
      InitializeComponent();
      LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      
    }

    private void OnNameClicked(object sender, EventArgs e)
    {

      var control = (UI.PatientListItem)sender;
      if (control.Customer == null)
      {
        AddVisitList();
      }
      else
      {
        this.splitContainer1.Panel2.Controls.Clear();
        var userForm = new UI.SinglePatientMain(control.Customer);
        userForm.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitContainer1.Panel2.Controls.Add(userForm);
      }

      foreach (var c in this.panel2.Controls)
      {
        var uc = (UI.PatientListItem)c;
        uc.BackColor = Color.White;
      }
      control.BackColor = Color.FromArgb(255, 236, 236);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      CreateNameList();
      AddVisitList();
    }

    private void CreateNameList()
    {
      using (var db = new Db.PhisioDB())
      {
        if (textBoxFilter.Text.Length>0)
          customers = db.Customers.LoadWith(e1 => e1.Address).LoadWith(e1 => e1.Pricelist).Where(x =>x.Surname.ToLower().Contains(textBoxFilter.Text.ToLower()) || x.Name.ToLower().Contains(textBoxFilter.Text.ToLower())).ToList();
        else
          customers = db.Customers.LoadWith(e1 => e1.Address).LoadWith(e1 => e1.Pricelist).ToList();
      }

      if (customers != null)
      {
        customers = customers.OrderByDescending(x => x.FullName).ToList();
        customers.Add(null);
        this.panel2.Controls.Clear();
        foreach (var customer in customers)
        {
          var listItemName = new UI.PatientListItem(customer);
          listItemName.Dock = System.Windows.Forms.DockStyle.Top;
          listItemName.Location = new System.Drawing.Point(0, 60);
          listItemName.Size = new System.Drawing.Size(175, 60);
          listItemName.TabIndex = 0;
          listItemName.UserClicked += OnNameClicked;
          if (customer == null)
            listItemName.BackColor = Color.FromArgb(255, 236, 236);
          this.panel2.Controls.Add(listItemName);
        }
      }
    }

    private void AddVisitList()
    {
      var visitList = new UI.VisitListCtrl(null);
      visitList.Dock = System.Windows.Forms.DockStyle.Fill;
      visitList.OpenVisit += OnOpenVisit;
      this.splitContainer1.Panel2.Controls.Clear();
      this.splitContainer1.Panel2.Controls.Add(visitList);
    }

    private void toolStripLabel1_Click(object sender, EventArgs e)
    {
      var newPatientForm = new UI.Globals.Setting();
      newPatientForm.ShowDialog();
    }

    private void OnOpenVisit(object sender, EventArgs e)
    {
      var vc = (UI.VisitListCtrl)sender;
      this.splitContainer1.Panel2.Controls.Clear();
      var userForm = new UI.SinglePatientMain(vc.SelectedVisit?.Customer);
      userForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Panel2.Controls.Add(userForm);
      userForm.OpenVisit(vc.SelectedVisit);
    }

    private void textBoxFilter_TextChanged(object sender, EventArgs e)
    {
      CreateNameList();
    }

    private void toolStripLabel2_Click(object sender, EventArgs e)
    {
      var newPatientForm = new UI.NewPatient();
      newPatientForm.ShowDialog();
    }
  }
}
