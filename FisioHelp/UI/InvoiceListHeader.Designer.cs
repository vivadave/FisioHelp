namespace FisioHelp.UI
{
  partial class InvoiceListHeader
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.labelTitle = new System.Windows.Forms.Label();
      this.labelName = new System.Windows.Forms.Label();
      this.labelInvoice = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(38, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(94, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Data Proforma";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(539, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(91, 17);
      this.label2.TabIndex = 1;
      this.label2.Text = "Numero Visite";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label3.Location = new System.Drawing.Point(-3, 37);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(949, 2);
      this.label3.TabIndex = 5;
      this.label3.Text = "label3";
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(711, 10);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(47, 17);
      this.label5.TabIndex = 7;
      this.label5.Text = "Prezzo";
      // 
      // labelTitle
      // 
      this.labelTitle.AutoSize = true;
      this.labelTitle.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTitle.Location = new System.Drawing.Point(266, 10);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(115, 17);
      this.labelTitle.TabIndex = 8;
      this.labelTitle.Text = "Numero Proforma";
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelName.Location = new System.Drawing.Point(394, 10);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(47, 17);
      this.labelName.TabIndex = 9;
      this.labelName.Text = "Cliente";
      // 
      // labelInvoice
      // 
      this.labelInvoice.AutoSize = true;
      this.labelInvoice.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelInvoice.Location = new System.Drawing.Point(150, 10);
      this.labelInvoice.Name = "labelInvoice";
      this.labelInvoice.Size = new System.Drawing.Size(100, 17);
      this.labelInvoice.TabIndex = 10;
      this.labelInvoice.Text = "Numero Fattura";
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(811, 10);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 17);
      this.label4.TabIndex = 11;
      this.label4.Text = "Pagato";
      // 
      // InvoiceListHeader
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.label4);
      this.Controls.Add(this.labelInvoice);
      this.Controls.Add(this.labelName);
      this.Controls.Add(this.labelTitle);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "InvoiceListHeader";
      this.Size = new System.Drawing.Size(945, 39);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelInvoice;
    private System.Windows.Forms.Label label4;
  }
}
