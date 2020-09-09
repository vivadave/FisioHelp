namespace FisioHelp.UI
{
  partial class InvoiceListCtrl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceListCtrl));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.buttonExcel = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBoxPayed = new System.Windows.Forms.ComboBox();
      this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
      this.dateTimePickerfrom = new System.Windows.Forms.DateTimePicker();
      this.panel2 = new System.Windows.Forms.Panel();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label8 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.labelTotNr = new System.Windows.Forms.Label();
      this.labelTotInvoice = new System.Windows.Forms.Label();
      this.labelTotMoney = new System.Windows.Forms.Label();
      this.labelTotPayed = new System.Windows.Forms.Label();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.invoiceNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.proformaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.customerCl = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.VisitNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.payed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.toInvoice = new System.Windows.Forms.DataGridViewImageColumn();
      this.toFolder = new System.Windows.Forms.DataGridViewImageColumn();
      this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.panel3.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
      this.panel1.Controls.Add(this.buttonExcel);
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.comboBoxPayed);
      this.panel1.Controls.Add(this.dateTimePickerTo);
      this.panel1.Controls.Add(this.dateTimePickerfrom);
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1017, 85);
      this.panel1.TabIndex = 0;
      // 
      // buttonExcel
      // 
      this.buttonExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonExcel.FlatAppearance.BorderSize = 0;
      this.buttonExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonExcel.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcel.Image")));
      this.buttonExcel.Location = new System.Drawing.Point(946, 23);
      this.buttonExcel.Name = "buttonExcel";
      this.buttonExcel.Size = new System.Drawing.Size(58, 59);
      this.buttonExcel.TabIndex = 16;
      this.buttonExcel.UseVisualStyleBackColor = true;
      this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
      // 
      // label9
      // 
      this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(852, 12);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(43, 17);
      this.label9.TabIndex = 13;
      this.label9.Text = "Azioni";
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.label7.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(829, -2);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(1, 85);
      this.label7.TabIndex = 12;
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.label6.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(-3, 83);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(1020, 2);
      this.label6.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(16, 12);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(48, 17);
      this.label5.TabIndex = 10;
      this.label5.Text = "Fatture";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label4.Location = new System.Drawing.Point(518, 40);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(52, 19);
      this.label4.TabIndex = 9;
      this.label4.Text = "Pagato";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label2.Location = new System.Drawing.Point(264, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(18, 19);
      this.label2.TabIndex = 7;
      this.label2.Text = "A";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label1.Location = new System.Drawing.Point(87, 40);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(26, 19);
      this.label1.TabIndex = 6;
      this.label1.Text = "Da";
      // 
      // comboBoxPayed
      // 
      this.comboBoxPayed.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBoxPayed.FormattingEnabled = true;
      this.comboBoxPayed.Location = new System.Drawing.Point(578, 37);
      this.comboBoxPayed.Name = "comboBoxPayed";
      this.comboBoxPayed.Size = new System.Drawing.Size(68, 25);
      this.comboBoxPayed.TabIndex = 4;
      this.comboBoxPayed.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayed_SelectedIndexChanged);
      // 
      // dateTimePickerTo
      // 
      this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dateTimePickerTo.Location = new System.Drawing.Point(288, 37);
      this.dateTimePickerTo.Name = "dateTimePickerTo";
      this.dateTimePickerTo.Size = new System.Drawing.Size(119, 25);
      this.dateTimePickerTo.TabIndex = 3;
      this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
      // 
      // dateTimePickerfrom
      // 
      this.dateTimePickerfrom.CustomFormat = "dd/MM/yyyy";
      this.dateTimePickerfrom.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dateTimePickerfrom.Location = new System.Drawing.Point(119, 37);
      this.dateTimePickerfrom.Name = "dateTimePickerfrom";
      this.dateTimePickerfrom.Size = new System.Drawing.Size(119, 25);
      this.dateTimePickerfrom.TabIndex = 2;
      this.dateTimePickerfrom.ValueChanged += new System.EventHandler(this.dateTimePickerfrom_ValueChanged);
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel2.AutoScroll = true;
      this.panel2.BackColor = System.Drawing.Color.White;
      this.panel2.Controls.Add(this.dataGridView1);
      this.panel2.Location = new System.Drawing.Point(0, 83);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1017, 382);
      this.panel2.TabIndex = 1;
      // 
      // dataGridView1
      // 
      this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
      this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceNr,
            this.date,
            this.proformaNr,
            this.customerCl,
            this.price,
            this.VisitNr,
            this.payed,
            this.toInvoice,
            this.toFolder,
            this.id});
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(1017, 382);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.Controls.Add(this.label8);
      this.panel3.Controls.Add(this.tableLayoutPanel1);
      this.panel3.Location = new System.Drawing.Point(0, 461);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(1017, 68);
      this.panel3.TabIndex = 0;
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.label8.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(-2, 2);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(1020, 2);
      this.label8.TabIndex = 17;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Controls.Add(this.labelTotNr, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTotInvoice, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTotMoney, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTotPayed, 2, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1017, 65);
      this.tableLayoutPanel1.TabIndex = 15;
      // 
      // labelTotNr
      // 
      this.labelTotNr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotNr.AutoSize = true;
      this.labelTotNr.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTotNr.Location = new System.Drawing.Point(3, 0);
      this.labelTotNr.Name = "labelTotNr";
      this.labelTotNr.Size = new System.Drawing.Size(248, 65);
      this.labelTotNr.TabIndex = 8;
      this.labelTotNr.Text = "#";
      this.labelTotNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelTotInvoice
      // 
      this.labelTotInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotInvoice.AutoSize = true;
      this.labelTotInvoice.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTotInvoice.Location = new System.Drawing.Point(765, 0);
      this.labelTotInvoice.Name = "labelTotInvoice";
      this.labelTotInvoice.Size = new System.Drawing.Size(249, 65);
      this.labelTotInvoice.TabIndex = 14;
      this.labelTotInvoice.Text = "#";
      this.labelTotInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelTotMoney
      // 
      this.labelTotMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotMoney.AutoSize = true;
      this.labelTotMoney.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTotMoney.Location = new System.Drawing.Point(257, 0);
      this.labelTotMoney.Name = "labelTotMoney";
      this.labelTotMoney.Size = new System.Drawing.Size(248, 65);
      this.labelTotMoney.TabIndex = 10;
      this.labelTotMoney.Text = "#";
      this.labelTotMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelTotPayed
      // 
      this.labelTotPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotPayed.AutoSize = true;
      this.labelTotPayed.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTotPayed.Location = new System.Drawing.Point(511, 0);
      this.labelTotPayed.Name = "labelTotPayed";
      this.labelTotPayed.Size = new System.Drawing.Size(248, 65);
      this.labelTotPayed.TabIndex = 12;
      this.labelTotPayed.Text = "#";
      this.labelTotPayed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "xlsx";
      this.saveFileDialog1.Filter = "Excel files|*.xlsx";
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "bill.png");
      this.imageList1.Images.SetKeyName(1, "record.png");
      // 
      // invoiceNr
      // 
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      this.invoiceNr.DefaultCellStyle = dataGridViewCellStyle2;
      this.invoiceNr.HeaderText = "Nr. Fattura";
      this.invoiceNr.Name = "invoiceNr";
      this.invoiceNr.ReadOnly = true;
      // 
      // date
      // 
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      this.date.DefaultCellStyle = dataGridViewCellStyle3;
      this.date.HeaderText = "Data";
      this.date.Name = "date";
      this.date.ReadOnly = true;
      // 
      // proformaNr
      // 
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      this.proformaNr.DefaultCellStyle = dataGridViewCellStyle4;
      this.proformaNr.HeaderText = "Nr. Proforma";
      this.proformaNr.Name = "proformaNr";
      this.proformaNr.ReadOnly = true;
      this.proformaNr.Width = 120;
      // 
      // customerCl
      // 
      this.customerCl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      this.customerCl.DefaultCellStyle = dataGridViewCellStyle5;
      this.customerCl.HeaderText = "Cliente";
      this.customerCl.Name = "customerCl";
      this.customerCl.ReadOnly = true;
      // 
      // price
      // 
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      this.price.DefaultCellStyle = dataGridViewCellStyle6;
      this.price.HeaderText = "Importo";
      this.price.Name = "price";
      this.price.ReadOnly = true;
      // 
      // VisitNr
      // 
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Historic", 10.25F);
      this.VisitNr.DefaultCellStyle = dataGridViewCellStyle7;
      this.VisitNr.HeaderText = "Numero Visite";
      this.VisitNr.Name = "VisitNr";
      this.VisitNr.ReadOnly = true;
      this.VisitNr.Width = 120;
      // 
      // payed
      // 
      this.payed.HeaderText = "Pagato";
      this.payed.Name = "payed";
      this.payed.ReadOnly = true;
      this.payed.Width = 60;
      // 
      // toInvoice
      // 
      this.toInvoice.HeaderText = "Alla fattura";
      this.toInvoice.Image = ((System.Drawing.Image)(resources.GetObject("toInvoice.Image")));
      this.toInvoice.Name = "toInvoice";
      this.toInvoice.ReadOnly = true;
      // 
      // toFolder
      // 
      this.toFolder.HeaderText = "Al documento";
      this.toFolder.Image = ((System.Drawing.Image)(resources.GetObject("toFolder.Image")));
      this.toFolder.Name = "toFolder";
      this.toFolder.ReadOnly = true;
      this.toFolder.Width = 120;
      // 
      // id
      // 
      this.id.HeaderText = "id";
      this.id.Name = "id";
      this.id.Visible = false;
      // 
      // InvoiceListCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "InvoiceListCtrl";
      this.Size = new System.Drawing.Size(1017, 529);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.panel3.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DateTimePicker dateTimePickerTo;
    private System.Windows.Forms.DateTimePicker dateTimePickerfrom;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBoxPayed;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label labelTotInvoice;
    private System.Windows.Forms.Label labelTotPayed;
    private System.Windows.Forms.Label labelTotMoney;
    private System.Windows.Forms.Label labelTotNr;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button buttonExcel;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNr;
    private System.Windows.Forms.DataGridViewTextBoxColumn date;
    private System.Windows.Forms.DataGridViewTextBoxColumn proformaNr;
    private System.Windows.Forms.DataGridViewTextBoxColumn customerCl;
    private System.Windows.Forms.DataGridViewTextBoxColumn price;
    private System.Windows.Forms.DataGridViewTextBoxColumn VisitNr;
    private System.Windows.Forms.DataGridViewCheckBoxColumn payed;
    private System.Windows.Forms.DataGridViewImageColumn toInvoice;
    private System.Windows.Forms.DataGridViewImageColumn toFolder;
    private System.Windows.Forms.DataGridViewTextBoxColumn id;
  }
}
