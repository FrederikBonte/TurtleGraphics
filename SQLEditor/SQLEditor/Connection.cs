using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLEditor
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        private frmMain getMain()
        {
            return (frmMain)this.MdiParent;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string myConnectionString = "SERVER="+txtHost.Text+";UID='"+txtUsername.Text+"';PASSWORD='"+txtPassword.Text+"';PORT="+txtPort.Text;
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SHOW DATABASES;";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();
                object selected = cmbDatabase.SelectedItem;
                cmbDatabase.Items.Clear();
                while (Reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        row += Reader.GetValue(i).ToString();
                    }
                    cmbDatabase.Items.Add(row);
                }
                getMain().speak("Connection succeeded.", frmMain.SpeechVerbosity.VERBOSE);
                getMain().speak(cmbDatabase.Items.Count + " databases were found.");
                connection.Close();
            }
            catch (Exception ex)
            {
                getMain().speak("Failed to connect to the database, because : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Connection_Shown(object sender, EventArgs e)
        {
        }

        private void saydescription(object sender, EventArgs e)
        {
            getMain().clearSpeechQueue();
            getMain().speak(((Control)sender).AccessibleDescription);
            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;
                if (txt.PasswordChar != 0)
                {
                    getMain().speak("your password", frmMain.SpeechVerbosity.MINIMAL);
                } else
                {
                    getMain().speak("Current value is ", frmMain.SpeechVerbosity.VERBOSE);
                    getMain().speak(((TextBox)sender).Text, frmMain.SpeechVerbosity.MINIMAL);
                }
            }
        }

        private void sayselection(object sender, EventArgs e)
        {
            getMain().clearSpeechQueue();
            string item = "" + ((ComboBox)sender).SelectedItem;
            if (item.Length==0)
            {
                getMain().speak("No value selected.", frmMain.SpeechVerbosity.MINIMAL);
                getMain().speak("Please use the arrow keys tochange your selection.", frmMain.SpeechVerbosity.POLITE);
            } else
            {
                getMain().speak(item, frmMain.SpeechVerbosity.MINIMAL);
            }                
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedItem==null)
            {
                getMain().speak("Please select a database to which to connect.", "Please select a database", "No database");
            } else
            {
                getMain().speak("About to connect to '" + cmbDatabase.SelectedItem + "' on " + txtHost.Text, frmMain.SpeechVerbosity.MINIMAL);
            }
            getMain().connect(this.txtHost.Text, this.txtPort.Text, this.txtUsername.Text, this.txtPassword.Text, ""+this.cmbDatabase.SelectedItem);
        }
    }
}
