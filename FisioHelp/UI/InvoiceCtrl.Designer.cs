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
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.labelRivalsa = new System.Windows.Forms.Label();
      this.labelRivalsaSconto = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.labelBollo = new System.Windows.Forms.Label();
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
      this.label1.Location = new System.Drawing.Point(48, 281);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Sconto";
      // 
      // textBoxDiscount
      // 
      this.textBoxDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxDiscount.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxDiscount.Location = new System.Drawing.Point(119, 278);
      this.textBoxDiscount.Name = "textBoxDiscount";
      this.textBoxDiscount.Size = new System.Drawing.Size(108, 27);
      this.textBoxDiscount.TabIndex = 13;
      this.textBoxDiscount.TextChanged += new System.EventHandler(this.textBoxDiscount_TextChanged);
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
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Location = new System.Drawing.Point(51, 190);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(724, 82);
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
      this.label6.Location = new System.Drawing.Point(584, 384);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(61, 20);
      this.label6.TabIndex = 20;
      this.label6.Text = "Totale:";
      // 
      // labelTotal
      // 
      this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotal.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelTotal.Location = new System.Drawing.Point(656, 384);
      this.labelTotal.Name = "labelTotal";
      this.labelTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.labelTotal.Size = new System.Drawing.Size(58, 20);
      this.labelTotal.TabIndex = 21;
      this.labelTotal.Text = "label1";
      this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
      this.buttonSave.Location = new System.Drawing.Point(618, 429);
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
      this.buttonPrinter.Location = new System.Drawing.Point(656, 31);
      this.buttonPrinter.Name = "buttonPrinter";
      this.buttonPrinter.Size = new System.Drawing.Size(58, 59);
      this.buttonPrinter.TabIndex = 23;
      this.buttonPrinter.UseVisualStyleBackColor = true;
      this.buttonPrinter.Click += new System.EventHandler(this.buttonPrinter_Click);
      // 
      // checkBox1
      // 
      this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.checkBox1.AutoSize = true;
      this.checkBox1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold);
      this.checkBox1.Location = new System.Drawing.Point(52, 345);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBox1.Size = new System.Drawing.Size(68, 24);
      this.checkBox1.TabIndex = 24;
      this.checkBox1.Text = "Bollo";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(664, 155);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(60, 15);
      this.label7.TabIndex = 25;
      this.label7.Text = "- Rivalsa";
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(574, 155);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(47, 15);
      this.label8.TabIndex = 26;
      this.label8.Text = "Prezzo";
      // 
      // labelRivalsa
      // 
      this.labelRivalsa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelRivalsa.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelRivalsa.Location = new System.Drawing.Point(656, 310);
      this.labelRivalsa.Name = "labelRivalsa";
      this.labelRivalsa.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.labelRivalsa.Size = new System.Drawing.Size(58, 20);
      this.labelRivalsa.TabIndex = 27;
      this.labelRivalsa.Text = "label1";
      this.labelRivalsa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // labelRivalsaSconto
      // 
      this.labelRivalsaSconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelRivalsaSconto.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelRivalsaSconto.Location = new System.Drawing.Point(656, 281);
      this.labelRivalsaSconto.Name = "labelRivalsaSconto";
      this.labelRivalsaSconto.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.labelRivalsaSconto.Size = new System.Drawing.Size(58, 20);
      this.labelRivalsaSconto.TabIndex = 28;
      this.labelRivalsaSconto.Text = "label1";
      this.labelRivalsaSconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label9
      // 
      this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(585, 314);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(54, 15);
      this.label9.TabIndex = 29;
      this.label9.Text = "Rivalsa:";
      // 
      // label10
      // 
      this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(531, 285);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(108, 15);
      this.label10.TabIndex = 30;
      this.label10.Text = "Sconto - rivalsa:";
      // 
      // label11
      // 
      this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label11.Location = new System.Drawing.Point(711, 281);
      this.label11.Name = "label11";
      this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.label11.Size = new System.Drawing.Size(17, 20);
      this.label11.TabIndex = 33;
      this.label11.Text = "€";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label12
      // 
      this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label12.Location = new System.Drawing.Point(711, 310);
      this.label12.Name = "label12";
      this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.label12.Size = new System.Drawing.Size(17, 20);
      this.label12.TabIndex = 34;
      this.label12.Text = "€";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label13
      // 
      this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label13.Location = new System.Drawing.Point(711, 384);
      this.label13.Name = "label13";
      this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.label13.Size = new System.Drawing.Size(17, 20);
      this.label13.TabIndex = 35;
      this.label13.Text = "€";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label14
      // 
      this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label14.Location = new System.Drawing.Point(711, 341);
      this.label14.Name = "label14";
      this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.label14.Size = new System.Drawing.Size(17, 20);
      this.label14.TabIndex = 38;
      this.label14.Text = "€";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label15
      // 
      this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label15.AutoSize = true;
      this.label15.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.Location = new System.Drawing.Point(585, 345);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(43, 15);
      this.label15.TabIndex = 37;
      this.label15.Text = "Bollo:";
      // 
      // labelBollo
      // 
      this.labelBollo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelBollo.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelBollo.Location = new System.Drawing.Point(656, 341);
      this.labelBollo.Name = "labelBollo";
      this.labelBollo.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.labelBollo.Size = new System.Drawing.Size(58, 20);
      this.labelBollo.TabIndex = 36;
      this.labelBollo.Text = "label1";
      this.labelBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // InvoiceCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.labelBollo);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.labelRivalsaSconto);
      this.Controls.Add(this.labelRivalsa);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.checkBox1);
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
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.Label labelRivalsa;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label labelRivalsaSconto;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label labelBollo;
  }
}
