using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.TurtleDrawing
{
    public class Turtle
    {
        private readonly object lck = new object();
        private const float TORAD = (float)Math.PI / 180;
        private const float SX = 60f/4;
        private const float SY = 66.5f/4;
        private const float MOVE_SPEED = 5f;
        private const float TURN_SPEED = 18f;
        private Bitmap image;
        private Graphics ig;
        private Color color = Color.Black;
        private float thickness = 2f;

        private float x = 0;
        private float y = 0;

        private float angle = 0;
        private float dx, dy;
        private readonly Dictionary<string, float> variables = new Dictionary<string, float>();
        private readonly Queue<TurtleAction> actions;
        private bool loop = false, stop = false, penUpDown = true;
        private Thread thread = null;
        private int delay = 100;

        internal Turtle(Bitmap image)
        {
            this.setImage(image);
            this.asyncReset();
            this.actions = new Queue<TurtleAction>();
        }

        public void drawTurtle(Graphics graphics)
        {
            lock (lck)
            {
                PointF[] destPoints = new PointF[3];
                float fx = dx;
                float fy = dy;
                float rx = -dy;
                float ry = dx;
                destPoints[0] = new PointF(x + fx * SX - rx * SY, y + fy * SX - ry * SY);
                destPoints[1] = new PointF(x + fx * SX + rx * SY, y + fy * SX + ry * SY);
                destPoints[2] = new PointF(x - fx * SX - rx * SY, y - fy * SX - ry * SY);
                graphics.DrawImage(GraphicsUtilities.Properties.Resource.turtle, destPoints);
            }
        }

        internal void setImage(Bitmap image)
        {
            this.image = image;
            this.ig = Graphics.FromImage(this.image);
            this.ig.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        public void setDelay(int delay)
        {
            this.delay = Math.Max(0, Math.Min(delay, 1000));
        }

        public void clear()
        {
            this.halt();
            this.actions.Clear();
            this.asyncReset();
        }

        /// <summary>
        /// Please program the turtle using a TurtleProgrammer.
        /// </summary>
        /// <param name="action"></param>
        internal void add(TurtleAction action)
        {
            this.actions.Enqueue(action);
        }

        /// <summary>
        /// Runs the turtle program in a dedicated thread.
        /// </summary>
        /// <param name="loop">Make the program loop</param>
        public void run(bool loop = false)
        {
            if (this.thread!=null)
            {
                this.halt();
                thread.Join();
            }
            this.loop = loop;
            this.stop = false;
            this.thread = new Thread(new ThreadStart(asyncRun));
            this.thread.Start();
        }

        public void halt()
        {
            this.stop = true;
        }

        public float getVariable(string name)
        {
            if (this.variables.ContainsKey(name))
            {
                return this.variables[name];
            }
            else
            {
                return 0;
            }
        }

        public void setVariable(string name, float value)
        {
            this.variables[name] = value;
        }

        public void moveTo(float target_x, float target_y)
        {
            lock (lck)
            {
                this.x = target_x;
                this.y = target_y;
            }
        }

        public void penUp()
        {
            this.penUpDown = false;
        }

        public void penDown()
        {
            this.penUpDown = true;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public void setThickness(float thickness)
        {
            this.thickness = thickness;
        }

        #region These are the actual functions that handle the turtle animation.

        internal void asyncRun()
        {
            while (this.actions.Count>0 && !stop)
            {
                TurtleAction action = this.actions.Dequeue();
                if (action==null)
                {
                    continue;
                }
                action.run();
                if (loop)
                {
                    this.actions.Enqueue(action);
                }
            }
            this.thread = null;
        }

        internal void asyncReset()
        {
            lock(lck)
            {
                this.x = this.image.Width / 2;
                this.y = this.image.Height / 2;
                this.angle = 0;
                this.dx = 0;
                this.dy = -1;
            }
        }

        internal void asyncRotate(float delta_angle)
        {
            asyncSetAngle(this.angle + delta_angle);
        }

        internal void asyncSetAngle(float new_angle)
        {
            float target_angle = new_angle;
            while (target_angle > 360)
            {
                target_angle -= 360;
            }
            while (target_angle < 0)
            {
                target_angle += 360;
            }

            while (!sameAngle(target_angle, angle) && !stop)
            {
                lock(lck)
                {
                    this.angle += getAngleStep(target_angle, angle);
                    dx = (float)Math.Sin(angle * TORAD);
                    dy = -(float)Math.Cos(angle * TORAD);
                }
                if (delay > 0)
                {
                    Thread.Yield();
                    Thread.Sleep(delay);
                }
            }
        }

        private float getAngleStep(float target_angle, float angle)
        {
            float delta = target_angle - angle;
            while (delta > 180)
            {
                delta -= 360;
            }
            while (delta < -180)
            {
                delta += 360;
            }
            if (Math.Sign(delta)==-1)
            {
                return Math.Max(delta, -TURN_SPEED);
            } else
            {
                return Math.Min(delta, TURN_SPEED);
            }
        }

        private bool sameAngle(float target_angle, float angle)
        {
            float delta = target_angle - angle;
            while (delta > 180)
            {
                delta -= 360;
            }
            while (delta < -180)
            {
                delta += 360;
            }
            return Math.Abs(delta) < 0.1f;
        }

        internal void asyncMoveForward(float distance)
        {
            while (Math.Abs(distance)>0.01f && !stop)
            {
                float step = Math.Min(Math.Abs(distance), MOVE_SPEED);
                if (distance<0)
                {
                    step = -step;
                }
                distance -= step;
                float tx = this.x + this.dx * step;
                float ty = this.y + this.dy * step;
                if (penUpDown)
                {
                    Pen p = new Pen(this.color, this.thickness);
                    p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    ig.DrawLine(p, x, y, tx, ty);
                }
                lock(lck)
                {
                    this.x = tx;
                    this.y = ty;
                }
                if (delay > 0)
                {
                    Thread.Yield();
                    Thread.Sleep(delay);
                }
            }
        }
        #endregion
    }
}
