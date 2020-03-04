using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo2018
{
    public partial class DemoScherm : Form
    {
        public DemoScherm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "Knop 1 ingedrukt!";
            updateGui("Knop 1 ingedrukt!");
        }

        private void updateGui(string text)
        {
            txtSummary.Text = text;
            txtSummary.AppendText(Environment.NewLine);
            txtSummary.AppendText("Checkbox is aangevinkt : "+checkBox1.Checked);
            txtSummary.AppendText(Environment.NewLine);
            txtSummary.AppendText("Gemaakte keuze is : ");
            txtSummary.AppendText(comboBox1.Text);
            txtSummary.AppendText(Environment.NewLine);
            txtSummary.AppendText(textBox1.Text);
            txtSummary.AppendText(Environment.NewLine);
            txtSummary.AppendText("Progress is : "+progressBar1.Value+"%");
            txtSummary.AppendText(Environment.NewLine);
            txtSummary.AppendText("Chosen value is : "+numericUpDown1.Value);
            txtSummary.AppendText(Environment.NewLine);
            txtSummary.AppendText("Chosen slider value is : "+trackBar1.Value);
            txtSummary.AppendText(Environment.NewLine);
            txtSummary.AppendText("Done...");
        }
    }
}
