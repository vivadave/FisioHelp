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

namespace FisioHelp.UI
{
  public partial class SinglePatientMain : UserControl
  {
    private Customer _customer;
    public SinglePatientMain(Customer customer)
    {
      InitializeComponent();
      _customer = customer;
      labelName.Text = $"{customer.Name} {customer.Surname}".ToUpper();
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.panel3.Controls.Clear();
      var userForm = new UI.AddPatient(_customer);
      userForm.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Controls.Add(userForm);
    }
  }
}
