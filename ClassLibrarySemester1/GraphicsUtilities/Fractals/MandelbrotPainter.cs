using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsUtilities.Fractals
{
    public partial class MandelbrotPainter : UserControl
    {
        private Image image;
        private Graphics ig;
        private MandelbrotRenderer render;

        public MandelbrotPainter()
        {
            InitializeComponent();
            ResizeRedraw = true;
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
            this.render = new MandelbrotRenderer(this.ig, this.Width, this.Height);
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
            bool rerender = true;
            if (e.KeyCode == Keys.Add)
            {
                this.render.zoomIn();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                this.render.zoomOut();
            }
            else if (e.KeyCode == Keys.J)
            {
                this.render.toggleJulia();
            }
            else if (e.KeyCode == Keys.OemOpenBrackets)
            {
                this.render.shiftColorUp();
            }
            else if (e.KeyCode == Keys.OemCloseBrackets)
            {
                this.render.shiftColorDown();
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
            else if (e.KeyCode == Keys.S)
            {
                new Thread(saveHiRes).Start();
                rerender = false;
            }
            else
            {
                rerender = false;
            }
            //            Console.WriteLine(e.KeyCode+" ==> "+(char)e.KeyCode);
            if (rerender)
            {
                this.render.render();
            }
        }

        private void saveHiRes()
        {
            Console.WriteLine("About to save fractal...");
            Image image = new Bitmap(1600*5, 900*5);
            Graphics ig = Graphics.FromImage(image);
            MandelbrotRenderer renderer = new MandelbrotRenderer(ig, image.Width, image.Height);
            renderer.copySettings(this.render);
            renderer.setAa(true);
            renderer.renderAsync();
            image.Save("d:/temp/image.png", ImageFormat.Png);
            Console.WriteLine("Saved fractal image.");
        }

        private void MandelbrotPainter_Resize(object sender, EventArgs e)
        {
            if (this.render!=null)
            {
                this.render.pleaseStop();
            }
            this.image = new Bitmap(this.Width, this.Height);
            this.ig = Graphics.FromImage(image);
            MandelbrotRenderer mbr = this.render;
            this.render = new MandelbrotRenderer(this.ig, this.Width, this.Height);
            if (mbr!=null)
            {
                this.render.copySettings(mbr);
            }
            this.render.render();
        }
    }
}
