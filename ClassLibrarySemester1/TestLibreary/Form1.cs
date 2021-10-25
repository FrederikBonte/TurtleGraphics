using ROCvanTwente.Sumpel.Semester1.TurtleDrawing;
using ROCvanTwente.Sumpel.Semester2.Snowflakes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLibrary
{
    public partial class Form1 : Form
    {
        private Random RNG = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle();
            turtle.setDelay(1);
            turtle.right(8);

            turtle.beginRepeat(4);
            turtle.forward(150);
            turtle.left(4);
            turtle.back(150);
            turtle.right(8);
            turtle.endRepeat();
            turtle.right(21);

            turtle.run(true);
        }

        private void drawKoch(Turtle turtle, float distance, int depth)
        {
            if (depth==0)
            {
                turtle.back(distance);
            } else
            {
                drawKoch(turtle, distance, depth - 1);
                turtle.rotate(-60);
                drawKoch(turtle, distance, depth - 1);
                turtle.rotate(120);
                drawKoch(turtle, distance, depth - 1);
                turtle.rotate(-60);
                drawKoch(turtle, distance, depth - 1);
            }
        }

        private void btnDrunkTurtle_Click(object sender, EventArgs e)
        {
            Turtle turtle2 = this.tp.getTurtle("drunk");
            turtle2.setDelay(10);

            for (int i = 0; i < 127; i++)
            {
                turtle2.forward(7.3f);
                turtle2.setThickness(0.5f + i * 0.1f);
                turtle2.rotate(((RNG.Next(1000) / 500.0f) - 0.7f) * 37);
            }

            turtle2.run();
        }

        private void btnFractal_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("koch");
            turtle.setColor(Color.DarkGreen);
            turtle.setThickness(0.5f);
            turtle.rotate(120);

            drawKoch(turtle, 3.7f, 4);
            turtle.run(true);
            turtle.setDelay(1);
        }

        private void btnMoveRandom_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("random");
            turtle.setDelay(5);
            turtle.setColor(Color.LightBlue);
            turtle.setThickness(2f);
            turtle.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.run(true);
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("programmed");
            TurtleReader reader = new TurtleReader(turtle);
            reader.readFromText(txtProgram.Text);
            turtle.run();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("vierkant");
            turtle.setDelay(5);
            turtle.setColor(Color.Red);

            turtle.beginRepeat(36);
            turtle.forward(50);
            turtle.right(30);
            turtle.forward(50);
            turtle.right(120);
            turtle.forward(50);
            turtle.right(30);
            turtle.forward(50);
            turtle.right(90);
            turtle.forward(50);
            turtle.right(80);
            turtle.endRepeat();

            turtle.run();
        }
    }
}
