using ROCvanTwente.Sumpel.Semester1.Fractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLibrary
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            testFractions();
            testComplex();
            Application.Run(new Form1());
        }

        static void testFractions()
        {
            Fraction a = new Fraction(5, 4);
            Fraction b = new Fraction(1, 2);
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine((a + b).normalise());  // output: 14 / 8
            Console.WriteLine((a - b).normalise());  // output: 6 / 8
            Console.WriteLine((a * b).normalise());  // output: 5 / 8
            Console.WriteLine((a / b).normalise());  // output: 10 / 4
        }

        static void testComplex()
        {
            Console.WriteLine((Complex)5);
            Complex c = new Complex(3, 2);
            Console.WriteLine(c);
            Console.WriteLine(-c);
            Console.WriteLine(c * c);
            Console.WriteLine(c + 1);

            // Choose a random a value:
            Complex l = new Complex(0.5f,0.01f);
            c = (l * l) + 1;
            c = (c * c);
            Console.WriteLine("Constant : " + l + " ==> " + c);

            for (float r = -1;r<1;r+=0.01f)
            {
                Console.WriteLine("------------"+r.ToString("f3")+"-------------");

                float pa = -c.getReal()-1;
                float pb = -2 * r * c.getImaginary();
                float pc = r * r * c.getReal();
                solvePyth(pa, pb, pc);

                pa = -c.getImaginary();
                pb = 2 * r * c.getReal();
                pc = r * r * c.getImaginary();
                solvePyth(pa, pb, pc);

            }
        }

        private static void solvePyth(float a, float b, float c)
        {
            if (a==0)
            {
                Console.WriteLine("No definable solution");
                return;
            }
            float d = b * b - 4 * a * c;
            if (d<0)
            {
                Console.WriteLine("No real solution");
            }
            else if (d==0)
            {
                float f = -b / (2 * a);
                Console.WriteLine("One Solution : " + f.ToString("F3"));
            }
            else
            {
                d = (float)Math.Sqrt(d);
                float f1 = -b + a / (2 * a);
                float f2 = -b - a / (2 * a);
                Console.WriteLine("Two Solutions : " + f1.ToString("F3")+ " and " +f2.ToString("F3"));
            }
        }
    }
}
