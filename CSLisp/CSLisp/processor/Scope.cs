using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{
    /// <summary>
    /// Evaluators change expressions into other expressions.
    /// For instance replacing a variable with its value.
    /// </summary>
    public interface IEvaluator
    {
        bool canEvaluate(IExpression expression);
        IExpression evaluate(Scope scope, IExpression expression);
    }

    /// <summary>
    /// Applicators process the given expression and return a simpler value.
    /// For instance addition is an apply action.
    /// </summary>
    public interface IApplicator
    {
        bool canApply(NamedExpression expression, ListExpression list);
        IExpression apply(Scope scope, ListExpression expression);
    }

    /// <summary>
    /// Scope contains the already assigned variables as well as all known evaluators.
    /// </summary>
    public class Scope
    {
        private readonly List<IEvaluator> evaluators;
        private readonly List<IApplicator> applicators;
        private readonly Dictionary<NamedExpression, IExpression> assignments = new Dictionary<NamedExpression, IExpression>();
        private readonly Scope parent;

        public Scope(Scope parent = null)
        {
            this.parent = parent;
            this.evaluators = (parent != null) ? parent.evaluators : new List<IEvaluator>();
            this.applicators = (parent != null) ? parent.applicators : new List<IApplicator>();
        }

        public void register(IEvaluator evaluator)
        {
            this.evaluators.Add(evaluator);
        }

        public void register(IApplicator applicator)
        {
            this.applicators.Add(applicator);
        }

        public void assign(NamedExpression variable, IExpression value)
        {
            this.assignments.Add(variable, value);
        }

        public void define(NamedExpression name, IExpression value)
        {
            if (this.parent!=null)
            {
                this.parent.define(name, value);
            } else
            {
                this.assign(name, value);
            }
        }

        public void assign(string variable, IExpression value)
        {
            this.assign(new NamedExpression(variable), value);
        }

        private IEvaluator getEvaluator(IExpression expression)
        {
            foreach (IEvaluator e in evaluators)
            {
                if (e.canEvaluate(expression))
                {
                    return e;
                }
            }
            return null;
        }

        private IApplicator getApplicator(ListExpression list)
        {
            if (list.IsEmpty)
            {
                return null;
            }
            IExpression ex1 = list.getExpression(0);
            if (!(ex1 is NamedExpression))
            {
                return null;
            }
            NamedExpression op = (NamedExpression)ex1;
            foreach (IApplicator e in applicators)
            {
                if (e.canApply(op, list))
                {
                    return e;
                }
            }
            return null;
        }

        public IExpression getAssignment(NamedExpression expression)
        {
            if (this.assignments.ContainsKey(expression))
            {
                return this.assignments[expression];
            }
            else if (this.parent != null)
            {
                return this.parent.getAssignment(expression);
            }
            else
            {
                return null;
            }

        }

        public IExpression evaluate(IExpression expression)
        {
            if (
                expression.Equals(NilExpression.NIL) ||
                expression.Equals(ListExpression.EMPTY) ||
                isPrimitiveExpression(expression))
            {
                return expression;
            }
            IEvaluator evaluator = getEvaluator(expression);
            if (evaluator != null)
            {
                Scope scope = new Scope(this);
                Console.WriteLine("About to evaluate " + expression);
                return evaluator.evaluate(scope, expression);
            } else if (expression is ListExpression)
            {
                return apply((ListExpression)expression);
//                return expression;
            } else
            {
                return expression;
            }
        }

        public IExpression apply(ListExpression expression)
        {
            IApplicator applicator = getApplicator(expression);
            if (applicator!=null)
            {
                Scope scope = new Scope(this);
                Console.WriteLine("About to apply " + expression);
                return applicator.apply(scope, expression);
            } else
            {

                Console.WriteLine("Cannot apply unknown operator : " + expression.getExpression(0));
                return null;
            }
        }

        private static bool isPrimitiveExpression(IExpression expression)
        {
            return isInstanceOfGenericType(typeof(PrimitiveExpression<>), expression);
        }

        private static bool isInstanceOfGenericType(Type genericType, object instance)
        {
            Type type = instance.GetType();
            while (type != null)
            {
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }
    }
}
