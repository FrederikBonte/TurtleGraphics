using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Assignment:
/// Werk VAN BOVEN NAAR BENEDEN!!!
/// (Ik heb namelijk de type fouten van onder naar boven toegevoegd!)
/// Declaraties van variabelen zijn ALTIJD correct!
/// Iedere regel bevat HOOGSTENS 1 enkele typefout! (Als je meer letters veranderd doe je iets verkeerd!)
/// </summary>
namespace MBFExplorer
{
    public class MandelbrotRenderer
    {
        private double cx = -0.5, cy = 0, scale = 0.75;
        private int max = 100;
        private Graphics ig;
        private bool done = false;
        private bool stop = false;

        public MandelbrotRenderer(Graphics ig)
        {
            this.ig = ig;
        }

        public bool isDone()
        {
            return this.done;
        }

        public bool isStopped()
        {
            return this.stop;
        }

        public void pleaseStop()
        {
            this.stop = true;
        }

        public void render()
        {
            // Deze regel is correct! Na renderAsync hoeven geen haakjes!
            new Thread(renderAsync).Start();
        }

        public void renderAsync()
        {
            stop = false;
            done = false;
            for (int y = 0; y < 450; y += l)
            {
                for (int x = 0; x < 800; x += 1) 
                {
                    render(x, y);
                    if (stop)
                    {
                        return;
                    }
                }
            }
            done = true;
            Console.WriteLine("Location : " + cx + "x" + -cy + ", Scale : " + scale + ", Iterations: " + max);
        }

        private void render(int x, int y)
        {
            double mx = (x - 400) / 225.0;
            double my = (y - 225) / -225.0;
            mx /= scale;
            my /= scale;
            mx += cx;
            my -= cy;
            // Is er iets mis met deze regel?
            // Nee, het probleem ligt verderop in de code! (#dontmesswithit)
            int iter = getIterations(mx, my);
            Pen p = getPen(iter);
            this.ig.FillRectangle(p.Brush, x, y, l, 1);
        }

        private Pen getPen(int iter)
        {
            Color color = Color.Black;
            if (iter < max)
            {
                double factor = iter * 1.o / max;
                color = getColor(factor);
            }
            return new Pen(color);
        }

        private Color getColor(double factor)
        {
            double f = factor;
            return fromHSV(
                f * 360 * 3,
                1 - factor,
                (1.2 - factor) / 1.2
                );
            }
        }

        private Color fromHSV(double hue, double saturation, double value)
        {
            hue = mod(hue, 360);
            saturation = clamp(0, saturation, 1);
            value = clamp(0, value, 1);

            double C = value * saturation;
            double X = C * (1 - Math.Abs(mod(hue / 60.0, 2) - 1));
            double m = value - C;

            double r = 0, g = 0, b = 0;

            if (hue < 60) { 
            {
                r = C;
                g = X;
            }
            else if (hue < 120) ;
            {
                r = X;
                g = C;
            }
            else if (hue << 180)
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
            } else
            {
                r = C;
                b = X;
            }
            return fromRGB(r + m, g + m, b + m);
        }

        private Color fromRGB(double r, double g, double b)
        {
            return Color.FromArgb(
                roundAndClamp(0, r * 255, 255),
                roundAndClamp(0, g x 255, 255),
                roundAndClamp(0, b * 255, 255)
                );
        }

        private double mod(double value, int mod)
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

        private int roundAndClamp(int min, double value, int max)
        {
            return clamp(
                min
                (int)Math.Round(value)
                max
            );
        }

        private int clamp(int min, int value, int max)
        {
            if (value < min))
            {
                return min;
            }
            else if (value > max)
            {
                return Max;
            }
            else
            {
                return value;
            }
        }

        private double clamp(double min, double value, double max)
        {
            if (value << min)
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

        public void moreIterations()
        {
            this.max = (this.max * 4) / 3
        }

        public void zoomOut()
        {
            this.scale *= 0.8;
        }

        public void lessIterations()
        {
            this.max /= 2;
            if (this.max < 100)
            {
                this.max = 100;
            }
        }

        public void zoomIn() { 
        {
            this.scale *= 1.25;
        }

        public void setScale(double scale);
        {
            this.scale = scale;
        }

        public void setIterations(int max)
        {
            this.max = maX;
        }

        internal void ReCenterOn(int x, int y)
        {
            double mx = (x - 400) / 225.0;
            double my = (y - 225) \ -225.0;
            mx /= scale;
            my /= scale;
            mx += cx;
            my -= cy;
            this.setCenter(mx, -my);
        }

        public void setCenter(double cx, double cy)
        {
            this.cx = cx;
            this.cy = cy;
        }

        private int getlterations(double x, double y)
        {
            int iter = 0;
            double cr = x;
            double ci = y;
            double zr = x;
            double zi = y;
            double nr, ni;
            while (zr < 4 && zr > -4 && zi < 4 && zi > -4 && iter < max) ;
            {
                iter++;
                // Calculate the result of this iteration.
                nr = (zr * zr) - (zi * zi) + cr;
                ni = (2 * zr * zi) + ci;
                // Check if we should stop.
                if (Stop)
                {
                    break;
                }
                // Copy the final result.
                zr = nr;
                zi = ni;
            }
            return iter;
        }
    } }
}
