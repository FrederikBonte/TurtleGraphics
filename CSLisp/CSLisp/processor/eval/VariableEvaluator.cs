using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    /// <summary>
    /// Attempt to lookup the value of the named expression in the current scope.
    /// If it doesn't exist simply retain the named expression.
    /// </summary>
    public class VariableEvaluator : IEvaluator
    {
        public bool canEvaluate(IExpression expression)
        {
            return (expression is NamedExpression);
        }

        public IExpression evaluate(Scope scope, IExpression expression)
        {
            return evaluate(scope, (NamedExpression)expression);
        }

        protected IExpression evaluate(Scope scope, NamedExpression expression)
        {
            IExpression result = scope.getAssignment(expression);
            if (result == null)
            {
                return expression;
            }
            else
            {
                return result;
            }
        }

    }
}
