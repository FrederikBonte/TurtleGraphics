using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoogsteUitDeLijst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random RND = new Random();
            for (int k=0;k<10;k=k+1)
            {
                lstNumbers.Items.Add(RND.Next(50));
            }
        }

        private void btnHighest_Click(object sender, EventArgs e)
        {
            txtHighest.Text = "Dont know!";
            int highest = -1;
            for (int i=0;i<lstNumbers.Items.Count;i=i+1)
            {
                if ((int)lstNumbers.Items[i]>highest)
                {
                    highest = (int)lstNumbers.Items[i];
                }
            }
            txtHighest.Text = "" + highest;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int input = Int16.Parse(txtInput.Text);
            lstNumbers.Items.Add(input);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int count = 0;
            while (!isSorted())
            {
                count++;
                for (int i = 1; i < lstNumbers.Items.Count; i++)
                {
                    if ((int)lstNumbers.Items[i - 1] > (int)lstNumbers.Items[i])
                    {
                        lstNumbers.Items.Add(lstNumbers.Items[i - 1]);
                        lstNumbers.Items.RemoveAt(i - 1);
                    }
                }
            }
            Console.WriteLine("Number of iterations : " + count);
        }

        private bool isSorted()
        {
            for (int i = 1; i < lstNumbers.Items.Count; i++)
            {
                if ((int)lstNumbers.Items[i - 1] > (int)lstNumbers.Items[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
