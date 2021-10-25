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

namespace ROCvanTwente.Sumpel.Semester2.Noise
{
    public partial class NoiseMap : UserControl
    {
        private Image image = null;

        public NoiseMap()
        {
            InitializeComponent();
            ResizeRedraw = true;
            Perlin.init();
        }

        private void NoiseMap_Paint(object sender, PaintEventArgs e)
        {
            if (image == null)
            {
                generate();
            }
            e.Graphics.DrawImage(image, 0, 0);
        }

        private void generate()
        {
            this.image = new Bitmap(this.Width, this.Height);
            Graphics ig = Graphics.FromImage(this.image);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    double n = Perlin.noise(x*0.5, y*0.5, 0); //, 0.5, 5, 0.7, 0.2);
                    int c = (int)Math.Floor(n * 255); // 128+n*128);
                    if (c<0)
                    {
                        c = 0;
                    }
                    else if (c>255)
                    {
                        c = 255;
                    }
                    Pen p = new Pen(Color.FromArgb(c, c, c));
                    ig.FillRectangle(p.Brush, x, y, 1, 1);
                }
            }
        }
    }
}
