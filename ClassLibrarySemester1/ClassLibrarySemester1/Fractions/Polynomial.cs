using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Fractions
{
    public class Polynomial
    {
        private readonly char variable;
        // Coefficients are stored in reverse order.
        // i.e. the index in the array is the power of the variable.
        // c[0] is the constant because x^0 is always one.
        // c[1] is the times x coefficient.
        // c[2] is the x squared coefficient. etc.
        private readonly int[] coefficients;

        public Polynomial(char variable, params int[] coefficients)
        {
            this.variable = variable;
            this.coefficients = coefficients;
        }

        public Polynomial(params int[] coefficients):this('x', coefficients)
        {}

        public int getDegree()
        {
            for (int i = coefficients.Length-1; i >= 0; i++)
            {
                if (coefficients[i]>0)
                {
                    return i;
                }
            }
            throw new Exception("Cannot determine the degree of an in undefined polynomial. (All coefficients are zero)");
        }
    }
}
