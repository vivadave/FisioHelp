namespace FisioHelp.UI.Anamesys
{
  partial class Anamnesys
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anamnesys));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageAnaRecent = new System.Windows.Forms.TabPage();
      this.tabPageAnaRemota = new System.Windows.Forms.TabPage();
      this.tabPageStomato = new System.Windows.Forms.TabPage();
      this.buttonSave = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPageAnaRecent);
      this.tabControl1.Controls.Add(this.tabPageAnaRemota);
      this.tabControl1.Controls.Add(this.tabPageStomato);
      this.tabControl1.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.tabControl1.Location = new System.Drawing.Point(-1, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1368, 658);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPageAnaRecent
      // 
      this.tabPageAnaRecent.AutoScroll = true;
      this.tabPageAnaRecent.AutoScrollMinSize = new System.Drawing.Size(0, 100);
      this.tabPageAnaRecent.Location = new System.Drawing.Point(4, 26);
      this.tabPageAnaRecent.Name = "tabPageAnaRecent";
      this.tabPageAnaRecent.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageAnaRecent.Size = new System.Drawing.Size(1360, 628);
      this.tabPageAnaRecent.TabIndex = 0;
      this.tabPageAnaRecent.Text = "Anamnesi Recente";
      this.tabPageAnaRecent.UseVisualStyleBackColor = true;
      // 
      // tabPageAnaRemota
      // 
      this.tabPageAnaRemota.AutoScroll = true;
      this.tabPageAnaRemota.Location = new System.Drawing.Point(4, 26);
      this.tabPageAnaRemota.Name = "tabPageAnaRemota";
      this.tabPageAnaRemota.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageAnaRemota.Size = new System.Drawing.Size(1132, 428);
      this.tabPageAnaRemota.TabIndex = 1;
      this.tabPageAnaRemota.Text = "Anamnesi Remota";
      this.tabPageAnaRemota.UseVisualStyleBackColor = true;
      // 
      // tabPageStomato
      // 
      this.tabPageStomato.AutoScroll = true;
      this.tabPageStomato.Location = new System.Drawing.Point(4, 26);
      this.tabPageStomato.Name = "tabPageStomato";
      this.tabPageStomato.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageStomato.Size = new System.Drawing.Size(1132, 428);
      this.tabPageStomato.TabIndex = 2;
      this.tabPageStomato.Text = "Stomatognathic Test";
      this.tabPageStomato.UseVisualStyleBackColor = true;
      this.tabPageStomato.Click += new System.EventHandler(this.tabPage1_Click);
      // 
      // buttonSave
      // 
      this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSave.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.ForeColor = System.Drawing.Color.White;
      this.buttonSave.Location = new System.Drawing.Point(1249, 664);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(106, 38);
      this.buttonSave.TabIndex = 27;
      this.buttonSave.Text = "Save";
      this.buttonSave.UseVisualStyleBackColor = false;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // Anamnesys
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(1367, 714);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.tabControl1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Anamnesys";
      this.Text = "Schede valutazione";
      this.Load += new System.EventHandler(this.Anamnesys_Load);
      this.ResizeEnd += new System.EventHandler(this.Anamnesys_ResizeEnd);
      this.tabControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageAnaRecent;
    private System.Windows.Forms.TabPage tabPageAnaRemota;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.TabPage tabPageStomato;
  }
}