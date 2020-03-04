using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    class DoubleExpression:PrimitiveExpression<double>
    {
        protected DoubleExpression(double value) : base(value) { }

        public static DoubleExpression fromInteger(double value)
        {
            return new DoubleExpression(value);
        }

        public static bool isNumeric(string sequence, int offset = 0)
        {
            if (sequence[offset]=='+' || sequence[offset]=='-')
            {
                if (offset+1==sequence.Length)
                {
                    return false;
                } else
                {
                    return isNumeric(sequence, offset + 1);
                }
            }
            bool hasDot = false;
            while (offset<sequence.Length)
            {
                if (!hasDot && sequence[offset]=='.')
                {
                    hasDot = true;
                }
                else if (!Char.IsDigit(sequence[offset]))
                {
                    return false;
                }
                offset++;
            }
            return true;
        }

        public static DoubleExpression fromDouble(string value)
        {
            return fromDouble(Double.Parse(value));
        }

        public static DoubleExpression fromDouble(double value)
        {
            return new DoubleExpression(value);
        }

        public static IExpression fromNumeric(string value)
        {
            if (value.Contains("."))
            {
                return DoubleExpression.fromDouble(value);
            } else
            {
                return IntegerExpression.fromInteger(value);
            }
        }
    }
}
