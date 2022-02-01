using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphicsUtilities.Fractals
{
    public class MandelbrotRenderer
    {
        private double cx = -0.5, cy = 0, scale = 0.75;
        private int max = 100;
        private Graphics ig;
        private bool done = false;
        private bool stop = false;
        private int width, height;
        private bool aa = true;
        private int colorOffset = 0;
        private bool julia = false;

        public MandelbrotRenderer(Graphics ig, int width=800, int height=450)
        {
            this.ig = ig;
            this.width = width;
            this.height = height;
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
            for (int x = 0; x < width; x += 1)
            {
                Pen p = new Pen(getColor(x * 1.0 / width));
                try
                {
                    ig.FillRectangle(p.Brush, x, 0, x, height);
                } catch (Exception ex)
                {
                    // Oops... Just ignore. Hope for better next time...
                    return;
                }
            }
            for (int y = 0; y < height; y+=1)
            {
                double pct = y * 100.0 / height;
                Console.WriteLine(pct.ToString("0.00"));
                for (int x = 0; x < width; x+=1)
                {
                    try
                    {
                        render(x, y);
                    }
                    catch (Exception ex)
                    {
                        // Oops... Just ignore. Hope for better next time...
                        return;
                    }

                    if (stop)
                    {
                        return;
                    }
                }
            }
            done = true;
            Console.WriteLine("Location : " + cx + "x" + -cy + ", Scale : " + scale+", Iterations: "+max);
        }

        private void render(int x, int y)
        {
            Pen p;
            if (aa)
            {
                Color c1 = render(x + 0.0, y + 0.0);
                Color c2 = render(x + 0.5, y + 0.0);
                Color c3 = render(x + 0.5, y + 0.5);
                Color c4 = render(x + 0.0, y + 0.5);
                Color b = blend(c1, c2, c3, c4);
                p = new Pen(b);
            } else
            {
                Color c1 = render(x + 0.0, y + 0.0);
                p = new Pen(c1);
            }
            this.ig.FillRectangle(p.Brush, x, y, 1, 1);
        }

        private Color blend(params Color[] colors)
        {
            double r = 0, g = 0, b = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                r += colors[i].R;
                g += colors[i].G;
                b += colors[i].B;
            }
            return Color.FromArgb(
                HSVColor.roundAndClamp(0, r / colors.Length, 255),
                HSVColor.roundAndClamp(0, g / colors.Length, 255),
                HSVColor.roundAndClamp(0, b / colors.Length, 255)
                );
        }

        private Color render(double x, double y)
        {
            double hw = width / 2.0;
            double hh = height / 2.0;
            double s = Math.Min(hw, hh);
            double mx = (x - hw) / s;
            double my = (y - hh) / -s;
            if (!this.julia)
            {
                mx /= scale;
                my /= scale;
                mx += cx;
                my -= cy;
            }
            return getColorFromIterations(getIterations(mx, my));
        }

        private Color getColorFromIterations(int iter)
        {
            Color color = Color.Black;
            if (iter<max)
            {
                double factor = iter * 1.0 / max;
                color = getColor(factor);
            }
            return color;
        }

        internal void setAa(bool value)
        {
            this.aa = value;
        }

        internal void copySettings(MandelbrotRenderer render)
        {
            this.cx = render.cx;
            this.cy = render.cy;
            this.max = render.max;
            this.scale = render.scale;
            this.colorOffset = render.colorOffset;
            this.julia = render.julia;
        }

        private Color getColor(double factor)
        {

            double f = 1-factor;
            return HSVColor.fromHSV(
                (factor*factor*factor*360*4)+colorOffset,
                1-(factor * factor * factor),
                1-(f*f*f*f)
                );
        }

        public void moreIterations()
        {
            this.max = (this.max*4)/3;
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

        public void shiftColorUp()
        {
            this.colorOffset+=6;
        }

        public void shiftColorDown()
        {
            this.colorOffset-=6;
        }

        public void toggleJulia()
        {
            this.julia = !this.julia;
        }

        public void setJulia(bool julia)
        {
            this.julia = julia;
        }

        public void zoomIn()
        {
            this.scale *= 1.25;
        }

        public void setScale(double scale)
        {
            this.scale = scale;
        }

        public void setIterations(int max)
        {
            this.max = max;
        }

        internal void ReCenterOn(int x, int y)
        {
            double hw = width / 2.0;
            double hh = height / 2.0;
            double s = Math.Min(hw, hh);
            double mx = (x - hw) / s;
            double my = (y - hh) / -s;
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

        private int getIterations(double x, double y)
        {
            int iter = 0;
            double cr = x;
            double ci = y;
            if (this.julia)
            {
                cr = this.cx;
                ci = this.cy;
            }
            double zr = x;
            double zi = y;
            double nr, ni;
            while (zr < 4 && zr > -4 && zi < 4 && zi > -4 && iter < max)
            {
                iter++;
                // Calculate the result of this iteration.
                nr = (zr * zr) - (zi * zi) + cr;
                ni = (2 * zr * zi) + ci;
                // Check if we should stop.
                if (stop)
                {
                    break;
                }
                // Copy the final result.
                zr = nr;
                zi = ni;
            }
            return iter;
        }
    }
}
