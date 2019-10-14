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
  public partial class StomatognathicPalpationRow : UserControl
  {
    private StomatognathicTest _stomatognathic;
    private string _param;
    public StomatognathicPalpationRow(StomatognathicTest stomatognathic, string parameter, string description)
    {
      _stomatognathic = stomatognathic;
      _param = parameter;
      InitializeComponent();
      labelText.Text = description;

      comboBox1.Items.AddRange(new string[] { "Nulla", "Missempfinden", "Schmerz" });
      comboBox2.Items.AddRange(new string[] { "Nulla", "Missempfinden", "Schmerz" });
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
        comboBox1.SelectedItem = comboBox1.Items[1];
      else if (valR == 2)
        comboBox1.SelectedItem = comboBox1.Items[2];
      else
        comboBox1.SelectedItem = comboBox1.Items[0];

      if (valL == 1)
        comboBox2.SelectedItem = comboBox2.Items[1];
      else if (valL == 2)
        comboBox2.SelectedItem = comboBox2.Items[2];
      else
        comboBox2.SelectedItem = comboBox2.Items[0];
    }


    public void SetValues(ref StomatognathicTest stomatognathic)
    {
      Type t = _stomatognathic.GetType();
      PropertyInfo[] props = t.GetProperties();
      var paramR = props.FirstOrDefault(p => p.Name == $"{_param}R" || p.Name == $"{_param}r");
      var paramL = props.FirstOrDefault(p => p.Name == $"{_param}L" || p.Name == $"{_param}l");
      var valR = 0;
      var valL = 0;

      if (comboBox1.SelectedItem == comboBox1.Items[1])
        valR = 1;
      else if (comboBox1.SelectedItem == comboBox1.Items[2])
        valR = 2;
      else
        valR = 3;

      if (comboBox2.SelectedItem == comboBox2.Items[1])
        valL = 1;
      else if (comboBox2.SelectedItem == comboBox2.Items[2])
        valL = 2;
      else
        valL = 3;


      paramR.SetValue(stomatognathic, valR);
      paramL.SetValue(stomatognathic, valL);
    }

  }
}
