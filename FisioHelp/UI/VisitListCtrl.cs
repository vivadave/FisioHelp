using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;

namespace FisioHelp.UI
{
  public partial class VisitListCtrl : UserControl
  {
    public event EventHandler OpenVisit;
    private DateTime _dateFromFilter;
    private DateTime _dateToFilter;
    private int _filterPayed = 0;
    private int _filterInvoiced = 0;
    private int _filterProforma = 0;
    private bool _filterFuture = true;
    private string[] _comboBoxValues = new string[] { "Tutti", "Sì", "No" };
    private List<DataModels.Visit> _visits;
    public DataModels.Visit SelectedVisit { get; set; }
    private DataModels.Customer _customer;
    private List<DataModels.Visit> _visitsToInvoice { get; set; }
    private string _type;
    private ToolTip _displayAnamnesysTT = new ToolTip();
    private ToolTip _editAnamnesysTT = new ToolTip();
    private ToolTip _createInvoiceTT = new ToolTip();

    public VisitListCtrl(DataModels.Customer customer, string type = "economical")
    {
      _customer = customer;
      _visitsToInvoice = new List<DataModels.Visit>();
      _type = type;
      InitializeComponent();
      _visits = new List<DataModels.Visit>();

      dateTimePickerfrom.ValueChanged -= dateTimePickerfrom_ValueChanged;
      dateTimePickerfrom.Format = DateTimePickerFormat.Custom;
      dateTimePickerfrom.Value = Helper.Global.FilterFromData;
      dateTimePickerfrom.CustomFormat = "dd/MM/yyyy";
      dateTimePickerfrom.ValueChanged += dateTimePickerfrom_ValueChanged;

      dateTimePickerTo.Format = DateTimePickerFormat.Custom;
      dateTimePickerTo.Value = Helper.Global.FilterToData;
      dateTimePickerTo.CustomFormat = "dd/MM/yyyy";
      comboBoxInvoice.Items.AddRange(_comboBoxValues);
      comboBoxPayed.Items.AddRange(_comboBoxValues);
      comboBoxProforma.Items.AddRange(_comboBoxValues);
      comboBoxInvoice.SelectedItem = _comboBoxValues[0];
      comboBoxPayed.SelectedItem = _comboBoxValues[0];
      comboBoxProforma.SelectedItem = _comboBoxValues[0];
      panel2.Width = this.Size.Width;
      labelTitle.Text = type == "economical" ? "Visite: finanza" : "Visite: Relazione";
      labelAction.Text = type == "economical" ? "Azioni" : "Anamnesi";
      labelAction.BringToFront();
      _displayAnamnesysTT.SetToolTip(this.buttonAnamnesys, "Modifica anamnesi");
      _editAnamnesysTT.SetToolTip(this.buttonAnamnesysView, "Visualizza anamnesi");
      _createInvoiceTT.SetToolTip(this.buttonInvoices, "Crea una fattura delle visite selezionate");
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void dateTimePickerfrom_ValueChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetVisits();
      DrawVisits();
    }

    private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetVisits();
      DrawVisits();
    }

    private void CalculateTotals(object sender, EventArgs e)
    {
      CalculateTotals();
    }

    private void CalculateTotals()
    {
      labelTotNr.Text = "Totale visite: " + _visits.Count.ToString();
      labelTotMoney.Text = "Totale guadagno: " + _visits.Sum(x => x.Price).ToString() + " €";
      labelTotPayed.Text = "Totale incasso: " + _visits.Where(x => x.Payed != null && x.Payed == true).Sum(x => x.Price).ToString() + " €";
      labelTotProforma.Text = "Totale visite proforma: " + _visits.Count(x => x.ProformaInvoiced != null && x.ProformaInvoiced == true).ToString();
      labelTotInvoice.Text = "Totale visite fatturate: " + _visits.Count(x => x.Invoiced != null && x.Invoiced == true).ToString();
    }

    private void comboBoxInvoice_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetVisits();
      DrawVisits();
    }

    private void comboBoxPayed_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetVisits();
      DrawVisits();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void VisitListCtrl_Load(object sender, EventArgs e)
    {
      
    }

    private void SetFilters()
    {
      Helper.Global.FilterFromData = dateTimePickerfrom.Value;
      Helper.Global.FilterToData = dateTimePickerTo.Value;
      _dateFromFilter = Helper.Global.FilterFromData;
      _dateToFilter = Helper.Global.FilterToData;
      _filterFuture = checkBoxFuture.Checked;
      _filterInvoiced = comboBoxInvoice.SelectedItem == null ? 0 : _comboBoxValues.Select((v, i) => new { c = v, index = i }).First(x => x.c == comboBoxInvoice.SelectedItem?.ToString())?.index ?? 0;
      _filterPayed = comboBoxPayed.SelectedItem == null ? 0 : _comboBoxValues.Select((v, i) => new { c = v, index = i }).First(x => x.c == comboBoxPayed.SelectedItem?.ToString())?.index ?? 0;
      _filterProforma = comboBoxProforma.SelectedItem == null ? 0 : _comboBoxValues.Select((v, i) => new { c = v, index = i }).First(x => x.c == comboBoxProforma.SelectedItem?.ToString())?.index ?? 0;
    }

    private void GetVisits()
    {
      using (var db = new Db.PhisioDB())
      {
        Guid? custId = _customer?.Id;
        _visits = db.Visits.LoadWith(e1 => e1.Treatmentsvisitidfkeys)
          .LoadWith(e1 => e1.Invoice)
          .LoadWith(e1 => e1.Customer)
          .Where(x => x.Customer.Id == custId || custId == null)
          .Where(
          x=> x.Deleted == false && 
          ( x.Date >= new NpgsqlTypes.NpgsqlDate(_dateFromFilter) && 
          x.Date < new NpgsqlTypes.NpgsqlDate(_dateToFilter.AddDays(1)) 
          || x.Future == true))
          .ToList();
        _visits = _visits.OrderBy(x => x.Date).ToList();
        if (_filterInvoiced > 0)
          _visits = _visits.Where(x => x.Invoiced == (_filterInvoiced == 1 ? true : false)).ToList();
        if (_filterPayed > 0)
          _visits = _visits.Where(x => x.Payed == (_filterPayed == 1 ? true : false)).ToList();
        if (_filterProforma > 0)
          _visits = _visits.Where(x => x.ProformaInvoiced == (_filterProforma == 1 ? true : false)).ToList();
        if (_filterProforma > 0)
          _visits = _visits.Where(x => x.ProformaInvoiced == (_filterProforma == 1 ? true : false)).ToList();
        if (_filterFuture == false)
          _visits = _visits.Where(x => !x.Future).ToList();
      }
    }

    private void DrawVisits()
    {
      panel2.Controls.Clear();
      panel2.AutoScroll = true;
      if (_type == "economical")
        DrawEconomicVisit();
      else
        DrawMedicalVisit();
    }

    private void DrawEconomicVisit()
    {
      var pos = 0;
      int odd = 0;
      Color[] colors = { Color.FromArgb(255, 255, 255), Color.FromArgb(255, 241, 240) };

      buttonAnamnesys.Visible = false;
      buttonAnamnesysView.Visible = false;
      buttonInvoices.Visible = false;

      var vistitCltrlList = new List<VisitEconomicCtrl>();
      foreach (var visit in _visits)
      {
        var visitEconomic = new UI.VisitEconomicCtrl(visit);
        visitEconomic.Location = new Point(0, pos);
        //visitEconomic.Size = new Size(this.Width, 120);
        visitEconomic.Dock = DockStyle.Top;
        pos += 120;
        visitEconomic.OpenVisit += OnOpenVisit;
        visitEconomic.BackColor = visit.Future ? Color.FromArgb(220, 220, 220) : colors[odd];
        visitEconomic.ChangePayed += CalculateTotals;
        visitEconomic.ChangeInvoiced += AddInvoiced;
        vistitCltrlList.Add(visitEconomic);
        odd = (odd + 1) % 2;
      }
      if (_customer != null)
      {
        dataGridView1.Visible = false;
        panel2.Controls.AddRange(vistitCltrlList.ToArray());
      }
      else
      {
        this.panel2.Controls.Add(dataGridView1);
        dataGridView1.Rows.Clear();
        dataGridView1.Visible = true;
        foreach (var visit in _visits)
        {
          var r = (DataGridViewRow)dataGridView1.Rows[0].Clone();
          r.Cells[0].Value = visit.Customer.FullName;
          r.Cells[1].Value = (DateTime)visit.Date;
          r.Cells[2].Value = visit.StartTime;
          r.Cells[3].Value = visit.Price;
          r.Cells[4].Value = visit.Payed;
          r.Cells[5].Value = visit.ProformaInvoiced;
          r.Cells[6].Value = visit.Invoiced;
          r.Cells[7].Value = "Dettagli...";
          r.Cells[8].Value = visit.Id;
          r.DefaultCellStyle.BackColor = visit.Future ? Color.FromArgb(220, 220, 220) : colors[odd];
          dataGridView1.Rows.Add(r);
          odd = (odd + 1) % 2;
        }
      }

      panel3.Visible = true;
      panel2.Height = this.Height - 85 - 68;
      CalculateTotals();
    }

    private void AddInvoiced(object sender, EventArgs e)
    {
      var ve = (UI.VisitEconomicCtrl)sender;
      if (ve.Invoiced)
        _visitsToInvoice.Add(ve.Visit);
      else
        _visitsToInvoice.RemoveAll(x => x.Id == ve.Visit.Id);

      if (_visitsToInvoice.Any())
        buttonInvoices.Visible = true;
      else
        buttonInvoices.Visible = false;
    }
  
    private void DrawMedicalVisit()
    {
      var pos = 0;
      int odd = 0;
      Color[] colors = { Color.FromArgb(255, 255, 255), Color.FromArgb(255, 241, 240) };

      buttonAnamnesys.Visible = true;
      buttonAnamnesysView.Visible = true;
      buttonInvoices.Visible = false;
      dataGridView1.Visible = false;

      foreach (var visit in _visits)
      {
        var visitMedical = new UI.VisitMedicalCtrl(visit);
        visitMedical.Location = new Point(0, pos);
        visitMedical.Size = new Size(this.Width, 180);
        visitMedical.Dock = DockStyle.Top;
        pos += 180;
        visitMedical.OpenVisit += OnOpenVisit;
        panel2.Controls.Add(visitMedical);
        visitMedical.BackColor = colors[odd];
        odd = (odd + 1) % 2;
      }

      panel3.Visible = false;
      panel2.Height = this.Height - 85;
    }

    private void OnOpenVisit(object sender, EventArgs e)
    {
      if (_type == "economical")
      {
        var ve = (UI.VisitEconomicCtrl)sender;
        SelectedVisit = ve.Visit;
      }
      else
      {
        var vm = (UI.VisitMedicalCtrl)sender;
        SelectedVisit = vm.Visit;
      }
      OpenVisit?.Invoke(this, e);
    }

    private void buttonAnamnesys_Click(object sender, EventArgs e)
    {
      UI.Anamesys.Anamnesys anamnesysFrm = new Anamesys.Anamnesys(_customer);
      anamnesysFrm.ShowDialog();
    }
    private void buttonAnamnesysView_Click(object sender, EventArgs e)
    {
      UI.Anamesys.AnamnesysView anamnesysFrm = new Anamesys.AnamnesysView(_customer);
      anamnesysFrm.ShowDialog();
    }

    private void buttonInvoices_Click(object sender, EventArgs e)
    {
      var errors = "";
      var invoice = Helper.Helper.CreateNewProformaInvoice(_visitsToInvoice, out errors);
      if (!string.IsNullOrEmpty(errors))
      {
        MessageBox.Show(errors,"ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      UI.InvoiceFrm invoiceFrm = new InvoiceFrm(invoice);
      invoiceFrm.ShowDialog();
    }

    private void comboBoxProforma_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetVisits();
      DrawVisits();
    }

    private void checkBoxFuture_CheckedChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetVisits();
      DrawVisits();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != 7) return;
      var cell = dataGridView1.Rows[e.RowIndex].Cells["id"];

      SelectedVisit = _visits.FirstOrDefault(x => x.Id == new Guid(cell.Value.ToString()));
      OpenVisit?.Invoke(this, e);
    }
  }
}
