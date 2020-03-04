using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    public class NamedExpression:IExpression
    {
        private string name;

        public NamedExpression(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public override string ToString()
        {
            return this.name.ToString();
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
            } else
            {
                return false;
            }
        }

        public bool Equals(NamedExpression other)
        {
            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(this.name);
        }
    }
}
