﻿namespace Projections
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
            this.projectionRenderer1 = new Projections.ProjectionRenderer();
            this.btnPoint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // projectionRenderer1
            // 
            this.projectionRenderer1.Location = new System.Drawing.Point(13, 13);
            this.projectionRenderer1.Name = "projectionRenderer1";
            this.projectionRenderer1.Size = new System.Drawing.Size(656, 484);
            this.projectionRenderer1.TabIndex = 0;
            // 
            // btnPoint
            // 
            this.btnPoint.Location = new System.Drawing.Point(676, 13);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(75, 23);
            this.btnPoint.TabIndex = 1;
            this.btnPoint.Text = "Add Point";
            this.btnPoint.UseVisualStyleBackColor = true;
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 536);
            this.Controls.Add(this.btnPoint);
            this.Controls.Add(this.projectionRenderer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ProjectionRenderer projectionRenderer1;
        private System.Windows.Forms.Button btnPoint;
    }
}

