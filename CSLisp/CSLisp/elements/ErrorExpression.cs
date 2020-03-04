using CSLisp.processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    class ErrorExpression:IExpression
    {
        private readonly string message;
        private readonly IExpression expression;
        private readonly Scope scope;

        public ErrorExpression(string message, IExpression expression, Scope scope)
        {
            this.message = message;
            this.expression = expression;
            this.scope = scope;
        }

        public string Message
        {
            get { return this.message; }
        }

        public IExpression Expression
        {
            get { return this.expression; }
        }

        public Scope Scope
        {
            get { return this.scope; }
        }

        public override string ToString()
        {
            return this.message.ToString();
        }

        public override bool Equals(Object other)
        {
            if (other is NamedExpression)
            {
                return this.Equals((NamedExpression)other);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(IExpression other)
        {
            if (other is NamedExpression)
            {
                return Equals((NamedExpression)other);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(NamedExpression other)
        {
            return this.message.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return 13512314 + EqualityComparer<string>.Default.GetHashCode(this.message);
        }
    }
}
