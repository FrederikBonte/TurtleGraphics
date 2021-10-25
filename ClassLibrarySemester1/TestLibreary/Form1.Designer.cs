
namespace TestLibrary
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
            this.btnStar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDrunkTurtle = new System.Windows.Forms.Button();
            this.btnFractal = new System.Windows.Forms.Button();
            this.btnMoveRandom = new System.Windows.Forms.Button();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.tp = new ROCvanTwente.Sumpel.Semester1.TurtleDrawing.TurtlePainter();
            this.blizzard1 = new ROCvanTwente.Sumpel.Semester2.Snowflakes.Blizzard();
            this.noiseMap1 = new ROCvanTwente.Sumpel.Semester2.Noise.NoiseMap();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(3, 3);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(75, 23);
            this.btnStar.TabIndex = 1;
            this.btnStar.Text = "Star turtle";
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnStar);
            this.flowLayoutPanel1.Controls.Add(this.btnDrunkTurtle);
            this.flowLayoutPanel1.Controls.Add(this.btnFractal);
            this.flowLayoutPanel1.Controls.Add(this.btnMoveRandom);
            this.flowLayoutPanel1.Controls.Add(this.txtProgram);
            this.flowLayoutPanel1.Controls.Add(this.btnParse);
            this.flowLayoutPanel1.Controls.Add(this.btnSquare);
            this.flowLayoutPanel1.Controls.Add(this.blizzard1);
            this.flowLayoutPanel1.Controls.Add(this.noiseMap1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 698);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnDrunkTurtle
            // 
            this.btnDrunkTurtle.Location = new System.Drawing.Point(3, 32);
            this.btnDrunkTurtle.Name = "btnDrunkTurtle";
            this.btnDrunkTurtle.Size = new System.Drawing.Size(75, 23);
            this.btnDrunkTurtle.TabIndex = 2;
            this.btnDrunkTurtle.Text = "Druk turtle\r\n";
            this.btnDrunkTurtle.UseVisualStyleBackColor = true;
            this.btnDrunkTurtle.Click += new System.EventHandler(this.btnDrunkTurtle_Click);
            // 
            // btnFractal
            // 
            this.btnFractal.Location = new System.Drawing.Point(3, 61);
            this.btnFractal.Name = "btnFractal";
            this.btnFractal.Size = new System.Drawing.Size(75, 23);
            this.btnFractal.TabIndex = 3;
            this.btnFractal.Text = "Fractal";
            this.btnFractal.UseVisualStyleBackColor = true;
            this.btnFractal.Click += new System.EventHandler(this.btnFractal_Click);
            // 
            // btnMoveRandom
            // 
            this.btnMoveRandom.Location = new System.Drawing.Point(3, 90);
            this.btnMoveRandom.Name = "btnMoveRandom";
            this.btnMoveRandom.Size = new System.Drawing.Size(75, 23);
            this.btnMoveRandom.TabIndex = 4;
            this.btnMoveRandom.Text = "Move random";
            this.btnMoveRandom.UseVisualStyleBackColor = true;
            this.btnMoveRandom.Click += new System.EventHandler(this.btnMoveRandom_Click);
            // 
            // txtProgram
            // 
            this.txtProgram.Location = new System.Drawing.Point(3, 119);
            this.txtProgram.Multiline = true;
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.Size = new System.Drawing.Size(121, 236);
            this.txtProgram.TabIndex = 5;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(3, 361);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 6;
            this.btnParse.Text = "Read program";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.Location = new System.Drawing.Point(3, 390);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(101, 34);
            this.btnSquare.TabIndex = 3;
            this.btnSquare.Text = "Vierkant";
            this.btnSquare.UseVisualStyleBackColor = true;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // tp
            // 
            this.tp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tp.Location = new System.Drawing.Point(272, 0);
            this.tp.Name = "tp";
            this.tp.Size = new System.Drawing.Size(797, 698);
            this.tp.TabIndex = 0;
            // 
            // blizzard1
            // 
            this.blizzard1.BackColor = System.Drawing.Color.Black;
            this.blizzard1.Location = new System.Drawing.Point(3, 430);
            this.blizzard1.Name = "blizzard1";
            this.blizzard1.Size = new System.Drawing.Size(263, 152);
            this.blizzard1.TabIndex = 7;
            // 
            // noiseMap1
            // 
            this.noiseMap1.Location = new System.Drawing.Point(3, 588);
            this.noiseMap1.Name = "noiseMap1";
            this.noiseMap1.Size = new System.Drawing.Size(263, 94);
            this.noiseMap1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 698);
            this.Controls.Add(this.tp);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ROCvanTwente.Sumpel.Semester1.TurtleDrawing.TurtlePainter tp;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDrunkTurtle;
        private System.Windows.Forms.Button btnFractal;
        private System.Windows.Forms.Button btnMoveRandom;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnSquare;
        private ROCvanTwente.Sumpel.Semester2.Snowflakes.Blizzard blizzard1;
        private ROCvanTwente.Sumpel.Semester2.Noise.NoiseMap noiseMap1;
    }
}

