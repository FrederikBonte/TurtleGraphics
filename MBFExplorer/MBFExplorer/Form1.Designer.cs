
namespace MBFExplorer
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
            this.mandelbrotPainter1 = new MBFExplorer.MandelbrotPainter();
            this.SuspendLayout();
            // 
            // mandelbrotPainter1
            // 
            this.mandelbrotPainter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mandelbrotPainter1.Location = new System.Drawing.Point(0, 0);
            this.mandelbrotPainter1.MaximumSize = new System.Drawing.Size(800, 450);
            this.mandelbrotPainter1.MinimumSize = new System.Drawing.Size(800, 450);
            this.mandelbrotPainter1.Name = "mandelbrotPainter1";
            this.mandelbrotPainter1.Size = new System.Drawing.Size(800, 450);
            this.mandelbrotPainter1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(803, 452);
            this.Controls.Add(this.mandelbrotPainter1);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MandelbrotPainter mandelbrotPainter1;
    }
}

