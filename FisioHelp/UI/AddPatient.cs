using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using NpgsqlTypes;
using System.Threading.Tasks;
using System.Windows.Forms;
using FisioHelp.DataModels;
using LinqToDB;

namespace FisioHelp.UI
{
  public partial class AddPatient : UserControl
  {
    public event EventHandler PatientSaved;
    public event EventHandler Close;
    private FisioHelp.DataModels.Customer _customer;
    private PriceList[] _priceList;
    private Therapist _therapist;

    private void Initialize()
    {
      InitializeComponent();
      comboBoxLanguage.Items.Add("italian");
      comboBoxLanguage.Items.Add("german");

      using (var db = new Db.PhisioDB())
      {
        _priceList = db.PriceLists.ToArray();
        _therapist = db.Therapists.FirstOrDefault();
      }

    }

    public AddPatient()
    {
      Initialize();
    }

    public AddPatient(Customer customer)
    {
      Initialize();

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
      checkBox1.Checked = _customer.Privacy;

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
      _customer.CreationDate = NpgsqlDate.Now;
      _customer.Privacy = checkBox1.Checked;

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
          
          if (_customer.Id > 0)
          {
            MessageBox.Show("Utente salvato correttamente");
            PatientSaved?.Invoke(this, e);
          }
          else
          {
            MessageBox.Show("Si è verificato un errore");
          }
        }
      }
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

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      Close?.Invoke(this, e);
    }

    private void buttonOpenPrivacy_Click(object sender, EventArgs e)
    {
      if (_customer.Id <= 0)
      {
        MessageBox.Show("Prima di proseguire salvare il cliente");
        return;
      }

      if (string.IsNullOrEmpty(_customer.Language))
      {
        MessageBox.Show("Prima di proseguire scegliere una lingua e salvare");
        return;
      }
      var privacyPath = _therapist.PrivacyFolder;
      if (string.IsNullOrEmpty(privacyPath))
      {
        MessageBox.Show("Prima di proseguire impostare la cartella dei documenti privacy");
        return;
      }
      var folder = $"{_customer.Id.ToString("0000")}_{_customer.FullName.Replace(" ", "_")}";
      var path = Path.Combine(privacyPath, folder);
      Directory.CreateDirectory(path);
      var files = Directory.GetFiles(path);
      if (files.Length == 0)
      {
        var privacyOutPath = "";
        if (_customer.Language == "german")
        {
          privacyOutPath = Path.Combine(path, "privacy_de.pdf");
          File.Copy(@"Template\privacy_de.pdf", privacyOutPath);
        }
        else
        {
          privacyOutPath = Path.Combine(path, "privacy_it.pdf");
          File.Copy(@"Template\privacy_it.pdf", privacyOutPath);
        }
        System.Diagnostics.Process.Start(privacyOutPath);
      }
      else
      {
        var privacyOutPath = files.First();
        System.Diagnostics.Process.Start(privacyOutPath);
      }

    }
  }
}
