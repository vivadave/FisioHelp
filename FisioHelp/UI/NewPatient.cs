using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioHelp.UI
{
  public partial class NewPatient : Form
  {
    public event EventHandler PatientSaved;
    public NewPatient()
    {
      InitializeComponent();
    }

    private void PatientSave(object sender, EventArgs e)
    {
      PatientSaved?.Invoke(this, e);
    }

    private void Close(object sender, EventArgs e)
    {
      this.Close();
    }

    private void NewPatient_Load(object sender, EventArgs e)
    {
      var patientControl = new AddPatient(new DataModels.Customer());
      patientControl.PatientSaved += PatientSave;
      patientControl.Close += Close;
      patientControl.Dock = System.Windows.Forms.DockStyle.Fill;
      panel1.Controls.Add(patientControl);
    }
  }
}
