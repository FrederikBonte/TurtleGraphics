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
            TurtleProgrammer prg = new TurtleProgrammer(turtle);

            prg.right(8);
            prg.beginRepeat(4);
            prg.forward(150);
            prg.left(4);
            prg.back(150);
            prg.right(8);
            prg.endRepeat();
            prg.right(21);

            turtle.run(true);
        }

        private void drawKoch(TurtleProgrammer prg, float distance, int depth)
        {
            if (depth==0)
            {
                prg.back(distance);
            } else
            {
                drawKoch(prg, distance, depth - 1);
                prg.rotate(-60);
                drawKoch(prg, distance, depth - 1);
                prg.rotate(120);
                drawKoch(prg, distance, depth - 1);
                prg.rotate(-60);
                drawKoch(prg, distance, depth - 1);
            }
        }

        private void btnDrunkTurtle_Click(object sender, EventArgs e)
        {
            Turtle turtle2 = this.tp.getTurtle("drunk");
            TurtleProgrammer prg = new TurtleProgrammer(turtle2);
            turtle2.setDelay(10);

            for (int i = 0; i < 127; i++)
            {
                prg.forward(7.3f);
                prg.setThickness(0.5f + i * 0.1f);
                prg.rotate(((RNG.Next(1000) / 500.0f) - 0.7f) * 37);
            }

            turtle2.run();
        }

        private void btnFractal_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("koch");
            TurtleProgrammer prg = new TurtleProgrammer(turtle);

            prg.setColor(Color.DarkGreen);
            prg.setThickness(0.5f);
            prg.rotate(120);

            drawKoch(prg, 3.7f, 4);
            turtle.run(true);
            turtle.setDelay(1);
        }

        private void btnMoveRandom_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("random");
            TurtleProgrammer prg = new TurtleProgrammer(turtle);
            turtle.setDelay(5);
            prg.setColor(Color.LightBlue);
            prg.setThickness(2f);
            prg.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            prg.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            prg.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            prg.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            prg.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            prg.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            prg.moveTo(RNG.Next(this.Width), RNG.Next(this.Height));
            turtle.run(true);
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("programmed");
            TurtleProgrammer prg = new TurtleProgrammer(turtle);
            turtle.clear();
            prg.setThickness(0.2f);
            TurtleReader reader = new TurtleReader(prg);
            reader.readFromText(txtProgram.Text);
            turtle.run();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("vierkant");
            turtle.setDelay(5);
            TurtleProgrammer prg = new TurtleProgrammer(turtle);

            prg.setColor(Color.Red);
            prg.beginRepeat(36);
            prg.forward(50);
            prg.right(30);
            prg.forward(50);
            prg.right(120);
            prg.forward(50);
            prg.right(30);
            prg.forward(50);
            prg.right(90);
            prg.forward(50);
            prg.right(80);
            prg.endRepeat();

            turtle.run();
        }

        private void btnLarge_Click(object sender, EventArgs e)
        {

        }

        private void btnSpirals_Click(object sender, EventArgs e)
        {
            Turtle turtle = this.tp.getTurtle("spirals");
            turtle.setDelay(0);
            TurtleProgrammer prg = new TurtleProgrammer(turtle);
            prg.setThickness(0.5f);
            prg.setColor(Color.BlueViolet);
            prg.setVariable("degrees", 0);

            prg.beginRepeat(10000000);
            prg.forward(0.37f);
            prg.right("degrees");
            prg.increase("degrees", 1.00011f);
            prg.endRepeat();

            turtle.run();
        }
    }
}
