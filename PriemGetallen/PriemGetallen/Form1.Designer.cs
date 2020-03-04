namespace PriemGetallen
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lstPrimes = new System.Windows.Forms.ListBox();
            this.btnGenereer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(403, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lstPrimes
            // 
            this.lstPrimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPrimes.FormattingEnabled = true;
            this.lstPrimes.Location = new System.Drawing.Point(0, 20);
            this.lstPrimes.Name = "lstPrimes";
            this.lstPrimes.Size = new System.Drawing.Size(403, 257);
            this.lstPrimes.TabIndex = 1;
            // 
            // btnGenereer
            // 
            this.btnGenereer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenereer.Location = new System.Drawing.Point(0, 254);
            this.btnGenereer.Name = "btnGenereer";
            this.btnGenereer.Size = new System.Drawing.Size(403, 23);
            this.btnGenereer.TabIndex = 2;
            this.btnGenereer.Text = "Genereer priemgetallen";
            this.btnGenereer.UseVisualStyleBackColor = true;
            this.btnGenereer.Click += new System.EventHandler(this.btnGenereer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 277);
            this.Controls.Add(this.btnGenereer);
            this.Controls.Add(this.lstPrimes);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox lstPrimes;
        private System.Windows.Forms.Button btnGenereer;
    }
}

