namespace ROC.FBE02.ClockDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radRound = new System.Windows.Forms.RadioButton();
            this.radSquare = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkHourTicks = new System.Windows.Forms.CheckBox();
            this.chkMinuteTicks = new System.Windows.Forms.CheckBox();
            this.chkSeconds = new System.Windows.Forms.CheckBox();
            this.chkDitgital = new System.Windows.Forms.CheckBox();
            this.chkKoch = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sldWidth = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHours = new System.Windows.Forms.Button();
            this.btnSecondsColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.radNone = new System.Windows.Forms.RadioButton();
            this.radNumbers = new System.Windows.Forms.RadioButton();
            this.radRoman = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numPomodoro = new System.Windows.Forms.NumericUpDown();
            this.btnPomodoro = new System.Windows.Forms.Button();
            this.pnlClock = new System.Windows.Forms.Panel();
            this.dlgColors = new System.Windows.Forms.ColorDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.clockControl1 = new ROC.FBE02.ClockDemo.ClockControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldWidth)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPomodoro)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlClock);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 606);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.sldWidth, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 606);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clockface";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radRound);
            this.flowLayoutPanel1.Controls.Add(this.radSquare);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(205, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(195, 50);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // radRound
            // 
            this.radRound.AutoSize = true;
            this.radRound.Location = new System.Drawing.Point(3, 3);
            this.radRound.Name = "radRound";
            this.radRound.Size = new System.Drawing.Size(52, 17);
            this.radRound.TabIndex = 0;
            this.radRound.TabStop = true;
            this.radRound.Text = "round";
            this.radRound.UseVisualStyleBackColor = true;
            // 
            // radSquare
            // 
            this.radSquare.AutoSize = true;
            this.radSquare.Location = new System.Drawing.Point(61, 3);
            this.radSquare.Name = "radSquare";
            this.radSquare.Size = new System.Drawing.Size(57, 17);
            this.radSquare.TabIndex = 1;
            this.radSquare.TabStop = true;
            this.radSquare.Text = "square";
            this.radSquare.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Display";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.chkHourTicks);
            this.flowLayoutPanel2.Controls.Add(this.chkMinuteTicks);
            this.flowLayoutPanel2.Controls.Add(this.chkSeconds);
            this.flowLayoutPanel2.Controls.Add(this.chkDitgital);
            this.flowLayoutPanel2.Controls.Add(this.chkKoch);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(205, 61);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(195, 115);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // chkHourTicks
            // 
            this.chkHourTicks.AutoSize = true;
            this.chkHourTicks.Checked = true;
            this.chkHourTicks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHourTicks.Location = new System.Drawing.Point(3, 3);
            this.chkHourTicks.Name = "chkHourTicks";
            this.chkHourTicks.Size = new System.Drawing.Size(74, 17);
            this.chkHourTicks.TabIndex = 0;
            this.chkHourTicks.Text = "Hour ticks";
            this.chkHourTicks.UseVisualStyleBackColor = true;
            // 
            // chkMinuteTicks
            // 
            this.chkMinuteTicks.AutoSize = true;
            this.chkMinuteTicks.Checked = true;
            this.chkMinuteTicks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinuteTicks.Location = new System.Drawing.Point(83, 3);
            this.chkMinuteTicks.Name = "chkMinuteTicks";
            this.chkMinuteTicks.Size = new System.Drawing.Size(83, 17);
            this.chkMinuteTicks.TabIndex = 2;
            this.chkMinuteTicks.Text = "Minute ticks";
            this.chkMinuteTicks.UseVisualStyleBackColor = true;
            // 
            // chkSeconds
            // 
            this.chkSeconds.AutoSize = true;
            this.chkSeconds.Checked = true;
            this.chkSeconds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeconds.Location = new System.Drawing.Point(3, 26);
            this.chkSeconds.Name = "chkSeconds";
            this.chkSeconds.Size = new System.Drawing.Size(96, 17);
            this.chkSeconds.TabIndex = 3;
            this.chkSeconds.Text = "Show seconds";
            this.chkSeconds.UseVisualStyleBackColor = true;
            // 
            // chkDitgital
            // 
            this.chkDitgital.AutoSize = true;
            this.chkDitgital.Checked = true;
            this.chkDitgital.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDitgital.Location = new System.Drawing.Point(105, 26);
            this.chkDitgital.Name = "chkDitgital";
            this.chkDitgital.Size = new System.Drawing.Size(83, 17);
            this.chkDitgital.TabIndex = 4;
            this.chkDitgital.Text = "Show digital";
            this.chkDitgital.UseVisualStyleBackColor = true;
            // 
            // chkKoch
            // 
            this.chkKoch.AutoSize = true;
            this.chkKoch.Location = new System.Drawing.Point(3, 49);
            this.chkKoch.Name = "chkKoch";
            this.chkKoch.Size = new System.Drawing.Size(51, 17);
            this.chkKoch.TabIndex = 5;
            this.chkKoch.Text = "Koch";
            this.chkKoch.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thickness";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Colors";
            // 
            // sldWidth
            // 
            this.sldWidth.Location = new System.Drawing.Point(205, 182);
            this.sldWidth.Maximum = 25;
            this.sldWidth.Minimum = 2;
            this.sldWidth.Name = "sldWidth";
            this.sldWidth.Size = new System.Drawing.Size(104, 45);
            this.sldWidth.SmallChange = 2;
            this.sldWidth.TabIndex = 6;
            this.sldWidth.Value = 10;
            this.sldWidth.ValueChanged += new System.EventHandler(this.sldWidth_ValueChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnHours);
            this.flowLayoutPanel3.Controls.Add(this.btnSecondsColor);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(205, 233);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(110, 60);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // btnHours
            // 
            this.btnHours.Location = new System.Drawing.Point(3, 3);
            this.btnHours.Name = "btnHours";
            this.btnHours.Size = new System.Drawing.Size(100, 23);
            this.btnHours.TabIndex = 8;
            this.btnHours.Text = "Minutes/Hours";
            this.btnHours.UseVisualStyleBackColor = true;
            this.btnHours.Click += new System.EventHandler(this.btnHours_Click);
            // 
            // btnSecondsColor
            // 
            this.btnSecondsColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSecondsColor.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSecondsColor.Location = new System.Drawing.Point(3, 32);
            this.btnSecondsColor.Name = "btnSecondsColor";
            this.btnSecondsColor.Size = new System.Drawing.Size(75, 23);
            this.btnSecondsColor.TabIndex = 7;
            this.btnSecondsColor.Text = "Seconds Color";
            this.btnSecondsColor.UseVisualStyleBackColor = true;
            this.btnSecondsColor.Click += new System.EventHandler(this.btnSecondsColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Numbers";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.radNone);
            this.flowLayoutPanel4.Controls.Add(this.radNumbers);
            this.flowLayoutPanel4.Controls.Add(this.radRoman);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(205, 299);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(120, 75);
            this.flowLayoutPanel4.TabIndex = 10;
            // 
            // radNone
            // 
            this.radNone.AutoSize = true;
            this.radNone.Checked = true;
            this.radNone.Location = new System.Drawing.Point(3, 3);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(51, 17);
            this.radNone.TabIndex = 10;
            this.radNone.TabStop = true;
            this.radNone.Text = "None";
            this.radNone.UseVisualStyleBackColor = true;
            // 
            // radNumbers
            // 
            this.radNumbers.AutoSize = true;
            this.radNumbers.Location = new System.Drawing.Point(3, 26);
            this.radNumbers.Name = "radNumbers";
            this.radNumbers.Size = new System.Drawing.Size(67, 17);
            this.radNumbers.TabIndex = 11;
            this.radNumbers.Text = "Numbers";
            this.radNumbers.UseVisualStyleBackColor = true;
            // 
            // radRoman
            // 
            this.radRoman.AutoSize = true;
            this.radRoman.Location = new System.Drawing.Point(3, 49);
            this.radRoman.Name = "radRoman";
            this.radRoman.Size = new System.Drawing.Size(59, 17);
            this.radRoman.TabIndex = 12;
            this.radRoman.Text = "Roman";
            this.radRoman.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(5, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 227);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pomodoro";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.numPomodoro, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPomodoro, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.clockControl1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(205, 380);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(195, 221);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // numPomodoro
            // 
            this.numPomodoro.Location = new System.Drawing.Point(3, 3);
            this.numPomodoro.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.numPomodoro.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPomodoro.Name = "numPomodoro";
            this.numPomodoro.Size = new System.Drawing.Size(114, 20);
            this.numPomodoro.TabIndex = 0;
            this.numPomodoro.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnPomodoro
            // 
            this.btnPomodoro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPomodoro.Location = new System.Drawing.Point(3, 35);
            this.btnPomodoro.Name = "btnPomodoro";
            this.btnPomodoro.Size = new System.Drawing.Size(189, 26);
            this.btnPomodoro.TabIndex = 1;
            this.btnPomodoro.Text = "Start";
            this.btnPomodoro.UseVisualStyleBackColor = true;
            this.btnPomodoro.Click += new System.EventHandler(this.btnPomodoro_Click);
            // 
            // pnlClock
            // 
            this.pnlClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClock.Location = new System.Drawing.Point(0, 0);
            this.pnlClock.Name = "pnlClock";
            this.pnlClock.Size = new System.Drawing.Size(605, 606);
            this.pnlClock.TabIndex = 0;
            this.pnlClock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlClock_MouseClick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.updateClock);
            // 
            // clockControl1
            // 
            this.clockControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.clockControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clockControl1.Location = new System.Drawing.Point(3, 67);
            this.clockControl1.MinuteTicks = true;
            this.clockControl1.Name = "clockControl1";
            this.clockControl1.Size = new System.Drawing.Size(189, 151);
            this.clockControl1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 606);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ClockDemo1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.updateClock);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldWidth)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPomodoro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radRound;
        private System.Windows.Forms.RadioButton radSquare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkHourTicks;
        private System.Windows.Forms.Panel pnlClock;
        private System.Windows.Forms.CheckBox chkMinuteTicks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar sldWidth;
        private System.Windows.Forms.ColorDialog dlgColors;
        private System.Windows.Forms.Button btnSecondsColor;
        private System.Windows.Forms.CheckBox chkSeconds;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnHours;
        private System.Windows.Forms.CheckBox chkDitgital;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton radNone;
        private System.Windows.Forms.RadioButton radNumbers;
        private System.Windows.Forms.RadioButton radRoman;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numPomodoro;
        private System.Windows.Forms.Button btnPomodoro;
        private System.Windows.Forms.CheckBox chkKoch;
        private System.Windows.Forms.Timer timer;
        private ClockControl clockControl1;
    }
}

