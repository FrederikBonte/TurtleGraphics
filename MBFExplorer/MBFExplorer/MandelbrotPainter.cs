using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBFExplorer
{
    public partial class MandelbrotPainter : UserControl
    {
        private Image image;
        private Graphics ig;
        private MandelbrotRenderer render;

        public MandelbrotPainter()
        {
            InitializeComponent();
        }

        private void MandelbrotRenderer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.image, 0, 0);
        }

        private void MandelbrotRenderer_Load(object sender, EventArgs e)
        {
            this.image = new Bitmap(this.Width, this.Height);
            this.ig = Graphics.FromImage(image);
            this.timer.Enabled = true;
            this.render = new MandelbrotRenderer(this.ig);
            this.render.render();
        }

        private void timer_Tick(object sender, EventArgs e)
        {            
            this.Invalidate();
        }

        private void MandelbrotPainter_MouseClick(object sender, MouseEventArgs e)
        {
            this.render.pleaseStop();
            this.render.ReCenterOn(e.X, e.Y);
            this.render.render();
        }

        /// <summary>
        /// Manipulate the zoomfactor and precision.
        /// Special keys store beautiful locations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MandelbrotPainter_KeyDown(object sender, KeyEventArgs e)
        {
            this.render.pleaseStop();
            if (e.KeyCode == Keys.Add)
            {
                this.render.zoomIn();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                this.render.zoomOut();
            }
            else if (e.KeyCode == Keys.OemPeriod)
            {
                this.render.moreIterations();
            }
            else if (e.KeyCode == Keys.Oemcomma)
            {
                this.render.lessIterations();
            }
            else if (e.KeyCode == Keys.F1)
            {
                // Valley of the elephants...
                this.render.setCenter(0.255400228930274, 0.000622256331899663);
                this.render.setScale(4500);
                this.render.setIterations(1000);
            }
            else if (e.KeyCode == Keys.F2)
            {
                // Medallion
                this.render.setCenter(-0.182681618134666, 0.661405416447963);
                this.render.setScale(1885091890);
                this.render.setIterations(3000);
            }
            else if (e.KeyCode == Keys.F3)
            {
                // Swirls
                this.render.setCenter(-1.12029261968809, -0.219362051763942);
                this.render.setScale(65000);
                this.render.setIterations(15000);
            }
            //            Console.WriteLine(e.KeyCode+" ==> "+(char)e.KeyCode);
            this.render.render();
        }
    }
}
