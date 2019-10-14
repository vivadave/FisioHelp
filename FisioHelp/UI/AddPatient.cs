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
using LinqToDB;

namespace FisioHelp.UI
{
  public partial class AddPatient : UserControl
  {
    public event EventHandler PatientSaved;
    private FisioHelp.DataModels.Customer _customer;
    private PriceList[] _priceList;

    public AddPatient()
    {
      InitializeComponent();
      comboBoxLanguage.Items.Add("italian");
      comboBoxLanguage.Items.Add("german");
    }

    public AddPatient(Customer customer)
    {
      InitializeComponent();
      comboBoxLanguage.Items.Add("italian");
      comboBoxLanguage.Items.Add("german");

      using (var db = new Db.PhisioDB())
      {
        _priceList = db.PriceLists.ToArray();
      }

        _customer = customer;

      textBoxName.Text = customer.Name;
      textBoxCognome.Text = customer.Surname;
      textBoxEmail.Text = customer.Email;
      richTextBoxEx1.Text = customer.Note;
      textBoxTel1.Text = customer.Tel1;
      textBoxTel2.Text = customer.Tel2;
      textBoxFiscalCode.Text = customer.Fiscalcode;
      textBoxVat.Text = customer.Vat;
      comboBoxLanguage.SelectedItem = customer.Language;
      comboBoxPrices.Items.AddRange(_priceList);
      comboBoxPrices.SelectedItem = _priceList.FirstOrDefault(p => p.Id == customer.Pricelist?.Id);
      if (customer.Address != null)
      {
        textBoxIndirizzo.Text = customer.Address.Address_Column;
        textBoxCity.Text = customer.Address.City;
        textBoxPostalCode.Text = customer.Address.Cap;
      }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void AddPatient_Load(object sender, EventArgs e)
    {
      buttonSave.Enabled = false;
      this.ValidateChildren();
    }

    private void SetCustomer()
    {
      _customer.Name = textBoxName.Text;
      _customer.Surname = textBoxCognome.Text;
      _customer.Email = textBoxEmail.Text;
      _customer.Note = richTextBoxEx1.Text;
      _customer.Tel1 = textBoxTel1.Text;
      _customer.Tel2 = textBoxTel2.Text;
      _customer.Fiscalcode = textBoxFiscalCode.Text;
      _customer.Vat = textBoxVat.Text;
      if (comboBoxLanguage.SelectedItem != null)
        _customer.Language = comboBoxLanguage.SelectedItem.ToString();

      if (_customer.Address != null)
      {
        _customer.Address.Address_Column = textBoxIndirizzo.Text;
        _customer.Address.City = textBoxCity.Text;
        _customer.Address.Cap = textBoxPostalCode.Text;
      } else
      {
        _customer.Address = new Address
        {
          Address_Column = textBoxIndirizzo.Text,
          City = textBoxCity.Text,
          Cap = textBoxPostalCode.Text
        };
      }

      if (comboBoxPrices.SelectedItem != null)
      {
        _customer.Pricelist = (PriceList)comboBoxPrices.SelectedItem;
        _customer.PricelistId = ((PriceList)comboBoxPrices.SelectedItem).Id;
      }
      
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      
      SetCustomer();
      if (_customer.Id > 0)
      {
        using (var db = new Db.PhisioDB())
        {
          if (_customer.Address != null && _customer.Address.Id > 0)
          {
            db.Update(_customer.Address);
          }
          else if (_customer.Address != null)
          { 
            _customer.Address.Id = db.InsertWithInt32Identity(_customer.Address);
            _customer.AddressId = _customer.Address.Id;
          }

          db.Update(_customer);
        }
      }
      else
      {
        using (var db = new Db.PhisioDB())
        {
          if (_customer.Address != null)
          {
            _customer.Address.Id = db.InsertWithInt32Identity(_customer.Address);
            _customer.AddressId = _customer.Address.Id;
          }
          _customer.Id = db.InsertWithInt32Identity(_customer);          
        }
      }

      PatientSaved?.Invoke(this, e);
    }

    private void textBoxName_Validating(object sender, CancelEventArgs e)
    {
      if (textBoxName.Text.Length <= 0)
      {
        errorProvider1.SetError(textBoxName, "Il campo nome è obbligatorio");
        buttonSave.Enabled = false;
        return;
      }
      buttonSave.Enabled = true;
    }

    private void textBoxCognome_Validating(object sender, CancelEventArgs e)
    {
      if (textBoxCognome.Text.Length <= 0)
      {
        errorProvider1.SetError(textBoxCognome, "Il campo cognome è obbligatorio");
        buttonSave.Enabled = false;
        return;
      }
      buttonSave.Enabled = true;
    }

    private void textBoxEmail_Validating(object sender, CancelEventArgs e)
    {
      if (textBoxEmail.Text.Length <= 0)
      {
        errorProvider1.SetError(textBoxEmail, "Il campo email è obbligatorio");
        buttonSave.Enabled = false;
        return;
      }
      buttonSave.Enabled = true;
    }

    private void textBoxVat_Validating(object sender, CancelEventArgs e)
    {
    }

    private void textBoxFiscalCode_Validating(object sender, CancelEventArgs e)
    {
    }

    private void comboBoxLanguage_Resize(object sender, EventArgs e)
    {
      this.BeginInvoke(new Action(() => { comboBoxLanguage.Select(0, 0); }));
    }

    private void comboBoxPrices_Resize(object sender, EventArgs e)
    {
      this.BeginInvoke(new Action(() => { comboBoxPrices.Select(0, 0); }));
    }
  }
}
