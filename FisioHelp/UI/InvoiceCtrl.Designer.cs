namespace FisioHelp.UI
{
  partial class InvoiceCtrl
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceCtrl));
      this.labelName = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxDiscount = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.labelCustomerName = new System.Windows.Forms.Label();
      this.labelFiscalCode = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.labelTotal = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.buttonSave = new System.Windows.Forms.Button();
      this.buttonPrinter = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelName.Location = new System.Drawing.Point(177, 31);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(50, 20);
      this.labelName.TabIndex = 0;
      this.labelName.Text = "label1";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(49, 373);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Sconto";
      // 
      // textBoxDiscount
      // 
      this.textBoxDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxDiscount.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxDiscount.Location = new System.Drawing.Point(120, 370);
      this.textBoxDiscount.Name = "textBoxDiscount";
      this.textBoxDiscount.Size = new System.Drawing.Size(108, 27);
      this.textBoxDiscount.TabIndex = 13;
      this.textBoxDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDiscount_KeyDown);
      this.textBoxDiscount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxDiscount_KeyUp);
      this.textBoxDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDiscount_Validating);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(48, 31);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(94, 20);
      this.label2.TabIndex = 14;
      this.label2.Text = "Fattura Nr. ";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Location = new System.Drawing.Point(51, 190);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(724, 158);
      this.panel1.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(48, 73);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(66, 20);
      this.label3.TabIndex = 15;
      this.label3.Text = "Cliente:";
      // 
      // labelCustomerName
      // 
      this.labelCustomerName.AutoSize = true;
      this.labelCustomerName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelCustomerName.Location = new System.Drawing.Point(177, 73);
      this.labelCustomerName.Name = "labelCustomerName";
      this.labelCustomerName.Size = new System.Drawing.Size(50, 20);
      this.labelCustomerName.TabIndex = 16;
      this.labelCustomerName.Text = "label1";
      // 
      // labelFiscalCode
      // 
      this.labelFiscalCode.AutoSize = true;
      this.labelFiscalCode.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelFiscalCode.Location = new System.Drawing.Point(177, 104);
      this.labelFiscalCode.Name = "labelFiscalCode";
      this.labelFiscalCode.Size = new System.Drawing.Size(50, 20);
      this.labelFiscalCode.TabIndex = 18;
      this.labelFiscalCode.Text = "label1";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(48, 104);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(121, 20);
      this.label5.TabIndex = 17;
      this.label5.Text = "Codice Fiscale:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(48, 155);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(56, 20);
      this.label4.TabIndex = 19;
      this.label4.Text = "VISITE";
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(645, 377);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(61, 20);
      this.label6.TabIndex = 20;
      this.label6.Text = "Totale:";
      // 
      // labelTotal
      // 
      this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotal.AutoSize = true;
      this.labelTotal.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelTotal.Location = new System.Drawing.Point(729, 377);
      this.labelTotal.Name = "labelTotal";
      this.labelTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.labelTotal.Size = new System.Drawing.Size(50, 20);
      this.labelTotal.TabIndex = 21;
      this.labelTotal.Text = "label1";
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // buttonSave
      // 
      this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSave.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.ForeColor = System.Drawing.Color.White;
      this.buttonSave.Location = new System.Drawing.Point(669, 425);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(106, 38);
      this.buttonSave.TabIndex = 22;
      this.buttonSave.Text = "Create";
      this.buttonSave.UseVisualStyleBackColor = false;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // buttonPrinter
      // 
      this.buttonPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonPrinter.FlatAppearance.BorderSize = 0;
      this.buttonPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonPrinter.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrinter.Image")));
      this.buttonPrinter.Location = new System.Drawing.Point(717, 31);
      this.buttonPrinter.Name = "buttonPrinter";
      this.buttonPrinter.Size = new System.Drawing.Size(58, 59);
      this.buttonPrinter.TabIndex = 23;
      this.buttonPrinter.UseVisualStyleBackColor = true;
      this.buttonPrinter.Click += new System.EventHandler(this.buttonPrinter_Click);
      // 
      // InvoiceCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.Controls.Add(this.buttonPrinter);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.labelTotal);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.labelFiscalCode);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.labelCustomerName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBoxDiscount);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.labelName);
      this.Name = "InvoiceCtrl";
      this.Size = new System.Drawing.Size(826, 485);
      this.Load += new System.EventHandler(this.InvoiceCtrl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxDiscount;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label labelCustomerName;
    private System.Windows.Forms.Label labelFiscalCode;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label labelTotal;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button buttonPrinter;
  }
}
