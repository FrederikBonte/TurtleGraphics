
using System.Drawing;

namespace ProjectEvaluationTool
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabTeacher = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.lstClasses = new System.Windows.Forms.CheckedListBox();
            this.txtStudentCount = new System.Windows.Forms.TextBox();
            this.txtTotalTime = new System.Windows.Forms.TextBox();
            this.tabTalk = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRandom = new System.Windows.Forms.Button();
            this.cmbStudents = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkOkee = new System.Windows.Forms.CheckBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.cmbProjectEval = new System.Windows.Forms.ComboBox();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.tabProjects = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.numStars = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numSemester = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lstCriteria = new System.Windows.Forms.ListBox();
            this.btnAddCrit = new System.Windows.Forms.Button();
            this.btnEditCrit = new System.Windows.Forms.Button();
            this.btnSaveProj = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabMain.SuspendLayout();
            this.tabTeacher.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.tabTalk.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabProjects.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemester)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabTeacher);
            this.tabMain.Controls.Add(this.tabTalk);
            this.tabMain.Controls.Add(this.tabProjects);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(891, 598);
            this.tabMain.TabIndex = 0;
            // 
            // tabTeacher
            // 
            this.tabTeacher.Controls.Add(this.tableLayoutPanel1);
            this.tabTeacher.Location = new System.Drawing.Point(4, 41);
            this.tabTeacher.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabTeacher.Name = "tabTeacher";
            this.tabTeacher.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabTeacher.Size = new System.Drawing.Size(883, 553);
            this.tabTeacher.TabIndex = 0;
            this.tabTeacher.Text = "Docent";
            this.tabTeacher.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbTeacher, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstClasses, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtStudentCount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalTime, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 7);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(867, 539);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 50);
            this.label4.TabIndex = 6;
            this.label4.Text = "Totaal : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 50);
            this.label3.TabIndex = 5;
            this.label3.Text = "Leerlingen :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gesprekstijd :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Docent :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Items.AddRange(new object[] {
            "meneer Bonte",
            "meneer de Jong",
            "meneer Pierik",
            "Rients Dijkstra",
            "Lucas Weel",
            "Gep"});
            this.cmbTeacher.Location = new System.Drawing.Point(224, 7);
            this.cmbTeacher.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(200, 40);
            this.cmbTeacher.TabIndex = 1;
            this.cmbTeacher.SelectedIndexChanged += new System.EventHandler(this.cmbTeacher_SelectedIndexChanged);
            // 
            // numTime
            // 
            this.numTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.numTime.Location = new System.Drawing.Point(224, 57);
            this.numTime.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numTime.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numTime.Size = new System.Drawing.Size(200, 41);
            this.numTime.TabIndex = 3;
            this.numTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lstClasses
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstClasses, 2);
            this.lstClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClasses.FormattingEnabled = true;
            this.lstClasses.Items.AddRange(new object[] {
            "0SV1 (S1)",
            "0SV2 (S1)",
            "0SV3 (S1)",
            "9FA1 (S3)",
            "8FA1 (S5)"});
            this.lstClasses.Location = new System.Drawing.Point(440, 7);
            this.lstClasses.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstClasses.Name = "lstClasses";
            this.tableLayoutPanel1.SetRowSpan(this.lstClasses, 5);
            this.lstClasses.Size = new System.Drawing.Size(419, 525);
            this.lstClasses.TabIndex = 4;
            this.lstClasses.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstClasses_ItemCheck);
            // 
            // txtStudentCount
            // 
            this.txtStudentCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtStudentCount.Enabled = false;
            this.txtStudentCount.Location = new System.Drawing.Point(219, 103);
            this.txtStudentCount.Name = "txtStudentCount";
            this.txtStudentCount.Size = new System.Drawing.Size(210, 41);
            this.txtStudentCount.TabIndex = 7;
            this.txtStudentCount.Text = "0";
            this.txtStudentCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalTime
            // 
            this.txtTotalTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalTime.Location = new System.Drawing.Point(219, 153);
            this.txtTotalTime.Name = "txtTotalTime";
            this.txtTotalTime.Size = new System.Drawing.Size(210, 41);
            this.txtTotalTime.TabIndex = 8;
            this.txtTotalTime.Text = "0:00";
            this.txtTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabTalk
            // 
            this.tabTalk.Controls.Add(this.tableLayoutPanel2);
            this.tabTalk.Location = new System.Drawing.Point(4, 41);
            this.tabTalk.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabTalk.Name = "tabTalk";
            this.tabTalk.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabTalk.Size = new System.Drawing.Size(883, 553);
            this.tabTalk.TabIndex = 1;
            this.tabTalk.Text = "Gesprek";
            this.tabTalk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnRandom, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbStudents, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnStart, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtTime, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtNotes, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.chkOkee, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.btnPrev, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnNext, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cmbProjectEval, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnEvaluate, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 7);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(867, 539);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnRandom
            // 
            this.btnRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRandom.Location = new System.Drawing.Point(3, 3);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(427, 44);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "Kies een student";
            this.btnRandom.UseVisualStyleBackColor = true;
            // 
            // cmbStudents
            // 
            this.cmbStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudents.FormattingEnabled = true;
            this.cmbStudents.Items.AddRange(new object[] {
            "Sjors",
            "Denise",
            "Willem",
            "Henk",
            "Pieter",
            "Marie",
            "Enzovoort"});
            this.cmbStudents.Location = new System.Drawing.Point(436, 3);
            this.cmbStudents.Name = "cmbStudents";
            this.cmbStudents.Size = new System.Drawing.Size(428, 40);
            this.cmbStudents.TabIndex = 1;
            this.cmbStudents.SelectedValueChanged += new System.EventHandler(this.cmbStudents_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(427, 50);
            this.label5.TabIndex = 4;
            this.label5.Text = "Project :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(427, 50);
            this.label6.TabIndex = 5;
            this.label6.Text = "Oplever datum :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(3, 153);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(427, 44);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.Black;
            this.txtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.ForeColor = System.Drawing.Color.LightGreen;
            this.txtTime.Location = new System.Drawing.Point(436, 153);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(428, 39);
            this.txtTime.TabIndex = 7;
            this.txtTime.Text = "4:39";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            // 
            // txtNotes
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtNotes, 2);
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Location = new System.Drawing.Point(3, 253);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(861, 233);
            this.txtNotes.TabIndex = 7;
            this.txtNotes.Text = "Student heeft nog niks gedaan... Zo snel mogelijk kielhalen. :)";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(436, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(428, 44);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Bewaren";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkOkee
            // 
            this.chkOkee.AutoSize = true;
            this.chkOkee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOkee.Location = new System.Drawing.Point(3, 492);
            this.chkOkee.Name = "chkOkee";
            this.chkOkee.Size = new System.Drawing.Size(427, 44);
            this.chkOkee.TabIndex = 10;
            this.chkOkee.Text = "Voortgang okee!";
            this.chkOkee.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrev.Location = new System.Drawing.Point(3, 203);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(427, 44);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Location = new System.Drawing.Point(436, 203);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(428, 44);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cmbProjectEval
            // 
            this.cmbProjectEval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProjectEval.FormattingEnabled = true;
            this.cmbProjectEval.Location = new System.Drawing.Point(436, 53);
            this.cmbProjectEval.Name = "cmbProjectEval";
            this.cmbProjectEval.Size = new System.Drawing.Size(428, 40);
            this.cmbProjectEval.TabIndex = 2;
            this.cmbProjectEval.SelectedValueChanged += new System.EventHandler(this.cmbProjectEval_SelectedValueChanged);
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(436, 103);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(428, 44);
            this.btnEvaluate.TabIndex = 3;
            this.btnEvaluate.Text = "Waarderen";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // tabProjects
            // 
            this.tabProjects.Controls.Add(this.tableLayoutPanel3);
            this.tabProjects.Location = new System.Drawing.Point(4, 41);
            this.tabProjects.Name = "tabProjects";
            this.tabProjects.Size = new System.Drawing.Size(883, 553);
            this.tabProjects.TabIndex = 2;
            this.tabProjects.Text = "Projecten";
            this.tabProjects.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.numStars, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbProjects, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.numSemester, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtDescription, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lstCriteria, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnAddCrit, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnEditCrit, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnSaveProj, 3, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(883, 553);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // numStars
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.numStars, 2);
            this.numStars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numStars.Location = new System.Drawing.Point(443, 103);
            this.numStars.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numStars.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStars.Name = "numStars";
            this.numStars.Size = new System.Drawing.Size(437, 41);
            this.numStars.TabIndex = 4;
            this.numStars.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStars.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(434, 50);
            this.label8.TabIndex = 2;
            this.label8.Text = "Sterren :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbProjects
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cmbProjects, 4);
            this.cmbProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(3, 3);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(877, 40);
            this.cmbProjects.TabIndex = 0;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            this.cmbProjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProjects_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label7, 2);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(434, 50);
            this.label7.TabIndex = 1;
            this.label7.Text = "Semester :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSemester
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.numSemester, 2);
            this.numSemester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSemester.Location = new System.Drawing.Point(443, 53);
            this.numSemester.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSemester.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSemester.Name = "numSemester";
            this.numSemester.Size = new System.Drawing.Size(437, 41);
            this.numSemester.TabIndex = 3;
            this.numSemester.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSemester.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDescription
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtDescription, 4);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 153);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(877, 99);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // lstCriteria
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.lstCriteria, 4);
            this.lstCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCriteria.FormattingEnabled = true;
            this.lstCriteria.ItemHeight = 32;
            this.lstCriteria.Location = new System.Drawing.Point(3, 258);
            this.lstCriteria.Name = "lstCriteria";
            this.lstCriteria.Size = new System.Drawing.Size(877, 241);
            this.lstCriteria.TabIndex = 6;
            // 
            // btnAddCrit
            // 
            this.btnAddCrit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddCrit.Location = new System.Drawing.Point(3, 505);
            this.btnAddCrit.Name = "btnAddCrit";
            this.btnAddCrit.Size = new System.Drawing.Size(214, 45);
            this.btnAddCrit.TabIndex = 7;
            this.btnAddCrit.Text = "Toevoegen";
            this.btnAddCrit.UseVisualStyleBackColor = true;
            // 
            // btnEditCrit
            // 
            this.btnEditCrit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditCrit.Location = new System.Drawing.Point(223, 505);
            this.btnEditCrit.Name = "btnEditCrit";
            this.btnEditCrit.Size = new System.Drawing.Size(214, 45);
            this.btnEditCrit.TabIndex = 8;
            this.btnEditCrit.Text = "Wijzigen";
            this.btnEditCrit.UseVisualStyleBackColor = true;
            // 
            // btnSaveProj
            // 
            this.btnSaveProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveProj.Location = new System.Drawing.Point(663, 505);
            this.btnSaveProj.Name = "btnSaveProj";
            this.btnSaveProj.Size = new System.Drawing.Size(217, 45);
            this.btnSaveProj.TabIndex = 10;
            this.btnSaveProj.Text = "Bewaren";
            this.btnSaveProj.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 127;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 598);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabMain.ResumeLayout(false);
            this.tabTeacher.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.tabTalk.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabProjects.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemester)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabTeacher;
        private System.Windows.Forms.TabPage tabTalk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTeacher;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.CheckedListBox lstClasses;
        private System.Windows.Forms.TextBox txtStudentCount;
        private System.Windows.Forms.TextBox txtTotalTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.ComboBox cmbStudents;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkOkee;
        private System.Windows.Forms.TabPage tabProjects;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown numStars;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numSemester;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ListBox lstCriteria;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAddCrit;
        private System.Windows.Forms.Button btnEditCrit;
        private System.Windows.Forms.Button btnSaveProj;
        private System.Windows.Forms.ComboBox cmbProjectEval;
        private System.Windows.Forms.Button btnEvaluate;
    }
}

