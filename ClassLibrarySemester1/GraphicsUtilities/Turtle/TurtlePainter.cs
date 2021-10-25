using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROCvanTwente.Sumpel.Semester1.TurtleDrawing
{
    public partial class TurtlePainter: UserControl
    {
        private static string FIRST = "FIRST_TURTLE";
        private Bitmap image = null;
        private Dictionary<string, Turtle> turtles = new Dictionary<string, Turtle>();

        public TurtlePainter()
        {
            InitializeComponent();
            ResizeRedraw = true;
            Disposed += TurtlePainter_Disposed;
        }

        private void TurtlePainter_Disposed(object sender, EventArgs e)
        {
            foreach (Turtle turtle in turtles.Values)
            {
                turtle.halt();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void TurtlePainter_Paint(object sender, PaintEventArgs e)
        {
            if (this.image != null)
            {
                e.Graphics.DrawImage(image, 0, 0);
            }
            foreach (Turtle turtle in turtles.Values)
            {
                turtle.drawTurtle(e.Graphics);
            }
        }

        public int getTurtleCount()
        {
            return this.turtles.Count;
        }

        public Turtle getTurtle()
        {
            return getTurtle(FIRST);
        }

        public Turtle getTurtle(string name)
        {
            Turtle result;
            if (this.turtles.ContainsKey(name))
            {
                result = this.turtles[name];
                result.clear();
                result.asyncReset();
            }
            else
            {
                result = new Turtle(this.image);
                this.turtles.Add(name, result);
            }
            return result;
        }

        private void TurtlePainter_Resize(object sender, EventArgs e)
        {
            this.image = new Bitmap(this.Width, this.Height);
            Graphics ig = Graphics.FromImage(image);
            ig.Clear(Color.Wheat);
            try 
            {
                foreach (Turtle turtle in turtles.Values)
                {
                    turtle.setImage(image);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to update all turtles...");
            }
        }
    }
}
