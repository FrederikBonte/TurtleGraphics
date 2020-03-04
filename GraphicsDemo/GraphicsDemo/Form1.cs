using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void NumSeed_ValueChanged(object sender, EventArgs e)
        {
            this.frederiksControl1.setSeed((int)this.numSeed.Value);
        }

        private void TrkMinSize_ValueChanged(object sender, EventArgs e)
        {
            this.frederiksControl1.setMinSize(this.trkMinSize.Value);
        }

        private void TrkStartSize_Scroll(object sender, EventArgs e)
        {
            this.frederiksControl1.setStartSize(this.trkStartSize.Value);
        }

        private void NumRandFactor_ValueChanged(object sender, EventArgs e)
        {
            this.frederiksControl1.setRandomFactor((int)this.numRandFactor.Value);
        }
    }
}
