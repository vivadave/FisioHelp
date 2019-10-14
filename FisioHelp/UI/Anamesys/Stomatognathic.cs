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

namespace FisioHelp.UI.Anamesys
{
  public partial class Stomatognathic : UserControl
  {
    private string[] parameters1 = new string[] { "LastissimusDors1", "LastissimusDors2",
      "LastissimusDors3", "LastissimusDors3", "LastissimusDors5",
      "NeckFlex", "NeckExtflex", "Sterncleid", "Rectfem", "Pirif", "Iliopsoas"};

    private Customer _customer;
    public StomatognathicTest StomatognathicTest { get; set; }

    public Stomatognathic( Customer customer)
    {
      _customer = customer;
      using (var db = new Db.PhisioDB())
      {
        StomatognathicTest = db.StomatognathicTests.FirstOrDefault(ra => ra.CustomerId == customer.Id);
      }

      if (StomatognathicTest == null)
        StomatognathicTest = new StomatognathicTest();

      InitializeComponent();
    }

    private void Stomatognathic_Load(object sender, EventArgs e)
    {
      var yPos = 0;
      foreach ( var parameter in parameters1)
      {
        var stomatomatognaticRow = new StomatognathicRow(StomatognathicTest, parameter, parameter);
        stomatomatognaticRow.Location = new Point(0, yPos);
        yPos += 30;
        panel6.Controls.Add(stomatomatognaticRow);
      }

      checkBoxCat1Err.Checked = StomatognathicTest.Cat1Err ?? false;
      textBoxCat1ErrPos.Text = StomatognathicTest.Cat1ErrPos;
      SetRadioButton(new RadioButton[] { radioButtonCat2PosR1, radioButtonCat2PosR2 }, StomatognathicTest.Cat2ErrR ?? 0);
      SetRadioButton(new RadioButton[] { radioButtonCat2PosL1, radioButtonCat2PosL2 }, StomatognathicTest.Cat2ErrL ?? 0);

      textBoxIndicator.Text = StomatognathicTest.Inicator;

      SetRadioButton(new RadioButton[] { radioButtonTlOkzi1, radioButtonTlOkzi2, radioButtonTlOkzi3 }, StomatognathicTest.TlOkziput ?? 0);
      SetRadioButton(new RadioButton[] { radioButtonDoubleTlCat1, radioButtonDoubleTlCat2 }, StomatognathicTest.DoubleTlCat ?? 0);
      SetRadioButton(new RadioButton[] { radioButtonDoubleTlOkz1, radioButtonDoubleTlOkz2 }, StomatognathicTest.DoubleTlOkz ?? 0);

      textBoxRuheschwebeR.Text = StomatognathicTest.RuheschwebeR;
      textBoxRuheschwebeL.Text = StomatognathicTest.RuheschwebeL;
      textBoxFesterR.Text = StomatognathicTest.FesterR;
      textBoxFesterL.Text = StomatognathicTest.FesterL;
      textBoxWeiteOffR.Text = StomatognathicTest.WeiteOffR;
      textBoxWeiteOffL.Text = StomatognathicTest.WeiteOffL;
    }

    public void SetStomatognathicTest()
    {
      foreach( var control in panel6.Controls)
      {
        var ctrl = (StomatognathicRow)control;
        var stTemp = StomatognathicTest;
        ctrl.SetValues(ref stTemp);
        StomatognathicTest = stTemp;
      }

      StomatognathicTest.Cat1Err = checkBoxCat1Err.Checked;
      StomatognathicTest.Cat1ErrPos = textBoxCat1ErrPos.Text;
      GetRadioButtonValues(new RadioButton[] { radioButtonCat2PosR1, radioButtonCat2PosR2 });
      GetRadioButtonValues(new RadioButton[] { radioButtonCat2PosL1, radioButtonCat2PosL2 });

      textBoxIndicator.Text = StomatognathicTest.Inicator;

      GetRadioButtonValues(new RadioButton[] { radioButtonTlOkzi1, radioButtonTlOkzi2, radioButtonTlOkzi3 });
      GetRadioButtonValues(new RadioButton[] { radioButtonDoubleTlCat1, radioButtonDoubleTlCat2 });
      GetRadioButtonValues(new RadioButton[] { radioButtonDoubleTlOkz1, radioButtonDoubleTlOkz2 });

      StomatognathicTest.RuheschwebeR = textBoxRuheschwebeR.Text;
      StomatognathicTest.RuheschwebeL = textBoxRuheschwebeL.Text;
      StomatognathicTest.FesterR = textBoxFesterR.Text;
      StomatognathicTest.FesterL = textBoxFesterL.Text;
      StomatognathicTest.WeiteOffR = textBoxWeiteOffR.Text;
      StomatognathicTest.WeiteOffL = textBoxWeiteOffL.Text;
    }

    public void SetRadioButton(RadioButton[] radiobuttons, int value)
    {
      for (int i = 0; i < radiobuttons.Length; i++)
        radiobuttons[i].Checked = value == i + 1;
    }

    public int GetRadioButtonValues(RadioButton[] radiobuttons)
    {
      int value = 0;
      for (int i = 0; i < radiobuttons.Length; i++)
      {
        if (radiobuttons[i].Checked)
          value = i + 1;
      }
      return value;
    }
  }

}
