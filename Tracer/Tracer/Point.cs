using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class Point
    {
        public static readonly Point ORIGIN = new Point(0, 0, 0);
        private double x, y, z;

        public Point() : this(0, 0, 0)
        { }

        public Point(Point p) : this(p.X, p.Y, p.Z)
        { }

        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X
        {
            get { return this.x; }
            protected set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            protected set { this.y = value; }
        }
        public double Z
        {
            get { return this.z; }
            protected set { this.z = value; }
        }

        public double lengthSquared()
        {
            return this.x * this.x + this.y * this.y + this.z * this.z;
        }

        public double length()
        {
            return Math.Sqrt(this.lengthSquared());
        }

        public static Point normalize(Point vector)
        {
            double l = vector.length();
            return new Point(vector.X / l, vector.Y / l, vector.Z / l);
        }

        public static Point delta(Point p1, Point p2, double length = 1)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double dz = p2.Z - p1.Z;
            double l = Math.Sqrt(dx * dx + dy * dy + dz * dz);
            if (length!=-1)
            {
                l *= length;
            }
            return new Point(dx / l, dy / l, dz / l);
        }

        public static double dot(Point p1, Point p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y + p1.Z * p2.Z;
        }

        public static Point add(Point p1, Point p2)
        {
            return new Point(
                p1.X + p2.X,
                p1.Y + p2.Y,
                p1.Z + p2.Z
                );
        }

        public static Point subtract(Point p1, Point p2)
        {
            return new Point(
                p2.X - p1.X,
                p2.Y - p1.Y,
                p2.Z - p1.Z
                );
        }

        public static double distanceSquared(Point p1, Point p2)
        {
            double result = 0;
            double d = p1.X - p2.X;
            result += d * d;
            d = p1.Y - p2.Y;
            result += d * d;
            d = p1.Z - p2.Z;
            result += d * d;
            return result;
        }

        public static double distance(Point p1, Point p2)
        {
            return Math.Sqrt(distanceSquared(p1,p2));
        }

        public static Point perpendicular(Point p1, Point p2)
        {
            return new Point(
                p1.Y * p2.Z - p1.Z * p2.Y,
                p1.Z * p2.X - p1.X * p2.Z,
                p1.X * p2.Y - p1.Y * p2.X
                );
        }

        public static Point scale(Point p, double s)
        {
            return new Point(p.X / s, p.Y / s, p.Z / s);
        }

        public static Point scale(Point p, Point s)
        {
            return scale(p, s.X, s.Y, s.Z);
        }

        public static Point scale(Point p, double sx, double sy, double sz)
        {
            return new Point(p.X / sx, p.Y / sy, p.Z / sz);
        }
    }

    public class MutablePoint : Point
    {
        public MutablePoint() : base(0, 0, 0)
        { }

        public MutablePoint(Point p) : base(p.X, p.Y, p.Z)
        { }

        public MutablePoint(double x, double y, double z) : base(x, y, z)
        {
        }

        public new double X
        {
            get { return base.X; }
            set { base.X = value; }
        }
        public new double Y
        {
            get { return base.Y; }
            set { base.Y = value; }
        }
        public new double Z
        {
            get { return base.Z; }
            set { base.Z = value; }
        }

        public void add(Point p)
        {
            this.add(p.X, p.Y, p.Z);
        }

        public void add(double x, double y, double z)
        {
            this.X += x;
            this.Y += y;
            this.Z += z;
        }

        public void subtract(Point p)
        {
            this.add(-p.X, -p.Y, -p.Z);
        }

        public void subtract(double x, double y, double z)
        {
            this.add(-x, -y, -z);
        }

        public void scale(double scale)
        {
            this.scale(scale, scale, scale);
        }

        public void scale(Point p)
        {
            this.scale(p.X, p.Y, p.Z);
        }

        public void scale(double sx, double sy, double sz)
        {
            this.X *= sx;
            this.Y *= sy;
            this.Z *= sz;
        }


    }

    // @TODO: Animated point...
}
