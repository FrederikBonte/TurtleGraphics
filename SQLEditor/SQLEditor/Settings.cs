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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private frmMain getMain()
        {
            return (frmMain)this.MdiParent;
        }

        private void trkSpeechRate_ValueChanged(object sender, EventArgs e)
        {
            getMain().Synthesizer.Rate = this.trkSpeechRate.Value;
            getMain().clearSpeechQueue();
            getMain().speak("Chosen speech rate ");
            getMain().speak("" + getMain().Synthesizer.Rate, frmMain.SpeechVerbosity.MINIMAL);
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            this.trkSpeechRate.Value = this.getMain().Synthesizer.Rate;
            this.lstVerbosity.SelectedIndex = (int)this.getMain().Verbosity;
        }

        private void sayselection(object sender, EventArgs e)
        {
            getMain().clearSpeechQueue();
            getMain().speak(((Control)sender).AccessibleDescription);
            getMain().speak("Current value is ", frmMain.SpeechVerbosity.VERBOSE);
            if (sender is TextBox)
            {
                TextBox txt = (TextBox)sender;
                if (txt.PasswordChar != 0)
                {
                    getMain().speak("your password", frmMain.SpeechVerbosity.MINIMAL);
                }
                else
                {
                    getMain().speak(((TextBox)sender).Text, frmMain.SpeechVerbosity.MINIMAL);
                }
            }
            else if (sender is ListBox)
            {
                getMain().speak("" + ((ListBox)sender).SelectedItem, frmMain.SpeechVerbosity.MINIMAL);
            }
            else if (sender is ComboBox)
            {
                getMain().speak("" + ((ComboBox)sender).SelectedItem, frmMain.SpeechVerbosity.MINIMAL);
            }
            else if (sender is TrackBar)
            {
                getMain().speak("" + ((TrackBar)sender).Value, frmMain.SpeechVerbosity.MINIMAL);
            }
        }

        private void lstVerbosity_MouseClick(object sender, MouseEventArgs e)
        {
            getMain().clearSpeechQueue();
            getMain().Verbosity = (frmMain.SpeechVerbosity)this.lstVerbosity.SelectedIndex;
            getMain().speak("Chosen verbosity ");
            getMain().speak(""+getMain().Verbosity, frmMain.SpeechVerbosity.MINIMAL);
        }
    }
}
