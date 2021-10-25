namespace UIDLijstjes3
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lstCity = new System.Windows.Forms.ListBox();
            this.cmbTravelMethod = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(146, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(356, 47);
            this.txtName.TabIndex = 0;
            // 
            // numAge
            // 
            this.numAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAge.Location = new System.Drawing.Point(165, 94);
            this.numAge.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numAge.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(389, 47);
            this.numAge.TabIndex = 1;
            this.numAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAge.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lstCity
            // 
            this.lstCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCity.FormattingEnabled = true;
            this.lstCity.ItemHeight = 37;
            this.lstCity.Items.AddRange(new object[] {
            "Parijs",
            "Londen",
            "Rome",
            "Amsterdam",
            "Oslo",
            "Barcelona",
            "Almelo"});
            this.lstCity.Location = new System.Drawing.Point(12, 163);
            this.lstCity.Name = "lstCity";
            this.lstCity.Size = new System.Drawing.Size(326, 115);
            this.lstCity.TabIndex = 2;
            // 
            // cmbTravelMethod
            // 
            this.cmbTravelMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTravelMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTravelMethod.FormattingEnabled = true;
            this.cmbTravelMethod.Items.AddRange(new object[] {
            "Auto",
            "Trein",
            "Vliegtuig"});
            this.cmbTravelMethod.Location = new System.Drawing.Point(385, 163);
            this.cmbTravelMethod.Name = "cmbTravelMethod";
            this.cmbTravelMethod.Size = new System.Drawing.Size(403, 45);
            this.cmbTravelMethod.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbTravelMethod);
            this.Controls.Add(this.lstCity);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.ListBox lstCity;
        private System.Windows.Forms.ComboBox cmbTravelMethod;
    }
}

