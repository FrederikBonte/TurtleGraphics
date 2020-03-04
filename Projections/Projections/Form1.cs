using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projections
{
    public partial class Form1 : Form
    {
        private readonly Random RNG = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            this.projectionRenderer1.Add(new Point(((RNG.NextDouble()-0.5)*6), ((RNG.NextDouble() - 0.5) * 6), ((RNG.NextDouble() - 0.5) * 6)));
            this.projectionRenderer1.Invalidate();
        }
    }
}
