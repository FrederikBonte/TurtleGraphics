using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROC.FBE02.ClockDemo
{
    public abstract class Wijzer
    {
        public int thickness { get; set; }
        public Color color { get; set; }
        public int length { get; set; }
        public abstract int getTime();
        public abstract double getAngle();
    }

    public class HourHand : Wijzer
    {
        public override int getTime()
        {
            return DateTime.Now.Hour;
        }
        public override double getAngle()
        {
            DateTime time = DateTime.Now;
            return (time.Hour + (time.Minute / 60.0)) * 30;
        }
    }

    public class MinuteHand : Wijzer
    {
        public override double getAngle()
        {
            DateTime time = DateTime.Now;
            return time.Minute * 6 + (time.Second / 10.0);
        }

        public override int getTime()
        {
            return DateTime.Now.Minute;
        }
    }

    public class SecondHand : Wijzer
    {
        public override double getAngle()
        {
            DateTime time = DateTime.Now;
            // 
            return (time.Second * 6) + (time.Millisecond * 6 / 1000.0);
        }

        public override int getTime()
        {
            return DateTime.Now.Second;
        }
    }
}
