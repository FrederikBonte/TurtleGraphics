namespace HoogsteUitDeLijst
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
            this.lstNumbers = new System.Windows.Forms.ListBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnHighest = new System.Windows.Forms.Button();
            this.txtHighest = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstNumbers
            // 
            this.lstNumbers.FormattingEnabled = true;
            this.lstNumbers.Location = new System.Drawing.Point(13, 51);
            this.lstNumbers.Name = "lstNumbers";
            this.lstNumbers.Size = new System.Drawing.Size(356, 290);
            this.lstNumbers.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(13, 22);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnHighest
            // 
            this.btnHighest.Location = new System.Drawing.Point(13, 348);
            this.btnHighest.Name = "btnHighest";
            this.btnHighest.Size = new System.Drawing.Size(75, 23);
            this.btnHighest.TabIndex = 2;
            this.btnHighest.Text = "Zoek";
            this.btnHighest.UseVisualStyleBackColor = true;
            this.btnHighest.Click += new System.EventHandler(this.btnHighest_Click);
            // 
            // txtHighest
            // 
            this.txtHighest.Location = new System.Drawing.Point(95, 348);
            this.txtHighest.Name = "txtHighest";
            this.txtHighest.Size = new System.Drawing.Size(100, 20);
            this.txtHighest.TabIndex = 3;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(95, 22);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(202, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Toevoegen";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(202, 348);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtHighest);
            this.Controls.Add(this.btnHighest);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lstNumbers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstNumbers;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnHighest;
        private System.Windows.Forms.TextBox txtHighest;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSort;
    }
}

