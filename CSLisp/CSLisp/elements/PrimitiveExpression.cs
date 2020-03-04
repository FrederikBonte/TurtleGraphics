using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    public class PrimitiveExpression<T> : IExpression
    {
        private T value;

        protected PrimitiveExpression(T value) {
            this.value = value;
        }

        public T Value {
            get { return this.value; }
            protected set { this.value = value; }
        }

        public override string ToString()
        {
            if (this.value == null)
            {
                return "null";
            }
            else
            {
                return this.value.ToString();

            }
        }

        public bool Equals(IExpression other)
        {
            if (other is PrimitiveExpression<T>)
            {
                return this.Equals((PrimitiveExpression<T>)other);
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object other)
        {
            if (other is PrimitiveExpression<T>)
            {
                return this.Equals((PrimitiveExpression<T>)other);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(PrimitiveExpression<T> other)
        {
            if (this.Value == null)
            {
                return other.Value == null;
            }
            else
            {
                return this.Value.Equals(other.Value);
            }
        }

        public override int GetHashCode()
        {
            int hashCode = 1927018180;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(this.value);
            return hashCode;
        }

    }
}
