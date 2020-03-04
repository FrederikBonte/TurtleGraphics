using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    public class NilExpression : PrimitiveExpression<Object>
    {
        private static readonly string NIL_TEXT = "NIL";
        public static readonly NilExpression NIL = new NilExpression();

        private NilExpression() : base(null) { }

        public override string ToString() {
            return NIL_TEXT;
        }

        public static bool isNil(string expression)
        {
            string temp = expression.ToLower().Trim();
            return temp.Equals("nil") || temp.Equals("null");
        }
    }
}
