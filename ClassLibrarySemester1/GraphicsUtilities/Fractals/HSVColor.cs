using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsUtilities.Fractals
{
    public class HSVColor
    {
        private double hue; // 0 - 360 degrees
        private double saturation; // 0 - 1 no to full
        private double value; // 0 - 1 black, 0.5, white

        public HSVColor(double hue, double saturation, double value)
        {
            this.hue = hue;
            this.saturation = saturation;
            this.value = value;
        }

        public double getHue()
        {
            return this.hue;
        }

        public double getSaturation()
        {
            return this.saturation;
        }

        public double getValue()
        {
            return this.value;
        }

        public Color ToRGB()
        {
            return fromHSV(getHue(), getSaturation(), getValue());
        }

        public static HSVColor blend(HSVColor left, HSVColor right, double factor)
        {
            return new HSVColor(
                lerp(left.getHue(), right.getHue(), factor),
                lerp(left.getSaturation(), right.getSaturation(), factor),
                lerp(left.getValue(), right.getValue(), factor)
                );
        }

        public static double lerp(double a, double b, double t)
        {
            return a + t * (b - a);
        }

        public static Color fromHSV(double hue, double saturation, double value)
        {
            hue = mod(hue, 360);
            saturation = clamp(0, saturation, 1);
            value = clamp(0, value, 1);

            double C = value * saturation;
            double X = C * (1 - Math.Abs(mod(hue / 60.0, 2) - 1));
            double m = value - C;

            double r = 0, g = 0, b = 0;

            if (hue < 60)
            {
                r = C;
                g = X;
            }
            else if (hue < 120)
            {
                r = X;
                g = C;
            }
            else if (hue < 180)
            {
                g = C;
                b = X;
            }
            else if (hue < 240)
            {
                g = X;
                b = C;
            }
            else if (hue < 300)
            {
                r = X;
                b = C;
            }
            else
            {
                r = C;
                b = X;
            }
            return fromRGB(r + m, g + m, b + m);
        }

        public static Color fromRGB(double r, double g, double b)
        {
            return Color.FromArgb(
                roundAndClamp(0, r * 255, 255),
                roundAndClamp(0, g * 255, 255),
                roundAndClamp(0, b * 255, 255)
                );
        }

        private static double mod(double value, int mod)
        {
            while (value > mod)
            {
                value -= mod;
            }
            while (value < 0)
            {
                value += mod;
            }
            return value;
        }

        public static int roundAndClamp(int min, double value, int max)
        {
            return clamp(
                min,
                (int)Math.Round(value),
                max
            );
        }

        private static int clamp(int min, int value, int max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }

        private static double clamp(double min, double value, double max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }
    }
}
