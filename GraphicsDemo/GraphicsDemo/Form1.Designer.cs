namespace GraphicsDemo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numSeed = new System.Windows.Forms.NumericUpDown();
            this.trkMinSize = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trkStartSize = new System.Windows.Forms.TrackBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.numRandFactor = new System.Windows.Forms.NumericUpDown();
            this.frederiksControl1 = new GraphicsDemo.FrederiksControl();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkStartSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 516);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numSeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trkMinSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.trkStartSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numRandFactor, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(266, 338);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Random seed :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimum size :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSeed
            // 
            this.numSeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSeed.Location = new System.Drawing.Point(136, 3);
            this.numSeed.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numSeed.Name = "numSeed";
            this.numSeed.Size = new System.Drawing.Size(127, 20);
            this.numSeed.TabIndex = 3;
            this.numSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSeed.Value = new decimal(new int[] {
            12345,
            0,
            0,
            0});
            this.numSeed.ValueChanged += new System.EventHandler(this.NumSeed_ValueChanged);
            // 
            // trkMinSize
            // 
            this.trkMinSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkMinSize.Location = new System.Drawing.Point(136, 35);
            this.trkMinSize.Name = "trkMinSize";
            this.trkMinSize.Size = new System.Drawing.Size(127, 26);
            this.trkMinSize.TabIndex = 4;
            this.trkMinSize.ValueChanged += new System.EventHandler(this.TrkMinSize_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Starting size :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trkStartSize
            // 
            this.trkStartSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkStartSize.Location = new System.Drawing.Point(136, 67);
            this.trkStartSize.Name = "trkStartSize";
            this.trkStartSize.Size = new System.Drawing.Size(127, 26);
            this.trkStartSize.TabIndex = 6;
            this.trkStartSize.Value = 6;
            this.trkStartSize.Scroll += new System.EventHandler(this.TrkStartSize_Scroll);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(3, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 26);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save picture";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "c:\\temp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Random factor :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numRandFactor
            // 
            this.numRandFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numRandFactor.Location = new System.Drawing.Point(136, 131);
            this.numRandFactor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRandFactor.Name = "numRandFactor";
            this.numRandFactor.Size = new System.Drawing.Size(127, 20);
            this.numRandFactor.TabIndex = 9;
            this.numRandFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRandFactor.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRandFactor.ValueChanged += new System.EventHandler(this.NumRandFactor_ValueChanged);
            // 
            // frederiksControl1
            // 
            this.frederiksControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frederiksControl1.Location = new System.Drawing.Point(266, 0);
            this.frederiksControl1.Name = "frederiksControl1";
            this.frederiksControl1.Size = new System.Drawing.Size(711, 516);
            this.frederiksControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 516);
            this.Controls.Add(this.frederiksControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkStartSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FrederiksControl frederiksControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSeed;
        private System.Windows.Forms.TrackBar trkMinSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trkStartSize;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numRandFactor;
    }
}

