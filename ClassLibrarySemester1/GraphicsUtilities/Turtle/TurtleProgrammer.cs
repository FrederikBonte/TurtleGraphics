using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.TurtleDrawing
{
    public class TurtleProgrammer
    {
        private readonly Turtle turtle;
        private readonly Stack<Repeat> repeats;

        public TurtleProgrammer(Turtle turtle)
        {
            this.turtle = turtle;
            this.repeats = new Stack<Repeat>();
        }

        ~TurtleProgrammer()
        {
            while (this.repeats.Count > 0)
            {
                Console.WriteLine("WARNING: closing remaining REPEATS");
                this.endRepeat();
            }
        }

        public void setDelay(int delay)
        {
            turtle.setDelay(delay);
        }

        public void reset()
        {
            turtle.add(new Reset(turtle));
        }

        public void beginRepeat(int number)
        {
            Repeat repeat = new Repeat(turtle, number);
            this.repeats.Push(repeat);
        }

        public void endRepeat()
        {
            Repeat repeat = this.repeats.Pop();
            this.add(repeat);
        }

        private void add(TurtleAction action)
        {
            if (this.repeats.Count > 0)
            {
                this.repeats.Peek().add(action);
            }
            else
            {
                turtle.add(action);
            }
        }

        public void rotate(float angle)
        {
            this.rotate(new TurtleConstant(angle));
        }

        public void rotate(string variable)
        {
            this.rotate(createVariable(variable));
        }

        internal void rotate(TurtleExpression expression)
        {
            this.add(new Rotate(turtle, expression));
        }

        internal void right(TurtleExpression expression)
        {
            this.rotate(expression);
        }

        internal void left(TurtleExpression expression)
        {
            this.rotate(new NegativeExpression(turtle, expression));
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
            this.rotate(new NegativeExpression(turtle, createVariable(variable)));
        }

        internal void setAngle(TurtleExpression expression)
        {
            this.add(new SetAngle(turtle, expression));
        }

        public void setAngle(float angle)
        {
            this.setAngle(new TurtleConstant(angle));
        }

        public void setAngle(string variable)
        {
            this.setAngle(createVariable(variable));
        }

        internal void forward(TurtleExpression expression)
        {
            this.add(new Forward(turtle, expression));
        }

        public void forward(float distance)
        {
            this.forward(new TurtleConstant(distance));
        }

        public void forward(string variable)
        {
            this.forward(createVariable(variable));
        }

        internal void back(TurtleExpression expression)
        {
            this.forward(new NegativeExpression(turtle, expression));
        }

        public void back(float distance)
        {
            this.forward(new TurtleConstant(-distance));
        }

        public void back(string variable)
        {
            this.forward(new NegativeExpression(turtle, createVariable(variable)));
        }

        internal void increase(string variable, TurtleExpression expression)
        {
            this.add(new IncreaseVariable(turtle, variable, expression));
        }

        public void increase(string variable, float value)
        {
            this.increase(variable, new TurtleConstant(value));
        }

        public void increase(string variable, string incVariable)
        {
            this.increase(variable, createVariable(incVariable));
        }

        internal void decrease(string variable, TurtleExpression expression)
        {
            this.add(new DecreaseVariable(turtle, variable, expression));
        }

        public void decrease(string variable, float value)
        {
            this.decrease(variable, new TurtleConstant(value));
        }

        public void decrease(string variable, string incVariable)
        {
            this.decrease(variable, createVariable(incVariable));
        }

        public void moveTo(float tx, float ty)
        {
            this.add(new MoveTo(turtle, new TurtleConstant(tx), new TurtleConstant(ty)));
        }

        public void penUp()
        {
            this.add(new PenUp(turtle));
        }

        public void penDown()
        {
            this.add(new PenDown(turtle));
        }

        public void setColor(Color color)
        {
            this.add(new SetColor(turtle, color));
        }

        public void setThickness(float thickness)
        {
            this.add(new SetThickness(turtle, thickness));
        }

        internal void setVariable(string variable, TurtleExpression expression)
        {
            this.add(new SetVariable(turtle, variable, expression));
        }

        public void setVariable(string variable, float value = 0)
        {
            this.setVariable(variable, new TurtleConstant(value));
        }

        public void setVariable(string variable, string otherVariable)
        {
            this.setVariable(variable, createVariable(otherVariable));
        }

        internal TurtleVariable createVariable(string name)
        {
            return new TurtleVariable(turtle, name);
        }
    }
}
