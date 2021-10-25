
namespace FlappyTrial2
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
            this.flappyViewer1 = new FlappyTrial2.FlappyViewer();
            this.SuspendLayout();
            // 
            // flappyViewer1
            // 
            this.flappyViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flappyViewer1.Location = new System.Drawing.Point(0, 0);
            this.flappyViewer1.Name = "flappyViewer1";
            this.flappyViewer1.Size = new System.Drawing.Size(1101, 746);
            this.flappyViewer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 746);
            this.Controls.Add(this.flappyViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private FlappyViewer flappyViewer1;
    }
}

