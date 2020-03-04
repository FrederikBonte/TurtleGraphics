using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projections
{
    public class Point
    {
        public double x, y, z, w;

        public Point(double x, double y, double z = 0, double w = 1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void normalize()
        {
            if (this.w == 0)
            {
                return;
            } else
            {
                this.x /= this.w;
                this.y /= this.w;
                this.z /= this.w;
                this.w = 1;
            }
        }
    }

    public interface IMatrix
    {
        double get(int x, int y);
    }

    public interface IMutableMatrix : IMatrix
    {
        void set(int x, int y, double value);
    }

    public class Mesh : IMatrix
    {
        private List<Point> coordinates, transformedCoordinates;
        private List<int[]> polygons;
        private Transformation transformation = Transformation.UNIT;

        public Mesh(params Point[] coordinates)
        {
            this.coordinates = new List<Point>();
            this.transformedCoordinates = new List<Point>();
            this.coordinates.AddRange(coordinates);
            foreach (var point in coordinates)
            {
                this.transformedCoordinates.Add(new TransformedPoint(point, this.transformation));
            }
        }

        public Mesh(List<Point> coordinates)
        {
            this.coordinates = new List<Point>();
            this.transformedCoordinates = new List<Point>();
            this.coordinates.AddRange(coordinates);
            foreach (var point in coordinates)
            {
                this.transformedCoordinates.Add(new TransformedPoint(point, this.transformation));
            }
        }

        public void Add(Point p)
        {
            coordinates.Add(p);
        }

        public void Add(int[] polygon)
        {
            this.polygons.Add(polygon);
        }

        public Transformation Transformation
        {
            get { return this.transformation; }
            set
            {
                this.transformation = value; foreach (TransformedPoint point in transformedCoordinates)
                {
                    point.Transformation = this.transformation;
                }
            }
        }

        public double get(int x, int y)
        {
            Point p = transformedCoordinates[y];
            switch (x)
            {
                case 0: return p.x;
                case 1: return p.y;
                case 2: return p.z;
                case 3: return p.w;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    public class Transformation : IMutableMatrix
    {
        public static readonly Transformation UNIT = new Transformation(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

        public double[] values = new double[16];

        public Transformation(params double[] values)
        {
            if (values.Length == 0)
            {
                this.values = new double[16];
            } else if (values.Length == 16) {
                this.values = values;
            } else
            {
                throw new ArgumentException();
            }
        }

        public double get(int x, int y)
        {
            return values[y * 4 + x];
        }

        public void set(int x, int y, double value)
        {
            values[y * 4 + x] = value;
        }

        public double[] ToArray()
        {
            return values;
        }

        public static Transformation mul(Transformation one, Transformation two)
        {
            Transformation result = new Transformation();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    double sum = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        sum += one.get(i, y) * two.get(x, i);
                    }
                    result.set(x, y, sum);
                }
            }
            return result;
        }

        public static Transformation mul(Transformation tf, double factor)
        {
            Transformation result = new Transformation();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    result.set(x, y, tf.get(x, y) * factor);
                }
            }
            return result;
        }

        public static Transformation add(params Transformation[] ts)
        {
            Transformation result = new Transformation();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    double sum = 0;
                    for (int i = 0; i < ts.Length; i++)
                    {
                        sum += ts[i].get(x, y);
                    }
                    result.set(x, y, sum);
                }
            }
            return result;
        }

        public static Transformation createTranslation(double x, double y, double z)
        {
            return new Transformation(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                x, y, z, 1
                );
        }

        public static Transformation createPerspective(double distance)
        {
            return new Transformation(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 0, 1 / distance,
                0, 0, 0, 1
                );
        }
        public static Transformation createRotationX(double angle)
        {
            double
                c = Math.Cos(Math.PI * angle / 180),
                s = Math.Sin(Math.PI * angle / 180);
            return new Transformation(
                1, 0, 0, 0,
                0, c, s, 0,
                0, -s, c, 0,
                0, 0, 0, 1
                );
        }

        public static Transformation createRotationY(double angle)
        {
            double
              c = Math.Cos(Math.PI * angle / 180),
              s = Math.Sin(Math.PI * angle / 180);
            return new Transformation(
                c, 0, -s, 0,
                0, 1, 0, 0,
                s, 0, c, 0,
                0, 0, 0, 1
                );
        }

        public static Transformation buildRotationZ(double angle)
        {
            double
              c = Math.Cos(Math.PI * angle / 180),
              s = Math.Sin(Math.PI * angle / 180);
            return new Transformation(
                c, s, 0, 0,
                -s, c, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );
        }

    }

    public class TransformedPoint : Point {
        private readonly Point original;
        private Transformation transformation;

        public TransformedPoint(Point original) : this(original, Transformation.UNIT)
        {
        }

        public TransformedPoint(Point original, Transformation transformation) : base(0, 0, 0, 0)
        {
            this.original = original;
            this.transformation = transformation;
            this.update();
        }

        public Transformation Transformation
        {
            get { return this.transformation; }
            set { this.transformation = value; this.update(); }
        }

        private void update()
        {
            base.x =
                original.x * transformation.get(0, 0) +
                original.y * transformation.get(0, 1) +
                original.z * transformation.get(0, 2) +
                original.w * transformation.get(0, 3);
            base.y =
                original.x * transformation.get(1, 0) +
                original.y * transformation.get(1, 1) +
                original.z * transformation.get(1, 2) +
                original.w * transformation.get(1, 3);
            base.z =
                original.x * transformation.get(2, 0) +
                original.y * transformation.get(2, 1) +
                original.z * transformation.get(2, 2) +
                original.w * transformation.get(2, 3);
            base.w =
                original.x * transformation.get(3, 0) +
                original.y * transformation.get(3, 1) +
                original.z * transformation.get(3, 2) +
                original.w * transformation.get(3, 3);
        }
    }
}
