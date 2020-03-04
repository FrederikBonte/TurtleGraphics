using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDoStuff_Click(object sender, EventArgs e)
        {
            txtInput.Text = "Hello world!";

            txtInput.Text = "" + fibonacci(10);
        }

        public int fibonacci(int n)
        {
            if (n<2)
            {
                return n;
            } else
            {
                return fibonacci(n - 2) + fibonacci(n - 1);
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "Hello world!";
        }
    }
}
