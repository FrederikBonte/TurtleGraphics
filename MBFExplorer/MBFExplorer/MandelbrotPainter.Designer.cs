
namespace MBFExplorer
{
    partial class MandelbrotPainter
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
            this.timer.Interval = 127;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MandelbrotPainter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MandelbrotPainter";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.MandelbrotRenderer_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MandelbrotRenderer_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MandelbrotPainter_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MandelbrotPainter_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
    }
}
