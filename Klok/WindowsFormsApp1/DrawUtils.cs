using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROC.FBE02.ClockDemo
{
    class DrawUtils
    {
        private static readonly double[] koch_definition =
        {
            0,      0,
            1/3.0,  0,
            1/2.0,  1/-4.0,
            2/3.0,  0,
            1,      0
        };

        private static readonly double[] dragon_definition =
        {
            0,      0,
            0,      1/-3.0,
            1/2.0,  0,
            1,      0
        };

        public static void drawFace(Graphics g, int size, int cx, int cy, bool roundFace, bool showNumbers, bool show_hour_ticks, bool showMinuteTicks, string[] numbers)
        {
            Pen p = new Pen(Color.Black)
            {
                Width = 10,
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };
            if (roundFace)
            {

                g.DrawEllipse(p, cx - size / 2, cy - size / 2, size, size);
            }
            else
            {
                g.DrawRectangle(p, cx - size / 2, cy - size / 2, size, size);
            }
            if (show_hour_ticks)
            {
                int startMin = showNumbers ? 70 : 90;
                int startHour = showNumbers ? 65 : 85;
                int endTick = showNumbers ? 72 : 95;

                for (int i = 0; i < 60; i += (showMinuteTicks ? 1 : 5))
                {
                    drawLine(g, p, size, cx, cy, i * 6, ((i % 5) == 0) ? startHour : startMin, endTick, !roundFace);
                }
            }
            if (showNumbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    drawNumber(g, p, size, cx, cy, i, numbers[i]);
                }
            }
        }

        public static void drawDigital(Graphics g, int size, int cx, int cy)
        {
            Pen p = new Pen(Color.Black);
            string time = String.Format("{0:HH}:{0:mm}.{0:ss}", DateTime.Now);
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            g.DrawString(time, new Font("Arial Black", 24), p.Brush, new Rectangle(cx - (size / 2), cy + (size / 8), size, (size / 4)), sf);
        }

        public static void drawTime(Graphics g, int size, int cx, int cy, Wijzer wijzer, bool showCircle, bool koch = false)
        {
            Pen p = new Pen(wijzer.color)
            {
                Width = wijzer.thickness,
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };
            drawLine(g, p, size, cx, cy, wijzer.getAngle(), 0, wijzer.length, false, koch);
            if (showCircle)
            {
                p.Width = 1;
                g.FillEllipse(p.Brush, cx - (size / 24), cy - (size / 24), size / 12, size / 12);
            }
        }

        public static void drawLine(Graphics g, Pen p, int size, int cx, int cy, double angle, int fromPercent, int toPercent, bool square = false, bool koch = false)
        {
            double radians = angle * Math.PI / 180;
            double dx = Math.Sin(radians)*size;
            double dy = -Math.Cos(radians)*size;
            double f = 1;
            if (square)
            {
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    f = size / Math.Abs(dx);
                } else
                {
                    f = size / Math.Abs(dy);
                }
            }
            dx *= f;
            dy *= f;
            int sx = (int)Math.Round((dx * fromPercent) / 200);
            int sy = (int)Math.Round((dy * fromPercent) / 200);
            int ex = (int)Math.Round((dx * toPercent) / 200);
            int ey = (int)Math.Round((dy * toPercent) / 200);
            if (koch) { 
                drawKoch(g, p, cx + sx, cy + sy, cx + ex, cy + ey,5);
            } else
            {
                g.DrawLine(p, cx + sx, cy + sy, cx + ex, cy + ey);
            }
        }

        private static void drawKoch(Graphics g, Pen p, int x1, int y1, int x2, int y2, int count = 3)
        {
            double d1x = x2 - x1;
            double d1y = y2 - y1;
            double d2x = d1y;
            double d2y = -d1x;

            bool first = true;
            Point start = new Point(0,0), next = new Point(0,0);


            for (int i = 0; i < koch_definition.Length; i += 2)
            {
                double f1 = koch_definition[i];
                double f2 = koch_definition[i + 1];
                next = new Point(
                    (int)Math.Round(x1 + f1 * d1x + f2 * d2x),
                    (int)Math.Round(y1 + f1 * d1y + f2 * d2y)
                    );
                if (first)
                {
                    first = false;
                }
                else
                {
                    if (count > 1)
                    {
                        drawKoch(g, p, start.X, start.Y, next.X, next.Y,count-1);
                    } else
                    {
                        g.DrawLine(p, start.X, start.Y, next.X, next.Y);
                    }
                }
                start = next;
            }

        }

        public static void drawNumber(Graphics g, Pen p, int size, int cx, int cy, int index, string number)
        {
            double radians = (index + 1) * Math.PI / 6;
            double dx = Math.Sin(radians);
            double dy = -Math.Cos(radians);
            int sx = (int)Math.Round((dx * size * 90) / 200);
            int sy = (int)Math.Round((dy * size * 90) / 200);
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            g.DrawString(number, new Font("Times", 24, FontStyle.Bold), p.Brush, new Rectangle(cx + sx - 50, cy + sy - 10, 100, 25), sf);
        }

        internal static void drawPomodoro(Graphics graphics, int size, int cx, int cy, int pomodoro_from, int current, int pomodoro_until)
        {
            Pen p = new Pen(Color.DarkRed);
            p.Width = 20;
            if (current<pomodoro_from) {
                current += 60;
            }

            int start_angle = 270+pomodoro_from*6;
            int current_angle = 270+current * 6;
            int end_angle = 270+pomodoro_until * 6;

            p.Width = 10;
            graphics.DrawArc(p, cx - size / 5, cy - size / 5, (size * 2) / 5, (size * 2) / 5, current_angle, end_angle - current_angle);
            p.Width = 15;
            graphics.DrawArc(p, cx - size / 4, cy - size / 4, size / 2, size / 2, current_angle, end_angle - current_angle);
            p.Width = 20;
            graphics.DrawArc(p, cx - size / 3, cy - size / 3, (size * 2) / 3, (size * 2) / 3, current_angle, end_angle - current_angle);

            p.Color = Color.DarkGray;
            p.Width = 10;
            graphics.DrawArc(p, cx - size / 5, cy - size / 5, (size * 2) / 5, (size * 2) / 5, start_angle, (current_angle - start_angle));
            p.Width = 15;
            graphics.DrawArc(p, cx - size / 4, cy - size / 4, size / 2, size / 2, start_angle, (current_angle - start_angle));
            p.Width = 20;
            graphics.DrawArc(p, cx - size / 3, cy - size / 3, (size * 2) / 3, (size * 2) / 3, start_angle, (current_angle - start_angle));
        }
    }
}
