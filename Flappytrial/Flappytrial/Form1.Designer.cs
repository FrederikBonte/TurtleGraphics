
namespace Flappytrial
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
            this.components = new System.ComponentModel.Container();
            this.picFloor = new System.Windows.Forms.PictureBox();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.picBird = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBird)).BeginInit();
            this.SuspendLayout();
            // 
            // picFloor
            // 
            this.picFloor.BackColor = System.Drawing.Color.Transparent;
            this.picFloor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picFloor.Image = global::Flappytrial.Properties.Resources.flappy_floor;
            this.picFloor.Location = new System.Drawing.Point(0, 580);
            this.picFloor.Name = "picFloor";
            this.picFloor.Size = new System.Drawing.Size(932, 47);
            this.picFloor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFloor.TabIndex = 4;
            this.picFloor.TabStop = false;
            // 
            // picBottom
            // 
            this.picBottom.Image = global::Flappytrial.Properties.Resources.flappy_pipe_bottom;
            this.picBottom.Location = new System.Drawing.Point(198, 320);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(171, 465);
            this.picBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBottom.TabIndex = 3;
            this.picBottom.TabStop = false;
            // 
            // picTop
            // 
            this.picTop.Image = global::Flappytrial.Properties.Resources.flappy_pipe_top;
            this.picTop.Location = new System.Drawing.Point(369, -268);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(184, 525);
            this.picTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTop.TabIndex = 2;
            this.picTop.TabStop = false;
            // 
            // picBird
            // 
            this.picBird.Image = global::Flappytrial.Properties.Resources.flappy_bird;
            this.picBird.Location = new System.Drawing.Point(44, 249);
            this.picBird.Name = "picBird";
            this.picBird.Size = new System.Drawing.Size(66, 49);
            this.picBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBird.TabIndex = 1;
            this.picBird.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 27;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 627);
            this.Controls.Add(this.picBird);
            this.Controls.Add(this.picFloor);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.picTop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBird;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.PictureBox picFloor;
        private System.Windows.Forms.Timer timer;
    }
}

