using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Tracer
{
    public class Sphere:TracableElement
    {
        public struct Intersection
        {
            public double l1, l2;
        }

        private Point center;
        private double radius;

        public Sphere(Point center, double radius):base(SolidTexture.RED)
        {
            this.center = center;
            this.radius = radius;
        }

        public Point Center { get { return this.center; } }
        public double Radius { get { return this.radius; } }

        public static Intersection intersection(Sphere s, Line l)
        {
            Intersection result = new Intersection();

            double a, b, c;

            Point p2 = Point.subtract(s.Center, l.Origin);

            a = Point.dot(l.Delta, l.Delta);
            b = 2 * Point.dot(l.Delta, p2);
            c = Point.dot(p2, p2) - (s.Radius*s.Radius);

            double w = b * b - 4 * a * c;
            
            if (w<0)
            {
                result.l1 = Double.NaN;
                result.l2 = Double.NaN;
                return result;
            } else
            {
                w = Math.Sqrt(w);
                result.l1 = (-b - w) / (2 * a);
                result.l2 = (-b + w) / (2 * a);
            }

            return result;
        }

        public override double intersection(Line ray)
        {
            Intersection result = Sphere.intersection(this, ray);
            return result.l1;
        }

        public override Point getNormal(Point point)
        {
            return Point.delta(this.Center, point);
        }

        public override double distance(Point point)
        {
            return Point.distance(this.center, point) - this.radius;
        }

        public override double distanceSquared(Point point)
        {
            return Point.distanceSquared(this.center, point) - this.radius;
        }
    }
}
