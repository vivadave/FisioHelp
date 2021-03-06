﻿using System;
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

      if (_customer.Id == null || _customer.Id == Guid.Empty)
      {
        buttonDelete.Visible = false;
      }

      textBoxName.Text = customer.Name;
      textBoxCognome.Text = customer.Surname;
      textBoxEmail.Text = customer.Email;
      richTextBoxEx1.Text = customer.Note;
      textBoxTel1.Text = customer.Tel1;
      textBoxTel2.Text = customer.Tel2;
      textBoxFiscalCode.Text = customer.Fiscalcode;
      textBoxVat.Text = customer.Vat;
      textBoxAge.Text = customer.Age.ToString(); 
      textBoxLegRapp.Text = customer.LegalRepresentative;
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
      textBoxName.Select();
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
      int.TryParse(textBoxAge.Text, out int age);
      _customer.Age = age;
      _customer.LegalRepresentative = textBoxLegRapp.Text;
      _customer.CreationDate = NpgsqlDate.Now;
      _customer.Privacy = checkBox1.Checked;
      _customer.Therapist = _therapist;
      _customer.TherapistId = _therapist.Id;

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
      
      if (_customer.Address != null)
        _customer.AddressId = _customer.Address.SaveToDB();
      _customer.SaveToDB();

      buttonDelete.Visible = true;
      PatientSaved?.Invoke(this, e);
      MessageBox.Show("Salvato Correttamente", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }

    private void textBoxVat_Validating(object sender, CancelEventArgs e)
    {
    }

    private void textBoxFiscalCode_Validating(object sender, CancelEventArgs e)
    {
      if (textBoxFiscalCode.Text.Length <= 0)
      {
        errorProvider1.SetError(textBoxFiscalCode, "Il campo codice fiscale è obbligatorio");
        buttonSave.Enabled = false;
        return;
      }
      buttonSave.Enabled = true;
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
      if (_customer.Id == null || _customer.Id == Guid.Empty)
      {
        MessageBox.Show("Prima di proseguire salvare il cliente", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      if (string.IsNullOrEmpty(_customer.Language))
      {
        MessageBox.Show("Prima di proseguire scegliere una lingua e salvare", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      var privacyPath = _therapist.PrivacyFolder;
      if (string.IsNullOrEmpty(privacyPath))
      {
        MessageBox.Show("Prima di proseguire impostare la cartella dei documenti privacy", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      var html = File.ReadAllText("Template/privacy.html");
      html = Helper.Helper.ReplacePrivacyPlaceHolder(html, _customer);

      var folder = $"{_customer.FullName.Replace(" ", "_")}";
      var path = Path.Combine(privacyPath, folder);
      Directory.CreateDirectory(path);
      var htmlPath = Path.Combine(path, "privacy.html");
      var pdfPath = Path.Combine(path, "privacy.pdf");

      if (!File.Exists(pdfPath))
      {
        try
        {
          File.WriteAllText(htmlPath, html);
          Helper.PdfManager.CreatePdf(pdfPath, htmlPath);
          System.Threading.Thread.Sleep(1000);
        }
        catch (Exception ee)
        {
          MessageBox.Show("Il file è già aperto, chiuderlo", "Stampa", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }

      System.Diagnostics.Process.Start(pdfPath);     

    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (_customer.Id == null || _customer.Id == Guid.Empty)
        return;

      if (MessageBox.Show("Sicura di voler cancellare il cliente?", "Cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      if (MessageBox.Show("Verranno cancellate anche tutte le visite e le anamnesi del paziente, continuo?", "Cancellazione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      using (var db = new Db.PhisioDB())
      {
        var addressId = _customer.AddressId;

        var visits = db.Visits.LoadWith(v => v.Treatmentsvisitidfkeys).LoadWith(x=>x.Invoice).Where(x=> x.CustomerId == _customer.Id ).ToList();
        if (visits.Any(x => x.Invoice != null))
        {
          MessageBox.Show("Non si possono cancellare clienti per cui è stata emessa qualche fattura", "Cancellazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        foreach (var visit in visits)
        {
          foreach (var treaVis in visit.Treatmentsvisitidfkeys)
            db.Delete(treaVis);

          db.Delete(visit);
        }

        var recentAnamnesys = db.RecentAnamnesys.FirstOrDefault(x => x.CustomerId == _customer.Id);
        if (recentAnamnesys != null)
          db.Delete(recentAnamnesys);
        var remoteAnamnesys = db.RemoteAnamnesys.FirstOrDefault(x => x.CustomerId == _customer.Id);
        if (remoteAnamnesys != null)
          db.Delete(remoteAnamnesys);
        var stomatognathicTests = db.StomatognathicTests.FirstOrDefault(x => x.CustomerId == _customer.Id);
        if (stomatognathicTests != null)
          db.Delete(stomatognathicTests);

        db.Delete(_customer);
        var addr = db.Addresses.FirstOrDefault(x => x.Id == addressId);

        if (addr != null)
          db.Delete(addr);

        MessageBox.Show("Paziente Cancellato", "Cancellazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        PatientSaved?.Invoke(this, e);
      }

      }
  }
}
