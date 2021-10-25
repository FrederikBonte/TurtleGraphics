
namespace ProjectEvaluationTool
{
    partial class WaarderingForm
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
            this.pnlForm = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTeacher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlWaardering = new System.Windows.Forms.TableLayoutPanel();
            this.pnlForm.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.ColumnCount = 2;
            this.pnlForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlForm.Controls.Add(this.txtProject, 1, 2);
            this.pnlForm.Controls.Add(this.label3, 0, 2);
            this.pnlForm.Controls.Add(this.txtStudent, 1, 1);
            this.pnlForm.Controls.Add(this.label2, 0, 1);
            this.pnlForm.Controls.Add(this.label1, 0, 0);
            this.pnlForm.Controls.Add(this.txtTeacher, 1, 0);
            this.pnlForm.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.pnlForm.Controls.Add(this.pnlScroll, 0, 3);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.RowCount = 5;
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlForm.Size = new System.Drawing.Size(977, 666);
            this.pnlForm.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Docent :";
            // 
            // txtTeacher
            // 
            this.txtTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTeacher.Location = new System.Drawing.Point(491, 3);
            this.txtTeacher.Name = "txtTeacher";
            this.txtTeacher.ReadOnly = true;
            this.txtTeacher.Size = new System.Drawing.Size(483, 37);
            this.txtTeacher.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "Leerling :";
            // 
            // txtStudent
            // 
            this.txtStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStudent.Location = new System.Drawing.Point(491, 53);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.ReadOnly = true;
            this.txtStudent.Size = new System.Drawing.Size(483, 37);
            this.txtStudent.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(472, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = "Project :";
            // 
            // txtProject
            // 
            this.txtProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProject.Location = new System.Drawing.Point(491, 103);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(483, 37);
            this.txtProject.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(201, 41);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Bewaren";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flowLayoutPanel1
            // 
            this.pnlForm.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 619);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(971, 44);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(208, 41);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlForm.SetColumnSpan(this.pnlScroll, 2);
            this.pnlScroll.Controls.Add(this.pnlWaardering);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(3, 153);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(971, 460);
            this.pnlScroll.TabIndex = 8;
            // 
            // pnlWaardering
            // 
            this.pnlWaardering.ColumnCount = 2;
            this.pnlWaardering.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlWaardering.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlWaardering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWaardering.Location = new System.Drawing.Point(0, 0);
            this.pnlWaardering.Name = "pnlWaardering";
            this.pnlWaardering.RowCount = 10;
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.pnlWaardering.Size = new System.Drawing.Size(971, 460);
            this.pnlWaardering.TabIndex = 0;
            // 
            // WaarderingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 666);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "WaarderingForm";
            this.Text = "WaarderingForm";
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTeacher;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.TableLayoutPanel pnlWaardering;
    }
}