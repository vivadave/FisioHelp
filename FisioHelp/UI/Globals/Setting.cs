using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using LinqToDB;
using System.Windows.Forms;
using FisioHelp.DataModels;

namespace FisioHelp.UI.Globals
{
  public partial class Setting : Form
  {
    private List<PriceList> _priceLists;
    private List<Treatment> _treatMentLists;

    public Setting()
    {
      InitializeComponent();
    }

    private void Setting_Load(object sender, EventArgs e)
    {
      using (var db = new Db.PhisioDB())
      {
        _priceLists = db.PriceLists.ToList();
        _treatMentLists = db.Treatments.ToList();
      }
      FillDataBindings();
    }

    private void FillDataBindings()
    {
      priceListBindingSource.Clear();
      treatmentBindingSource.Clear();

      foreach (var price in _priceLists)
        priceListBindingSource.Add(price);

      foreach (var treatment in _treatMentLists)
        treatmentBindingSource.Add(treatment);
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      _priceLists.Clear();
      _treatMentLists.Clear();

      using (var db = new Db.PhisioDB())
      {
        foreach (var a in priceListBindingSource)
        {
          var price = (PriceList)a;
          if (price.Id > 0)
            db.Update(price);
          else
            price.Id = db.InsertWithInt32Identity(price);
          _priceLists.Add(price);

        }
        foreach (var t in treatmentBindingSource)
        {
          var treatment = (Treatment)t;
          if (treatment.Id > 0)
            db.Update(treatment);
          else
            treatment.Id = db.InsertWithInt32Identity(treatment);
          _treatMentLists.Add(treatment);
        }

        FillDataBindings();
      }
    }
  }
}
