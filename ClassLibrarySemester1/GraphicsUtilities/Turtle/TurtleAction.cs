using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.TurtleDrawing
{
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
            turtle.penUp();
        }
    }

    internal class PenDown : TurtleAction
    {
        public PenDown(Turtle turtle) : base(turtle)
        {
        }

        public override void run()
        {
            turtle.penDown();
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
            turtle.moveTo(tx.getValue(), ty.getValue());
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
            turtle.setVariable(variable, expression.getValue());
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
            turtle.setColor(color);
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
            turtle.setThickness(thickness);
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

    internal class IncreaseVariable : TurtleAction
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
            string name = variable.ToLower();
            // Mumble mumble avoid very high angles.
            if (name.Contains("deg") || name.Contains("angle"))
            {
                while (value > 360)
                {
                    value -= 360;
                }
                while (value < 0)
                {
                    value += 360;
                }
            }
            turtle.setVariable(variable, value);
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
            turtle.setVariable(variable, turtle.getVariable(variable) - expression.getValue());
        }

    }

}
