using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AMazeing
{
    internal partial class Form1 : Form
    {
        private Character character2;
        private bool solving = false;
        private int speed;

        public Form1()
        {
            InitializeComponent();
            maze1.generateMaze();
            character2 = new Character();
            character2.Appearance = Character.Sprite.SPACE_MAN_BLUE;
            maze1.initCharacter(character2);
            //            txtStrength.Text = "" + character2.strength;
            //            txtConstitution.Text = "" + character2.constitution;
            //maze1.addBlob();
            //maze1.startBlob();
            this.speed = (int)trkSpeed.Value;
        }

        private void maze1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                character2.Direction = Room.EAST;
                tryMove(character2);
            }
            else if (e.KeyCode == Keys.A)
            {
                character2.Direction = Room.WEST;
                tryMove(character2);
            }
            else if (e.KeyCode == Keys.W)
            {
                character2.Direction = Room.NORTH;
                tryMove(character2);
            }
            else if (e.KeyCode == Keys.S)
            {
                character2.Direction = Room.SOUTH;
                tryMove(character2);
            }
            else if (e.KeyCode == Keys.Space)
            {
                character2.pickUpTreasure();
            }

        }

        private void tryMove(Character character)
        {
            character.moveForward();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.solving)
            {
                this.solving = false;
                this.maze1.resetCharacter(character2);
            } else
            {
                Thread t = new Thread(new ThreadStart(solve));
                t.Start();
            }
        }

        private void solve()
        {
            this.solving = true;
            while (solving && !this.character2.getRoom().isFinish())
            {
                character2.turnRight();
                for (int i=0;i<4;i++)
                {
                    if (character2.canMoveForward())
                    {
                        break;
                    } else
                    {
                        character2.turnLeft();
                    }
                }
                character2.moveForward();
                if (character2.getRoom().containsTreasure())
                {
                    character2.pickUpTreasure();
                }
                this.maze1.Invalidate();
                Thread.Sleep(this.speed);
            }
            this.solving = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.maze1.generateMaze();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.solving = false;
            this.maze1.stopBlob();
        }

        private void demoTimer_Tick(object sender, EventArgs e)
        {
            if (this.solving)
            {
                return;
            }
            else
            {
                this.maze1.generateMaze();
                this.maze1.resetCharacter(character2);
                this.button1_Click(null, null);
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {

        }

        private void trkSpeed_Scroll(object sender, EventArgs e)
        {
            this.speed = trkSpeed.Value;
        }
    }
}
