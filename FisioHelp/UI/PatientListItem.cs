using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioHelp.UI
{
  public partial class PatientListItem : UserControl
  {
    public DataModels.Customer Customer { get; set; }
    public event EventHandler UserClicked;

    public PatientListItem( FisioHelp.DataModels.Customer customer)
    {
      InitializeComponent();
      Customer = customer;
      if (customer != null)
        labelName.Text = customer.FullName.ToUpper();
      else
        labelName.Text = "DASHBOARD";
    }

    private void PatientListItem_Click(object sender, EventArgs e)
    {
      UserClicked?.Invoke(this, e);
    }

    private void PatientListItem_Load(object sender, EventArgs e)
    {

    }

    private void labelName_Click(object sender, EventArgs e)
    {
      UserClicked?.Invoke(this, e) ;
    }
  }
}
