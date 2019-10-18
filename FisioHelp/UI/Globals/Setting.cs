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
        textBoxCf.Text = _therapist.FiscalCode;
        textBoxIban.Text = _therapist.Iban;
        textBoxPiva.Text = _therapist.TaxNumber;
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
        _therapist.FiscalCode = textBoxCf.Text;
        _therapist.Iban = textBoxIban.Text;
        _therapist.TaxNumber = textBoxPiva.Text;
        _therapist.Address = textBoxAddress.Text;

        if (_therapist.Id != null)
          db.Update(_therapist);
        else
          _therapist.Id = Guid.Parse(db.InsertWithIdentity(_therapist).ToString());

        foreach (var a in priceListBindingSource)
        {
          var price = (PriceList)a;
          price.TherapistId = _therapist.Id;
          price.SaveToDB();
          _priceLists.Add(price);

        }
        foreach (var t in treatmentBindingSource)
        {
          var treatment = (Treatment)t;
          treatment.TherapistId = _therapist.Id;
          treatment.SaveToDB();
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
