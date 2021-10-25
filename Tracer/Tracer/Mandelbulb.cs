using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class Mandelbulb : TracableElement
    {
        private readonly double power;
        private readonly Point center;
        private readonly double scale;
        private const int ITERATIONS = 250;

        public Mandelbulb(double power = 8, double scale = 1) : this(Point.ORIGIN,power,scale)
        {
        }

        public Mandelbulb(Point center, double power = 8, double scale = 1) : base(SolidTexture.WHITE)
        {
            this.power = power;
            this.scale = scale;
            this.center = center;
        }

        public override double distance(Point point)
        {
            return mandelbulbDistance(point);
        }

        public override double distanceSquared(Point point)
        {
            double d = mandelbulbDistance(point);
            return d*d;
        }

        public double mandelbulbDistance(Point point)
        {
            Point z = Point.scale(point, this.scale);
            double dr = 20;
            double r = 0;

            for (int i = 0; i < ITERATIONS; i++)
            {
                r = z.length();
                if (r>2) break;

                double theta = Math.Acos(z.Z / r)*power;
                double phi = Math.Atan2(z.Y, z.X)*power;
                double zr = Math.Pow(r, power);
                dr = Math.Pow(r, power - 1) * power * dr + 1;

                double zx = Math.Sin(theta) * Math.Cos(phi) * zr;
                double zy = Math.Sin(phi) * Math.Sin(theta) * zr;
                double zz = Math.Cos(theta) * zr;
                Point delta = new Point(zx, zy, zz);
                z = Point.add(z, delta);
            }
            return 0.5 * Math.Log(r) * r / dr;
        }

        public override Point getNormal(Point point)
        {
            MutablePoint result = new MutablePoint();
            for (int z=-1;z<=1;z++)
            {
                for (int y=-1; y<=1;y++)
                {
                    for (int x=-1;x<=1;x++)
                    {
                        if (x==0 && y==0 && z==0)
                        {
                            continue;
                        }

                        Point target = new MutablePoint(point.X + x * 0.2, point.Y + y * 0.2, point.Z + z * 0.2);
                        double d = mandelbulbDistance(target);
                        Point delta = new Point(x * d, y * d, z * d);
                        result.add(delta);
                    }
                }
            }
            result.scale(1 / result.length());
            return result;
        }

        public override double intersection(Line ray)
        {
            throw new NotImplementedException();
        }
    }
}
