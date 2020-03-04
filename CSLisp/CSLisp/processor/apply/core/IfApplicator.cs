using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    public class IfApplicator : IApplicator
    {
        public static readonly NamedExpression IF = new NamedExpression("if");

        public bool canApply(NamedExpression op, ListExpression expression)
        {
            if (!op.Equals(IF))
            {
                return false;
            }
            if (expression.Count!=4)
            {
                return false;
            }
            return true;
        }

        public IExpression apply(Scope scope, ListExpression expression)
        {
            IExpression test = scope.evaluate(expression.getExpression(1));

            if (!(test is BooleanExpression))
            {
                Console.WriteLine("Cannot decide on non-boolean : " + test);
                return expression;
            }
            bool choose = ((BooleanExpression)test).Value;
            if (choose)
            {
                return scope.evaluate(expression.getExpression(2));
            }
            else
            {
                return scope.evaluate(expression.getExpression(3));
            }
        }
    }
}
