namespace SQLEditor
{
    partial class Settings
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.trkSpeechRate = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lstVerbosity = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeechRate)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.trkSpeechRate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstVerbosity, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speech rate :";
            // 
            // trkSpeechRate
            // 
            this.trkSpeechRate.AccessibleDescription = "The speed at which text is spoken";
            this.trkSpeechRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkSpeechRate.Location = new System.Drawing.Point(403, 3);
            this.trkSpeechRate.Minimum = -10;
            this.trkSpeechRate.Name = "trkSpeechRate";
            this.trkSpeechRate.Size = new System.Drawing.Size(394, 26);
            this.trkSpeechRate.TabIndex = 1;
            this.trkSpeechRate.Value = 5;
            this.trkSpeechRate.ValueChanged += new System.EventHandler(this.trkSpeechRate_ValueChanged);
            this.trkSpeechRate.Enter += new System.EventHandler(this.sayselection);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Verbosity : ";
            // 
            // lstVerbosity
            // 
            this.lstVerbosity.AccessibleDescription = "How chatty do you want the system to be?";
            this.lstVerbosity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVerbosity.FormattingEnabled = true;
            this.lstVerbosity.Items.AddRange(new object[] {
            "SILENT",
            "MINIMAL",
            "VERBOSE",
            "POLITE"});
            this.lstVerbosity.Location = new System.Drawing.Point(403, 35);
            this.lstVerbosity.Name = "lstVerbosity";
            this.lstVerbosity.Size = new System.Drawing.Size(394, 26);
            this.lstVerbosity.TabIndex = 3;
            this.lstVerbosity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstVerbosity_MouseClick);
            this.lstVerbosity.Enter += new System.EventHandler(this.sayselection);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeechRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkSpeechRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstVerbosity;
    }
}