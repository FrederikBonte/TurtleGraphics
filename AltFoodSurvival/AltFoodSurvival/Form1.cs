using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltFoodSurvival
{
    public partial class Form1 : Form
    {
        private int x = 100, y = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            panel1.Invalidate();
            splitContainer1.Panel2.Invalidate();
            Console.WriteLine(x + " - " + y);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gc = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);

            Console.WriteLine("Selected index : "+cmbRole.SelectedIndex);

            switch (cmbRole.SelectedIndex)
            {
                case 1:
                    {
                        Console.WriteLine("Circle");
                        SolidBrush brush = new SolidBrush(Color.Red);
                        gc.FillEllipse(brush, x - 50, y - 50, 100, 100);
                        gc.DrawEllipse(p, x - 50, y - 50, 100, 100);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Rectangle");
                        SolidBrush brush = new SolidBrush(Color.Blue);
                        gc.FillEllipse(brush, x - 50, y - 50, 100, 100);
                        gc.DrawEllipse(p, x - 50, y - 50, 100, 100);
                        break;
                    }
                case 0:
                    {
                        break;
                    }
                default:
                    {
                        Console.Write("Unknown selection, catastrophic failure of the unierse.");
                        break;
                    }
            }
        }
    }
}
