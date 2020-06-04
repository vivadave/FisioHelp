namespace FisioHelp
{
  partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.buttonVisits = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.panel4 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.textBoxFilter = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.splitContainer1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 450);
      this.panel1.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.panel3.Controls.Add(this.buttonVisits);
      this.panel3.Controls.Add(this.button3);
      this.panel3.Controls.Add(this.button2);
      this.panel3.Controls.Add(this.button1);
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(800, 39);
      this.panel3.TabIndex = 2;
      // 
      // buttonVisits
      // 
      this.buttonVisits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonVisits.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.buttonVisits.ForeColor = System.Drawing.Color.White;
      this.buttonVisits.Location = new System.Drawing.Point(319, 3);
      this.buttonVisits.Name = "buttonVisits";
      this.buttonVisits.Size = new System.Drawing.Size(152, 33);
      this.buttonVisits.TabIndex = 3;
      this.buttonVisits.Text = "VISITE";
      this.buttonVisits.UseVisualStyleBackColor = false;
      this.buttonVisits.Click += new System.EventHandler(this.buttonVisits_Click);
      // 
      // button3
      // 
      this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button3.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.button3.ForeColor = System.Drawing.Color.White;
      this.button3.Location = new System.Drawing.Point(645, 3);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(152, 33);
      this.button3.TabIndex = 2;
      this.button3.Text = "IMPOSTAZIONI";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.button2.ForeColor = System.Drawing.Color.White;
      this.button2.Location = new System.Drawing.Point(161, 3);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(152, 33);
      this.button2.TabIndex = 1;
      this.button2.Text = "FATTURE";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.button1.ForeColor = System.Drawing.Color.White;
      this.button1.Location = new System.Drawing.Point(3, 3);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(152, 33);
      this.button1.TabIndex = 0;
      this.button1.Text = "NUOVO PAZIENTE";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.splitContainer1.Location = new System.Drawing.Point(0, 41);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
      this.splitContainer1.Panel1.Controls.Add(this.panel4);
      this.splitContainer1.Panel1.Controls.Add(this.textBoxFilter);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.AutoScroll = true;
      this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
      this.splitContainer1.Size = new System.Drawing.Size(800, 409);
      this.splitContainer1.SplitterDistance = 120;
      this.splitContainer1.TabIndex = 1;
      // 
      // panel4
      // 
      this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel4.AutoScroll = true;
      this.panel4.BackColor = System.Drawing.Color.LightGray;
      this.panel4.Controls.Add(this.panel2);
      this.panel4.Location = new System.Drawing.Point(3, 27);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(114, 378);
      this.panel4.TabIndex = 1;
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel2.AutoScroll = true;
      this.panel2.BackColor = System.Drawing.Color.Transparent;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(114, 129);
      this.panel2.TabIndex = 0;
      // 
      // textBoxFilter
      // 
      this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxFilter.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxFilter.ImeMode = System.Windows.Forms.ImeMode.Off;
      this.textBoxFilter.Location = new System.Drawing.Point(3, 0);
      this.textBoxFilter.Name = "textBoxFilter";
      this.textBoxFilter.Size = new System.Drawing.Size(114, 27);
      this.textBoxFilter.TabIndex = 38;
      this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.panel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Gestione visite";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.panel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox textBoxFilter;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonVisits;
    }
}

