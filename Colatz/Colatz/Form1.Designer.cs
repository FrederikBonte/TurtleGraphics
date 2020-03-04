namespace Colatz
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
            this.btnColatz = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lstColatz = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnColatz
            // 
            this.btnColatz.Location = new System.Drawing.Point(13, 13);
            this.btnColatz.Name = "btnColatz";
            this.btnColatz.Size = new System.Drawing.Size(75, 23);
            this.btnColatz.TabIndex = 0;
            this.btnColatz.Text = "Colatz";
            this.btnColatz.UseVisualStyleBackColor = true;
            this.btnColatz.Click += new System.EventHandler(this.btnColatz_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(95, 13);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 1;
            // 
            // lstColatz
            // 
            this.lstColatz.FormattingEnabled = true;
            this.lstColatz.Location = new System.Drawing.Point(13, 43);
            this.lstColatz.Name = "lstColatz";
            this.lstColatz.Size = new System.Drawing.Size(182, 251);
            this.lstColatz.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aantal : ";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(65, 298);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(100, 20);
            this.txtCount.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstColatz);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnColatz);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnColatz;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.ListBox lstColatz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCount;
    }
}

