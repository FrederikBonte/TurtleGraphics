using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    public class LessThanApplicator : IApplicator
    {
        public static readonly NamedExpression LESSTHAN = new NamedExpression("<");

        public bool canApply(NamedExpression op, ListExpression list)
        {
            return op.Equals(LESSTHAN) && list.Count==3;
        }

        public IExpression apply(Scope scope, ListExpression expression)
        {
            IExpression e1 = scope.evaluate(expression.getExpression(1));
            IExpression e2 = scope.evaluate(expression.getExpression(2));
            if (isNumeric(e1) && isNumeric(e2))
            {
                return BooleanExpression.fromBool(getNumeric(e1) < getNumeric(e2));
            } else
            {
                return new ErrorExpression("Cannot compare " + e1 + " and " + e2, expression, scope);
            }
        }

        private bool isNumeric(IExpression expression)
        {
            return (expression is IntegerExpression) ||
                (expression is DoubleExpression);
        }

        private double getNumeric(IExpression expression)
        {
            if (expression is IntegerExpression)
            {
                return ((IntegerExpression)expression).Value;
            } else
            {
                return ((DoubleExpression)expression).Value;
            }
        }
    }
}
