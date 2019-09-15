using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisioHelp.UI.Globals
{
  public partial class RichText : UserControl
  {
    public string Title { get; set; }
    public string Text { get; set; }
    public bool ReadOnly { get; set; }
    public RichText()
    {
      InitializeComponent();
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {

    }

    private void RichText_Load(object sender, EventArgs e)
    {
      label2.Text = Title;
      textBoxBegin.Text = Text;
      textBoxBegin.ReadOnly = ReadOnly;
    }
  }
}
