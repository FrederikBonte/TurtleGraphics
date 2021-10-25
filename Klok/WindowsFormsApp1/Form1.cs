using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace ROC.FBE02.ClockDemo
{
    public partial class Form1 : Form
    {
        private readonly string[] ROMANS = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
//        private readonly string[] NUMBERS = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        private readonly string[] NUMBERS = { "3", "6", "9", "12" };
        private readonly int MARGIN = 20*2;
        private int pomodoro_from = 0, pomodoro_until = -1;

        private readonly Wijzer 
            hourHand = new HourHand()
            {
                thickness = 10,
                color = Color.Black,
                length = 65
            },
            minuteHand = new MinuteHand()
            {
                thickness = 10,
                color = Color.Black,
                length = 90
            },
            secondHand = new SecondHand()
            {
                thickness = 5,
                color = Color.Red,
                length = 75
            };

        public Form1()
        {
            InitializeComponent();
        }

        private void updateClock(object source, EventArgs e)
        {
            if (pnlClock.IsDisposed)
            {
                return;
            }
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            Graphics g = pnlClock.CreateGraphics();
            BufferedGraphics myBuffer = currentContext.Allocate(g, pnlClock.DisplayRectangle);
            myBuffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            myBuffer.Graphics.Clear(Color.LightGray);

            int size = Math.Min(pnlClock.Width, pnlClock.Height) - MARGIN;
            int cx = pnlClock.Width / 2;
            int cy = pnlClock.Height / 2;

            if (pomodoro_until > 0)
            {
                DrawUtils.drawPomodoro(myBuffer.Graphics, size, cx, cy, pomodoro_from, minuteHand.getTime(), pomodoro_until);
            }

            string[] numbers = null;
            if (radRoman.Checked)
            {
                numbers = ROMANS;
            }
            if (radNumbers.Checked)
            {
                numbers = NUMBERS;
            }
            DrawUtils.drawFace(myBuffer.Graphics, size, cx, cy, radRound.Checked, !radNone.Checked, chkHourTicks.Checked, chkMinuteTicks.Checked, numbers);
            if (chkDitgital.Checked)
            {
                DrawUtils.drawDigital(myBuffer.Graphics, size, cx, cy);
            }
            DrawUtils.drawTime(myBuffer.Graphics, size, cx, cy, hourHand, false, chkKoch.Checked);
            DrawUtils.drawTime(myBuffer.Graphics, size, cx, cy, minuteHand, false, chkKoch.Checked);
            if (chkSeconds.Checked) {
                DrawUtils.drawTime(myBuffer.Graphics, size, cx, cy, secondHand, true, chkKoch.Checked);
            }

            if (minuteHand.getTime() == pomodoro_until % 60)
            {
                pomodoro_until = -1;
            }

            myBuffer.Render(g);

            myBuffer.Dispose();
            g.Dispose();
        }

        private void sldWidth_ValueChanged(object sender, EventArgs e)
        {
            this.hourHand.thickness = sldWidth.Value;
            this.minuteHand.thickness = ((TrackBar)sender).Value;
        }

        private void pnlClock_MouseClick(object sender, MouseEventArgs e)
        {
            var tts = new SpeechSynthesizer();
            tts.Speak("The time is ");
            tts.Speak(""+DateTime.Now.Hour+" hours");
            tts.Speak(" and " + DateTime.Now.Minute + " minutes");
            tts.Dispose();
        }

        private void btnSecondsColor_Click(object sender, EventArgs e)
        {
            dlgColors.Color = secondHand.color;
            dlgColors.ShowDialog();
            secondHand.color = dlgColors.Color;
        }

        private void btnHours_Click(object sender, EventArgs e)
        {
            dlgColors.Color = hourHand.color;
            dlgColors.ShowDialog();
            hourHand.color = dlgColors.Color;
            minuteHand.color = dlgColors.Color;
        }

        private void btnPomodoro_Click(object sender, EventArgs e)
        {
            pomodoro_from = minuteHand.getTime();
            pomodoro_until = pomodoro_from + (int)numPomodoro.Value;
        }
    }
}
