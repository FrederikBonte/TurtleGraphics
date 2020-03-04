using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriemGetallen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenereer_Click(object sender, EventArgs e)
        {
            int nextPrime = 0;
            lstPrimes.Items.Clear();
            while (lstPrimes.Items.Count<numericUpDown1.Value)
            {
                nextPrime = getNextPrime(nextPrime);
                lstPrimes.Items.Add(nextPrime);
            }

            Console.WriteLine(countPrimeCombinations((int)numericUpDown1.Value));

        }

        private int countPrimeCombinations(int value, int max_prime=-1)
        {
            if (value < 2)
            {
                throw new Exception("Cannot compute less than 2");
            }
            else if (value < 4)
            {
//                Console.Write(value);
                return 1;
            }
            int result = 0;
            int pprime = (max_prime==-1)?getPreviousPrime(value):max_prime;
            while (pprime>1)
            {
                int remainder = value - pprime;
                while (isPrime(remainder) && remainder > pprime)
                {
                    remainder -= pprime;
//                    Console.Write(" + " + pprime);
                }
                if (remainder>=2) {
//                    Console.Write(" + (");
                    result += countPrimeCombinations(remainder, pprime);
//                    Console.Write(")");
                } else if (remainder==0)
                {
                    result++;
                } else
                {
//                    Console.Write(" -= XXX =-");
                }
                if (max_prime == -1)
                {
//                    Console.WriteLine();
                }
                pprime = getPreviousPrime(pprime);
            }
            return result;
        }

        private int getNextPrime(int nextPrime)
        {
            int result = nextPrime + 1;
            while (!isPrime(result)) 
            {
                result++;
            }
            return result;
        }

        private int getPreviousPrime(int nextPrime)
        {
            int result = nextPrime - 1;
            while (result>1 && !isPrime(result))
            {
                result--;
            }
            return result;
        }

        private bool isPrime(int number)
        {
            double sqt = Math.Sqrt(number);
            for (int i=2;i<=sqt;i++)
            {
                if ((number%i)==0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
