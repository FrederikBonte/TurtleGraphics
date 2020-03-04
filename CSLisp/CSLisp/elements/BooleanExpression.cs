using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    public class BooleanExpression : PrimitiveExpression<bool>
    {
        public static readonly BooleanExpression TRUE = new BooleanExpression(true);
        public static readonly BooleanExpression FALSE = new BooleanExpression(false);

        protected BooleanExpression(bool value) : base(value) {}

        public static BooleanExpression fromBool(bool value)
        {
            return value ? TRUE : FALSE;
        }
    }
}
