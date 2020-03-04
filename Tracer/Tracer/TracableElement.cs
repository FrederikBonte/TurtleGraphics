using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public abstract class TracableElement
    {
        private Texture texture;

        public TracableElement(Texture texture)
        {
            this.texture = texture;
        }

        public Texture Texture {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public abstract double intersection(Line ray);
        public abstract Point getNormal(Point point);
        public abstract double distance(Point point);
    }
}
