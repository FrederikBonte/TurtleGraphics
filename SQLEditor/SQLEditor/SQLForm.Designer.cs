namespace SQLEditor
{
    partial class SQLForm
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
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.btnExecute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSQL
            // 
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSQL.Location = new System.Drawing.Point(0, 0);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(800, 138);
            this.txtSQL.TabIndex = 0;
            this.txtSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSQL_KeyDown);
            // 
            // dataView
            // 
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataView.Location = new System.Drawing.Point(0, 138);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(800, 312);
            this.dataView.TabIndex = 1;
            this.dataView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellEnter);
            this.dataView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataView_EditingControlShowing);
            this.dataView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataView_KeyDown);
            this.dataView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataView_KeyPress);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExecute.Location = new System.Drawing.Point(0, 427);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(800, 23);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // SQLForm
            // 
            this.AcceptButton = this.btnExecute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.txtSQL);
            this.Name = "SQLForm";
            this.Text = "SQLForm";
            this.Activated += new System.EventHandler(this.SQLForm_Activated);
            this.Enter += new System.EventHandler(this.SQLForm_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button btnExecute;
    }
}