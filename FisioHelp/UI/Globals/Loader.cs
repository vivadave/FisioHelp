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
  using Helper;

  public partial class Loader : Form
  {
    private GifImage gifImage = null;
    public Loader(string text)
    {
      InitializeComponent();
      label1.Text = text;
      gifImage = new GifImage(@"Template/loader.gif");
      gifImage.ReverseAtEnd = false; //dont reverse at end
      timer1.Enabled = true;
    }
    
    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      pictureBox.Image = gifImage.GetNextFrame();
    }

    private void Loader_FormClosing(object sender, FormClosingEventArgs e)
    {
      timer1.Dispose();
    }
  }
}
