﻿using System;
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
    private List<DataModels.ProformaInvoice> _proformaInvoices;
    public DataModels.ProformaInvoice SelectedInvoice { get; set; }
    public DataModels.Customer Customer;

    public InvoiceListCtrl(DataModels.Customer customer)
    {
      Customer = customer;
      InitializeComponent();
      _proformaInvoices = new List<DataModels.ProformaInvoice>();

      dateTimePickerfrom.ValueChanged -= dateTimePickerfrom_ValueChanged;
      dateTimePickerfrom.Format = DateTimePickerFormat.Custom;
      dateTimePickerfrom.Value = Helper.Global.FilterFromData;
      dateTimePickerfrom.CustomFormat = "dd/MM/yyyy";
      dateTimePickerfrom.ValueChanged += dateTimePickerfrom_ValueChanged;

      dateTimePickerTo.Format = DateTimePickerFormat.Custom;
      dateTimePickerTo.Value = Helper.Global.FilterToData;
      dateTimePickerTo.CustomFormat = "dd/MM/yyyy";
      comboBoxPayed.Items.AddRange(_comboBoxValues);
      comboBoxPayed.SelectedItem = _comboBoxValues[0];

      InvoiceListHeader invoiceListHeader = new InvoiceListHeader();
      invoiceListHeader.Dock = DockStyle.Top;
      panel2.Controls.Add(invoiceListHeader);
      panel2.Width = this.Size.Width;
    }
    
    private void dateTimePickerfrom_ValueChanged(object sender, EventArgs e)
    {
      RedrawInvoices();
    }

    private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
    {
      RedrawInvoices();
    }

    private void RedrawInvoices()
    {
      SetFilters();
      GetInvoices();
      DrawVisits();
    }

    private void CalculateTotals(object sender, EventArgs e)
    {
      CalculateTotals();
    }

    private void CalculateTotals()
    {
      labelTotNr.Text = "Totale fatture: " + _proformaInvoices.Count.ToString();
      labelTotMoney.Text = "Totale guadagno: " + _proformaInvoices.Sum(x => x.Total).ToString() + " €";
      labelTotPayed.Text = "Totale incasso: " + _proformaInvoices.Where(x => x.Payed == true).Sum(x => x.Total).ToString() + " €";    
    }

    private void comboBoxInvoice_SelectedIndexChanged(object sender, EventArgs e)
    {
      RedrawInvoices();
    }

    private void comboBoxPayed_SelectedIndexChanged(object sender, EventArgs e)
    {
      RedrawInvoices();
    }
    
    private void SetFilters()
    {
      Helper.Global.FilterFromData = dateTimePickerfrom.Value;
      _dateFromFilter = Helper.Global.FilterFromData;
      Helper.Global.FilterToData = dateTimePickerTo.Value;
      _dateToFilter = Helper.Global.FilterToData;
      _filterPayed = comboBoxPayed.SelectedItem == null ? 0 : _comboBoxValues.Select((v, i) => new { c = v, index = i }).First(x => x.c == comboBoxPayed.SelectedItem?.ToString())?.index ?? 0;
    }

    private void GetInvoices()
    {
      using (var db = new Db.PhisioDB())
      {
        Guid? custId = Customer?.Id;

        _proformaInvoices = db.ProformaInvoices.LoadWith(e1 => e1.Visitsproformainvoiceidfkeys.First().Treatmentsvisitidfkeys.First().Treatment).LoadWith(e1 => e1.Visitsproformainvoiceidfkeys.First().Customer.Address).LoadWith(x=>x.Invoice)
          .Where(x =>  x.Visitsproformainvoiceidfkeys.Any(xx=>xx.CustomerId == custId) || custId == null)
          .Where(x => x.Date >= new NpgsqlTypes.NpgsqlDate(_dateFromFilter) && x.Date < new NpgsqlTypes.NpgsqlDate(_dateToFilter.AddDays(1)))
          .ToList();
        _proformaInvoices = _proformaInvoices.OrderBy(x => x.Date).OrderBy(x => x.Invoice == null).ToList();

        if (_filterPayed > 0)
        {
          _proformaInvoices = _proformaInvoices.Where(x => x.Payed == (_filterPayed == 1)).ToList();
        }
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


      foreach (var proformaInvoice in _proformaInvoices)
      {
        var invoiceListItem = new UI.InvoiceListItem(proformaInvoice, Customer);
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
      SelectedInvoice = invCtrl.ProformaInvoice;
      
      OpenInvoice?.Invoke(this, e);
    }

  }
}
