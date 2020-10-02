using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;
using System.IO;

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
    DataModels.Therapist _therapist = null;

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

      var col = this.dataGridView1.Columns[1];
      col.DefaultCellStyle.Format = "dd.MM.yyyy";
      using (var db = new Db.PhisioDB())
      {
        _therapist = db.Therapists.FirstOrDefault();
      }
    }

    public void InsertHeader()
    {
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
          .Where(x =>  x.Visitsproformainvoiceidfkeys.Any(xx=>xx.CustomerId == custId ) || custId == null)
          .Where(x => (x.Date >= new NpgsqlTypes.NpgsqlDate(_dateFromFilter) && x.Date < new NpgsqlTypes.NpgsqlDate(_dateToFilter.AddDays(1)) || x.Invoice.Date >= new NpgsqlTypes.NpgsqlDate(_dateFromFilter) && x.Invoice.Date < new NpgsqlTypes.NpgsqlDate(_dateToFilter.AddDays(1)) ) && x.Deleted == false)
          .ToList();

        _proformaInvoices = _proformaInvoices.OrderBy(x => x.Date).OrderBy(x => x.Invoice == null).ToList();

        //Remove proforma with deleted visits
        _proformaInvoices = _proformaInvoices.Where(x => x.Visitsproformainvoiceidfkeys.Count() > 0).ToList();
        if (_filterPayed > 0)
        {
          _proformaInvoices = _proformaInvoices.Where(x => x.Payed == (_filterPayed == 1)).ToList();
        }

        if (checkBox1.Checked)
        {
          _proformaInvoices = _proformaInvoices.Where(x => x.Invoice != null).ToList();
        }

        _proformaInvoices = _proformaInvoices.OrderBy(x => x.Invoice?.Title).ThenBy(x=>x.Date).ThenBy(x => x.Title).ToList();
        /*
        var noinvoices = _proformaInvoices.Where(x => x.Invoice == null).ToList();
        foreach (var proformaInvoice in noinvoices)
        {
          if (proformaInvoice.Invoice == null)
          {
            _proformaInvoices.Remove(proformaInvoice);
            _proformaInvoices.Add(proformaInvoice);
          }
        }*/
      }
    }

    private void DrawVisits()
    {
      panel2.Controls.Clear();
      panel2.AutoScroll = true;
      DrawInvoces();
      if (Customer != null)
        InsertHeader();
    }

    private void DrawInvoces()
    {
      var pos = 0;
      int odd = 0;
      Color[] colors = { Color.FromArgb(255, 255, 255), Color.FromArgb(255, 241, 240) };
      var invoiceListItemList = new List<InvoiceListItem>();
      foreach (var proformaInvoice in _proformaInvoices)
      {
        var invoiceListItem = new UI.InvoiceListItem(proformaInvoice, Customer);
        invoiceListItem.Location = new Point(0, pos);
        //visitEconomic.Size = new Size(this.Width, 120);
        invoiceListItem.Dock = DockStyle.Top;
        pos += 120;
        invoiceListItem.OnOpenInvoice += OnOpenInvoice;
        invoiceListItem.BackColor = colors[odd];
        invoiceListItem.ChangePayed += CalculateTotals;
        invoiceListItemList.Add(invoiceListItem);
        odd = (odd + 1) % 2;
      }
      
      if (Customer != null)
      {
        dataGridView1.Visible = false;
        panel2.Controls.AddRange(invoiceListItemList.ToArray());
      }
      else
      {
        this.panel2.Controls.Add(dataGridView1);
        dataGridView1.Rows.Clear();
        int i = 0;
        dataGridView1.Visible = true;
        foreach (var proforma in _proformaInvoices)
        {
          var invoiceDate = proforma.Invoice != null ? ((DateTime)proforma.Invoice.Date) : ((DateTime)proforma.Date);
          var r = (DataGridViewRow)dataGridView1.Rows[0].Clone();

          var invTit = proforma.Invoice == null ? "" : proforma.Invoice.Title;
          var invoiceTitle = new InvoiceTitle(invTit);
          r.Cells[0].Value = invoiceTitle;
          r.Cells[1].Value = invoiceDate;
          r.Cells[2].Value = proforma.Title;
          r.Cells[3].Value = proforma.Customer?.FullName;
          r.Cells[4].Value = proforma.Total;
          r.Cells[5].Value = proforma.Visitsproformainvoiceidfkeys.ToList().Count.ToString();
          r.Cells[6].Value = proforma.Payed;
          r.Cells[7].Value = imageList1.Images[0];
          r.Cells[8].Value = imageList1.Images[1];
          r.Cells[9].Value = proforma.Id;
          r.DefaultCellStyle.BackColor = colors[odd];
          dataGridView1.Rows.Add(r);
          odd = (odd + 1) % 2;
        }
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

    private void buttonExcel_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      var curs = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      var path = saveFileDialog1.FileName;
      Helper.ExcelManagement.CreateExel(path, _proformaInvoices);
      this.Cursor = curs;
      MessageBox.Show("File Salvato!", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {

    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0) return;
      var id = dataGridView1[9, e.RowIndex].Value;

      if (e.RowIndex + 1 >= dataGridView1.RowCount)
        return;
      SelectedInvoice = _proformaInvoices.FirstOrDefault(x => x.Id == new Guid(id.ToString()));
      if (e.ColumnIndex == 7) //fatture
      { 
        if(SelectedInvoice.Invoice == null)
        {
          MessageBox.Show("La fattura non è ancora disponibile");
        } 
        else
        {
          var basePath = _therapist.InvoicesFolder;
          var date = $"{SelectedInvoice.Invoice.Date.Year}{SelectedInvoice.Invoice.Date.Month}";
          basePath = Path.Combine(basePath, date);
          if (Directory.Exists(basePath))
            System.Diagnostics.Process.Start(basePath);
          else
            MessageBox.Show("La cartella non esiste ancora stampare prima la fattura");
        }
      }
      else if(e.ColumnIndex == 8) //dettagli
      {
        OpenInvoice?.Invoke(this, e);
      }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      SetFilters();
      GetInvoices();
      DrawVisits();
    }
  }

  public class InvoiceTitle
  {
    private string _title;
    private string _sortTitle;
    public InvoiceTitle(string title)
    {
      _title = title;
      var temp = title.Split('/').ToList();
      if (temp.Count >= 2)
      {
        _sortTitle = temp[1] + temp[0];
      }
      else
      {
        _sortTitle = title;
      }
    }
    public override bool Equals(object obj)
    {
      var item = obj as InvoiceTitle;

      if (item == null)
      {
        return false;
      }

      return this._sortTitle.Equals(item._sortTitle);
    }
    public override int GetHashCode()
    {
      return this._sortTitle.GetHashCode();
    }
    public override string ToString()
    {
      return _title;
    }
  }

}
