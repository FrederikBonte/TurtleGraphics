using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class Line
    {
        private Point p1, p2, delta;

        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.delta = Point.delta(this.p1, this.p2, -1);
        }

        public Point P1 { get { return this.p1; } }
        public Point P2 { get { return this.p2; } }
        public Point Origin { get { return this.p1; } }
        public Point Delta { get { return this.delta; } }

        public Point PointAt(double l, double margin = 0.0001)
        {
            double rx = this.delta.X * (l - margin) + this.Origin.X;
            double ry = this.delta.Y * (l - margin) + this.Origin.Y;
            double rz = this.delta.Z * (l - margin) + this.Origin.Z;
            return new Point(rx, ry, rz);
        }

        internal static Point getClosest(Point point, Line segment)
        {
            Point ap = Point.subtract(segment.P1, point);
            double t = Point.dot(ap, segment.Delta) / segment.Delta.lengthSquared();
            t = GradientTexture.clamp(0, t, 1);
            return segment.PointAt(t);
        }
    }
}
