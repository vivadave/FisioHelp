namespace FisioHelp.UI
{
  partial class PatientListItem
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
      this.labelName = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelName.ForeColor = System.Drawing.Color.Black;
      this.labelName.Location = new System.Drawing.Point(19, 18);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(50, 20);
      this.labelName.TabIndex = 0;
      this.labelName.Text = "label1";
      this.labelName.Click += new System.EventHandler(this.labelName_Click);
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(142)))));
      this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.label1.Location = new System.Drawing.Point(0, 60);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(244, 2);
      this.label1.TabIndex = 1;
      // 
      // PatientListItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.labelName);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.Name = "PatientListItem";
      this.Size = new System.Drawing.Size(244, 62);
      this.Load += new System.EventHandler(this.PatientListItem_Load);
      this.Click += new System.EventHandler(this.PatientListItem_Click);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label label1;
  }
}
