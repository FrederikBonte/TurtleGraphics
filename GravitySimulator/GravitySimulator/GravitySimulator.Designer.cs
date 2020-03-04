namespace GravitySimulator
{
    partial class GravitySimulator
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAltitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.proFuel = new System.Windows.Forms.ProgressBar();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnInc = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.lblCrashed = new System.Windows.Forms.Label();
            this.lblLanded = new System.Windows.Forms.Label();
            this.trkThrust = new System.Windows.Forms.TrackBar();
            this.btnReset = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.landerGraphics1 = new GravitySimulator.LanderGraphics();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkThrust)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Altitude :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 512);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtAltitude, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSpeed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.proFuel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnMax, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnInc, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnDec, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnOff, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblCrashed, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblLanded, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.trkThrust, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnReset, 1, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 360);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtAltitude
            // 
            this.txtAltitude.Location = new System.Drawing.Point(126, 3);
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.ReadOnly = true;
            this.txtAltitude.Size = new System.Drawing.Size(117, 20);
            this.txtAltitude.TabIndex = 1;
            this.txtAltitude.TabStop = false;
            this.txtAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Speed :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpeed
            // 
            this.txtSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpeed.Location = new System.Drawing.Point(126, 33);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.ReadOnly = true;
            this.txtSpeed.Size = new System.Drawing.Size(117, 20);
            this.txtSpeed.TabIndex = 3;
            this.txtSpeed.TabStop = false;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fuel :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // proFuel
            // 
            this.proFuel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proFuel.Location = new System.Drawing.Point(126, 63);
            this.proFuel.Maximum = 20000;
            this.proFuel.Name = "proFuel";
            this.proFuel.Size = new System.Drawing.Size(117, 24);
            this.proFuel.TabIndex = 5;
            this.proFuel.Value = 20000;
            // 
            // btnMax
            // 
            this.btnMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMax.Location = new System.Drawing.Point(126, 93);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(117, 24);
            this.btnMax.TabIndex = 6;
            this.btnMax.Text = "Max";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnInc
            // 
            this.btnInc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInc.Location = new System.Drawing.Point(126, 123);
            this.btnInc.Name = "btnInc";
            this.btnInc.Size = new System.Drawing.Size(117, 24);
            this.btnInc.TabIndex = 7;
            this.btnInc.Text = "+ 1";
            this.btnInc.UseVisualStyleBackColor = true;
            this.btnInc.Click += new System.EventHandler(this.btnInc_Click);
            // 
            // btnDec
            // 
            this.btnDec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDec.Location = new System.Drawing.Point(126, 153);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(117, 24);
            this.btnDec.TabIndex = 8;
            this.btnDec.Text = "- 1";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // btnOff
            // 
            this.btnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOff.Location = new System.Drawing.Point(126, 183);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(117, 24);
            this.btnOff.TabIndex = 9;
            this.btnOff.Text = "Off";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // lblCrashed
            // 
            this.lblCrashed.AutoSize = true;
            this.lblCrashed.BackColor = System.Drawing.Color.Red;
            this.lblCrashed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrashed.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrashed.Location = new System.Drawing.Point(3, 210);
            this.lblCrashed.Name = "lblCrashed";
            this.lblCrashed.Size = new System.Drawing.Size(117, 30);
            this.lblCrashed.TabIndex = 10;
            this.lblCrashed.Text = "Crashed";
            this.lblCrashed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLanded
            // 
            this.lblLanded.AutoSize = true;
            this.lblLanded.BackColor = System.Drawing.Color.Lime;
            this.lblLanded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLanded.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanded.Location = new System.Drawing.Point(126, 210);
            this.lblLanded.Name = "lblLanded";
            this.lblLanded.Size = new System.Drawing.Size(117, 30);
            this.lblLanded.TabIndex = 11;
            this.lblLanded.Text = "Landed";
            this.lblLanded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trkThrust
            // 
            this.trkThrust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkThrust.Location = new System.Drawing.Point(126, 243);
            this.trkThrust.Name = "trkThrust";
            this.trkThrust.Size = new System.Drawing.Size(117, 24);
            this.trkThrust.TabIndex = 12;
            this.trkThrust.ValueChanged += new System.EventHandler(this.trkThrust_ValueChanged);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(126, 333);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(117, 24);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // landerGraphics1
            // 
            this.landerGraphics1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.landerGraphics1.Location = new System.Drawing.Point(266, 0);
            this.landerGraphics1.Name = "landerGraphics1";
            this.landerGraphics1.Size = new System.Drawing.Size(562, 512);
            this.landerGraphics1.TabIndex = 2;
            // 
            // GravitySimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.landerGraphics1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GravitySimulator";
            this.Size = new System.Drawing.Size(828, 512);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkThrust)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtAltitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar proFuel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnInc;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Label lblCrashed;
        private System.Windows.Forms.Label lblLanded;
        private System.Windows.Forms.TrackBar trkThrust;
        private LanderGraphics landerGraphics1;
        private System.Windows.Forms.Button btnReset;
    }
}
