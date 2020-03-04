using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public abstract class Texture
    {
        public Color getColor(Point point)
        {
            return this.getColor(point.X, point.Y, point.Z);
        }

        public abstract Color getColor(double x, double y, double z);
    }

    public class SolidTexture : Texture
    {
        public static readonly Texture RED = new SolidTexture(Color.Red);
        public static readonly Texture GREEN = new SolidTexture(Color.Green);
        public static readonly Texture BLUE = new SolidTexture(Color.Blue);
        public static readonly Texture YELLOW = new SolidTexture(Color.Yellow);
        public static readonly Texture PURPLE = new SolidTexture(Color.Purple);
        public static readonly Texture WHITE = new SolidTexture(Color.White);
        public static readonly Texture BLACK = new SolidTexture(Color.Black);
        public static readonly Texture GRAY = new SolidTexture(Color.Gray);
        private readonly Color color;

        public SolidTexture(Color color)
        {
            this.color = color;
        }

        public override Color getColor(double x, double y, double z)
        {
            return this.color;
        }
    }

    public class CheckerTexture : Texture
    {
        private readonly Texture odd, even;
        private readonly double sx, sy, sz;

        public CheckerTexture(Texture odd, Texture even, double sx = 1, double sy = 1, double sz = 1)
        {
            this.odd = odd;
            this.even = even;
            this.sx = sx;
            this.sy = sy;
            this.sz = sz;
        }

        public override Color getColor(double x, double y, double z)
        {
            int total = 0;
            total += oddeven(x / sx);
            total += oddeven(y / sy);
            total += oddeven(z / sz);
            return ((total % 2) == 0) ? this.odd.getColor(x, y, z) : this.even.getColor(x, y, z);
        }

        public static int oddeven(double value)
        {
            return (int)Math.Floor(Math.Abs(value) - 0.5);
        }
    }

    public class GradientTexture : Texture
    {
        public enum Mode
        {
            LINEAR,
            BLOCK,
            SINE
        }
        private readonly TextureGradient gradient;
        private readonly Mode mode;
        private readonly bool mirrored;
        private readonly double scale;

        public GradientTexture(Texture from, Texture to, Mode mode = Mode.LINEAR, bool mirrored = true, double scale = 1)
        {
            this.gradient = new TextureGradient(from, to);
            this.mode = mode;
            this.mirrored = mirrored;
            this.scale = scale;
        }

        public void add(double index, Texture texture)
        {
            this.gradient.add(index, texture);
        }

        protected Color getColor(double phase, double x, double y, double z)
        {
            return this.gradient.getColor(phase, x, y, z);
        }

        public override Color getColor(double x, double y, double z)
        {
            double value = Math.Abs(x / scale);
            long order = (long)Math.Floor(value);
            double phase = value - order;
            if (mirrored && ((order % 2) == 1))
            {
                phase = 1 - phase;
            }
            phase = getPhase(phase);
            return this.getColor(phase, x, y, z);
            //if (phase == 0)
            //{
            //    return this.to.getColor(x, y, z);
            //}
            //else if (phase == 1)
            //{
            //    return this.from.getColor(x, y, z);
            //}
            //else
            //{
            //    Color from = this.from.getColor(x, y, z);
            //    Color to = this.to.getColor(x, y, z);

            //    return mixColor(from, to, phase);
            //}
        }

        private double getPhase(double phase)
        {
            switch (this.mode)
            {
                case (Mode.LINEAR): { return phase; }
                case (Mode.BLOCK): { return (phase < 0.5) ? 0 : 1; }
                case (Mode.SINE): { return (Math.Cos(phase * Math.PI) + 1) / 2; }
                default: { return 0; }
            }
        }

        public static Color mixColor(Color c1, Color c2, double v)
        {
            double value = (v < 0) ? 0 : ((v > 1) ? 1 : v);
            double minus = 1 - value;
            return Color.FromArgb(
                mix(c1.R, c2.R, value),
                mix(c1.G, c2.G, value),
                mix(c1.B, c2.B, value)
                );
        }

        private static byte mix(byte b1, byte b2, double value)
        {
            double d = (b1 * value) + (b2 * (1 - value));
            int i = (int)Math.Round(d);
            return (byte)clamp(0, i, 255);
        }

        public static int clamp(int lower, int value, int higher)
        {
            if (value < lower)
            {
                return lower;
            }
            else if (value > higher)
            {
                return higher;
            }
            else
            {
                return value;
            }
        }

        public static double clamp(double lower, double value, double higher)
        {
            if (value < lower)
            {
                return lower;
            }
            else if (value > higher)
            {
                return higher;
            }
            else
            {
                return value;
            }
        }
    }


    public abstract class RotatedTexture : Texture
    {
        public static readonly double PI180 = Math.PI / 180;
        protected readonly double cr, sr;
        protected readonly Texture texture;

        public RotatedTexture(Texture texture, double angle)
        {
            this.texture = texture;
            this.cr = Math.Cos(angle * PI180);
            this.sr = Math.Sin(angle * PI180);
        }
    }

    public class XRotatedTexture : RotatedTexture
    {
        public XRotatedTexture(Texture texture, double angle) : base(texture, angle)
        { }

        public override Color getColor(double x, double y, double z)
        {
            double ry = y * cr + z * sr;
            double rz = y * -sr + z * cr;
            return this.texture.getColor(x, ry, rz);
        }
    }

    public class YRotatedTexture : RotatedTexture
    {
        public YRotatedTexture(Texture texture, double angle) : base(texture, angle)
        { }

        public override Color getColor(double x, double y, double z)
        {
            double rx = x * cr + z * -sr;
            double rz = x * sr + z * cr;
            return this.texture.getColor(rx, y, rz);
        }
    }

    public class ZRotatedTexture : RotatedTexture
    {
        public ZRotatedTexture(Texture texture, double angle) : base(texture, angle)
        { }

        public override Color getColor(double x, double y, double z)
        {
            double rx = x * cr + y * sr; ;
            double ry = y * -sr + x * cr;
            return this.texture.getColor(rx, ry, z);
        }
    }

    public class XYZRotatedTexture : Texture
    {
        private readonly Texture texture;

        public XYZRotatedTexture(Texture texture, double anglex = 0, double angley = 0, double anglez = 0)
        {
            this.texture = new XRotatedTexture(new YRotatedTexture(new ZRotatedTexture(texture, anglez), angley), anglex);
        }

        public override Color getColor(double x, double y, double z)
        {
            return texture.getColor(x, y, z);
        }
    }

    public class ScaledTexture : Texture
    {
        private readonly Texture texture;
        private readonly double sx, sy, sz;

        public ScaledTexture(Texture texture, double sx = 1, double sy = 1, double sz = 1)
        {
            this.texture = texture;
            this.sx = sx;
            this.sy = sy;
            this.sz = sz;
        }

        public override Color getColor(double x, double y, double z)
        {
            return texture.getColor(x / sx, y / sy, z / sz);
        }
    }

    public class TranslatedTexture : Texture
    {
        private readonly Texture texture;
        private readonly double dx, dy, dz;

        public TranslatedTexture(Texture texture, double dx = 0, double dy = 0, double dz = 0)
        {
            this.texture = texture;
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;
        }

        public override Color getColor(double x, double y, double z)
        {
            return texture.getColor(x - dx, y - dy, z - dz);
        }
    }

    public class PerlinNoiseTexture : GradientTexture
    {
        public PerlinNoiseTexture(Texture from, Texture to):base(from, to)
        {
            for (int i = 0; i < 256; i++) p[256 + i] = p[i] = permutation[i];
        }

        public override Color getColor(double x, double y, double z)
        {
            double phase = multiPerlin(x * 0.3, y * 0.3, z * 0.3);
            return this.getColor(phase, x, y, z);
            //Color from = this.from.getColor(x, y, z);
            //Color to = this.to.getColor(x, y, z);
            //return GradientTexture.mixColor(from, to, phase);
        }

        private double multiPerlin(double x, double y, double z, int octaves = 8, double power = 0.9, double decay = 0.75)
        {
            double total = 0;
            for (int i = 0; i < octaves; i++)
            {
                double temp = perlin(x, y, z) * power;
                total += temp;
                x *= 2;
                y *= 2;
                z *= 2;
                x += 7;
                z += 13;
                power *= decay;
            }
            return GradientTexture.clamp(0, total, 1);
        }

        private double perlin(double x, double y, double z)
        {
            int X = (int)Math.Floor(x) & 255,                  // FIND UNIT CUBE THAT
                Y = (int)Math.Floor(y) & 255,                  // CONTAINS POINT.
                Z = (int)Math.Floor(z) & 255;
            x -= Math.Floor(x);                                // FIND RELATIVE X,Y,Z
            y -= Math.Floor(y);                                // OF POINT IN CUBE.
            z -= Math.Floor(z);
            double u = fade(x),                                // COMPUTE FADE CURVES
                   v = fade(y),                                // FOR EACH OF X,Y,Z.
                   w = fade(z);
            int A = p[X] + Y, AA = p[A] + Z, AB = p[A + 1] + Z,      // HASH COORDINATES OF
                B = p[X + 1] + Y, BA = p[B] + Z, BB = p[B + 1] + Z;      // THE 8 CUBE CORNERS,

            return lerp(w, lerp(v, lerp(u, grad(p[AA], x, y, z),  // AND ADD
                                           grad(p[BA], x - 1, y, z)), // BLENDED
                                   lerp(u, grad(p[AB], x, y - 1, z),  // RESULTS
                                           grad(p[BB], x - 1, y - 1, z))),// FROM  8
                           lerp(v, lerp(u, grad(p[AA + 1], x, y, z - 1),  // CORNERS
                                           grad(p[BA + 1], x - 1, y, z - 1)), // OF CUBE
                                   lerp(u, grad(p[AB + 1], x, y - 1, z - 1),
                                           grad(p[BB + 1], x - 1, y - 1, z - 1))));
        }
        static double fade(double t) { return t * t * t * (t * (t * 6 - 15) + 10); }
        static double lerp(double t, double a, double b) { return a + t * (b - a); }
        static double grad(int hash, double x, double y, double z)
        {
            int h = hash & 15;                      // CONVERT LO 4 BITS OF HASH CODE
            double u = h < 8 ? x : y,                 // INTO 12 GRADIENT DIRECTIONS.
                   v = h < 4 ? y : h == 12 || h == 14 ? x : z;
            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }
        private readonly int[] p = new int[512];
        private readonly int[] permutation = { 151,160,137,91,90,15,
   131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
   190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
   88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
   77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
   102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
   135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
   5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
   223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
   129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
   251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
   49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
   138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
   };

    }

    class GradientEntry:IComparable
    {
        private double index;
        private Texture texture;

        public GradientEntry(double index, Texture texture)
        {
            this.index = GradientTexture.clamp(0,index,1);
            this.texture = texture;
        }

        public int CompareTo(object obj)
        {
            return CompareTo((GradientEntry)obj);
        }

        public int CompareTo(GradientEntry other)
        {
            return Math.Sign(this.index - other.index);
        }

        public double Index {  get { return this.index; } }
        public Texture Texture { get { return this.texture; } }
    }

    public class TextureGradient {
        private SortedSet<GradientEntry> entries = new SortedSet<GradientEntry>();

        public TextureGradient(Color color):this(color, color)
        {
        }

        public TextureGradient(Color from, Color to):this(new SolidTexture(from), new SolidTexture(to))
        {
        }

        public TextureGradient(Texture texture) : this(texture, texture)
        {
        }

        public TextureGradient(Texture from, Texture to)
        {
            this.entries.Add(new GradientEntry(0, from));
            this.entries.Add(new GradientEntry(1, to));
        }

        public void add(double index, Texture texture)
        {
            this.entries.Add(new GradientEntry(index, texture));
        }

        public Color getColor(double phase, Point point)
        {
            return getColor(phase, point.X, point.Y, point.Z);
        }

        public Color getColor(double phase, double x, double y, double z)
        {
            GradientEntry lesser = null, higher = null;
            foreach(GradientEntry entry in this.entries)
            {
                if (entry.Index<phase)
                {
                    lesser = entry;
                } else
                {
                    higher = entry;
                    break;
                }
            }
            if (lesser==null)
            {
                return higher.Texture.getColor(x,y,z);
            } else if (higher==null)
            {
                return lesser.Texture.getColor(x,y,z);
            } else
            {
                double offset = (higher.Index - phase) / (higher.Index - lesser.Index);
                Color from = lesser.Texture.getColor(x,y,z);
                Color to = higher.Texture.getColor(x,y,z);
                return GradientTexture.mixColor(from, to, offset);
            }
        }
    }
}
