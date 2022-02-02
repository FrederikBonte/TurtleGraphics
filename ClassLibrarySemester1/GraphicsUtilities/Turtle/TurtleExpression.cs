using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.TurtleDrawing
{
    internal abstract class TurtleExpression
    {
        protected readonly Turtle turtle;
        public TurtleExpression(Turtle turtle)
        {
            this.turtle = turtle;
        }

        public abstract float getValue();
    }

    internal class TurtleConstant : TurtleExpression
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
}
