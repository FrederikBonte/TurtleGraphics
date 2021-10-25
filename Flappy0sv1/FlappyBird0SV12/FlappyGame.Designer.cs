
namespace FlappyBird0SV12
{
    partial class FlappyGame
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
            // FlappyGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(33F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FlappyBird0SV12.Properties.Resources.fb_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("GrilledCheese BTN Wide Blk", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.Margin = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.Name = "FlappyGame";
            this.Size = new System.Drawing.Size(654, 374);
            this.Load += new System.EventHandler(this.FlappyGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlappyGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlappyGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FlappyGame_KeyUp);
            this.Leave += new System.EventHandler(this.FlappyGame_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
    }
}
