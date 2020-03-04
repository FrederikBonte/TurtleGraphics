using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    /// <summary>
    /// If the first expression in the list is a named expression of "+" then
    /// attempt to add all the numbers in the list if possible.
    /// </summary>
    public class AddApplicator : IApplicator
    {
        public static readonly NamedExpression PLUS = new NamedExpression("+");

        public bool canApply(NamedExpression op, ListExpression list)
        {
            return op.Equals(PLUS);
        }

        public IExpression apply(Scope scope, ListExpression expression)
        {
            double result = 0;
            bool isDouble = false;
//            Console.WriteLine("About to add " + expression);
            for (int i = 1; i < expression.Count; i++)
            {
                IExpression temp = scope.evaluate(expression.getExpression(i));
                if (temp is DoubleExpression)
                {
                    result += ((DoubleExpression)temp).Value;
                    isDouble = true;
                }
                else if (temp is IntegerExpression)
                {
                    result += ((IntegerExpression)temp).Value;
                } else
                {
                    return new ErrorExpression("Cannot add "+temp+" to total.", expression, scope);
                }
            }
            return isDouble ? (IExpression)DoubleExpression.fromDouble(result) : (IExpression)IntegerExpression.fromInteger((int)result);
        }
    }
}
