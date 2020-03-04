using AMazeing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Character character;
/*        private static readonly SpeechSynthesizer syn = new SpeechSynthesizer();
        private static readonly Choices list = new Choices();
        private static bool stop = false, please = false;

        private static void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "hello": { syn.Speak("Hi"); please = false; break; }
                case "how are you": { syn.Speak("I'm a bit busy"); please = false; break; }
                case "stop": { if (!please) { syn.Speak("No"); } else { stop = true; } break; }
                case "please": { please = true; break; }
            }
        }*/

        public Form1()
        {
            InitializeComponent();
            maze1.generateMaze();

            character = new Character();
            character.Appearance = Character.Sprite.EVIL_KNIGHT;

            maze1.initCharacter(character);
        }

        private void maze1_Load(object sender, EventArgs e)
        {

        }

        private void maze1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                case Keys.Right:
                    { 
                        this.character.Direction = Room.EAST; 
                        break; 
                    }
                case Keys.A:
                case Keys.Left:
                    { 
                        this.character.Direction = Room.WEST; 
                        break; 
                    }
                case Keys.W:
                case Keys.Up:
                    { 
                        this.character.Direction = Room.NORTH; 
                        break; 
                    }
                case Keys.S:
                case Keys.Down:
                    { 
                        this.character.Direction = Room.SOUTH; 
                        break; 
                    }

        
            }
            this.character.moveForward();

            if (this.character.getRoom().isFinish())
            {
                MessageBox.Show("You have reached the end of the maze!", "Success!");
            }
            //else if (this.character.getRoom().isStart())
            //{
            //    MessageBox.Show("You are back at the beginning.", "Good luck!");
            //
        
            if (character.seeTreasure())
            {
                character.pickUpTreasure();
            }
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            maze1.generateMaze();
            maze1.resetCharacter(character);
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(solve));
            t.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
/*            syn.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add(new String[] { "hello", "how are you", "stop", "please" });

            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load speech grammar thingies : " + ex.Message);
            }*/
        }

        private void solve() {
            while (!this.character.getRoom().isFinish())
            {
                bool moved = false;
                this.character.turnLeft();
                for (int i = 0; i < 4; i++)
                {
                    if (this.character.canMoveForward())
                    {
                        moved = true;
                        break;
                    }
                    else
                    {
                        character.turnRight();
                    }
                }
                Thread.Sleep(25);
                Thread.Yield();
                if (moved)
                {
                    this.character.moveForward();
                }
                else
                {
                    MessageBox.Show("Character is stuck!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
