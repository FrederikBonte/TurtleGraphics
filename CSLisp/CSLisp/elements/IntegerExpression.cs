using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    class IntegerExpression:PrimitiveExpression<long>
    {
        protected IntegerExpression(long value) : base(value) { }

        public static IntegerExpression fromInteger(long value)
        {
            return new IntegerExpression(value);
        }

        public static IntegerExpression fromInteger(string value)
        {
            return fromInteger(Int64.Parse(value));
        }
    }
}
