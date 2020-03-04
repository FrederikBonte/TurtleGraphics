using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colatz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnColatz_Click(object sender, EventArgs e)
        {
            int n = 0;
            try
            {
                n = Int16.Parse(txtNumber.Text);
            } catch (Exception ex)
            {
                MessageBox.Show("Thingies went wrong : "+ex.Message, "Aaargh!!!");
                return;
            }
            lstColatz.Items.Clear();
            lstColatz.Items.Add(n);
            while (n>1)
            {
                if (n%2==0)
                {
                    n = n / 2;
                } else
                {
                    n = 3 * n + 1;
                }
                lstColatz.Items.Add(n);
            }
            txtCount.Text = "" + lstColatz.Items.Count;
        }
    }
}
