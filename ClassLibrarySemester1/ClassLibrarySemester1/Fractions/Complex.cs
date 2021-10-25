using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester1.Fractions
{
    public class Complex
    {
        private float real, imaginary;

        public Complex(float real, float imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public float getReal()
        {
            return this.real;
        }

        public float getImaginary()
        {
            return this.imaginary;
        }

        public static explicit operator Complex(float v) => new Complex(v,0);

        public static Complex operator +(Complex a) => a;
        public static Complex operator -(Complex a) => new Complex(-a.real, -a.imaginary);

        public static Complex operator +(Complex a, Complex b) => new Complex(a.real + b.real, a.imaginary + b.imaginary);

        public static Complex operator +(Complex a, float v) => a + (Complex)v;

        public static Complex operator -(Complex a, Complex b)
            => a + (-b);

        public static Complex operator -(Complex a, float v) => a - (Complex)v;

        public static Complex operator *(Complex a, Complex b)
            => new Complex(a.real * b.real - a.imaginary*b.imaginary, a.real * b.imaginary + b.real * a.imaginary);

        public static Complex operator *(Complex a, float v) => a * (Complex)v;

        public static Complex operator /(Complex a, Complex b)
        {
            float f = b.real * b.real + b.imaginary * b.imaginary;
            return new Complex((a.real * b.real + a.imaginary * b.imaginary) / f, (a.imaginary * b.real - a.real * b.imaginary) / f);
        }

        public static Complex operator /(Complex a, float v) => a / (Complex)v;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (real!=0)
            {
                result.Append(real.ToString("F2"));
                if (imaginary>0)
                {
                    result.Append("+");
                }
            }
            if (imaginary!=0)
            {
                result.Append(imaginary.ToString("F2"));
                result.Append("i");
            }
            return result.ToString();
        }
    }
}
