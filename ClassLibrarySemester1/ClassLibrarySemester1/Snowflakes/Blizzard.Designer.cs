
namespace ROCvanTwente.Sumpel.Semester2.Snowflakes
{
    partial class Blizzard
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
            this.timer.Interval = 27;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Blizzard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.DoubleBuffered = true;
            this.Name = "Blizzard";
            this.Size = new System.Drawing.Size(431, 300);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Blizzard_Paint);
            this.Resize += new System.EventHandler(this.Blizzard_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
    }
}
