using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conway
{
    public partial class ConwayRenderer : UserControl
    {
        ConwayField field = new ConwayField(50,50,true);
        private const int SIZE = 10;

        public ConwayRenderer()
        {
            InitializeComponent();
            for (int y = 0; y < field.getSizeX(); y++)
            {
                for (int x = 0; x < field.getSizeY(); x++)
                {
                    if ((x*5417+y*227)%17<3)
                    {
                        field.setAlive(x, y);
                    }
                }
            }

            for (int i=0;i<20;i++)
            {
                field.setAlive(20+i, 25);
            }
        }

        private void ConwayRenderer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Color.Black);
            Pen p = new Pen(Color.White);

            for (int y = 0; y < field.getSizeX(); y++)
            {
                for (int x = 0; x < field.getSizeY(); x++)
                {
                    if (field.isAlive(x,y))
                    {
                        g.FillRectangle(p.Brush, x * SIZE, y * SIZE, SIZE, SIZE);
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            field.evaluate();
            field.process();
            Invalidate();
        }
    }
}
