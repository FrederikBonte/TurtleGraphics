using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy0sv3
{
    public partial class Form1 : Form
    {
        private readonly BirdFrames frames = new BirdFrames();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!testTimer.Enabled)
            {
                return;
            } 
            else
            {
                // Loop through all the birds.
                for (int i = 0; i < 8; i++)
                {
                    // Draw the current frame for each bird.
                    frames.drawBird(e.Graphics, i, 50 + i * 50, 50 + ((i * 11) % 7) * 5);
                }
            }
        }

        private void testTimer_Tick(object sender, EventArgs e)
        {
            // Advance the animation.
            frames.nextFrame();
            // Trigger a repaint.
            Invalidate();
        }
    }
}
