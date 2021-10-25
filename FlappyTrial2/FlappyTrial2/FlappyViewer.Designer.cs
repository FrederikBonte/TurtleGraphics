
namespace FlappyTrial2
{
    partial class FlappyViewer
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
            // FlappyViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.DoubleBuffered = true;
            this.Name = "FlappyViewer";
            this.Size = new System.Drawing.Size(1110, 702);
            this.Load += new System.EventHandler(this.FlappyViewer_Load);
            this.VisibleChanged += new System.EventHandler(this.FlappyViewer_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FlappyViewer_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlappyViewer_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FlappyViewer_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
    }
}
