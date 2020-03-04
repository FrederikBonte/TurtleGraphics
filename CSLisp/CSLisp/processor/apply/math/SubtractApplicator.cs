using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    public class SubtractApplicator : IApplicator
    {
        public static readonly NamedExpression MINUS = new NamedExpression("-");

        public bool canApply(NamedExpression op, ListExpression list)
        {
            if (!op.Equals(MINUS))
            {
                return false;
            }
            if (list.Count!=3 && list.Count!=2)
            {
                return false;
            }
            return true;
        }

        public IExpression apply(Scope scope, ListExpression expression)
        {
            double result = 0;
            bool isDouble = false;
//            Console.WriteLine("Attempt to subtract " + expression);
            IExpression temp = scope.evaluate(expression.getExpression(1));
            if (expression.Count==3)
            {
                if (temp is DoubleExpression)
                {
                    result = ((DoubleExpression)temp).Value;
                    isDouble = true;
                }
                else
                {
                    result = ((IntegerExpression)temp).Value;
                }
                // Subtract the second expression from this one...
                temp = scope.evaluate(expression.getExpression(2));
                // Otherwise the expression is subtracted from zero...
            }
            if (temp is DoubleExpression)
            {
                result -= ((DoubleExpression)temp).Value;
                isDouble = true;
            }
            else
            {
                result -= ((IntegerExpression)temp).Value;
            }

            return isDouble ? (IExpression)DoubleExpression.fromDouble(result) : (IExpression)IntegerExpression.fromInteger((int)result);
        }
    }
}
