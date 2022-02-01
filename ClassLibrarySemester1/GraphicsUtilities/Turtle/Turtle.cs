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
        private readonly Stack<Repeat> repeats;
        private bool loop = false, stop = false, penUpDown = true;
        private Thread thread = null;
        private int delay = 100;

        internal Turtle(Bitmap image)
        {
            this.setImage(image);
            this.asyncReset();
            this.actions = new Queue<TurtleAction>();
            this.repeats = new Stack<Repeat>();
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
        }

        public void reset()
        {
            this.actions.Enqueue(new Reset(this));
        }

        public void beginRepeat(int number)
        {
            Repeat repeat = new Repeat(this, number);
            this.repeats.Push(repeat);
        }

        public void endRepeat()
        {
            Repeat repeat = this.repeats.Pop();
            this.add(repeat);
        }

        private void add(TurtleAction action)
        {
            if (this.repeats.Count>0)
            {
                this.repeats.Peek().add(action);
            } else
            {
                this.actions.Enqueue(action);
            }
        }

        public void rotate(float angle)
        {
            this.rotate(new TurtleConstant(angle));
        }

        public void rotate(string variable)
        {
            this.rotate(new TurtleVariable(this, variable));
        }

        internal void rotate(TurtleExpression expression)
        {
            this.add(new Rotate(this, expression));
        }

        internal void right(TurtleExpression expression)
        {
            this.rotate(expression);
        }

        internal void left(TurtleExpression expression)
        {
            this.rotate(new NegativeExpression(this, expression));
        }

        public void right(float angle)
        {
            this.rotate(angle);
        }

        public void right(string variable)
        {
            this.rotate(variable);
        }

        public void left(float angle)
        {
            this.rotate(-angle);
        }

        public void left(string variable)
        {
            this.rotate(new NegativeExpression(this, new TurtleVariable(this, variable)));
        }

        internal void setAngle(TurtleExpression expression)
        {
            this.add(new SetAngle(this, expression));
        }

        public void setAngle(float angle)
        {
            this.setAngle(new TurtleConstant(angle));
        }

        public void setAngle(string variable)
        {
            this.setAngle(new TurtleVariable(this, variable));
        }

        internal void forward(TurtleExpression expression)
        {
            this.add(new Forward(this, expression));
        }

        public void forward(float distance)
        {
            this.forward(new TurtleConstant(distance));
        }

        public void forward(string variable)
        {
            this.forward(new TurtleVariable(this, variable));
        }

        internal void back(TurtleExpression expression)
        {
            this.forward(new NegativeExpression(this, expression));
        }

        public void back(float distance)
        {
            this.forward(new TurtleConstant(-distance));
        }

        public void back(string variable)
        {
            this.forward(new NegativeExpression(this, new TurtleVariable(this, variable)));
        }

        internal void increase(string variable, TurtleExpression expression)
        {
            this.add(new IncreaseVariable(this, variable, expression));
        }

        public void increase(string variable, float value)
        {
            this.increase(variable, new TurtleConstant(value));
        }

        public void increase(string variable, string incVariable)
        {
            this.increase(variable, new TurtleVariable(this, incVariable));
        }

        internal void decrease(string variable, TurtleExpression expression)
        {
            this.add(new DecreaseVariable(this, variable, expression));
        }

        public void decrease(string variable, float value)
        {
            this.decrease(variable, new TurtleConstant(value));
        }

        public void decrease(string variable, string incVariable)
        {
            this.decrease(variable, new TurtleVariable(this, incVariable));
        }

        public void moveTo(float tx, float ty)
        {
            this.add(new MoveTo(this, new TurtleConstant(tx), new TurtleConstant(ty)));
        }

        public void penUp()
        {
            this.add(new PenUp(this));
        }

        public void penDown()
        {
            this.add(new PenDown(this));
        }

        public void setColor(Color color)
        {
            this.add(new SetColor(this, color));
        }

        public void setThickness(float thickness)
        {
            this.add(new SetThickness(this, thickness));
        }

        internal void setVariable(string variable, TurtleExpression expression)
        {
            this.add(new SetVariable(this, variable, expression));
        }

        public void setVariable(string variable, float value = 0)
        {
            this.setVariable(variable, new TurtleConstant(value));
        }

        public void setVariable(string variable, string otherVariable)
        {
            this.setVariable(variable, new TurtleVariable(this, otherVariable));
        }

        public void run(bool loop = false)
        {
            while (this.repeats.Count>0)
            {
                Console.WriteLine("WARNING: closing remaining REPEATS");
                this.endRepeat();
            }
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

        internal void updateVariable(string name, float value)
        {
            this.variables[name] = value;
        }

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

        internal void asyncMoveTo(float target_x, float target_y)
        {
            lock(lck)
            {
                this.x = target_x;
                this.y = target_y;
            }
        }

        internal void asyncPenUp()
        {
            this.penUpDown = false;
        }

        internal void asyncPenDown()
        {
            this.penUpDown = true;
        }

        internal void asyncSetColor(Color color)
        {
            this.color = color;
        }

        internal void asyncSetThickness(float thickness)
        {
            this.thickness = thickness;
        }

        internal abstract class TurtleExpression
        {
            protected readonly Turtle turtle;
            public TurtleExpression(Turtle turtle)
            {
                this.turtle = turtle;
            }

            public abstract float getValue();
        }

        internal class TurtleConstant:TurtleExpression
        {
            private readonly float value;

            public TurtleConstant(float value) : base(null)
            {
                this.value = value;
            }

            public override float getValue()
            {
                return value;
            }
        }

        internal class NegativeExpression : TurtleExpression
        {
            private readonly TurtleExpression expression;

            public NegativeExpression(Turtle turtle, TurtleExpression expression) : base(turtle)
            {
                this.expression = expression;
            }

            public override float getValue()
            {
                return -expression.getValue();
            }
        }

        internal class TurtleVariable : TurtleExpression
        {
            private readonly string name;

            public TurtleVariable(Turtle turtle, string name, float value = 0) : base(turtle)
            {
                this.name = name;
                this.turtle.updateVariable(name, value);
            }

            public override float getValue()
            {
                return turtle.getVariable(name);
            }
        }

        internal abstract class TurtleAction
        {
            protected readonly Turtle turtle;
            public TurtleAction(Turtle turtle)
            {
                this.turtle = turtle;
            }

            public abstract void run();
        }

        internal class Reset : TurtleAction
        {
            public Reset(Turtle turtle) : base(turtle)
            {
            }

            public override void run()
            {
                turtle.asyncReset();
            }
        }

        internal class PenUp : TurtleAction
        {
            public PenUp(Turtle turtle) : base(turtle)
            {
            }

            public override void run()
            {
                turtle.asyncPenUp();
            }
        }

        internal class PenDown : TurtleAction
        {
            public PenDown(Turtle turtle) : base(turtle)
            {
            }

            public override void run()
            {
                turtle.asyncPenDown();
            }
        }

        internal class Forward : TurtleAction
        {
            private readonly TurtleExpression distance;

            public Forward(Turtle turtle, TurtleExpression distance) : base(turtle)
            {
                this.distance = distance;
            }

            public override void run()
            {
                turtle.asyncMoveForward(distance.getValue());
            }
        }

        internal class MoveTo : TurtleAction
        {
            private readonly TurtleExpression tx, ty;

            public MoveTo(Turtle turtle, TurtleExpression tx, TurtleExpression ty) : base(turtle)
            {
                this.tx = tx;
                this.ty = ty;
            }

            public override void run()
            {
                turtle.asyncMoveTo(tx.getValue(), ty.getValue());
            }
        }

        internal class Rotate : TurtleAction
        {
            private readonly TurtleExpression angle;

            public Rotate(Turtle turtle, TurtleExpression angle) : base(turtle)
            {
                this.angle = angle;
            }

            public override void run()
            {
                turtle.asyncRotate(angle.getValue());
            }
        }

        internal class SetAngle : TurtleAction
        {
            private readonly TurtleExpression angle;

            public SetAngle(Turtle turtle, TurtleExpression angle) : base(turtle)
            {
                this.angle = angle;
            }

            public override void run()
            {
                turtle.asyncSetAngle(angle.getValue());
            }
        }

        internal class SetVariable : TurtleAction
        {
            private readonly TurtleExpression expression;
            private readonly string variable;

            public SetVariable(Turtle turtle, string variable, TurtleExpression expression) : base(turtle)
            {
                this.variable = variable;
                this.expression = expression;
            }

            public override void run()
            {
                turtle.updateVariable(variable, expression.getValue());
            }
        }

        internal class SetColor : TurtleAction
        {
            private readonly Color color;

            public SetColor(Turtle turtle, Color color) : base(turtle)
            {
                this.color = color;
            }

            public override void run()
            {
                turtle.asyncSetColor(color);
            }
        }

        internal class SetThickness : TurtleAction
        {
            private readonly float thickness;

            public SetThickness(Turtle turtle, float thickness) : base(turtle)
            {
                this.thickness = thickness;
            }

            public override void run()
            {
                turtle.asyncSetThickness(thickness);
            }
        }

        internal class Repeat : TurtleAction
        {
            private readonly int number;
            private readonly List<TurtleAction> actions = new List<TurtleAction>();

            public Repeat(Turtle turtle, int number, params TurtleAction[] actions) : base(turtle)
            {
                this.number = number;
                this.actions.AddRange(actions);
            }

            public void add(TurtleAction action)
            {
                this.actions.Add(action);
            }

            public override void run()
            {
                for (int i = 0; i < number; i++)
                {
                    foreach (TurtleAction action in actions)
                    {
                        action.run();
                    }
                }
            }
        }

        internal class IncreaseVariable: TurtleAction
        {
            private readonly string variable;
            private readonly TurtleExpression expression;

            public IncreaseVariable(Turtle turtle, string variable, TurtleExpression expression) : base(turtle)
            {
                this.variable = variable;
                this.expression = expression;
            }

            public override void run()
            {
                float value = turtle.getVariable(variable) + expression.getValue();
                if (variable.ToLower().Contains("deg"))
                {
                    while (value>360)
                    {
                        value -= 360;
                    }
                    while (value<0)
                    {
                        value += 360;
                    }
                }
                turtle.updateVariable(variable, value);
            }

        }
        internal class DecreaseVariable : TurtleAction
        {
            private readonly string variable;
            private readonly TurtleExpression expression;

            public DecreaseVariable(Turtle turtle, string variable, TurtleExpression expression) : base(turtle)
            {
                this.variable = variable;
                this.expression = expression;
            }

            public override void run()
            {
                turtle.updateVariable(variable, turtle.getVariable(variable) - expression.getValue());
            }

        }
    }
}
