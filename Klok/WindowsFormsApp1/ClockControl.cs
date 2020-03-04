using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ROC.FBE02.ClockDemo
{
    public partial class ClockControl : UserControl
    {
        private bool minuteTicks = false;

        private readonly Wijzer
            hourHand = new HourHand()
            {
                thickness = 5,
                color = Color.Black,
                length = 65
            },
            minuteHand = new MinuteHand()
            {
                thickness = 5,
                color = Color.Black,
                length = 90
            },
            secondHand = new SecondHand()
            {
                thickness = 3,
                color = Color.Red,
                length = 75
            };

        public ClockControl()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.LightGray);

            int size = Math.Min(this.Width, this.Height) - 10;
            int cx = this.Width / 2;
            int cy = this.Height / 2;

            string[] numbers = null;
            DrawUtils.drawFace(g, size, cx, cy, true, false, true, this.minuteTicks, numbers);
            DrawUtils.drawTime(g, size, cx, cy, hourHand, false, false);
            DrawUtils.drawTime(g, size, cx, cy, minuteHand, false, false);
            DrawUtils.drawTime(g, size, cx, cy, secondHand, true, false);
        }

        [Description("Show minute ticks"), Category("Appearance")]
        public bool MinuteTicks
        {
            get { return this.minuteTicks; }
            set { this.minuteTicks = value; }
        }
    }
}
