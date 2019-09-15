namespace FisioHelp.UI
{
  partial class InvoiceListItem
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceListItem));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label1.Location = new System.Drawing.Point(38, 50);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label2.Location = new System.Drawing.Point(181, 50);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "label2";
      // 
      // checkBox2
      // 
      this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.checkBox2.AutoSize = true;
      this.checkBox2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.checkBox2.Location = new System.Drawing.Point(570, 46);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(104, 24);
      this.checkBox2.TabIndex = 3;
      this.checkBox2.Text = "Pagamento";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
      this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.BackColor = System.Drawing.Color.Transparent;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
      this.button1.Location = new System.Drawing.Point(722, 31);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(58, 59);
      this.button1.TabIndex = 4;
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label3.Location = new System.Drawing.Point(-3, 118);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(806, 2);
      this.label3.TabIndex = 5;
      this.label3.Text = "label3";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label5.Location = new System.Drawing.Point(423, 50);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(50, 20);
      this.label5.TabIndex = 7;
      this.label5.Text = "label5";
      // 
      // InvoiceListItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.checkBox2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "InvoiceListItem";
      this.Size = new System.Drawing.Size(802, 120);
      this.Load += new System.EventHandler(this.VisitEconomicCtrl_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
  }
}
