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
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.label8 = new System.Windows.Forms.Label();
      this.labelRivalsaSconto = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.labelBollo = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.labelInviceName = new System.Windows.Forms.Label();
      this.buttonPrintInvoice = new System.Windows.Forms.Button();
      this.buttonPrintProformaInvoice = new System.Windows.Forms.Button();
      this.dateTimePickerPayed = new System.Windows.Forms.DateTimePicker();
      this.label9 = new System.Windows.Forms.Label();
      this.checkBoxPayed = new System.Windows.Forms.CheckBox();
      this.labelProformaData = new System.Windows.Forms.Label();
      this.labelInviceDate = new System.Windows.Forms.Label();
      this.checkBoxGroup = new System.Windows.Forms.CheckBox();
      this.checkBoxContanti = new System.Windows.Forms.CheckBox();
      this.label12 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.textBoxCustomText = new System.Windows.Forms.TextBox();
      this.buttonDeleteProforma = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // labelName
      // 
      this.labelName.AutoSize = true;
      this.labelName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelName.Location = new System.Drawing.Point(220, 73);
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
      this.label1.Location = new System.Drawing.Point(48, 408);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Sconto";
      // 
      // textBoxDiscount
      // 
      this.textBoxDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxDiscount.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxDiscount.Location = new System.Drawing.Point(119, 405);
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
      this.label2.Location = new System.Drawing.Point(48, 73);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(169, 20);
      this.label2.TabIndex = 14;
      this.label2.Text = "Fattura Proforma Nr. ";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.AutoScroll = true;
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Location = new System.Drawing.Point(51, 280);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(727, 113);
      this.panel1.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(48, 115);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(66, 20);
      this.label3.TabIndex = 15;
      this.label3.Text = "Cliente:";
      // 
      // labelCustomerName
      // 
      this.labelCustomerName.AutoSize = true;
      this.labelCustomerName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelCustomerName.Location = new System.Drawing.Point(177, 115);
      this.labelCustomerName.Name = "labelCustomerName";
      this.labelCustomerName.Size = new System.Drawing.Size(50, 20);
      this.labelCustomerName.TabIndex = 16;
      this.labelCustomerName.Text = "label1";
      // 
      // labelFiscalCode
      // 
      this.labelFiscalCode.AutoSize = true;
      this.labelFiscalCode.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelFiscalCode.Location = new System.Drawing.Point(177, 146);
      this.labelFiscalCode.Name = "labelFiscalCode";
      this.labelFiscalCode.Size = new System.Drawing.Size(50, 20);
      this.labelFiscalCode.TabIndex = 18;
      this.labelFiscalCode.Text = "label1";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(48, 146);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(121, 20);
      this.label5.TabIndex = 17;
      this.label5.Text = "Codice Fiscale:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(47, 257);
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
      this.label6.Location = new System.Drawing.Point(587, 475);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(61, 20);
      this.label6.TabIndex = 20;
      this.label6.Text = "Totale:";
      // 
      // labelTotal
      // 
      this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotal.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelTotal.Location = new System.Drawing.Point(659, 475);
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
      this.buttonSave.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.ForeColor = System.Drawing.Color.White;
      this.buttonSave.Location = new System.Drawing.Point(580, 521);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(170, 38);
      this.buttonSave.TabIndex = 22;
      this.buttonSave.Text = "Crea Fattura Proforma";
      this.buttonSave.UseVisualStyleBackColor = false;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // checkBox1
      // 
      this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.checkBox1.AutoSize = true;
      this.checkBox1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold);
      this.checkBox1.Location = new System.Drawing.Point(51, 442);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBox1.Size = new System.Drawing.Size(68, 24);
      this.checkBox1.TabIndex = 24;
      this.checkBox1.Text = "Bollo";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(670, 261);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(47, 15);
      this.label8.TabIndex = 26;
      this.label8.Text = "Prezzo";
      // 
      // labelRivalsaSconto
      // 
      this.labelRivalsaSconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelRivalsaSconto.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelRivalsaSconto.Location = new System.Drawing.Point(659, 405);
      this.labelRivalsaSconto.Name = "labelRivalsaSconto";
      this.labelRivalsaSconto.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.labelRivalsaSconto.Size = new System.Drawing.Size(58, 20);
      this.labelRivalsaSconto.TabIndex = 28;
      this.labelRivalsaSconto.Text = "label1";
      this.labelRivalsaSconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label10
      // 
      this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(588, 409);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(54, 15);
      this.label10.TabIndex = 30;
      this.label10.Text = "Sconto:";
      // 
      // label11
      // 
      this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label11.Location = new System.Drawing.Point(714, 405);
      this.label11.Name = "label11";
      this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.label11.Size = new System.Drawing.Size(17, 20);
      this.label11.TabIndex = 33;
      this.label11.Text = "€";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label13
      // 
      this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label13.Location = new System.Drawing.Point(714, 475);
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
      this.label14.Location = new System.Drawing.Point(714, 438);
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
      this.label15.Location = new System.Drawing.Point(588, 442);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(43, 15);
      this.label15.TabIndex = 37;
      this.label15.Text = "Bollo:";
      // 
      // labelBollo
      // 
      this.labelBollo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.labelBollo.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelBollo.Location = new System.Drawing.Point(659, 438);
      this.labelBollo.Name = "labelBollo";
      this.labelBollo.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.labelBollo.Size = new System.Drawing.Size(58, 20);
      this.labelBollo.TabIndex = 36;
      this.labelBollo.Text = "0";
      this.labelBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI Historic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(46, 21);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(137, 30);
      this.label7.TabIndex = 40;
      this.label7.Text = "Fattura  Nr. ";
      // 
      // labelInviceName
      // 
      this.labelInviceName.AutoSize = true;
      this.labelInviceName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelInviceName.Location = new System.Drawing.Point(180, 29);
      this.labelInviceName.Name = "labelInviceName";
      this.labelInviceName.Size = new System.Drawing.Size(56, 20);
      this.labelInviceName.TabIndex = 39;
      this.labelInviceName.Text = "label1";
      // 
      // buttonPrintInvoice
      // 
      this.buttonPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonPrintInvoice.BackColor = System.Drawing.Color.White;
      this.buttonPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonPrintInvoice.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonPrintInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonPrintInvoice.Location = new System.Drawing.Point(537, 20);
      this.buttonPrintInvoice.Name = "buttonPrintInvoice";
      this.buttonPrintInvoice.Size = new System.Drawing.Size(213, 38);
      this.buttonPrintInvoice.TabIndex = 41;
      this.buttonPrintInvoice.Text = "Stampa Fattura";
      this.buttonPrintInvoice.UseVisualStyleBackColor = false;
      this.buttonPrintInvoice.Click += new System.EventHandler(this.buttonPrintInvoice_Click);
      // 
      // buttonPrintProformaInvoice
      // 
      this.buttonPrintProformaInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonPrintProformaInvoice.BackColor = System.Drawing.Color.White;
      this.buttonPrintProformaInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonPrintProformaInvoice.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonPrintProformaInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonPrintProformaInvoice.Location = new System.Drawing.Point(537, 64);
      this.buttonPrintProformaInvoice.Name = "buttonPrintProformaInvoice";
      this.buttonPrintProformaInvoice.Size = new System.Drawing.Size(213, 38);
      this.buttonPrintProformaInvoice.TabIndex = 42;
      this.buttonPrintProformaInvoice.Text = "Stampa Fattura Proforma";
      this.buttonPrintProformaInvoice.UseVisualStyleBackColor = false;
      this.buttonPrintProformaInvoice.Click += new System.EventHandler(this.buttonPrintProformaInvoice_Click);
      // 
      // dateTimePickerPayed
      // 
      this.dateTimePickerPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.dateTimePickerPayed.Location = new System.Drawing.Point(163, 500);
      this.dateTimePickerPayed.Name = "dateTimePickerPayed";
      this.dateTimePickerPayed.Size = new System.Drawing.Size(200, 20);
      this.dateTimePickerPayed.TabIndex = 43;
      this.dateTimePickerPayed.ValueChanged += new System.EventHandler(this.dateTimePickerPayed_ValueChanged);
      // 
      // label9
      // 
      this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold);
      this.label9.Location = new System.Drawing.Point(48, 496);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(62, 20);
      this.label9.TabIndex = 44;
      this.label9.Text = "Pagato";
      // 
      // checkBoxPayed
      // 
      this.checkBoxPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.checkBoxPayed.AutoSize = true;
      this.checkBoxPayed.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold);
      this.checkBoxPayed.Location = new System.Drawing.Point(127, 500);
      this.checkBoxPayed.Name = "checkBoxPayed";
      this.checkBoxPayed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBoxPayed.Size = new System.Drawing.Size(15, 14);
      this.checkBoxPayed.TabIndex = 45;
      this.checkBoxPayed.UseVisualStyleBackColor = true;
      this.checkBoxPayed.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
      // 
      // labelProformaData
      // 
      this.labelProformaData.AutoSize = true;
      this.labelProformaData.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelProformaData.Location = new System.Drawing.Point(297, 75);
      this.labelProformaData.Name = "labelProformaData";
      this.labelProformaData.Size = new System.Drawing.Size(43, 17);
      this.labelProformaData.TabIndex = 46;
      this.labelProformaData.Text = "label1";
      // 
      // labelInviceDate
      // 
      this.labelInviceDate.AutoSize = true;
      this.labelInviceDate.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelInviceDate.Location = new System.Drawing.Point(268, 31);
      this.labelInviceDate.Name = "labelInviceDate";
      this.labelInviceDate.Size = new System.Drawing.Size(43, 17);
      this.labelInviceDate.TabIndex = 47;
      this.labelInviceDate.Text = "label1";
      // 
      // checkBoxGroup
      // 
      this.checkBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.checkBoxGroup.AutoSize = true;
      this.checkBoxGroup.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold);
      this.checkBoxGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.checkBoxGroup.Location = new System.Drawing.Point(575, 115);
      this.checkBoxGroup.Name = "checkBoxGroup";
      this.checkBoxGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.checkBoxGroup.Size = new System.Drawing.Size(175, 24);
      this.checkBoxGroup.TabIndex = 48;
      this.checkBoxGroup.Text = "Raggruppa le visite";
      this.checkBoxGroup.UseVisualStyleBackColor = true;
      this.checkBoxGroup.CheckedChanged += new System.EventHandler(this.checkBoxGroup_CheckedChanged);
      // 
      // checkBoxContanti
      // 
      this.checkBoxContanti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.checkBoxContanti.AutoSize = true;
      this.checkBoxContanti.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold);
      this.checkBoxContanti.Location = new System.Drawing.Point(127, 534);
      this.checkBoxContanti.Name = "checkBoxContanti";
      this.checkBoxContanti.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBoxContanti.Size = new System.Drawing.Size(15, 14);
      this.checkBoxContanti.TabIndex = 50;
      this.checkBoxContanti.UseVisualStyleBackColor = true;
      this.checkBoxContanti.CheckedChanged += new System.EventHandler(this.checkBoxContanti_CheckedChanged);
      // 
      // label12
      // 
      this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold);
      this.label12.Location = new System.Drawing.Point(48, 530);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(73, 20);
      this.label12.TabIndex = 49;
      this.label12.Text = "Contanti";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label16.Location = new System.Drawing.Point(48, 185);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(143, 20);
      this.label16.TabIndex = 51;
      this.label16.Text = "Testo Alternativo:";
      // 
      // textBoxCustomText
      // 
      this.textBoxCustomText.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxCustomText.Location = new System.Drawing.Point(197, 185);
      this.textBoxCustomText.Multiline = true;
      this.textBoxCustomText.Name = "textBoxCustomText";
      this.textBoxCustomText.Size = new System.Drawing.Size(330, 61);
      this.textBoxCustomText.TabIndex = 52;
      // 
      // buttonDeleteProforma
      // 
      this.buttonDeleteProforma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonDeleteProforma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonDeleteProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonDeleteProforma.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonDeleteProforma.ForeColor = System.Drawing.Color.White;
      this.buttonDeleteProforma.Location = new System.Drawing.Point(434, 521);
      this.buttonDeleteProforma.Name = "buttonDeleteProforma";
      this.buttonDeleteProforma.Size = new System.Drawing.Size(140, 38);
      this.buttonDeleteProforma.TabIndex = 53;
      this.buttonDeleteProforma.Text = "Elimina Proforma";
      this.buttonDeleteProforma.UseVisualStyleBackColor = false;
      this.buttonDeleteProforma.Click += new System.EventHandler(this.buttonDeleteProforma_Click);
      // 
      // InvoiceCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.Controls.Add(this.buttonDeleteProforma);
      this.Controls.Add(this.textBoxCustomText);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.checkBoxContanti);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.checkBoxGroup);
      this.Controls.Add(this.labelInviceDate);
      this.Controls.Add(this.labelProformaData);
      this.Controls.Add(this.checkBoxPayed);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.dateTimePickerPayed);
      this.Controls.Add(this.buttonPrintProformaInvoice);
      this.Controls.Add(this.buttonPrintInvoice);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.labelInviceName);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.labelBollo);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.labelRivalsaSconto);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.checkBox1);
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
      this.Size = new System.Drawing.Size(829, 576);
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
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label labelRivalsaSconto;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label labelBollo;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label labelInviceName;
    private System.Windows.Forms.Button buttonPrintProformaInvoice;
    private System.Windows.Forms.Button buttonPrintInvoice;
    private System.Windows.Forms.CheckBox checkBoxPayed;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.DateTimePicker dateTimePickerPayed;
    private System.Windows.Forms.Label labelInviceDate;
    private System.Windows.Forms.Label labelProformaData;
    private System.Windows.Forms.CheckBox checkBoxGroup;
    private System.Windows.Forms.CheckBox checkBoxContanti;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox textBoxCustomText;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Button buttonDeleteProforma;
  }
}
