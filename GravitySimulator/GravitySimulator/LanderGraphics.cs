using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GravitySimulator.Properties;
using System.Drawing.Imaging;

namespace GravitySimulator
{
    internal partial class LanderGraphics : UserControl
    {
        private int flame = 0; // mod 6
        private bool oddeven = false;

        private Lander lander = null;

        public LanderGraphics()
        {
            InitializeComponent();
        }

        public void setLander(Lander lander)
        {
            this.lander = lander;
        }

        private void animation_Tick(object sender, EventArgs e)
        {
            oddeven = !oddeven;
            if (oddeven)
            {
                flame = (flame + 1) % 6;
            }
            this.Invalidate();
        }

        public Color Blend(Color color1, Color color2, double amount)
        {
            byte r = (byte)((color2.R * amount) + color1.R * (1 - amount));
            byte g = (byte)((color2.G * amount) + color1.G * (1 - amount));
            byte b = (byte)((color2.B * amount) + color1.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }

        private void LanderGraphics_Paint(object sender, PaintEventArgs e)
        {
            if (this.lander==null)
            {
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (lander.IsCrashed)
            {
                Pen p = new Pen(Color.Yellow);
                g.Clear(Color.Black);
                g.DrawString("YOU CRASHED!!!", DefaultFont, p.Brush, 100, 100);
            }
            else
            {
                float mix = (float)lander.Altitude;
                if (mix==-1)
                {
                    mix = 1;
                } else
                {
                    mix /= 3000;
                }
                float alt = (1-mix)*200;
                float floor = 334+(float)Math.Round((Math.Sqrt(mix)*250));
                float floorMedium = 304 + (float)Math.Round((Math.Sqrt(mix) * 200));
                float floorFar = 254 + (float)Math.Round((Math.Sqrt(mix) * 150));
                mix *= mix;
                g.Clear(Blend(Color.LightBlue, Color.DarkBlue, mix));

                Pen p = new Pen(Color.LightGreen);
                g.FillRectangle(p.Brush, 0, floorFar, 700, 300);
                p = new Pen(Color.Green);
                g.FillRectangle(p.Brush, 0, floorMedium, 700, 300);
                p = new Pen(Color.DarkGreen);
                g.FillRectangle(p.Brush, 0, floor, 700, 300);

                if (!lander.IsLanded && lander.Thrust>0 && lander.Fuel>0)
                {
                    float y = 130+alt;
                    g.DrawImage(Resources.flames, 77, y, new Rectangle(flame * 100 + 10, 0, 80, 200), GraphicsUnit.Pixel);
                    if (oddeven)
                    {
                        int other = (flame + 1) % 6;
                        g.DrawImage(Resources.flames, 77, y, new Rectangle(other * 100 + 10, 0, 80, 200), GraphicsUnit.Pixel);
                    }
                }
                g.DrawImage(Resources.rocket, 50, 34+alt);
            }
        }
    }
}
