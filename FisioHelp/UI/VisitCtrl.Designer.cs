namespace FisioHelp.UI
{
  partial class VisitCtrl
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
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.richTextBoxExInitial = new RichTextBoxEx.RichTextBoxEx();
      this.textBoxPrice = new System.Windows.Forms.TextBox();
      this.buttonSave = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
      this.richTextBoxExFinal = new RichTextBoxEx.RichTextBoxEx();
      this.label5 = new System.Windows.Forms.Label();
      this.textBoxTime = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // richTextBoxExInitial
      // 
      this.richTextBoxExInitial.AllowBullets = true;
      this.richTextBoxExInitial.AllowDefaultInsertText = true;
      this.richTextBoxExInitial.AllowDefaultSmartText = true;
      this.richTextBoxExInitial.AllowHyphenation = true;
      this.richTextBoxExInitial.AllowPictures = true;
      this.richTextBoxExInitial.AllowSpellCheck = true;
      this.richTextBoxExInitial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxExInitial.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
      this.richTextBoxExInitial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.richTextBoxExInitial.FilePath = "";
      this.richTextBoxExInitial.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.richTextBoxExInitial.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.richTextBoxExInitial.Location = new System.Drawing.Point(132, 220);
      this.richTextBoxExInitial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.richTextBoxExInitial.Name = "richTextBoxExInitial";
      this.richTextBoxExInitial.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1040{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI Hi" +
    "storic;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs23\\par\r\n}\r\n";
      this.richTextBoxExInitial.SetColorWithFont = true;
      this.richTextBoxExInitial.ShowToolStrip = true;
      this.richTextBoxExInitial.Size = new System.Drawing.Size(754, 131);
      this.richTextBoxExInitial.TabIndex = 27;
      // 
      // textBoxPrice
      // 
      this.textBoxPrice.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxPrice.Location = new System.Drawing.Point(752, 72);
      this.textBoxPrice.Name = "textBoxPrice";
      this.textBoxPrice.Size = new System.Drawing.Size(108, 27);
      this.textBoxPrice.TabIndex = 12;
      this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxPrice_TextChanged);
      // 
      // buttonSave
      // 
      this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
      this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonSave.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonSave.ForeColor = System.Drawing.Color.White;
      this.buttonSave.Location = new System.Drawing.Point(780, 548);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(106, 38);
      this.buttonSave.TabIndex = 26;
      this.buttonSave.Text = "Save";
      this.buttonSave.UseVisualStyleBackColor = false;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // label4
      // 
      this.label4.AllowDrop = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label4.Location = new System.Drawing.Point(33, 220);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 80);
      this.label4.TabIndex = 24;
      this.label4.Text = "Pre Visita";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label1.Location = new System.Drawing.Point(693, 77);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 20);
      this.label1.TabIndex = 28;
      this.label1.Text = "Prezzo";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label2.Location = new System.Drawing.Point(34, 142);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 20);
      this.label2.TabIndex = 29;
      this.label2.Text = "Trattamenti";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label3.Location = new System.Drawing.Point(33, 80);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 20);
      this.label3.TabIndex = 31;
      this.label3.Text = "Data";
      // 
      // dateTimePicker1
      // 
      this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.dateTimePicker1.Location = new System.Drawing.Point(132, 75);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new System.Drawing.Size(222, 27);
      this.dateTimePicker1.TabIndex = 32;
      // 
      // richTextBoxExFinal
      // 
      this.richTextBoxExFinal.AllowBullets = true;
      this.richTextBoxExFinal.AllowDefaultInsertText = true;
      this.richTextBoxExFinal.AllowDefaultSmartText = true;
      this.richTextBoxExFinal.AllowHyphenation = true;
      this.richTextBoxExFinal.AllowPictures = true;
      this.richTextBoxExFinal.AllowSpellCheck = true;
      this.richTextBoxExFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxExFinal.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
      this.richTextBoxExFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.richTextBoxExFinal.FilePath = "";
      this.richTextBoxExFinal.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.richTextBoxExFinal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.richTextBoxExFinal.Location = new System.Drawing.Point(133, 361);
      this.richTextBoxExFinal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.richTextBoxExFinal.Name = "richTextBoxExFinal";
      this.richTextBoxExFinal.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1040{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI Hi" +
    "storic;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs23\\par\r\n}\r\n";
      this.richTextBoxExFinal.SetColorWithFont = true;
      this.richTextBoxExFinal.ShowToolStrip = true;
      this.richTextBoxExFinal.Size = new System.Drawing.Size(754, 179);
      this.richTextBoxExFinal.TabIndex = 34;
      // 
      // label5
      // 
      this.label5.AllowDrop = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label5.Location = new System.Drawing.Point(34, 361);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(92, 147);
      this.label5.TabIndex = 33;
      this.label5.Text = "Conclusioni";
      // 
      // textBoxTime
      // 
      this.textBoxTime.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.textBoxTime.Location = new System.Drawing.Point(482, 72);
      this.textBoxTime.Name = "textBoxTime";
      this.textBoxTime.Size = new System.Drawing.Size(123, 27);
      this.textBoxTime.TabIndex = 36;
      this.textBoxTime.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTime_Validating);
      this.textBoxTime.Validated += new System.EventHandler(this.textBoxTime_Validated);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.label6.Location = new System.Drawing.Point(406, 77);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(51, 20);
      this.label6.TabIndex = 35;
      this.label6.Text = "Orario";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(33, 25);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(72, 25);
      this.label7.TabIndex = 37;
      this.label7.Text = "VISITA";
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.checkedListBox1.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F);
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new System.Drawing.Point(133, 142);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(753, 70);
      this.checkedListBox1.TabIndex = 38;
      this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
      // 
      // VisitCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.checkedListBox1);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.textBoxTime);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.richTextBoxExFinal);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.dateTimePicker1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.richTextBoxExInitial);
      this.Controls.Add(this.textBoxPrice);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.label4);
      this.Name = "VisitCtrl";
      this.Size = new System.Drawing.Size(923, 611);
      this.Load += new System.EventHandler(this.VisitCtrl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.TextBox textBoxTime;
    private System.Windows.Forms.Label label6;
    private RichTextBoxEx.RichTextBoxEx richTextBoxExFinal;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private RichTextBoxEx.RichTextBoxEx richTextBoxExInitial;
    private System.Windows.Forms.TextBox textBoxPrice;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
  }
}
