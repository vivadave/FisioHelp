using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioHelp
{
  using DataModels;
  using LinqToDB;
  using Helper;
  using System.Collections.ObjectModel;

  public partial class Form1 : Form
  {
    private Therapist _therapist;
    List<Customer> customers;
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
        AddDashBoard();
      }
      else
      {
        this.splitContainer1.Panel2.Controls.Clear();
        var userForm = new UI.SinglePatientMain(control.Customer);
        userForm.PatientSaved += NewPatient;
        userForm.Dock = DockStyle.Fill;
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
      //Helper.DriveManagement.DeleteAll();
      CreateNameList();
      AddDashBoard();

      using (var db = new Db.PhisioDB())
      {
        _therapist = db.Therapists.FirstOrDefault();
      }

      if (_therapist != null)
        BackupManager.SetBackupTimer(_therapist);

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
        customers = customers.OrderByDescending(x => x.FullName).Skip(Math.Max(0, customers.Count() - 60)).ToList();
        customers.Add(null);
        this.panel2.Controls.Clear();
                var panelHeight = 0;
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
          panelHeight += 75;
        }        
        this.panel2.Size = new Size(this.panel4.Size.Width, panelHeight);
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

    private void AddDashBoard()
    {
      var dashBoardCtrl = new UI.Dashboard.Dashboard();
      dashBoardCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Panel2.Controls.Clear();
      this.splitContainer1.Panel2.Controls.Add(dashBoardCtrl);
    }

    private void OnOpenVisit(object sender, EventArgs e)
    {
      var vc = (UI.VisitListCtrl)sender;
      this.splitContainer1.Panel2.Controls.Clear();
      var userForm = new UI.SinglePatientMain(vc.SelectedVisit?.Customer);
      userForm.PatientSaved += NewPatient;
      userForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Panel2.Controls.Add(userForm);
      userForm.OpenVisit(vc.SelectedVisit);
    }

    private async void textBoxFilter_TextChanged(object sender, EventArgs e)
    {
      TextBox tb = (TextBox)sender;
      int startLength = tb.Text.Length;

      await Task.Delay(500);
      if (startLength == tb.Text.Length)
        CreateNameList();
    }
    
    private void NewPatient(object sender, EventArgs e)
    {
      new Task(CreateNameList).Start();
      // CreateNameList();
      AddDashBoard();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (string.IsNullOrEmpty(_therapist.SqlbackupFolder))
        return;

      var loaderFrm = new UI.Globals.Loader("Attendere il salvataggio del database");
      loaderFrm.Show();

      var file = Path.Combine(_therapist.SqlbackupFolder, $"pisioHelp_{DateTime.Today.ToString("yyyyMMdd")}.sql");
      DbManagement.PostgreSqlDump(file);
      DriveManagement.DeleteInFolder("Database_Backup", DataModels.Enums.FileType.sql, 7);
      DriveManagement.InsertFile(file, new List<string> { "Database_Backup" }, DataModels.Enums.FileType.sql);
    }

    private void OnOpenInvoice(object sender, EventArgs e)
    {
      var vlc = (UI.InvoiceListCtrl)sender;
      var selectedInvoice = vlc.SelectedInvoice;
      OpenInvoice(selectedInvoice);
    }

    private void OpenInvoice(ProformaInvoice proformaInvoice)
    {
      this.splitContainer1.Panel2.Controls.Clear();
      var userForm = new UI.SinglePatientMain(proformaInvoice.Customer);
      userForm.PatientSaved += NewPatient;
      userForm.Dock = DockStyle.Fill;
      this.splitContainer1.Panel2.Controls.Add(userForm);
      userForm.OpenInvoice(proformaInvoice);
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      var newPatientForm = new UI.NewPatient();
      newPatientForm.PatientSaved += NewPatient;
      newPatientForm.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var dashBoardCtrl = new UI.Dashboard.Dashboard();
      dashBoardCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Panel2.Controls.Clear();
      this.splitContainer1.Panel2.Controls.Add(dashBoardCtrl);

      var visitList = new UI.InvoiceListCtrl(null);
      visitList.Dock = System.Windows.Forms.DockStyle.Fill;
      visitList.OpenInvoice += OnOpenInvoice;
      this.splitContainer1.Panel2.Controls.Clear();
      this.splitContainer1.Panel2.Controls.Add(visitList);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      var newPatientForm = new UI.Globals.Setting();
      newPatientForm.ShowDialog();
    }

    private void buttonVisits_Click(object sender, EventArgs e)
    {
      var dashBoardCtrl = new UI.Dashboard.Dashboard();
      dashBoardCtrl.Dock = DockStyle.Fill;
      this.splitContainer1.Panel2.Controls.Clear();
      this.splitContainer1.Panel2.Controls.Add(dashBoardCtrl);

      var visitList = new UI.VisitListCtrl(null, "economical");
      visitList.Dock = System.Windows.Forms.DockStyle.Fill;
      visitList.OpenVisit += OnOpenVisit;
      this.splitContainer1.Panel2.Controls.Clear();
      this.splitContainer1.Panel2.Controls.Add(visitList);
    }

    private void textBoxFilter_Enter(object sender, EventArgs e)
    {
      // CreateNameList();
    }
  }
}
