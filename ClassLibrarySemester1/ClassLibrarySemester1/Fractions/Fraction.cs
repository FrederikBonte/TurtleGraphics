using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Fractions
{
    public class Fraction
    {
        private int numerator, denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public bool isDefined()
        {
            return this.denominator != 0;
        }

        public bool isUndefined()
        {
            return this.denominator == 0;
        }

        public int getNumerator()
        {
            return this.numerator;
        }

        public int getDenominator()
        {
            return this.denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.denominator);

        public static Fraction normalise(Fraction a)
        {
            if (a.isUndefined())
            {
                return a;
            } 
            else
            {
                int g = gcd(a.numerator, a.denominator);
                if (g>1)
                {
                    return new Fraction(a.numerator / g, a.denominator / g);
                }
                else
                {
                    return a;
                }
            }
        }

        public static int gcd(int a, int b)
        {
            if (b==0)
            {
                return a;
            } 
            else
            {
                return gcd(b, a % b);
            }
        }

        public Fraction normalise()
        {
            return Fraction.normalise(this);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            if (a.denominator==b.denominator)
            {
                return new Fraction(a.numerator + b.numerator, a.denominator);
            }
            else {
                return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
            }
        }

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);

        public static Fraction operator /(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);

        public override string ToString()
        {
            if (isUndefined() || numerator<denominator)
            {
                return $"{numerator}/{denominator}";
            } else
            {
                return $"{numerator / denominator} {numerator % denominator}/{denominator}";
            }
        }
    }
}

