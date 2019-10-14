namespace FisioHelp.UI.Anamesys
{
  partial class StomatognathicPalpationRow
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.labelText = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.comboBox2);
      this.panel2.Location = new System.Drawing.Point(579, -3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(129, 36);
      this.panel2.TabIndex = 11;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.comboBox1);
      this.panel1.Location = new System.Drawing.Point(392, -3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(129, 36);
      this.panel1.TabIndex = 10;
      // 
      // labelText
      // 
      this.labelText.AutoSize = true;
      this.labelText.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelText.Location = new System.Drawing.Point(24, 6);
      this.labelText.Name = "labelText";
      this.labelText.Size = new System.Drawing.Size(315, 17);
      this.labelText.TabIndex = 9;
      this.labelText.Text = "M.latissimus dorsi ( im Stehen. in Ruheschwebelage )";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.label1.Location = new System.Drawing.Point(0, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(731, 1);
      this.label1.TabIndex = 12;
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(5, 8);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 21);
      this.comboBox1.TabIndex = 0;
      // 
      // comboBox2
      // 
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new System.Drawing.Point(4, 8);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new System.Drawing.Size(121, 21);
      this.comboBox2.TabIndex = 1;
      // 
      // StomatognathicRow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.labelText);
      this.Name = "StomatognathicRow";
      this.Size = new System.Drawing.Size(730, 30);
      this.Load += new System.EventHandler(this.stomatognathicRow_Load);
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label labelText;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.ComboBox comboBox1;
  }
}
