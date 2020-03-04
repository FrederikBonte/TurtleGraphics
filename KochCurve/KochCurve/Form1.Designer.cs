namespace KochCurve
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
            this.kochCurve1 = new KochCurve();
            this.btnRefine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kochCurve1
            // 
            this.kochCurve1.Location = new System.Drawing.Point(13, 13);
            this.kochCurve1.Name = "kochCurve1";
            this.kochCurve1.Size = new System.Drawing.Size(842, 539);
            this.kochCurve1.TabIndex = 0;
            // 
            // btnRefine
            // 
            this.btnRefine.Location = new System.Drawing.Point(13, 559);
            this.btnRefine.Name = "btnRefine";
            this.btnRefine.Size = new System.Drawing.Size(75, 23);
            this.btnRefine.TabIndex = 1;
            this.btnRefine.Text = "Refine";
            this.btnRefine.UseVisualStyleBackColor = true;
            this.btnRefine.Click += new System.EventHandler(this.btnRefine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 639);
            this.Controls.Add(this.btnRefine);
            this.Controls.Add(this.kochCurve1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private KochCurve kochCurve1;
        private System.Windows.Forms.Button btnRefine;
    }
}

