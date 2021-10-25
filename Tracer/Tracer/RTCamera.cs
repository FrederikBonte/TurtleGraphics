using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Specialized;
using System.Collections;

namespace Tracer
{
    public partial class RTCamera : UserControl
    {
        private Bitmap painting = null;
        private Graphics pg = null;
        private int width, height, scale;
        private bool rendering = false;
        private Thread renderThread = null;
        private Point camera_origin = new Point(5, 2, -10);
        private Point camera_look_at = new Point(0, 0, 0);
        private Point up = new Point(0, 1, 0);
        private double zoom = 10;
        private List<TracableElement> elements = new List<TracableElement>();
        private Point light = new Point(50, 50, -20);
        private Random RNG = new Random();

        public RTCamera()
        {
            InitializeComponent();
            this.ResizeRedraw = true;

            TracableElement plane = new Sphere(new Point(0, -1000000002, 0), 1000000000);
            plane.Texture =
                new YRotatedTexture(
                    new CheckerTexture(
                        SolidTexture.GRAY,
                    new ScaledTexture(
                        new PerlinNoiseTexture(
                            SolidTexture.WHITE,
                            SolidTexture.BLACK
                            ),
                        3, 3, 3
                    )
                ),
                37);
            this.elements.Add(plane);


            //            this.elements.Add(new Plane(new Point(0, -1, 0), new Point(0.001, -0.1, 0)));
            //            this.elements.Add(new Sphere(new Point(0, 0, 0),3));
            //            this.elements.Add(new Sphere(new Point(-2.5, 0, 2), 3));
            //            this.elements.Add(new Sphere(new Point(1.5, 1, 1.5), 2));

            TracableElement earthCapsule = new Capsule(new Point(4, 2, -2), new Point(4.5, 0.5, -2.1), 1);

            PerlinNoiseTexture perlin = new PerlinNoiseTexture(
                            new SolidTexture(Color.DarkBlue),
                            new SolidTexture(Color.White)
                            );
            perlin.add(0.1, new SolidTexture(Color.Azure));
            perlin.add(0.15, new SolidTexture(Color.Yellow));
            perlin.add(0.3, new SolidTexture(Color.DarkGreen));
            perlin.add(0.7, new SolidTexture(Color.DarkGray));
            perlin.add(0.8, new SolidTexture(Color.White));

            earthCapsule.Texture =
                new TranslatedTexture(
                new ScaledTexture(
                    perlin,
                1.5, 1.5, 1.5),
                0.0, 0.0, 2.0);

            this.elements.Add(earthCapsule);

            for (int i = 0; i < 5; i++)
            {
                Sphere s = new Sphere(new Point(RNG.NextDouble()*10-5, RNG.NextDouble()*5-2, RNG.NextDouble()*10-5), RNG.NextDouble()*0.2+0.2);
                s.Texture = new SolidTexture(Color.FromArgb(RNG.Next(256), RNG.Next(256), RNG.Next(256)));
                this.elements.Add(s);
            }

            TracableElement mb = new Mandelbulb(new Point(0, 0, 0), 8, 3);
            mb.Texture = SolidTexture.RED;
            //mb.Texture =
            //    new XYZRotatedTexture(
            //        new GradientTexture(
            //            new SolidTexture(Color.DarkRed), 
            //            SolidTexture.RED, 
            //            GradientTexture.Mode.SINE, 
            //            true, 
            //            0.079381
            //        ), 
            //        90, 36, 127
            //    );
            this.elements.Add(mb);


        }

        private void RTCamera_Paint(object sender, PaintEventArgs e)
        {
            if (this.painting != null)
            {
                try
                {
                    e.Graphics.DrawImage(this.painting, 0, 0);
                }
                catch (Exception ex)
                {
                    // Ignore this happens when the "painting is in use elsewhere".
                }
            }
        }

        private void RTCamera_Load(object sender, EventArgs e)
        {
            this.startRenderProcess();
        }

        private void startRenderProcess(bool force = false)
        {
            if (this.rendering && !force)
            {
                // Already rendering, no need to restart.
                return;
            }
            this.rendering = false;
            if (this.renderThread != null)
            {
                this.renderThread.Join();
            }
            if (this.painting != null)
            {
                this.painting.Dispose();
            }
            this.painting = null;
            this.renderThread = new Thread(new ThreadStart(render));
            this.renderThread.Start();
        }

        private void render()
        {
            Pen p = new Pen(Color.Blue);
            if (this.painting == null)
            {
                this.painting = new Bitmap(this.DisplayRectangle.Width, this.DisplayRectangle.Height);
                this.pg = Graphics.FromImage(this.painting);
                this.width = this.painting.Width;
                this.height = this.painting.Height;
                this.scale = Math.Min(this.width, this.height);
                this.pg.DrawLine(p, 0, 0, this.width, this.height);
                this.pg.DrawLine(p, 0, this.height, this.width, 0);
            }
            for (int i = 32; i > 0; i = (i >> 1))
            {
                int mod = i * 2;
                Console.WriteLine("Render scale " + i);
                this.rendering = true;
                for (int y = 0; y < this.height; y += i)
                {
                    for (int x = 0; x < this.width; x += i)
                    {
                        if (this.rendering == false)
                        {
                            return;
                        }
                        if (mod==32 || x%mod!=0 || y%mod!=0)
                        {
                            p.Color = marchPixel(x, y);
                            this.pg.FillRectangle(p.Brush, x, y, i, i);
                        }
                        //                        Console.Write(".");
                    }
//                    Console.WriteLine();
                    this.Invalidate();
                }
            }
            Console.WriteLine("Done...");
        }

        private Color renderPixel(int x, int y)
        {
            double dx = (x - (this.width / 2.0)) / scale;
            double dy = (y - (this.height / 2.0)) / scale;

            Point p2 = new Point(dx*0.1, -dy*0.1, -9);
            Line ray = new Line(camera_origin, p2);

            SortedDictionary<double, TracableElement> hits = this.renderRay(ray);
            foreach (KeyValuePair<double, TracableElement> pair in hits)
            {
                Point hitPoint = ray.PointAt(pair.Key);
                Line lightRay = new Line(hitPoint, light);
                Point normal = pair.Value.getNormal(hitPoint);

                if (isInShadow(lightRay))
                {
                    return Color.Black;
                } else
                {
                    return GradientTexture.mixColor(pair.Value.Texture.getColor(hitPoint), Color.Black, Math.Pow(Point.dot(normal, lightRay.Delta),0.5));
                }
            }
            return Color.LightBlue;

            //double p = Math.Sqrt(dx * dx + dy * dy)*Math.PI*3;
            //return Color.FromArgb(
            //    (int)Math.Round((Math.Sin(p) + 1) * 255 / 2),
            //    (int)Math.Round((Math.Cos(p) + 1) * 255 / 2),
            //    0
            //    );

        }

        private Color marchPixel(int x, int y)
        {
            double dx = (x - (this.width / 2.0)) / scale;
            double dy = (y - (this.height / 2.0)) / scale;

            Line ray = createCameraRay(dx, dy);

            Color result = Color.MidnightBlue;

            MarchResult marchResult = this.marchRay(ray);
            if (marchResult.element != null)
            {
                Point hitPoint = ray.PointAt(marchResult.offset-0.001);
                Line lightRay = new Line(hitPoint, light);
                Point normal = marchResult.element.getNormal(hitPoint);
                Color textureColor = marchResult.element.Texture.getColor(hitPoint);

                if (isInShadowM(lightRay))
                {
                    result = Color.Black;
                }
                else
                {
                    result = GradientTexture.mixColor(textureColor, Color.Black, Math.Pow(Point.dot(normal, lightRay.Delta), 0.5));
                }
            }

            return result;

/*            double glow = GradientTexture.clamp(0, (marchResult.iterations -25) / 200.0, 1);
            return GradientTexture.mixColor(Color.White, result, glow);*/
        }

        private Line createCameraRay(double dx, double dy)
        {
            Point direction = Point.delta(camera_origin, camera_look_at);
            MutablePoint x = new MutablePoint(Point.perpendicular(direction, up));
            MutablePoint y = new MutablePoint(Point.perpendicular(direction, x));
            y.scale(dy * zoom / y.length());
            x.scale(dx * -zoom/ x.length());
            Point p2 = Point.add(direction, x);
            p2 = Point.add(p2, y);

            Line ray = new Line(camera_origin, p2);

            return ray;
        }

        private bool isInShadow(Line lightRay)
        {
            foreach (TracableElement element in this.elements)
            {
                double current = element.intersection(lightRay);
                if (Double.IsNaN(current))
                {
                    continue;
                } else if (current>0)
                {
                    return true; // Found hit.
                }
            }
            return false;
        }

        private bool isInShadowM(Line lightRay)
        {
            MarchResult m = marchRay(lightRay);
            return m.element != null;
        }

        private double smoothMin(double k = 1.0, params double[] mins)
        {
            k = GradientTexture.clamp(0, k, 1);
            double invk = 1 / k;
            double inv6 = 1 / 6.0;
            double result = mins[0];
            for (int i = 1; i < mins.Length; i++)
            {
                double minB = mins[i];
                double h = Math.Max(k-Math.Abs(result-minB), 0)*invk;
                result = Math.Min(result, minB) - h * h * h * k * inv6;
            }
            return result;
        }

        struct MarchResult
        {
            public double offset;
            public TracableElement element;
            public int iterations;
        }

        struct DistanceResult {
            public double distance;
            public TracableElement element;
        }

        private MarchResult marchRay(Line ray, double max_dist = 100000)
        {
            MarchResult result = new MarchResult();
            result.offset = 0;
            result.iterations = 0;
            result.element = null;
            DistanceResult distanceResult;
            do
            {
                Point target = ray.PointAt(result.offset);
                distanceResult = getMinDistance(target);
                if (distanceResult.distance > max_dist)
                {
                    result.element = null;
                    break;
                }
                else if (distanceResult.distance < 0.01)
                {
                    result.element = distanceResult.element;
                }
                result.offset += Math.Min(300000, distanceResult.distance);
                result.iterations++;
            } while (distanceResult.distance > 0.0001 && result.iterations<1000);

            return result;            
        }

        private DistanceResult getMinDistance(Point point)
        {
            DistanceResult result = new DistanceResult();
            result.distance = Double.NaN;
            result.element = null;
            foreach (TracableElement element in this.elements)
            {
                double distance = element.distance(point);
                if (distance < 0)
                {
                    continue;
                } else if (Double.IsNaN(result.distance) || distance<result.distance)
                {
                    result.distance = distance;
                    result.element = element;
                }
            }
            //result.distance = Math.Sqrt(result.distance);
            return result;
        }

        private SortedDictionary<double, TracableElement> renderRay(Line line)
        {
            SortedDictionary<double, TracableElement> result = new SortedDictionary<double, TracableElement>();
            foreach (TracableElement element in this.elements)
            {
                double current = element.intersection(line);
//                Console.WriteLine("Intersection with " + element.GetType() + " at distance " + current);
                if (Double.IsNaN(current) || current < 0.01)
                {
                    continue;
                }
                result.Add(current, element);
            }
            return result;
        }

        public void stop()
        {
            this.rendering = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void RTCamera_Resize(object sender, EventArgs e)
        {
            this.startRenderProcess(true);
        }

        class ReverseDoubleComparer : IEqualityComparer
        {
            public static readonly IEqualityComparer INSTANCE = new ReverseDoubleComparer();

            private ReverseDoubleComparer() { }

            public int Compare(double x, double y)
            {
                return y.CompareTo(x);
            }

            public new bool Equals(object x, object y)
            {
                return y.Equals(x);
            }

            public int GetHashCode(object obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
