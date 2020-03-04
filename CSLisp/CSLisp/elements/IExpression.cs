using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLisp.elements
{
    public interface IExpression
    {
        bool Equals(IExpression other);
    }
}
