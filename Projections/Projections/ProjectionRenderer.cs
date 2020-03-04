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
    public partial class ProjectionRenderer : UserControl
    {
        private readonly List<Point> points = new List<Point>();

        public ProjectionRenderer()
        {
            InitializeComponent();
            this.ResizeRedraw = true;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public void Add(Point p)
        {
            this.points.Add(p);
        }

        public void Remove(Point p)
        {
            this.points.Remove(p);
        }

        private void ProjectionRenderer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int mx = this.Width / 2;
            int my = this.Height / 2;
            float scale = (Math.Min(mx, my)/3.0f);
            e.Graphics.Transform.Translate(mx, my);
            Pen p = new Pen(Color.Black);
            foreach (var point in points)
            {
                e.Graphics.DrawRectangle(p, (int)(mx+(point.x*scale)), (int)(my+(point.y*scale)), 1, 1);
            }
        }
    }
}