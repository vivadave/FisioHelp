namespace FisioHelp.UI
{
  partial class MultipleVisits
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
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxPrice = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonSave = new System.Windows.Forms.Button();
      this.labelSingleVisit = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label1.Location = new System.Drawing.Point(317, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(99, 20);
      this.label1.TabIndex = 30;
      this.label1.Text = "Prezzo Totale";
      // 
      // textBoxPrice
      // 
      this.textBoxPrice.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxPrice.Location = new System.Drawing.Point(422, 26);
      this.textBoxPrice.Name = "textBoxPrice";
      this.textBoxPrice.Size = new System.Drawing.Size(120, 27);
      this.textBoxPrice.TabIndex = 29;
      this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxPrice_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label2.Location = new System.Drawing.Point(26, 28);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(118, 20);
      this.label2.TabIndex = 32;
      this.label2.Text = "Numero di visite";
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.numericUpDown1.Location = new System.Drawing.Point(150, 26);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(120, 27);
      this.numericUpDown1.TabIndex = 33;
      this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.checkedListBox1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new System.Drawing.Point(150, 71);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(528, 70);
      this.checkedListBox1.TabIndex = 40;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label3.Location = new System.Drawing.Point(26, 71);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(86, 20);
      this.label3.TabIndex = 39;
      this.label3.Text = "Trattamenti";
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonCancel.ForeColor = System.Drawing.Color.White;
      this.buttonCancel.Location = new System.Drawing.Point(572, 156);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(106, 38);
      this.buttonCancel.TabIndex = 42;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = false;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonSave
      // 
      this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSave.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.ForeColor = System.Drawing.Color.White;
      this.buttonSave.Location = new System.Drawing.Point(460, 156);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(106, 38);
      this.buttonSave.TabIndex = 41;
      this.buttonSave.Text = "Crea";
      this.buttonSave.UseVisualStyleBackColor = false;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // labelSingleVisit
      // 
      this.labelSingleVisit.AutoSize = true;
      this.labelSingleVisit.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.labelSingleVisit.Location = new System.Drawing.Point(562, 29);
      this.labelSingleVisit.Name = "labelSingleVisit";
      this.labelSingleVisit.Size = new System.Drawing.Size(101, 20);
      this.labelSingleVisit.TabIndex = 43;
      this.labelSingleVisit.Text = "( 70€ a visita )";
      // 
      // MultipleVisits
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(698, 209);
      this.Controls.Add(this.labelSingleVisit);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.checkedListBox1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.numericUpDown1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBoxPrice);
      this.Name = "MultipleVisits";
      this.Text = "Visite Multiple";
      this.Load += new System.EventHandler(this.MultipleVisits_Load);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSingleVisit;
    }
}