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

namespace FisioHelp.UI
{
  public partial class SinglePatientMain : UserControl
  {
    private Customer _customer;
    private DataModels.Visit _selectedVist;
    private DataModels.Invoice _selectedInvoice;

    private ToolTip _editPatientTT = new ToolTip();
    private ToolTip _createVisitTT = new ToolTip();
    private ToolTip _visitListTT = new ToolTip();
    private ToolTip _visitEconomicListTT = new ToolTip();
    private ToolTip _invoiceListTT = new ToolTip();

    public SinglePatientMain(Customer customer)
    {
      InitializeComponent();
      _customer = customer;
      labelName.Text = $"{customer.Name} {customer.Surname}".ToUpper();
      _editPatientTT.SetToolTip(this.buttonCustomer, "Modifica i dati del paziente");
      _createVisitTT.SetToolTip(this.buttonVisit, $"Crea una nuova visita per {_customer.Name}");
      _visitListTT.SetToolTip(this.buttonMedicalList, "Visualizza la lista dei referti delle visite e le anamnesi");
      _visitEconomicListTT.SetToolTip(this.buttonEconomicList, $"Visualizza la lista dei dati finanziari delle visite di {_customer.Name}");
      _invoiceListTT.SetToolTip(this.buttonInvoice, "Visualizza la lista delle fatture");
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.panel3.Controls.Clear();
      var userForm = new UI.AddPatient(_customer);
      userForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Controls.Add(userForm);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      OpenVisit(new Visit());
    }

    public void OpenVisit(Visit visit)
    {
      this.panel3.Controls.Clear();
      var userForm = new UI.VisitCtrl(_customer, visit);
      userForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Controls.Add(userForm);
    }

    public void OpenInvoice(Invoice invoice)
    {
      this.panel3.Controls.Clear();
      var userForm = new UI.InvoiceCtrl(invoice, true);
      userForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Controls.Add(userForm);
    }

    private void SinglePatientMain_Load(object sender, EventArgs e)
    {
      EconomicListLoad();
    }

    private void EconomicListLoad()
    {
      var visitList = new UI.VisitListCtrl(_customer, "economical");
      visitList.Dock = System.Windows.Forms.DockStyle.Fill;
      visitList.OpenVisit += OnOpenVisit;
      this.panel3.Controls.Clear();
      this.panel3.Controls.Add(visitList);
    }

    private void MedicalListLoad()
    {
      var visitList = new UI.VisitListCtrl(_customer, "medical");
      visitList.Dock = System.Windows.Forms.DockStyle.Fill;
      visitList.OpenVisit += OnOpenVisit;
      this.panel3.Controls.Clear();
      this.panel3.Controls.Add(visitList);
    }

    private void InvoiceListLoad()
    {
      var visitList = new UI.InvoiceListCtrl(_customer);
      visitList.Dock = System.Windows.Forms.DockStyle.Fill;
      visitList.OpenInvoice += OnOpenInvoice;
      this.panel3.Controls.Clear();
      this.panel3.Controls.Add(visitList);
    }

    private void OnOpenVisit(object sender, EventArgs e)
    {
      var vlc = (UI.VisitListCtrl)sender;
      _selectedVist = vlc.SelectedVisit;
      OpenVisit(_selectedVist);
    }

    private void OnOpenInvoice(object sender, EventArgs e)
    {
      var vlc = (UI.InvoiceListCtrl)sender;
      _selectedInvoice = vlc.SelectedInvoice;
      OpenInvoice(_selectedInvoice);
    }

    private void buttonEconomicList_Click(object sender, EventArgs e)
    {
      EconomicListLoad();
    }

    private void buttonMedicalList_Click(object sender, EventArgs e)
    {
      MedicalListLoad();
    }

    private void buttonInvoice_Click(object sender, EventArgs e)
    {
      InvoiceListLoad();
    }
  }
}
