using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    public class EqualsApplicator : IApplicator
    {
        public static readonly NamedExpression EQUAL = new NamedExpression("=");

        public bool canApply(NamedExpression op, ListExpression list)
        {
            return op.Equals(EQUAL) && list.Count==3;
        }

        public IExpression apply(Scope scope, ListExpression expression)
        {
            //            ListExpression evaluatedExpression = Util.evaluateOperatorList(scope, expression);
            IExpression e1 = scope.evaluate(expression.getExpression(1));
            IExpression e2 = scope.evaluate(expression.getExpression(2));
            return BooleanExpression.fromBool(
                e1.Equals(e2)
                );
        }
    }
}
