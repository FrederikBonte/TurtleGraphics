using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsUtilities.Fractals
{
    public partial class HSVMap : UserControl
    {
        private HSVGradient gradient;
        public HSVMap()
        {
            InitializeComponent();
            gradient = new HSVGradient(
                new HSVColor(360*7,0f,1f),
                new HSVColor(0, 1f, 0.3f)
                );
        }

        private void HSVMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            FillGradient(g);
        }

        private void FillGradient(Graphics g)
        {
            for (int x = 0; x < Width; x++)
            {
                Pen p = new Pen(gradient.getRGBColor(x*1.0f/Width));
                g.FillRectangle(p.Brush, x, 0, 1, Height);
            }
        }

        private void FillFullGradient(Graphics g)
        { 
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    float h = x * 360.0f / Width;
                    float v = y * 1.0f / Height;
                    Pen p = new Pen(HSVColor.fromHSV(h, 0.5f, v));
                    g.FillRectangle(p.Brush, x, y, 1, 1);
                }
            }
        }
    }
}
