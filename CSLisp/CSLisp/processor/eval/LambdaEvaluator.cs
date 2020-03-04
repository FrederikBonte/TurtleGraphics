using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    public class LambdaEvaluator : IEvaluator
    {
        public static readonly NamedExpression LAMBDA = new NamedExpression("lambda");

        public bool canEvaluate(IExpression expression)
        {
            if (!(expression is ListExpression))
            {
                return false;
            }
            ListExpression temp = (ListExpression)expression;
            if (temp.IsEmpty)
            {
                return false;
            }
            IExpression lambda = temp.getExpression(0);
            return isLambdaExpression(lambda); // || isFunctionCall(temp);
        }

        public static bool isFunctionCall(ListExpression lambda)
        {
            return lambda.getExpression(0) is NamedExpression;
        }

        public static bool isLambdaExpression(IExpression expression)
        {
            if (!(expression is ListExpression))
            {
                return false;
            }
            else
            {
                return isLambdaExpression((ListExpression)expression);
            }
        }

        public static bool isLambdaExpression(ListExpression expression)
        {
            if (expression.Count != 3)
            {
                return false;
            }
            IExpression first = expression.getExpression(0);
            if (!(first is NamedExpression))
            {
                return false;
            }
            if (!LAMBDA.Equals(first))
            {
                return false;
            }
            IExpression second = expression.getExpression(1);
            if (!isVariableList(second))
            {
                return false;
            }
            return true;
        }

        public static bool isVariableList(IExpression expression)
        {
            if (!(expression is ListExpression))
            {
                return false;
            }
            else
            {
                ListExpression list = (ListExpression)expression;
                for (int i = 0; i < list.Count; i++)
                {
                    if (!(list.getExpression(i) is NamedExpression))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public IExpression evaluate(Scope scope, IExpression expression)
        {
            return evaluate(scope, (ListExpression)expression);
        }

        protected IExpression evaluate(Scope scope, ListExpression expression)
        {
            return lambda(scope, expression);
        }

        /// <summary>
        /// According to the MIT course this should be two separate actions.
        /// The Lambda evaluator should generate an applicable operator.
        /// (See: https://youtu.be/aAlR3cezPJg?list=PLE18841CABEA24090&t=652)
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IExpression lambda(Scope scope, ListExpression expression)
        {
            Scope sub = new Scope(scope);
            ListExpression lambda = (ListExpression)expression.getExpression(0);
            if (!lambda.getExpression(0).Equals(LAMBDA)) {
                IExpression temp = sub.evaluate(lambda);
                if (isLambdaExpression(temp))
                {
                    lambda = (ListExpression)temp;
                } else
                {
                    return new ErrorExpression("" + lambda + " cannot be resolved to a lambda expression.", lambda, scope);
                }
            }
            ListExpression variables = (ListExpression)lambda.getExpression(1);
            if (variables.Count != expression.Count - 1)
            {
                Console.WriteLine("Number of lambda variables doesn't match the expression.");
                return expression;
            }
            // Assign all variables their corresponding value in the sub-scope.
            for (int i = 0; i < variables.Count; i++)
            {
                sub.assign((NamedExpression)variables.getExpression(i), expression.getExpression(i + 1));
            }
            // This is the unevaluated result of the lambda expression.
            return sub.evaluate(lambda.getExpression(2));
        }
    }
}
