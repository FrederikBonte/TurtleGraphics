using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    public class StringExpression : PrimitiveExpression<string>
    {
        static readonly string QUOTE = "\"";
        protected StringExpression(string value) : base(value) { }

        public override string ToString()
        {
            return "\"" + base.ToString() + "\"";
        }

        public static bool isString(string expression)
        {
            return expression.StartsWith(QUOTE) && expression.EndsWith(QUOTE);
        }

        public static StringExpression fromString(string expression)
        {
            return new StringExpression(expression.Substring(1, expression.Length-2));
        }

    }
}
