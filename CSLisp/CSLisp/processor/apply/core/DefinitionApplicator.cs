using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{

    public class DefinitionApplicator : IApplicator
    {
        public bool canApply(NamedExpression op, ListExpression list)
        {
            return true;
        }

        public IExpression apply(Scope scope, ListExpression list)
        {
            NamedExpression name = (NamedExpression)list.getExpression(0);
            IExpression definition = scope.getAssignment(name);
            if (name.Equals(LambdaEvaluator.LAMBDA))
            {
                return applyLambdaNamedExpressions(scope, list);
            }
            else if (definition == null)
            {
                return list;
            }
            List<IExpression> result = new List<IExpression>();
            result.Add(definition);
            for (int i = 1; i < list.Count; i++)
            {
                IExpression temp = scope.evaluate(list.getExpression(i));
                result.Add(temp);
            }
            return scope.evaluate(new ListExpression(result));
        }

        private IExpression applyLambdaNamedExpressions(Scope scope, ListExpression list)
        {
            List<IExpression> result = new List<IExpression>();
            result.Add(LambdaEvaluator.LAMBDA);
            ListExpression vars = (ListExpression)list.getExpression(1);
            result.Add(vars);
            for (int i = 2; i < list.Count; i++)
            {
                IExpression temp = list.getExpression(i);
                result.Add(applyNamedExpressions(scope, vars, temp));
            }
            return new ListExpression(result);
        }

        private IExpression applyNamedExpressions(Scope scope, ListExpression vars, ListExpression list)
        {
            List<IExpression> result = new List<IExpression>();
            for (int i = 0; i < list.Count; i++)
            {
                IExpression temp = list.getExpression(i);
                result.Add(applyNamedExpressions(scope, vars, temp));
            }
            return new ListExpression(result);
        }

        private IExpression applyNamedExpressions(Scope scope, ListExpression vars, IExpression expression)
        {
            if (expression is ListExpression)
            {
                return applyNamedExpressions(scope, vars, (ListExpression)expression);
            }
            else if (expression is NamedExpression)
            {
                return applyNamedExpressions(scope, vars, (NamedExpression)expression);
            }
            else
            {
                return expression;
            }
        }

        private IExpression applyNamedExpressions(Scope scope, ListExpression vars, NamedExpression expression)
        {
            // Don't resolve the lambda variables using the current scope.
            if (vars.Contains(expression))
            {
                return expression;
            }
            IExpression result = scope.getAssignment(expression);
            return (result == null) ? expression : result;
        }
    }
}
