using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;

namespace FisioHelp.UI
{
  public partial class InvoiceListCtrl : UserControl
  {
    public event EventHandler OpenInvoice;
    private DateTime _dateFromFilter;
    private DateTime _dateToFilter;
    private int _filterPayed = 0;
    private string[] _comboBoxValues = new string[] { "Tutti", "Sì", "No" };
    private List<DataModels.Invoice> _invoices;
    public DataModels.Invoice SelectedInvoice { get; set; }
    private DataModels.Customer _customer;

    public InvoiceListCtrl(DataModels.Customer customer)
    {
      _customer = customer;
      InitializeComponent();
      _invoices = new List<DataModels.Invoice>();
      dateTimePickerfrom.Format = DateTimePickerFormat.Custom;
      dateTimePickerfrom.Value = DateTime.Today.AddDays(-7);
      dateTimePickerfrom.CustomFormat = "dd/MM/yyyy";
      dateTimePickerTo.Format = DateTimePickerFormat.Custom;
      dateTimePickerTo.CustomFormat = "dd/MM/yyyy";
      comboBoxPayed.Items.AddRange(_comboBoxValues);
      comboBoxPayed.SelectedItem = _comboBoxValues[0];
      panel2.Width = this.Size.Width;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void dateTimePickerfrom_ValueChanged(object sender, EventArgs e)
    {

    }

    private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
    {

    }

    private void CalculateTotals(object sender, EventArgs e)
    {
      CalculateTotals();
    }

    private void CalculateTotals()
    {
      labelTotNr.Text = "Totale fatture: " + _invoices.Count.ToString();
      labelTotMoney.Text = "Totale guadagno: " + _invoices.Sum(x => x.Total).ToString() + " €";
      labelTotPayed.Text = "Totale incasso: " + _invoices.Where(x => x.Payed != null && x.Payed == true).Sum(x => x.Total).ToString() + " €";
    
    }

    private void comboBoxInvoice_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetInvoices();
      DrawVisits();
    }

    private void comboBoxPayed_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetInvoices();
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
      _dateFromFilter = dateTimePickerfrom.Value;
      _dateToFilter = dateTimePickerTo.Value;
      _filterPayed = comboBoxPayed.SelectedItem == null ? 0 : _comboBoxValues.Select((v, i) => new { c = v, index = i }).First(x => x.c == comboBoxPayed.SelectedItem?.ToString())?.index ?? 0;
    }

    private void GetInvoices()
    {
      using (var db = new Db.PhisioDB())
      {
        var custId = _customer != null ? _customer.Id : -1;

        _invoices = db.Invoices.LoadWith(e1 => e1.Visitsinvoiceidfkeys.First().Treatmentsvisitidfkeys.First().Treatment).LoadWith(e1 => e1.Visitsinvoiceidfkeys.First().Customer.Address)
          .Where(x =>  x.Visitsinvoiceidfkeys.Any(xx=>xx.CustomerId == custId) || custId < 0)
          .Where(x=> x.Date >= new NpgsqlTypes.NpgsqlDate(_dateFromFilter) && x.Date < new NpgsqlTypes.NpgsqlDate(_dateToFilter.AddDays(1)))
          .ToList();
      }
    }

    private void DrawVisits()
    {
      panel2.Controls.Clear();
      panel2.AutoScroll = true;
      DrawInvoces();
    }

    private void DrawInvoces()
    {
      var pos = 0;
      int odd = 0;
      Color[] colors = { Color.FromArgb(255, 255, 255), Color.FromArgb(255, 241, 240) };


      foreach (var invoice in _invoices)
      {
        var invoiceListItem = new UI.InvoiceListItem(invoice);
        invoiceListItem.Location = new Point(0, pos);
        //visitEconomic.Size = new Size(this.Width, 120);
        invoiceListItem.Dock = DockStyle.Top;
        pos += 120;
        invoiceListItem.OnOpenInvoice += OnOpenInvoice;
        panel2.Controls.Add(invoiceListItem);
        invoiceListItem.BackColor = colors[odd];
        invoiceListItem.ChangePayed += CalculateTotals;
        odd = (odd + 1) % 2;
      }

      panel3.Visible = true;
      panel2.Height = this.Height - 85 - 68;
      CalculateTotals();
    }
    
    private void OnOpenInvoice(object sender, EventArgs e)
    { 
      var invCtrl = (UI.InvoiceListItem)sender;
      SelectedInvoice = invCtrl.Invoice;
      
      OpenInvoice?.Invoke(this, e);
    }

  }
}
