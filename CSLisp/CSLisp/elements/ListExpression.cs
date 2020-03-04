using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    public class ListExpression:IExpression,IEnumerable<IExpression>
    {
        public static readonly ListExpression EMPTY = new ListExpression();

        private readonly List<IExpression> expressions = new List<IExpression>();

        public ListExpression(params IExpression[] expressions)
        {
            this.expressions.AddRange(expressions);
        }

        public ListExpression(List<IExpression> expressions)
        {
            this.expressions.AddRange(expressions);
        }

        public ListExpression(ListExpression clone)
        {
            this.expressions.AddRange(clone.expressions);
        }

        public int Count
        {
            get { return this.expressions.Count; }
        }

        public bool IsEmpty
        {
            get { return this.expressions.Count == 0; }
        }

        public IExpression getExpression(int index)
        {
            return this.expressions[index];
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("(");
            bool first = true;
            for (int i=0;i<this.Count;i++)
            {
                if (first)
                {
                    first = !first;
                } else
                {
                    result.Append(" ");
                }
                result.Append(this.expressions[i]);
            }
            result.Append(")");
            return result.ToString();
        }

        public override bool Equals(Object other)
        {
            if (other is ListExpression)
            {
                return this.Equals((ListExpression)other);
            }
            else
            {
                return false;
            }
        }

        public bool Equals(IExpression other)
        {
            if (other is ListExpression)
            {
                return Equals((ListExpression)other);
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns <i>true</i> when both lists contain the same expressions in the same locations.
        /// Two empty lists are always equal to eachother.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ListExpression other)
        {
            if (this.Count!=other.Count)
            {
                return false;
            }
            for (int i=0;i<this.Count;i++)
            {
                if (!this.getExpression(i).Equals(other.getExpression(i)))
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerator<IExpression> GetEnumerator()
        {
            return this.expressions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.expressions.GetEnumerator();
        }

        /// <summary>
        /// Returns the first expression in the list...
        /// </summary>
        /// <returns></returns>
        public IExpression GetHead()
        {
            return this.expressions[0];
        }

        /// <summary>
        /// Returns a list that contains all elements except the first one.
        /// </summary>
        /// <returns></returns>
        public ListExpression GetTail()
        {
            ListExpression result = new ListExpression();
            for (int i=1;i<this.expressions.Count;i++)
            {
                result.expressions.Add(this.expressions[i]);
            }
            return result;          
        }

        public override int GetHashCode()
        {
            var hashCode = 896530460;
            hashCode = hashCode + -152134295 * Count.GetHashCode();
            for (int i = 0; i < expressions.Count; i++)
            {
                hashCode *= 12343 * expressions[i].GetHashCode();
            }
            return hashCode;
        }
    }
}
