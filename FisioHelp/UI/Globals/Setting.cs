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
    private Therapist _therapist;

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
        _therapist = db.Therapists.FirstOrDefault();
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

      if (_therapist != null)
      {
        textBoxName.Text = _therapist.FullName;
        textBoxEmail.Text = _therapist.Email;
        textBoxCf.Text = _therapist.Fiscalcode;
        textBoxIban.Text = _therapist.Iban;
        textBoxPiva.Text = _therapist.Vat;
        textBoxAddress.Text = _therapist.Address;
      } else
        _therapist = new Therapist();
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      _priceLists.Clear();
      _treatMentLists.Clear();

      using (var db = new Db.PhisioDB())
      {
        
        _therapist.FullName = textBoxName.Text;
        _therapist.Email = textBoxEmail.Text;
        _therapist.Fiscalcode = textBoxCf.Text;
        _therapist.Iban = textBoxIban.Text;
        _therapist.Vat = textBoxPiva.Text;
        _therapist.Address = textBoxAddress.Text;

        if (_therapist.Id > 0)
          db.Update(_therapist);
        else
          _therapist.Id = db.InsertWithInt32Identity(_therapist);

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

    private void pricelis_Enter(object sender, EventArgs e)
    {

    }
  }
}
