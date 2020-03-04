using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projections
{
    public partial class Sierpinski : UserControl
    {
        private static readonly Random RNG = new Random();
        private Image painting;
        private Graphics ig;
        private Point[] points;
        private Point point = new Point(RNG.Next(500), RNG.Next(500));
        private readonly int margin = 25;

        public Sierpinski()
        {
            InitializeComponent();
            Sierpinski_SizeChanged(null, null);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Black);
            for (int i=0;i<1000;i++)
            {
                Point target = points[RNG.Next(points.Length)];
                point.x = 0.5 * (point.x + target.x);
                point.y = 0.5 * (point.y + target.y);
                ig.FillRectangle(p.Brush, (int)point.x, (int)point.y, 1, 1);
            }
            Invalidate();
        }

        private void Sierpinski_Paint(object sender, PaintEventArgs e)
        {
            if (this.painting!=null)
            {
                e.Graphics.DrawImage(this.painting, 0, 0);
            }
        }

        private void Sierpinski_SizeChanged(object sender, EventArgs e)
        {
            this.painting = new Bitmap(this.Width, this.Height);
            this.ig = Graphics.FromImage(this.painting);
            this.ig.Clear(Color.Wheat);
            this.initPoints();
        }

        private void initPoints()
        {
            this.points = new Point[3];
            this.points[0] = new Point(this.Width / 2, margin);
            this.points[1] = new Point(margin, this.Height - margin);
            this.points[2] = new Point(this.Width - margin, this.Height - margin);
        }
    }
}
