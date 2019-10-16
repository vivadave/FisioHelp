using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using LinqToDB;
using System.Windows.Forms;

namespace FisioHelp.UI.Dashboard
{
  using DataModels;

  public partial class Dashboard : UserControl
  {
    private List<Visit> _visitPreviousMonth;
    private List<Visit> _visitLatMonth;
    private List<Customer> _customerLastMonth;
    private List<Customer> _customerNoPrivacy;
    private Therapist _therapist;

    public Dashboard()
    {
      InitializeComponent();
    }

    private void Dashboard_Load(object sender, EventArgs e)
    {
      using (var db = new Db.PhisioDB())
      {
        var today = DateTime.Today;
        var todayLstMonth = DateTime.Today.AddMonths(-1);
        _therapist = db.Therapists.FirstOrDefault();
        _visitLatMonth = db.Visits.Where(x => x.Date >= new NpgsqlTypes.NpgsqlDate(today.Year, today.Month, 1)).ToList();
        _customerLastMonth = db.Customers.Where(x => x.CreationDate >= new NpgsqlTypes.NpgsqlDate(today.Year, today.Month, 1)).ToList();
        _visitPreviousMonth = db.Visits.Where(x => x.Date >= new NpgsqlTypes.NpgsqlDate(todayLstMonth.Year, todayLstMonth.Month, 1) && x.Date <= new NpgsqlTypes.NpgsqlDate(today.Year, today.Month, 1)).ToList();
        _customerNoPrivacy = db.Customers.Where(x => x.Privacy == false).ToList();
      }

      FillFields();
    }

    private void FillFields()
    {
      var lastMonthMoney = _visitLatMonth.Sum(x => x.Price);
      var previousMonthMoney = _visitPreviousMonth.Sum(x => x.Price) == 0 ? 1 : _visitPreviousMonth.Sum(x => x.Price);
      richTextBoxExPostit.Rtf = _therapist?.Postit;
      labelCustomers.Text = _customerLastMonth.Count.ToString();
      labelMoney.Text = lastMonthMoney.ToString() + " €";
      labelVariation.Text = ((double)((lastMonthMoney - previousMonthMoney) * 100 / previousMonthMoney)).ToString("#.00") + " %";
      labelVisits.Text = _visitLatMonth.Count().ToString();
      listBox1.DataSource = _customerNoPrivacy;
    }

    private void richTextBoxExPostit_Leave(object sender, EventArgs e)
    {
      _therapist.Postit = richTextBoxExPostit.Rtf;
      using (var db = new Db.PhisioDB())
      {
        db.Update(_therapist);
      }
    }
  }
}
