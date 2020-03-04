using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.processor
{

    public class DefineApplicator : IApplicator
    {
        public static readonly NamedExpression DEFINE = new NamedExpression("define");

        public bool canApply(NamedExpression op, ListExpression list)
        {
            if (!op.Equals(DEFINE))
            {
                return false;
            }
            if (list.Count!=3)
            {
                return false;
            }
            IExpression name = list.getExpression(1);
            if (!(name is NamedExpression))
            {
                return false;
            }
            return true;
        }

        public IExpression apply(Scope scope, ListExpression expression)
        {
            NamedExpression name = (NamedExpression)expression.getExpression(1);
            IExpression value = expression.getExpression(2);

            scope.define(name, value);

            return BooleanExpression.TRUE;
        }
    }
}
