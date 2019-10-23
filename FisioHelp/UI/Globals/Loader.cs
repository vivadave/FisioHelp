using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioHelp.UI.Globals
{
  public partial class Loader : Form
  {
    public Loader(string text)
    {
      InitializeComponent();
      label1.Text = text;
    }
    
    private void label1_Click(object sender, EventArgs e)
    {

    }
  }
}
