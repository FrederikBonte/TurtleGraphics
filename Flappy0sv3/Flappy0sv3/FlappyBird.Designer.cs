
namespace Flappy0sv3
{
    partial class FlappyBird
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 83;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FlappyBird
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(31F, 44F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Flappy0sv3.Properties.Resources.fb_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("GrilledCheese BTN Wide Blk", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.Name = "FlappyBird";
            this.Size = new System.Drawing.Size(771, 406);
            this.Load += new System.EventHandler(this.FlappyBird_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlappyBird_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlappyBird_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FlappyBird_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
    }
}
