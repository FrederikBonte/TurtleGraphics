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
    public partial class SQLForm : Form
    {
        public SQLForm()
        {
            InitializeComponent();
        }

        private frmMain getMain()
        {
            return (frmMain)this.MdiParent;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {            
            MySqlCommand command = getMain().Connection.CreateCommand();
            command.CommandText = this.txtSQL.Text;
            MySqlDataReader reader;
            getMain().Connection.Open();
            try
            {
                reader = command.ExecuteReader();
                this.dataView.Rows.Clear();
                this.dataView.Columns.Clear();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    this.dataView.Columns.Add("column" + (i + 1), reader.GetName(i));
                }
                while (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    row.SetValues(values);
                    this.dataView.Rows.Add(values);
                }
                this.dataView.Focus();
            } catch (Exception ex)
            {
                getMain().clearSpeechQueue();
                getMain().speak("Failed to execute your query.", "Error");
                getMain().speak(ex.Message);
            }
            getMain().Connection.Close();
        }

        private void dataView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            getMain().clearSpeechQueue();
            getMain().speak("Reckord " + (row+1), frmMain.SpeechVerbosity.VERBOSE);
            getMain().speak("Value for " + this.dataView.Columns[col].HeaderText, frmMain.SpeechVerbosity.VERBOSE);
            getMain().speak(""+this.dataView.Rows[row].Cells[col].Value, frmMain.SpeechVerbosity.MINIMAL);
        }

        private void SQLForm_Activated(object sender, EventArgs e)
        {
            this.txtSQL.Focus();
        }

        private void dataView_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                getMain().speak("Back to query editor");
                this.txtSQL.Focus();
            }
        }

        private void SQLForm_Enter(object sender, EventArgs e)
        {
            this.txtSQL.Focus();
        }

        private void dataView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyDown += new KeyEventHandler(dataView_KeyDown);

            e.Control.KeyDown += new KeyEventHandler(dataView_KeyDown);
        }

        private void txtSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Control)
            {
                string niceQuery = makeNice(this.txtSQL.Text);
                getMain().speak(niceQuery);
                e.Handled = true;
            }
        }

        private string makeNice(string text)
        {
            string result = text;
            result = result.Replace(" * ", " all columns ");
            return result;
        }
    }
}
