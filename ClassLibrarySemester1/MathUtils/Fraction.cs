using System;

namespace ROCvanTwente.Sumpel.MathUtils
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

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);

        public static Fraction operator /(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);

        public override string ToString() => $"{numerator} / {denominator}";
    }
}
