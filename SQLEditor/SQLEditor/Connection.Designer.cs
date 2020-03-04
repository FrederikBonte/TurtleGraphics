namespace SQLEditor
{
    partial class Connection
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
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHost, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsername, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbDatabase, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnTest, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnConnect, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 421);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host :";
            // 
            // txtHost
            // 
            this.txtHost.AccessibleDescription = "The hostname or ip address where the database resides";
            this.txtHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHost.Location = new System.Drawing.Point(273, 5);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(262, 20);
            this.txtHost.TabIndex = 1;
            this.txtHost.Text = "localhost";
            this.txtHost.Enter += new System.EventHandler(this.saydescription);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(5, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(5, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(5, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Database :";
            // 
            // txtPort
            // 
            this.txtPort.AccessibleDescription = "The port to which the database listens";
            this.txtPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.Location = new System.Drawing.Point(273, 37);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(262, 20);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "3307";
            this.txtPort.Enter += new System.EventHandler(this.saydescription);
            // 
            // txtUsername
            // 
            this.txtUsername.AccessibleDescription = "The username that gives access to the database";
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(273, 69);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(262, 20);
            this.txtUsername.TabIndex = 7;
            this.txtUsername.Text = "root";
            this.txtUsername.Enter += new System.EventHandler(this.saydescription);
            // 
            // txtPassword
            // 
            this.txtPassword.AccessibleDescription = "The password that gives access to the database.";
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(273, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = 'X';
            this.txtPassword.Size = new System.Drawing.Size(262, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "usbw";
            this.txtPassword.Enter += new System.EventHandler(this.saydescription);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.AccessibleDescription = "List of databases present on the server.";
            this.cmbDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(273, 133);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(262, 21);
            this.cmbDatabase.TabIndex = 9;
            this.cmbDatabase.SelectedValueChanged += new System.EventHandler(this.sayselection);
            this.cmbDatabase.Enter += new System.EventHandler(this.saydescription);
            // 
            // btnTest
            // 
            this.btnTest.AccessibleDescription = "Test to see if a connection can be established.";
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTest.Location = new System.Drawing.Point(5, 165);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(262, 26);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            this.btnTest.Enter += new System.EventHandler(this.saydescription);
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleDescription = "Connect to the database using this configuration.";
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Location = new System.Drawing.Point(273, 165);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(262, 26);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnConnect.Enter += new System.EventHandler(this.saydescription);
            // 
            // Connection
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Connection";
            this.Text = "Connection";
            this.Shown += new System.EventHandler(this.Connection_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnConnect;
    }
}