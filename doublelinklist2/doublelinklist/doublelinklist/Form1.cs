using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doublelinklist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Array made and put in listbox1
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            int[] x = { 5, 8, 1, 7, 8 };
            for (int i = 0; i < x.Length; i++)
            {
                cNode.AddToList(x[i]);
                listBox1.Items.Add(x[i]);
            }
        }
        /// <summary>
        /// Array sorted and put in listbox2
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            int[] x = cNode.getList();
            for (int i = 0; i < x.Length; i++)
            {
                listBox2.Items.Add(x[i]); 
            }
        }
    }
}



            //int[] x = cNode.getList();
            //for (int i = 0; i < x.Length; i++)
            //{
            //    listBox2.Items.Add(x[i]);
            //}

            //int[] x = { 5, 8, 1, 7, 8 };
            //for (int i = 0; i < x.Length; i++)
            //{
            //    cNode.AddToList(x[i]);
            //    listBox1.Items.Add(x[i]);
            //}