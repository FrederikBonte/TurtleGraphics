using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsUtilities.Fractals
{
    public class HSVGradient
    {
        private HSVColor start, end;

        public HSVGradient(HSVColor start, HSVColor end)
        {
            this.start = start;
            this.end = end;
        }

        public HSVColor getColor(float f)
        {
            return HSVColor.blend(start, end, f);
        }

        public Color getRGBColor(float f)
        {
            return getColor(f).ToRGB();
        }
    }
}
