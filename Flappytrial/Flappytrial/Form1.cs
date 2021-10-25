using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappytrial
{
    public partial class Form1 : Form
    {
        private const int BIRD_SPEED = 5;
        private const int PIPE_SPEED = -10;
        private int gravity = BIRD_SPEED;
        private int move = PIPE_SPEED;
        private readonly Random RNG = new Random(12345);

        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            picBird.Location = new Point(picBird.Location.X, picBird.Location.Y + gravity);
            picBottom.Location = new Point(picBottom.Location.X + move, picBottom.Location.Y);
            picTop.Location = new Point(picTop.Location.X + move, picTop.Location.Y);

            if (picTop.Location.X < -picTop.Width)
            {
                int gap = RNG.Next((Height * 60)/100) + (Height*10)/100;
                picTop.Location = new Point(Width, (gap) - picTop.Height);
                picBottom.Location = new Point(Width, gap + 100);
            }
        }

        private Point getRandomBottom()
        {
            int top = picTop.Height + picTop.Location.Y;
            return new Point(
                Width,
                Math.Max(top + 300 + RNG.Next(500), Height - 400)
                );
        }

        private Point getRandomTop()
        {
            int bottom = picBottom.Location.Y;
            return new Point(
                Width,
                Math.Max(bottom - (300 + RNG.Next(500)), 400)-picTop.Height
                );
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gravity = -BIRD_SPEED;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            gravity = BIRD_SPEED;
        }
    }
}
