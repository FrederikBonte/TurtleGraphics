using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KochCurve
{
    public partial class KochCurve : UserControl
    {
        private readonly List<Line> lines = new List<Line>();
        private readonly double[] definition =
        {
            0,     0,
            1.0/3, 0,
            1.0/3, 1.0/4,
            2.0/3, 1.0/4,
            2.0/3, 0,
            1.0,   0
        };
/*        private static readonly double[] definition =
        {
            0/2.0,  0,
            1/2.0,  0,
            1/2.0,  1/2.0,
            2/2.0,  1/2.0,
            2/2.0,  0
        };*/
        public KochCurve()
        {
            InitializeComponent();

            lines.Add(new Line(new Point(30, 250), new Point(500, 50)));
            lines.Add(new Line(new Point(500, 50), new Point(500, 500)));
            lines.Add(new Line(new Point(500, 500), new Point(30, 250)));
        }

        private void KochCurve_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            p.Width = 2;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Line line in lines)
            {
                e.Graphics.DrawLine(p, line.p1, line.p2);
            }
        }

        public void refine()
        {
            // Create a new list...
            List<Line> newList = new List<Line>();
            // Loop through all existing lines...
            foreach (Line line in lines)
            {
                // Refine each line into 4 new lines.
                newList.AddRange(refine(line));
            }
            // Erase original list.
            this.lines.Clear();
            // Fill with the new set of lines.
            this.lines.AddRange(newList);
            // Draw the screen again.
            this.Invalidate();
        }

        private List<Line> refine(Line line)
        {
            // Calculate line direction
            double dx = line.p2.X - line.p1.X;
            double dy = line.p2.Y - line.p1.Y;

            // Refine line origin and direction.
            return refine(line.p1, dx, dy);
        }

        private List<Line> refine(Point p1, double dx, double dy)
        {
            List<Line> result = new List<Line>();

            Point start = new Point(0,0), next;
            bool first = true;

            double mdx = dy;
            double mdy = -dx;

            for (int i = 0; i < definition.Length; i += 2)
            {
                double f1 = definition[i];
                double f2 = definition[i + 1];
                next = new Point(
                    (int)Math.Round(p1.X + f1*dx + f2*mdx),
                    (int)Math.Round(p1.Y + f1*dy + f2*mdy)
                    );
                if (first)
                {
                    first = false;
                }
                else
                {
                    result.Add(new Line(start, next));
                }
                start = next;
            }

            return result;
        }

    }

    public class Line
    {
        public readonly Point p1, p2;

        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}
