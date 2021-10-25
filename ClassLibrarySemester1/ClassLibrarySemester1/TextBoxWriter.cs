using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROCvanTwente.Sumpel.Semester1
{
    public class TextBoxWriter
    {
        private TextBox txtOutput;

        public TextBoxWriter(TextBox txtOutput)
        {
            this.txtOutput = txtOutput;
        }


        #region WriteLine functions for txtOutput
        public void Clear()
        {
            txtOutput.Text = "";
        }

        public void Write(string text = "")
        {
            txtOutput.AppendText(text);
        }

        public void Write(long number)
        {
            Write("" + number);
        }

        public void Write(double number, int decimals = 2)
        {
            Write(number.ToString("F" + decimals));
        }

        public void Write(char letter)
        {
            Write("" + letter);
        }

        public void Write(object obj, string nullValue = "<<NULL>>")
        {
            if (obj == null)
            {
                Write(nullValue);
            }
            else
            {
                Write(obj.ToString());
            }
        }

        public void WriteLine(string text = "")
        {
            Write(text);
            Write(Environment.NewLine);
        }

        public void WriteLine(long number)
        {
            Write(number);
            WriteLine();
        }

        public void WriteLine(double number, int decimals = 2)
        {
            Write(number, decimals);
            WriteLine();
        }

        public void WriteLine(char letter)
        {
            Write(letter);
            WriteLine();
        }

        public void WriteLine(object obj)
        {
            Write(obj);
            WriteLine();
        }

        #endregion
    }
}
