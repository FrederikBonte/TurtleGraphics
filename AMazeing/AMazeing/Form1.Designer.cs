namespace AMazeing
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trkSpeed = new System.Windows.Forms.TrackBar();
            this.btnDemo = new System.Windows.Forms.Button();
            this.txtConstitution = new System.Windows.Forms.TextBox();
            this.txtStrength = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.maze1 = new AMazeing.Maze();
            this.demoTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.trkSpeed);
            this.panel1.Controls.Add(this.btnDemo);
            this.panel1.Controls.Add(this.txtConstitution);
            this.panel1.Controls.Add(this.txtStrength);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 473);
            this.panel1.TabIndex = 2;
            // 
            // trkSpeed
            // 
            this.trkSpeed.Location = new System.Drawing.Point(12, 156);
            this.trkSpeed.Maximum = 100;
            this.trkSpeed.Minimum = 5;
            this.trkSpeed.Name = "trkSpeed";
            this.trkSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trkSpeed.Size = new System.Drawing.Size(104, 45);
            this.trkSpeed.TabIndex = 6;
            this.trkSpeed.Value = 5;
            this.trkSpeed.Scroll += new System.EventHandler(this.trkSpeed_Scroll);
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(12, 126);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(75, 23);
            this.btnDemo.TabIndex = 5;
            this.btnDemo.Text = "Demo";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // txtConstitution
            // 
            this.txtConstitution.Enabled = false;
            this.txtConstitution.Location = new System.Drawing.Point(13, 99);
            this.txtConstitution.Name = "txtConstitution";
            this.txtConstitution.Size = new System.Drawing.Size(100, 20);
            this.txtConstitution.TabIndex = 4;
            // 
            // txtStrength
            // 
            this.txtStrength.Enabled = false;
            this.txtStrength.Location = new System.Drawing.Point(13, 72);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(100, 20);
            this.txtStrength.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.maze1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(124, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 473);
            this.panel2.TabIndex = 3;
            // 
            // maze1
            // 
            this.maze1.AutoScroll = true;
            this.maze1.Generate = AMazeing.Maze.GenerateAlgorithm.KRUSKAL;
            this.maze1.Location = new System.Drawing.Point(0, 0);
            this.maze1.Name = "maze1";
            this.maze1.Size = new System.Drawing.Size(1104, 736);
            this.maze1.SizeX = 34;
            this.maze1.SizeY = 15;
            this.maze1.TabIndex = 0;
            this.maze1.Treasure = true;
            this.maze1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maze1_KeyDown);
            // 
            // demoTimer
            // 
            this.demoTimer.Enabled = true;
            this.demoTimer.Interval = 1000;
            this.demoTimer.Tick += new System.EventHandler(this.demoTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 473);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeed)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtConstitution;
        private System.Windows.Forms.TextBox txtStrength;
        private Maze maze1;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Timer demoTimer;
        private System.Windows.Forms.TrackBar trkSpeed;
    }
}