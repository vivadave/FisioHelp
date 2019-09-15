namespace FisioHelp.UI.Globals
{
  partial class RichText
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
      this.panel3 = new System.Windows.Forms.Panel();
      this.textBoxBegin = new System.Windows.Forms.RichTextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel2.Controls.Add(this.panel3);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Location = new System.Drawing.Point(0, 3);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(433, 171);
      this.panel2.TabIndex = 22;
      this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.textBoxBegin);
      this.panel3.Location = new System.Drawing.Point(6, 19);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(424, 149);
      this.panel3.TabIndex = 22;
      // 
      // textBoxBegin
      // 
      this.textBoxBegin.BackColor = System.Drawing.Color.White;
      this.textBoxBegin.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBoxBegin.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBoxBegin.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxBegin.Location = new System.Drawing.Point(0, 0);
      this.textBoxBegin.Name = "textBoxBegin";
      this.textBoxBegin.ReadOnly = true;
      this.textBoxBegin.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      this.textBoxBegin.Size = new System.Drawing.Size(422, 147);
      this.textBoxBegin.TabIndex = 20;
      this.textBoxBegin.Text = "";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 15);
      this.label2.TabIndex = 21;
      this.label2.Text = "Inizio";
      // 
      // RichText
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel2);
      this.Name = "RichText";
      this.Size = new System.Drawing.Size(436, 177);
      this.Load += new System.EventHandler(this.RichText_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.RichTextBox textBoxBegin;
    private System.Windows.Forms.Label label2;
  }
}
