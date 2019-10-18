namespace FisioHelp.UI.Globals
{
  partial class Setting
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
      this.components = new System.ComponentModel.Container();
      this.buttonSave = new System.Windows.Forms.Button();
      this.pricelis = new System.Windows.Forms.GroupBox();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.priceListBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.dataGridView2 = new System.Windows.Forms.DataGridView();
      this.Indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.treatmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.textBoxIban = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.textBoxCf = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.textBoxPiva = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBoxEmail = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxAddress = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.textBoxName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxAddressDe = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.pricelis.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // buttonSave
      // 
      this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSave.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.ForeColor = System.Drawing.Color.White;
      this.buttonSave.Location = new System.Drawing.Point(916, 463);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(106, 38);
      this.buttonSave.TabIndex = 28;
      this.buttonSave.Text = "Save";
      this.buttonSave.UseVisualStyleBackColor = false;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // pricelis
      // 
      this.pricelis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pricelis.Controls.Add(this.dataGridView1);
      this.pricelis.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F);
      this.pricelis.Location = new System.Drawing.Point(366, 13);
      this.pricelis.Name = "pricelis";
      this.pricelis.Size = new System.Drawing.Size(656, 262);
      this.pricelis.TabIndex = 29;
      this.pricelis.TabStop = false;
      this.pricelis.Text = "Price List";
      this.pricelis.Enter += new System.EventHandler(this.pricelis_Enter);
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.priceListBindingSource;
      this.dataGridView1.Location = new System.Drawing.Point(6, 19);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(626, 237);
      this.dataGridView1.TabIndex = 0;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      // 
      // priceDataGridViewTextBoxColumn
      // 
      this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
      this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
      this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
      // 
      // priceListBindingSource
      // 
      this.priceListBindingSource.DataSource = typeof(FisioHelp.DataModels.PriceList);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.dataGridView2);
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F);
      this.groupBox1.Location = new System.Drawing.Point(12, 273);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1010, 183);
      this.groupBox1.TabIndex = 30;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Trattamenti";
      // 
      // dataGridView2
      // 
      this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView2.AutoGenerateColumns = false;
      this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
      this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Indice,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
      this.dataGridView2.DataSource = this.treatmentBindingSource;
      this.dataGridView2.Location = new System.Drawing.Point(6, 19);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.Size = new System.Drawing.Size(980, 158);
      this.dataGridView2.TabIndex = 0;
      // 
      // Indice
      // 
      this.Indice.DataPropertyName = "Id";
      this.Indice.HeaderText = "Indice";
      this.Indice.Name = "Indice";
      this.Indice.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.dataGridViewTextBoxColumn4.DataPropertyName = "DescriptionDe";
      this.dataGridViewTextBoxColumn4.HeaderText = "DescriptionDe";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "DescriptionIt";
      this.dataGridViewTextBoxColumn5.HeaderText = "DescriptionIt";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.Width = 400;
      // 
      // treatmentBindingSource
      // 
      this.treatmentBindingSource.DataSource = typeof(FisioHelp.DataModels.Treatment);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.textBoxAddressDe);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.textBoxIban);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.textBoxCf);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.textBoxPiva);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.textBoxEmail);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.textBoxAddress);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.textBoxName);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F);
      this.groupBox2.Location = new System.Drawing.Point(18, 13);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(342, 256);
      this.groupBox2.TabIndex = 31;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Generale";
      // 
      // textBoxIban
      // 
      this.textBoxIban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxIban.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxIban.Location = new System.Drawing.Point(89, 222);
      this.textBoxIban.Name = "textBoxIban";
      this.textBoxIban.Size = new System.Drawing.Size(247, 27);
      this.textBoxIban.TabIndex = 25;
      // 
      // label6
      // 
      this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(10, 225);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(33, 17);
      this.label6.TabIndex = 24;
      this.label6.Text = "Iban";
      // 
      // textBoxCf
      // 
      this.textBoxCf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxCf.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxCf.Location = new System.Drawing.Point(89, 189);
      this.textBoxCf.Name = "textBoxCf";
      this.textBoxCf.Size = new System.Drawing.Size(247, 27);
      this.textBoxCf.TabIndex = 23;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(10, 192);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(28, 17);
      this.label5.TabIndex = 22;
      this.label5.Text = "C.F.";
      // 
      // textBoxPiva
      // 
      this.textBoxPiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxPiva.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxPiva.Location = new System.Drawing.Point(89, 156);
      this.textBoxPiva.Name = "textBoxPiva";
      this.textBoxPiva.Size = new System.Drawing.Size(247, 27);
      this.textBoxPiva.TabIndex = 21;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(10, 159);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 17);
      this.label4.TabIndex = 20;
      this.label4.Text = "P.IVA";
      // 
      // textBoxEmail
      // 
      this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxEmail.Location = new System.Drawing.Point(89, 123);
      this.textBoxEmail.Name = "textBoxEmail";
      this.textBoxEmail.Size = new System.Drawing.Size(247, 27);
      this.textBoxEmail.TabIndex = 19;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(8, 126);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(39, 17);
      this.label3.TabIndex = 18;
      this.label3.Text = "Email";
      // 
      // textBoxAddress
      // 
      this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxAddress.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxAddress.Location = new System.Drawing.Point(89, 57);
      this.textBoxAddress.Name = "textBoxAddress";
      this.textBoxAddress.Size = new System.Drawing.Size(247, 27);
      this.textBoxAddress.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(10, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(68, 17);
      this.label2.TabIndex = 16;
      this.label2.Text = "Indirizzo It";
      // 
      // textBoxName
      // 
      this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxName.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxName.Location = new System.Drawing.Point(89, 24);
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.Size = new System.Drawing.Size(247, 27);
      this.textBoxName.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(10, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(44, 17);
      this.label1.TabIndex = 14;
      this.label1.Text = "Nome";
      // 
      // textBoxAddressDe
      // 
      this.textBoxAddressDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.textBoxAddressDe.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxAddressDe.Location = new System.Drawing.Point(89, 90);
      this.textBoxAddressDe.Name = "textBoxAddressDe";
      this.textBoxAddressDe.Size = new System.Drawing.Size(247, 27);
      this.textBoxAddressDe.TabIndex = 3;
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(10, 93);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(77, 17);
      this.label7.TabIndex = 26;
      this.label7.Text = "Indirizzo De";
      // 
      // Setting
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1034, 513);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pricelis);
      this.Controls.Add(this.buttonSave);
      this.Name = "Setting";
      this.Text = "Setting";
      this.Load += new System.EventHandler(this.Setting_Load);
      this.pricelis.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource)).EndInit();
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.GroupBox pricelis;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.BindingSource priceListBindingSource;
    private System.Windows.Forms.BindingSource treatmentBindingSource;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView dataGridView2;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox textBoxIban;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox textBoxCf;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxPiva;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBoxEmail;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxAddress;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Indice;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.TextBox textBoxAddressDe;
    private System.Windows.Forms.Label label7;
  }
}