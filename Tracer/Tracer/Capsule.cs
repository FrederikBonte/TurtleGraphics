using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class Capsule : TracableElement
    {
        private readonly Line segment;
        private readonly double radius, lSquared;

        public Capsule(Point p1, Point p2, double radius):base(SolidTexture.PURPLE)
        {
            this.radius = radius;
            this.segment = new Line(p1, p2);
            this.lSquared = this.segment.Delta.lengthSquared();
        }

        public override double distance(Point point)
        {
            Point c = Line.getClosest(point, segment);
            return Point.distance(point, c) - radius;
        }

        public override Point getNormal(Point point)
        {
            Point c = Line.getClosest(point, segment);
            return Point.subtract(c, point);
        }

        public override double intersection(Line ray)
        {
            return -1;
        }
    }
}
