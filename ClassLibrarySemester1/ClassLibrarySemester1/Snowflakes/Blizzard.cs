using ROCvanTwente.Sumpel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROCvanTwente.Sumpel.Semester2.Snowflakes
{
    public partial class Blizzard : UserControl
    {
        private readonly int NUMBER = 500;
        private float[] x;
        private float[] y;

        private readonly Pen white = new Pen(Color.White);

        public Blizzard()
        {
            InitializeComponent();
            ResizeRedraw = true;
            reset();
        }

        private void Blizzard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < NUMBER; i++)
            {
                drawFlake(g, x[i], y[i]);
            }
        }

        private void drawFlake(Graphics g, float x, float y, float size = 5)
        {
            g.DrawRectangle(white, x, y, 1, 1);

            //g.DrawLine(white, x, y - size, x, y + size);
            //g.DrawLine(white, x - size*0.86f, y - (size / 2.5f), x + size*0.86f, y + (size / 2.5f));
            //g.DrawLine(white, x - size*0.86f, y + (size / 2.5f), x + size*0.86f, y - (size / 2.5f));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Update snowflake(s)
            for (int i = 0; i < NUMBER; i++)
            {
                y[i] += 0.17f+LehmerRNG.Next(1000)/2000f;
                x[i] += getRandomDirection();
                if (y[i] > this.Height)
                {
                    y[i] = 0;
                }
            }
            this.Invalidate();
        }

        private float getRandomDirection()
        {
            float basic = LehmerRNG.Next(2000) - 1000;
            basic /= 1000f;
            basic *= 1.77f;
            return basic;
        }

        private void Blizzard_Resize(object sender, EventArgs e)
        {
            // reset the snowflake(s)
            reset();
        }

        private void reset()
        {
            x = new float[NUMBER];
            y = new float[NUMBER];
            for (int i = 0; i < NUMBER; i++)
            {
                x[i] = LehmerRNG.Next(this.Width);
                y[i] = LehmerRNG.Next(this.Height);
            }
        }
    }
}
