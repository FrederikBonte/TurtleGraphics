using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    /// <summary>
    /// If the first expression in the list is a named expression of "*" then
    /// attempt to multiply all the numbers in the list if possible.
    /// </summary>
    public class MultiplyApplicator : IApplicator
    {
        public static readonly NamedExpression MUL = new NamedExpression("*");

        public bool canApply(NamedExpression op, ListExpression list)
        {
            return op.Equals(MUL);
        }

        public IExpression apply(Scope scope, ListExpression expression)
        {
            double result = 1;
            bool isDouble = false;
//            Console.WriteLine("About to to multiply " + expression);
            for (int i = 1; i < expression.Count; i++)
            {
                IExpression temp = scope.evaluate(expression.getExpression(i));
                if (temp is DoubleExpression)
                {
                    result *= ((DoubleExpression)temp).Value;
                    isDouble = true;
                }
                else if (temp is IntegerExpression)
                {
                    result *= ((IntegerExpression)temp).Value;
                } else
                {
                    return new ErrorExpression("Cannot multiply " + temp + " to total.", expression, scope);
                }
            }
            return isDouble ? (IExpression)DoubleExpression.fromDouble(result) : (IExpression)IntegerExpression.fromInteger((int)result);
        }
    }

}
