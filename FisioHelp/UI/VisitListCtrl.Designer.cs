﻿namespace FisioHelp.UI
{
  partial class VisitListCtrl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitListCtrl));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.checkBoxFuture = new System.Windows.Forms.CheckBox();
      this.label5 = new System.Windows.Forms.Label();
      this.comboBoxProforma = new System.Windows.Forms.ComboBox();
      this.buttonAnamnesys = new System.Windows.Forms.Button();
      this.buttonAnamnesysView = new System.Windows.Forms.Button();
      this.buttonInvoices = new System.Windows.Forms.Button();
      this.labelAction = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.labelTitle = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBoxInvoice = new System.Windows.Forms.ComboBox();
      this.comboBoxPayed = new System.Windows.Forms.ComboBox();
      this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
      this.dateTimePickerfrom = new System.Windows.Forms.DateTimePicker();
      this.panel2 = new System.Windows.Forms.Panel();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Ora = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Pagato = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Proforma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Fattura = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.Link = new System.Windows.Forms.DataGridViewLinkColumn();
      this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label8 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.labelTotInvoice = new System.Windows.Forms.Label();
      this.labelTotNr = new System.Windows.Forms.Label();
      this.labelTotMoney = new System.Windows.Forms.Label();
      this.labelTotPayed = new System.Windows.Forms.Label();
      this.labelTotProforma = new System.Windows.Forms.Label();
      this.visitListCtrlBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.panel3.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.visitListCtrlBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
      this.panel1.Controls.Add(this.checkBoxFuture);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.comboBoxProforma);
      this.panel1.Controls.Add(this.buttonAnamnesys);
      this.panel1.Controls.Add(this.buttonAnamnesysView);
      this.panel1.Controls.Add(this.buttonInvoices);
      this.panel1.Controls.Add(this.labelAction);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.labelTitle);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.comboBoxInvoice);
      this.panel1.Controls.Add(this.comboBoxPayed);
      this.panel1.Controls.Add(this.dateTimePickerTo);
      this.panel1.Controls.Add(this.dateTimePickerfrom);
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1156, 85);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
      // 
      // checkBoxFuture
      // 
      this.checkBoxFuture.AutoSize = true;
      this.checkBoxFuture.Checked = true;
      this.checkBoxFuture.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxFuture.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.checkBoxFuture.Location = new System.Drawing.Point(899, 39);
      this.checkBoxFuture.Name = "checkBoxFuture";
      this.checkBoxFuture.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.checkBoxFuture.Size = new System.Drawing.Size(68, 23);
      this.checkBoxFuture.TabIndex = 18;
      this.checkBoxFuture.Text = "Future";
      this.checkBoxFuture.UseVisualStyleBackColor = true;
      this.checkBoxFuture.CheckedChanged += new System.EventHandler(this.checkBoxFuture_CheckedChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label5.Location = new System.Drawing.Point(589, 41);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(66, 19);
      this.label5.TabIndex = 17;
      this.label5.Text = "Proforma";
      // 
      // comboBoxProforma
      // 
      this.comboBoxProforma.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBoxProforma.FormattingEnabled = true;
      this.comboBoxProforma.Location = new System.Drawing.Point(659, 38);
      this.comboBoxProforma.Name = "comboBoxProforma";
      this.comboBoxProforma.Size = new System.Drawing.Size(68, 25);
      this.comboBoxProforma.TabIndex = 16;
      this.comboBoxProforma.SelectedIndexChanged += new System.EventHandler(this.comboBoxProforma_SelectedIndexChanged);
      // 
      // buttonAnamnesys
      // 
      this.buttonAnamnesys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonAnamnesys.FlatAppearance.BorderSize = 0;
      this.buttonAnamnesys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonAnamnesys.Image = ((System.Drawing.Image)(resources.GetObject("buttonAnamnesys.Image")));
      this.buttonAnamnesys.Location = new System.Drawing.Point(1091, 19);
      this.buttonAnamnesys.Name = "buttonAnamnesys";
      this.buttonAnamnesys.Size = new System.Drawing.Size(58, 59);
      this.buttonAnamnesys.TabIndex = 15;
      this.buttonAnamnesys.UseVisualStyleBackColor = true;
      this.buttonAnamnesys.Click += new System.EventHandler(this.buttonAnamnesys_Click);
      // 
      // buttonAnamnesysView
      // 
      this.buttonAnamnesysView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonAnamnesysView.FlatAppearance.BorderSize = 0;
      this.buttonAnamnesysView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonAnamnesysView.Image = ((System.Drawing.Image)(resources.GetObject("buttonAnamnesysView.Image")));
      this.buttonAnamnesysView.Location = new System.Drawing.Point(1021, 19);
      this.buttonAnamnesysView.Name = "buttonAnamnesysView";
      this.buttonAnamnesysView.Size = new System.Drawing.Size(58, 59);
      this.buttonAnamnesysView.TabIndex = 15;
      this.buttonAnamnesysView.UseVisualStyleBackColor = true;
      this.buttonAnamnesysView.Click += new System.EventHandler(this.buttonAnamnesysView_Click);
      // 
      // buttonInvoices
      // 
      this.buttonInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonInvoices.FlatAppearance.BorderSize = 0;
      this.buttonInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonInvoices.Image = ((System.Drawing.Image)(resources.GetObject("buttonInvoices.Image")));
      this.buttonInvoices.Location = new System.Drawing.Point(1081, 16);
      this.buttonInvoices.Name = "buttonInvoices";
      this.buttonInvoices.Size = new System.Drawing.Size(58, 59);
      this.buttonInvoices.TabIndex = 14;
      this.buttonInvoices.UseVisualStyleBackColor = true;
      this.buttonInvoices.Click += new System.EventHandler(this.buttonInvoices_Click);
      // 
      // labelAction
      // 
      this.labelAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.labelAction.AutoSize = true;
      this.labelAction.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelAction.Location = new System.Drawing.Point(990, 11);
      this.labelAction.Name = "labelAction";
      this.labelAction.Size = new System.Drawing.Size(43, 17);
      this.labelAction.TabIndex = 13;
      this.labelAction.Text = "Azioni";
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.label7.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(968, -2);
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
      this.label6.Size = new System.Drawing.Size(1159, 2);
      this.label6.TabIndex = 11;
      // 
      // labelTitle
      // 
      this.labelTitle.AutoSize = true;
      this.labelTitle.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTitle.Location = new System.Drawing.Point(16, 12);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(39, 17);
      this.labelTitle.TabIndex = 10;
      this.labelTitle.Text = "Visite";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label4.Location = new System.Drawing.Point(750, 41);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(52, 19);
      this.label4.TabIndex = 9;
      this.label4.Text = "Pagato";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label3.Location = new System.Drawing.Point(431, 41);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(66, 19);
      this.label3.TabIndex = 8;
      this.label3.Text = "Fatturato";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label2.Location = new System.Drawing.Point(265, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(18, 19);
      this.label2.TabIndex = 7;
      this.label2.Text = "A";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.label1.Location = new System.Drawing.Point(88, 41);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(26, 19);
      this.label1.TabIndex = 6;
      this.label1.Text = "Da";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // comboBoxInvoice
      // 
      this.comboBoxInvoice.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBoxInvoice.FormattingEnabled = true;
      this.comboBoxInvoice.Location = new System.Drawing.Point(501, 38);
      this.comboBoxInvoice.Name = "comboBoxInvoice";
      this.comboBoxInvoice.Size = new System.Drawing.Size(68, 25);
      this.comboBoxInvoice.TabIndex = 5;
      this.comboBoxInvoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxInvoice_SelectedIndexChanged);
      // 
      // comboBoxPayed
      // 
      this.comboBoxPayed.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.comboBoxPayed.FormattingEnabled = true;
      this.comboBoxPayed.Location = new System.Drawing.Point(806, 38);
      this.comboBoxPayed.Name = "comboBoxPayed";
      this.comboBoxPayed.Size = new System.Drawing.Size(68, 25);
      this.comboBoxPayed.TabIndex = 4;
      this.comboBoxPayed.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayed_SelectedIndexChanged);
      // 
      // dateTimePickerTo
      // 
      this.dateTimePickerTo.CustomFormat = "dd/MM/yyyy";
      this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dateTimePickerTo.Location = new System.Drawing.Point(289, 38);
      this.dateTimePickerTo.Name = "dateTimePickerTo";
      this.dateTimePickerTo.Size = new System.Drawing.Size(119, 25);
      this.dateTimePickerTo.TabIndex = 3;
      this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
      // 
      // dateTimePickerfrom
      // 
      this.dateTimePickerfrom.CustomFormat = "dd/MM/yyyy";
      this.dateTimePickerfrom.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.dateTimePickerfrom.Location = new System.Drawing.Point(120, 38);
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
      this.panel2.Size = new System.Drawing.Size(1156, 382);
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
            this.Cliente,
            this.Data,
            this.Ora,
            this.Costo,
            this.Pagato,
            this.Proforma,
            this.Fattura,
            this.Link,
            this.id});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(1156, 382);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.Visible = false;
      this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      // 
      // Cliente
      // 
      this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.Cliente.DefaultCellStyle = dataGridViewCellStyle2;
      this.Cliente.HeaderText = "Cliente";
      this.Cliente.Name = "Cliente";
      // 
      // Data
      // 
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      dataGridViewCellStyle3.Format = "d";
      dataGridViewCellStyle3.NullValue = null;
      this.Data.DefaultCellStyle = dataGridViewCellStyle3;
      this.Data.HeaderText = "Data";
      this.Data.Name = "Data";
      // 
      // Ora
      // 
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.Ora.DefaultCellStyle = dataGridViewCellStyle4;
      this.Ora.HeaderText = "Ora";
      this.Ora.Name = "Ora";
      // 
      // Costo
      // 
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      this.Costo.DefaultCellStyle = dataGridViewCellStyle5;
      this.Costo.HeaderText = "Costo";
      this.Costo.Name = "Costo";
      // 
      // Pagato
      // 
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      dataGridViewCellStyle6.NullValue = false;
      this.Pagato.DefaultCellStyle = dataGridViewCellStyle6;
      this.Pagato.HeaderText = "Pagato";
      this.Pagato.Name = "Pagato";
      this.Pagato.ReadOnly = true;
      this.Pagato.Width = 50;
      // 
      // Proforma
      // 
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      dataGridViewCellStyle7.NullValue = false;
      this.Proforma.DefaultCellStyle = dataGridViewCellStyle7;
      this.Proforma.HeaderText = "Proforma";
      this.Proforma.Name = "Proforma";
      this.Proforma.ReadOnly = true;
      this.Proforma.Width = 60;
      // 
      // Fattura
      // 
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Historic", 10F);
      dataGridViewCellStyle8.NullValue = false;
      this.Fattura.DefaultCellStyle = dataGridViewCellStyle8;
      this.Fattura.HeaderText = "Fattura";
      this.Fattura.Name = "Fattura";
      this.Fattura.ReadOnly = true;
      this.Fattura.Width = 50;
      // 
      // Link
      // 
      this.Link.HeaderText = "Link";
      this.Link.Name = "Link";
      this.Link.ReadOnly = true;
      // 
      // id
      // 
      this.id.HeaderText = "id";
      this.id.Name = "id";
      this.id.Visible = false;
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.Controls.Add(this.label8);
      this.panel3.Controls.Add(this.tableLayoutPanel1);
      this.panel3.Location = new System.Drawing.Point(0, 461);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(1156, 68);
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
      this.label8.Size = new System.Drawing.Size(1159, 2);
      this.label8.TabIndex = 17;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.Controls.Add(this.labelTotInvoice, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTotNr, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTotMoney, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTotPayed, 4, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTotProforma, 2, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1156, 65);
      this.tableLayoutPanel1.TabIndex = 15;
      // 
      // labelTotInvoice
      // 
      this.labelTotInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotInvoice.AutoSize = true;
      this.labelTotInvoice.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTotInvoice.Location = new System.Drawing.Point(696, 0);
      this.labelTotInvoice.Name = "labelTotInvoice";
      this.labelTotInvoice.Size = new System.Drawing.Size(225, 65);
      this.labelTotInvoice.TabIndex = 14;
      this.labelTotInvoice.Text = "#";
      this.labelTotInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
      this.labelTotNr.Size = new System.Drawing.Size(225, 65);
      this.labelTotNr.TabIndex = 8;
      this.labelTotNr.Text = "#";
      this.labelTotNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelTotMoney
      // 
      this.labelTotMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotMoney.AutoSize = true;
      this.labelTotMoney.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTotMoney.Location = new System.Drawing.Point(234, 0);
      this.labelTotMoney.Name = "labelTotMoney";
      this.labelTotMoney.Size = new System.Drawing.Size(225, 65);
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
      this.labelTotPayed.Location = new System.Drawing.Point(927, 0);
      this.labelTotPayed.Name = "labelTotPayed";
      this.labelTotPayed.Size = new System.Drawing.Size(226, 65);
      this.labelTotPayed.TabIndex = 12;
      this.labelTotPayed.Text = "#";
      this.labelTotPayed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelTotProforma
      // 
      this.labelTotProforma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTotProforma.AutoSize = true;
      this.labelTotProforma.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelTotProforma.Location = new System.Drawing.Point(465, 0);
      this.labelTotProforma.Name = "labelTotProforma";
      this.labelTotProforma.Size = new System.Drawing.Size(225, 65);
      this.labelTotProforma.TabIndex = 15;
      this.labelTotProforma.Text = "#";
      this.labelTotProforma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // visitListCtrlBindingSource
      // 
      this.visitListCtrlBindingSource.DataSource = typeof(FisioHelp.UI.VisitListCtrl);
      // 
      // VisitListCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "VisitListCtrl";
      this.Size = new System.Drawing.Size(1156, 529);
      this.Load += new System.EventHandler(this.VisitListCtrl_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.panel3.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.visitListCtrlBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DateTimePicker dateTimePickerTo;
    private System.Windows.Forms.DateTimePicker dateTimePickerfrom;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label labelTotInvoice;
    private System.Windows.Forms.Label labelTotPayed;
    private System.Windows.Forms.Label labelTotMoney;
    private System.Windows.Forms.Label labelTotNr;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label labelAction;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button buttonInvoices;
    private System.Windows.Forms.Button buttonAnamnesys;
    private System.Windows.Forms.Button buttonAnamnesysView;
    private System.Windows.Forms.Label labelTotProforma;
    private System.Windows.Forms.CheckBox checkBoxFuture;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox comboBoxProforma;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboBoxInvoice;
    private System.Windows.Forms.ComboBox comboBoxPayed;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.BindingSource visitListCtrlBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
    private System.Windows.Forms.DataGridViewTextBoxColumn Data;
    private System.Windows.Forms.DataGridViewTextBoxColumn Ora;
    private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Pagato;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Proforma;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Fattura;
    private System.Windows.Forms.DataGridViewLinkColumn Link;
    private System.Windows.Forms.DataGridViewTextBoxColumn id;
  }
}
