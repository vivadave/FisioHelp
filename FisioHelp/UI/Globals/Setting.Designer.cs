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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.dataGridView2 = new System.Windows.Forms.DataGridView();
      this.priceListBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.treatmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.Indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pricelis.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonSave
      // 
      this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSave.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.ForeColor = System.Drawing.Color.White;
      this.buttonSave.Location = new System.Drawing.Point(655, 424);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(106, 38);
      this.buttonSave.TabIndex = 28;
      this.buttonSave.Text = "Save";
      this.buttonSave.UseVisualStyleBackColor = false;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // pricelis
      // 
      this.pricelis.Controls.Add(this.dataGridView1);
      this.pricelis.Location = new System.Drawing.Point(13, 13);
      this.pricelis.Name = "pricelis";
      this.pricelis.Size = new System.Drawing.Size(748, 199);
      this.pricelis.TabIndex = 29;
      this.pricelis.TabStop = false;
      this.pricelis.Text = "Price List";
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
      this.dataGridView1.Size = new System.Drawing.Size(718, 174);
      this.dataGridView1.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.dataGridView2);
      this.groupBox1.Location = new System.Drawing.Point(12, 218);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(749, 199);
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
      this.dataGridView2.Size = new System.Drawing.Size(719, 174);
      this.dataGridView2.TabIndex = 0;
      // 
      // priceListBindingSource
      // 
      this.priceListBindingSource.DataSource = typeof(DataModels.PriceList);
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
      // treatmentBindingSource
      // 
      this.treatmentBindingSource.DataSource = typeof(FisioHelp.DataModels.Treatment);
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
      // 
      // Setting
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(773, 474);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pricelis);
      this.Controls.Add(this.buttonSave);
      this.Name = "Setting";
      this.Text = "Setting";
      this.Load += new System.EventHandler(this.Setting_Load);
      this.pricelis.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.priceListBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).EndInit();
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
    private System.Windows.Forms.DataGridViewTextBoxColumn Indice;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
  }
}