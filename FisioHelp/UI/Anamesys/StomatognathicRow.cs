using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using FisioHelp.DataModels;

namespace FisioHelp.UI.Anamesys
{
  public partial class StomatognathicRow : UserControl
  {
    private StomatognathicTest _stomatognathic;
    private string _param;
    public StomatognathicRow(StomatognathicTest stomatognathic, string parameter, string description)
    {
      _stomatognathic = stomatognathic;
      _param = parameter;
      InitializeComponent();
      labelText.Text = description;
    }

    private void stomatognathicRow_Load(object sender, EventArgs e)
    {
      Type t = _stomatognathic.GetType();
      PropertyInfo[] props = t.GetProperties();
      var paramR = props.FirstOrDefault(p => p.Name == $"{_param}R" || p.Name == $"{_param}r");
      var paramL = props.FirstOrDefault(p => p.Name == $"{_param}L" || p.Name == $"{_param}l");
      var valR = paramR.GetValue(_stomatognathic) == null ? 0 : (int)paramR.GetValue(_stomatognathic);
      var valL = paramL.GetValue(_stomatognathic) == null ? 0 : (int)paramL.GetValue(_stomatognathic);

      if (valR == 1)
        radioButtonR1.Checked = true;
      else if (valR == 2)
        radioButtonR2.Checked = true;
      else if (valR == 3)
        radioButtonR3.Checked = true;

      if (valL == 1)
        radioButtonL1.Checked = true;
      else if (valL == 2)
        radioButtonL2.Checked = true;
      else if (valL == 3)
        radioButtonL3.Checked = true;
    }


    public void SetValues(ref StomatognathicTest stomatognathic)
    {
      Type t = _stomatognathic.GetType();
      PropertyInfo[] props = t.GetProperties();
      var paramR = props.FirstOrDefault(p => p.Name == $"{_param}R" || p.Name == $"{_param}r");
      var paramL = props.FirstOrDefault(p => p.Name == $"{_param}L" || p.Name == $"{_param}l");
      var valR = 0;
      var valL = 0;

      if (radioButtonR1.Checked)
        valR = 1;
      else if (radioButtonR2.Checked)
        valR = 2;
      else if (radioButtonR3.Checked)
        valR = 3;

      if (radioButtonL1.Checked)
        valL = 1;
      else if (radioButtonL2.Checked)
        valL = 2;
      else if (radioButtonL3.Checked)
        valL = 3;


      paramR.SetValue(stomatognathic, valR);
      paramL.SetValue(stomatognathic, valL);
    }

  }
}
