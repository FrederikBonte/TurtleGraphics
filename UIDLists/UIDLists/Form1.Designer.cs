namespace UIDLists
{
    partial class Form1
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
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.lstFont = new System.Windows.Forms.ListBox();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtExample = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numSize
            // 
            this.numSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSize.Location = new System.Drawing.Point(621, 3);
            this.numSize.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(304, 38);
            this.numSize.TabIndex = 0;
            this.numSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // lstFont
            // 
            this.lstFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFont.FormattingEnabled = true;
            this.lstFont.ItemHeight = 31;
            this.lstFont.Items.AddRange(new object[] {
            "Arial",
            "Blackadder ITC",
            "Broadway",
            "Bookman Old Style",
            "Comic Sans MS",
            "Consolas",
            "Times New Roman",
            "Courier New",
            "Gigi",
            "Fnurk!",
            "Verdana"});
            this.lstFont.Location = new System.Drawing.Point(3, 3);
            this.lstFont.Name = "lstFont";
            this.lstFont.Size = new System.Drawing.Size(303, 152);
            this.lstFont.TabIndex = 1;
            // 
            // cmbStyle
            // 
            this.cmbStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Items.AddRange(new object[] {
            "Regular",
            "Bold",
            "Italics",
            "Bold & Italics"});
            this.cmbStyle.Location = new System.Drawing.Point(312, 3);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(303, 39);
            this.cmbStyle.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lstFont, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numSize, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtExample, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbStyle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 254);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(621, 207);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(304, 44);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtExample
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtExample, 3);
            this.txtExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExample.Location = new System.Drawing.Point(3, 161);
            this.txtExample.Name = "txtExample";
            this.txtExample.Size = new System.Drawing.Size(922, 40);
            this.txtExample.TabIndex = 5;
            this.txtExample.Text = "Dit is een voorbeeld tekst";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 254);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.ListBox lstFont;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtExample;
    }
}

