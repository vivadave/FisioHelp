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
      this.labelTitle = new System.Windows.Forms.Label();
      this.labelName = new System.Windows.Forms.Label();
      this.labelInvoice = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label1.Location = new System.Drawing.Point(38, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "labelDate";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label2.Location = new System.Drawing.Point(539, 30);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "labelVisitNr";
      // 
      // checkBox2
      // 
      this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.checkBox2.AutoSize = true;
      this.checkBox2.Enabled = false;
      this.checkBox2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.checkBox2.Location = new System.Drawing.Point(814, 34);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(15, 14);
      this.checkBox2.TabIndex = 3;
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
      this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.BackColor = System.Drawing.Color.Transparent;
      this.button1.FlatAppearance.BorderSize = 0;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
      this.button1.Location = new System.Drawing.Point(866, 12);
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
      this.label3.Location = new System.Drawing.Point(-3, 80);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(949, 2);
      this.label3.TabIndex = 5;
      this.label3.Text = "label3";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label5.Location = new System.Drawing.Point(711, 30);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(74, 20);
      this.label5.TabIndex = 7;
      this.label5.Text = "labelPrice";
      // 
      // labelTitle
      // 
      this.labelTitle.AutoSize = true;
      this.labelTitle.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTitle.Location = new System.Drawing.Point(266, 30);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(71, 20);
      this.labelTitle.TabIndex = 8;
      this.labelTitle.Text = "labelTitle";
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelName.Location = new System.Drawing.Point(394, 30);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(82, 20);
      this.labelName.TabIndex = 9;
      this.labelName.Text = "labelName";
      // 
      // labelInvoice
      // 
      this.labelInvoice.AutoSize = true;
      this.labelInvoice.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelInvoice.Location = new System.Drawing.Point(150, 30);
      this.labelInvoice.Name = "labelInvoice";
      this.labelInvoice.Size = new System.Drawing.Size(101, 20);
      this.labelInvoice.TabIndex = 10;
      this.labelInvoice.Text = "labelInvoice";
      // 
      // InvoiceListItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.labelInvoice);
      this.Controls.Add(this.labelName);
      this.Controls.Add(this.labelTitle);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.checkBox2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "InvoiceListItem";
      this.Size = new System.Drawing.Size(945, 82);
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
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelInvoice;
  }
}
