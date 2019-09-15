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
  public partial class VisitMedicalCtrl : UserControl
  {
    public event EventHandler OpenVisit;
    public DataModels.Visit Visit { get; set; }
    public VisitMedicalCtrl(DataModels.Visit visit)
    {
      InitializeComponent();
      this.Visit = visit;
    }

    private void VisitEconomicCtrl_Load(object sender, EventArgs e)
    {
      if (Visit == null) return;

      label1.Text = ((DateTime)Visit.Date).ToShortDateString();
      textBoxBegin.Rtf = @"{\rtf1\ " + Visit.InitialEvaluetion + " }"; 
      textBoxEnd.Rtf = @"{\rtf1\ " + Visit.FinalEvaluetion + " }";
    }

    private void button1_Click(object sender, EventArgs e)
    {
      OpenVisit?.Invoke(this, e);
    }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void textBoxBegin_ContentsResized(object sender, ContentsResizedEventArgs e)
    {
      var richTextBox = (RichTextBox)sender;
      this.Height = Math.Min(180, e.NewRectangle.Height + 50);
    }
  }
}
