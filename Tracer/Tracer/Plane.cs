using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Tracer
{
    public class Plane:TracableElement
    {
        private Point origin, normal;
        private double d;

        public Plane(Point origin, Point normal):base(new SolidTexture(Color.DarkGreen))
        {
            this.origin = origin;
            this.normal = Point.normalize(normal);

            this.d = -Point.dot(this.origin, this.normal);
        }

        public Point Origin { get { return this.origin; } }
        public Point Normal { get { return this.normal; } }
        public double D {  get { return this.d; } }

        public double intersection(Plane p, Line l)
        {
            Point origin = l.Origin;
            Point delta = l.Delta;
            Point normal = p.Normal;
            double a = Point.dot(origin, normal)-d;
            double b = Point.dot(delta, normal);
            if (b==0)
            {
                return Double.NaN;
            } else
            {
                return a / b;
            }
        }

        public override double intersection(Line ray)
        {
            return intersection(this, ray);
        }

        public override Point getNormal(Point point)
        {
            return Normal;
        }

        public override double distance(Point point)
        {
            Point n = Point.normalize(this.normal);
            double dot = Point.dot(point, this.normal);
            return dot + d;
        }

        public override double distanceSquared(Point point)
        {
            double d = distance(point);
            return d * d;
        }
    }
}
