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
      InitializeComponent();
      LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      
    }

    private void OnNameClicked(object sender, EventArgs e)
    {
      var control = (UI.PatientListItem)sender;
      this.splitContainer1.Panel2.Controls.Clear();
      var userForm = new UI.SinglePatientMain(control.Customer);
      userForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Panel2.Controls.Add(userForm);
    }

    private void Form1_Load(object sender, EventArgs e)
    { 
      using (var db = new Db.PhisioDB())
      {
        customers = db.Customers.LoadWith(e1 => e1.Address).ToList();
      }

      if (customers != null)
      {
        var pos = 0;
        foreach (var customer in customers)
        {
          var listItemName = new UI.PatientListItem(customer);
          listItemName.Dock = System.Windows.Forms.DockStyle.Top;
          listItemName.Location = new System.Drawing.Point(0, 0);
          listItemName.Size = new System.Drawing.Size(175, 60);
          listItemName.TabIndex = 0;
          listItemName.UserClicked += OnNameClicked;
          pos += 40;
          this.splitContainer1.Panel1.Controls.Add(listItemName);

        }
      }
    }

    private void toolStripLabel1_Click(object sender, EventArgs e)
    {
      var newPatientForm = new UI.NewPatient();
      newPatientForm.ShowDialog();
    }
  }
}
