using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.parser
{
    public class ParseResult
    {
        public readonly string sequence;
        public readonly IExpression expression;

        public ParseResult(string sequence, IExpression expression)
        {
            this.sequence = sequence;
            this.expression = expression;
        }
    }
}
