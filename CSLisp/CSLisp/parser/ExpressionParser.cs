using CSLisp.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.parser
{
    public class ExpressionParser
    {
        private string sequence;
        private int lookahead;

        public ExpressionParser(string sequence)
        {
            if (sequence == null || sequence.Trim().Length==0)
            {
                throw new ArgumentException("Cannot parse anything from empty string.");
            }
            this.sequence = sequence;
            this.lookahead = 0;
        }

        public ParseResult parse()
        {
            IExpression expression;
            if (Lookahead=='(')
            {
                expression = null;
                expression = parseList();
            } else /*if (Lookahead=='\'')
            {
                expression = parseQuoted();
            } else*/
            {
                expression = parseExpression();
            }
            return new ParseResult(this.sequence.Substring(0, this.lookahead), expression);
        }

        private IExpression parseList()
        {
            List<IExpression> expressions = new List<IExpression>();
            match('(');
            skipEmptyLinesAndComments();
            ParseResult result;
            while (Lookahead!=')')
            {
                result = parse();
                expressions.Add(result.expression);
            }
            match(')');
            skipEmptyLinesAndComments();
            return new ListExpression(expressions);
        }

        private IExpression parseExpression()
        {
            int start;
            skipEmptyLinesAndComments();
            start = this.lookahead;
            bool endOfExpression, inString = false;
            do
            {
                if (Lookahead=='\"')
                {
                    inString = !inString;
                }
                this.match();
                if (inString)
                {
                    endOfExpression = EndOfSequence;
                } else {
                    endOfExpression = EndOfSequence || IsWhitespace || Lookahead == '(' || Lookahead == ')';
                }
            } while (!endOfExpression);
            string expression = this.sequence.Substring(start, this.lookahead-start);
            skipEmptyLinesAndComments();
            if (StringExpression.isString(expression))
            {
                return StringExpression.fromString(expression);
            } else if (NilExpression.isNil(expression))
            {
                return NilExpression.NIL;
            } else if (DoubleExpression.isNumeric(expression))
            {
                return DoubleExpression.fromNumeric(expression);
            } else if (expression.Trim().Length==0)
            {
                throw new ParseException("A named expression was expected.", this.lookahead);
            } else
            {
                return new NamedExpression(expression);
            }
        }

        void skipEmptyLinesAndComments()
        {
            while (!EndOfSequence)
            {
                while (!EndOfSequence && IsWhitespace)
                {
                    match();
                }
                if (EndOfSequence)
                {
                    break;
                }
                if (Lookahead==';')
                {
                    Console.WriteLine("Skipping comment...");
                    matchUntilEOL();
                }
                else
                {
                    break;
                }
            }
        }

        bool EndOfSequence
        {
            get { return this.lookahead >= this.sequence.Length; }
        }

        char Lookahead
        {
            get { return EndOfSequence?'\0':this.sequence[this.lookahead]; }
        }

        bool EndOfLine
        {
            get { return Lookahead == '\n' || Lookahead == '\r'; }
        }

        bool IsWhitespace
        {
            get { return Char.IsWhiteSpace(Lookahead); }
        }

        void match(char c)
        {
            if (Lookahead==c)
            {
                this.lookahead++;
            } else
            {
                throw new ParseException($"Expected '{c}' but found '{Lookahead}' instead at position {this.lookahead}.", this.lookahead);
            }
        }

        void match()
        {
            this.lookahead++;
        }

        void matchUntilEOL()
        {
            // Match until the first end of line character...
            while (!EndOfSequence && !EndOfLine)
            {
                match();
            }
            // Match multiple end of line characters...
            while (!EndOfSequence && EndOfLine)
            {
                match();
            }
        }

    }

    public class ParseException:Exception
    {
        public readonly int offset;

        public ParseException(string message, int offset = -1) : base(message)
        {
            this.offset = offset;
        }
    }
}
