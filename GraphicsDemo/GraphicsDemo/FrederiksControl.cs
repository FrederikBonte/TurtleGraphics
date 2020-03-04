using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace GraphicsDemo
{
    public partial class FrederiksControl : UserControl
    {
        private readonly Random RND = new Random();
        private Bitmap picture;
        private Graphics ig;
        private bool busy = false, stop = true;
        private int startSize = 128;
        private int minSize = 1;
        private int seed = 12345;
        private int rndFactor = 10;

        public FrederiksControl()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        public void setStartSize(int power)
        {
            startSize = (int)Math.Pow(2, power);
            this.stop = true;
            Thread.Sleep(100);
            landscape();
        }

        public void setMinSize(int power)
        {
            minSize = (int)Math.Pow(2, power);
            this.stop = true;
            Thread.Sleep(100);
            landscape();
        }

        public void setSeed(int seed)
        {
            this.seed = seed;
            this.stop = true;
            Thread.Sleep(100);
            landscape();
        }

        public void setRandomFactor(int factor)
        {
            this.rndFactor = factor;
            this.stop = true;
            Thread.Sleep(100);
            landscape();
        }

        private void FrederiksControl_Paint(object sender, PaintEventArgs e)
        {
            // Gebruik de Graphics uit het event.
            Graphics g = e.Graphics;
            // Activeer anti-aliasing.
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //            teleac(g);
            g.DrawImage(this.picture, 0, 0);
        }


        private void landscape()
        {
            if (busy)
            {
                return;
            }
            stop = false;
            busy = true;
            Random rndInit = new Random(54321);
            Random rnd = new Random(seed);
            Pen white = new Pen(Color.White);
            Pen black = new Pen(Color.Black);
            double power = Math.Log(DisplayRectangle.Width) / Math.Log(2);
            int width = (int)Math.Pow(2, (int)Math.Floor(power));
            power = Math.Log(DisplayRectangle.Height) / Math.Log(2);
            int height = (int)Math.Pow(2, (int)Math.Floor(power));
            int step = Math.Min(startSize,Math.Min(width, height));
            init(white, black, width, height, step, rndInit);
            this.Invalidate();
            while (step > minSize && !stop)
            {
                fill(white, black, width, height, step, rnd);
                step /= 2;
                this.Invalidate();
            }
            busy = false;
            stop = false;
        }

        private void fill(Pen white, Pen black, int width, int height, int step, Random rnd)
        {
            fill_central(white, black, width, height, step, rnd);
            fill_horizontal(white, black, width, height, step, rnd);
            fill_vertical(white, black, width, height, step, rnd);
        }

        private void fill_central(Pen white, Pen black, int width, int height, int step, Random rnd)
        {
            int half = step / 2;
            int half1 = half;
            for (int x = 0; x < width; x += step)
            {
                for (int y = 0; y < height; y += step)
                {
                    if (stop)
                    {
                        return;
                    }
                    Pen p = getRandomColor(
                        rnd,
                        white, black,
                        getColor(white, black, width, height, x, y),
                        getColor(white, black, width, height, x+step, y),
                        getColor(white, black, width, height, x+step, y+step),
                        getColor(white, black, width, height, x, y+step)
                    );
                    ig.FillRectangle(p.Brush, x + half, y + half, half1, half1);
                    ig.FillRectangle(p.Brush, x + half + width, y + half, half1, half1);
                    ig.FillRectangle(p.Brush, x + half, y + half + height, half1, half1);
                    ig.FillRectangle(p.Brush, x + half + width, y + half + height, half1, half1);
                }
            }
        }

        private void fill_vertical(Pen white, Pen black, int width, int height, int step, Random rnd)
        {
            int half = step / 2;
            int half1 = half;
            for (int x = 0; x < width; x += step)
            {
                for (int y = 0; y < height; y += step)
                {
                    if (stop)
                    {
                        return;
                    }
                    Pen p = getRandomColor(
                        rnd,
                        white, black,
                        getColor(white, black, width, height, x, y),
                        getColor(white, black, width, height, x + half, y - half),
                        getColor(white, black, width, height, x + half, y + half),
                        getColor(white, black, width, height, x, y + step)
                    );
                    ig.FillRectangle(p.Brush, x + half, y, half1, half1);
                    ig.FillRectangle(p.Brush, x + half + width, y, half1, half1);
                    ig.FillRectangle(p.Brush, x + half, y + height, half1, half1);
                    ig.FillRectangle(p.Brush, x + half + width, y + height, half1, half1);
                }
            }
        }

        private Pen getRandomColor(Random rnd, Pen white, Pen black, Pen pen1, Pen pen2, Pen pen3, Pen pen4)
        {
            int choice = rnd.Next(this.rndFactor);
            if (choice==0)
            {
                return white;
            } else if (choice ==1)
            {
                return black;
            } else
            {
                Pen[] list = new Pen[4];
                list[0] = pen1;
                list[1] = pen2;
                list[2] = pen3;
                list[3] = pen4;
                return list[choice % 4];
            }
        }

        private void fill_horizontal(Pen white, Pen black, int width, int height, int step, Random rnd)
        {
            int half = step / 2;
            int half1 = half;
            for (int x = 0; x < width; x += step)
            {
                for (int y = 0; y < height; y += step)
                {
                    if (stop)
                    {
                        return;
                    }
                    Pen p = getRandomColor(
                        rnd,
                        white, black,
                        getColor(white, black, width, height, x, y),
                        getColor(white, black, width, height, x + step, y),
                        getColor(white, black, width, height, x + half, y - half),
                        getColor(white, black, width, height, x + half, y + half)
                    );
                    ig.FillRectangle(p.Brush, x, y + half, half1, half1);
                    ig.FillRectangle(p.Brush, x + width, y + half, half1, half1);
                    ig.FillRectangle(p.Brush, x, y + half + height, half1, half1);
                    ig.FillRectangle(p.Brush, x + width, y + half + height, half1, half1);
                }
            }
        }

        private void init(Pen white, Pen black, int width, int height, int step, Random rnd)
        {
            for (int x = 0; x < width; x += step)
            {
                for (int y = 0; y < height; y += step)
                {
                    Pen p = ((rnd.Next(100) % 2) == 0) ? black : white;
                    ig.FillRectangle(p.Brush, x, y, step, step);
                    ig.FillRectangle(p.Brush, x + width, y, step, step);
                    ig.FillRectangle(p.Brush, x, y + height, step, step);
                    ig.FillRectangle(p.Brush, x + width, y + height, step, step);
                }
            }
        }

        public Pen getColor(Pen white, Pen black, int width, int height, int x, int y)
        {
            while (x>width)
            {
                x -= height;
            }
            while (y > width)
            {
                y -= height;
            }
            while (x < 0)
            {
                x += width;
            }
            while (y < 0)
            {
                y += height;
            }
            Color c = this.picture.GetPixel(x, y);
            if (c.R>200 && c.G>200 && c.B>200)
            {
                return white;
            } else
            {
                return black;
            }
        }

        private void ticks(Graphics g)
        {
            int cx = this.DisplayRectangle.Width / 2;
            int cy = this.DisplayRectangle.Height / 2;
            int size = Math.Min(cx, cy);

            Pen p = new Pen(Color.Black);
            p.Width = 10;
            p.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

            for (int i=0;i<360;i+=6)
            {
                double dx = Math.Sin(i * Math.PI / 180) * size;
                double dy = Math.Cos(i * Math.PI / 180) * size;
                double f;

                if (Math.Abs(dx)>Math.Abs(dy))
                {
                    f = size / Math.Abs(dx);
                } else
                {
                    f = size / Math.Abs(dy);
                }
                dx *= f;
                dy *= f;

                double us = 0.85;
                if (i%30==0)
                {
                    us = 0.75;
                }

                g.DrawLine(p, (int)Math.Round(cx + dx * us), (int)Math.Round(cy + dy * us), (int)Math.Round(cx + dx * 0.90), (int)Math.Round(cy + dy * 0.90));
            }
        }

        private void cirkel(Graphics g)
        {
            int cx = this.DisplayRectangle.Width / 2;
            int cy = this.DisplayRectangle.Height / 2;
            int size = Math.Min(cx, cy);

            g.Clear(Color.DarkOliveGreen);

            Pen p = new Pen(Color.AliceBlue);
            p.Width = 5;
            g.DrawEllipse(p, cx - size, cy - size, 2 * size, 2 * size);
        }

        private void teleac(Graphics g) { 

            // Vul de achtergrond met zwart.
            g.Clear(Color.Black);
            // Maak een nieuwe groene pen.
            Pen p = new Pen(Color.Green);
            // Breedte 3
            p.Width = 3;
            p.LineJoin = LineJoin.Round;
            p.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
            // Teken een "cirkel".
            g.DrawEllipse(p, this.DisplayRectangle);

            // Teken meer lijnen...
            for (int i = 0; i < this.DisplayRectangle.Width; i += 20)
            {
                // Kies een willekeurige kleur
                p.Color = Color.FromArgb(255, (byte)RND.Next(256), (byte)RND.Next(256), (byte)RND.Next(256));
                // Teken een lijn
                g.DrawLine(p, i, 0, this.DisplayRectangle.Width - i, this.DisplayRectangle.Height);
            }
            for (int i = 0; i < this.DisplayRectangle.Height; i += 20)
            {
                // Kies een willekeurige kleur
                p.Color = Color.FromArgb(255, (byte)RND.Next(256), (byte)RND.Next(256), (byte)RND.Next(256));
                // Teken een lijn
                g.DrawLine(p, 0, i, this.DisplayRectangle.Width, this.DisplayRectangle.Height - i);
            }
        }

        private void FrederiksControl_Resize(object sender, EventArgs e)
        {
            picture = new Bitmap(this.Width, this.Height);
            ig = Graphics.FromImage(picture);
            if (busy)
            {
                stop = true;
            }
            Thread.Sleep(100);
            landscape();
        }
    }
}
