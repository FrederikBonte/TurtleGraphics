
namespace FlappyBird0SV12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flappyGame1 = new FlappyBird0SV12.FlappyGame();
            this.SuspendLayout();
            // 
            // flappyGame1
            // 
            this.flappyGame1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flappyGame1.BackgroundImage")));
            this.flappyGame1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flappyGame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flappyGame1.Location = new System.Drawing.Point(0, 0);
            this.flappyGame1.Name = "flappyGame1";
            this.flappyGame1.Size = new System.Drawing.Size(1156, 652);
            this.flappyGame1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 652);
            this.Controls.Add(this.flappyGame1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FlappyGame flappyGame1;
    }
}

