using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLEditor
{
    public partial class frmMain : Form
    {
        public enum SpeechVerbosity
        {
            SILENT,
            MINIMAL,
            VERBOSE,
            POLITE
        };

        private Connection frmConnect;
        private SQLForm frmSQL;
        private Settings frmSettings;
        private MySqlConnection connection;
        private readonly SpeechSynthesizer SS = new SpeechSynthesizer();
        private BlockingCollection<string> speech = new BlockingCollection<string>();
        private Thread speaker;
        private bool stop = false;
        private SpeechVerbosity verbosity = SpeechVerbosity.VERBOSE;

        private void speaker_job()
        {
            while (!stop)
            {
                foreach (string text in speech.GetConsumingEnumerable())
                {
                    SS.Speak(text);
                }
                Thread.Sleep(100);
            }
        }

        public MySqlConnection Connection
        {
            get { return this.connection; }
        }

        public SpeechSynthesizer Synthesizer
        {
            get { return this.SS; }
        }

        public SpeechVerbosity Verbosity
        {
            get { return this.verbosity; }
            set { this.verbosity = value; }
        }


        public frmMain()
        {
            InitializeComponent();
            SS.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            SS.Rate = 5;
        }

        private void mnuConnect_Click(object sender, EventArgs e)
        {
            this.frmConnect.Visible = true;
            this.frmConnect.BringToFront();
            this.frmConnect.Show();
        }

        public void clearSpeechQueue()
        {
            string item;
            while (speech.TryTake(out item)) ;
        }

        public void speak(string text, SpeechVerbosity verbosity = SpeechVerbosity.VERBOSE)
        {
            if (verbosity<=this.verbosity) {
                speech.Add(text);
            }
        }

        public void speak(string v1, string v2, string v3)
        {
            switch (this.verbosity)
            {
                case SpeechVerbosity.POLITE: { speak(v1, SpeechVerbosity.POLITE); break; }
                case SpeechVerbosity.VERBOSE: { speak(v2, SpeechVerbosity.VERBOSE); break; }
                case SpeechVerbosity.MINIMAL: { speak(v3, SpeechVerbosity.MINIMAL); break; }
            }
        }

        public void speak(string v1, string v2)
        {
            speak(v1, v1, v2);
        }


        private void frmMain_Shown(object sender, EventArgs e)
        {
            speak("SQL Editor is online", SpeechVerbosity.MINIMAL);
            speak("Ready to connect.", SpeechVerbosity.POLITE);
            speaker = new Thread(new ThreadStart(speaker_job));
            speaker.Start();
            frmConnect = new Connection();
            frmConnect.MdiParent = this;
            frmConnect.WindowState = FormWindowState.Maximized;
            frmConnect.Visible = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            stop = true;
            this.speaker.Abort();
            if (this.connection!=null) {
                this.connection.Dispose();
                this.connection = null;
            }
        }

        public void connect(string host, string port, string username, string passwd, string database)
        {
            string myConnectionString = "SERVER=" + host + ";UID='" + username + "';PASSWORD='" + passwd + "';PORT=" + port + ";DATABASE="+database;
            this.connection = new MySqlConnection(myConnectionString);
            speak("Connection to "+database+" succeeded", "Connected to "+database, "Connected");

            frmSQL = new SQLForm();
            frmSQL.MdiParent = this;
            frmSQL.WindowState = FormWindowState.Maximized;
            frmSQL.Visible = true;

            this.mnuSQL.Enabled = true;
        }

        private void mnuSQL_Click(object sender, EventArgs e)
        {
            if (this.frmSQL!=null)
            {
                this.frmSQL.Visible = true;
                this.frmSQL.BringToFront();
                this.frmSQL.Focus();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.frmSettings == null)
            {
                this.frmSettings = new Settings();
            }
            frmSettings.MdiParent = this;
            frmSettings.WindowState = FormWindowState.Maximized;
            frmSettings.Visible = true;
        }
    }
}
