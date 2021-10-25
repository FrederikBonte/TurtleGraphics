using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{
    public class ConwayField
    {
        public const byte STATE_MASK = 0b00011111;
        public const byte ALIVE_MASK = 0b00010000;
        public const byte DYING_MASK = 0b00100000;
        public const byte BIRTH_MASK = 0b01000000;
        public const byte COUNT_MASK = 0b00001111;
        public const byte NOCNT_MASK = 0b11110000;

        byte[] field;
        bool wrap = false;
        int sizex, sizey;

        public ConwayField(int sizex, int sizey, bool wrap = false)
        {
            this.sizex = sizex;
            this.sizey = sizey;
            this.wrap = wrap;
            this.field = new byte[sizex * sizey];
        }

        public int getSizeX()
        {
            return this.sizex;
        }

        public int getSizeY()
        {
            return this.sizey;
        }

        public bool isAlive(int x, int y)
        {
            return (field[y*sizex+x] & ALIVE_MASK) != 0;
        }

        public void setAlive(int x, int y)
        {
            if (x<0 || x>=sizex || y<0 || y>=sizey)
            {
                throw new IndexOutOfRangeException("Cannot set field to alive at "+x+", "+y);
            }
            int index = y * sizex + x;
            bool wasDead = (field[index] & ALIVE_MASK) == 0;
            if (wasDead)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (j == 0 && i == 0)
                        {
                            continue;
                        }
                        update(x + i, y + j, 1);
                    }

                }
                field[index] |= ALIVE_MASK;
            }
        }

        public void setDead(int x, int y)
        {
            if (x < 0 || x >= sizex || y < 0 || y >= sizey)
            {
                throw new IndexOutOfRangeException("Cannot set field to dead at " + x + ", " + y);
            }
            int index = y * sizex + x;
            bool wasAlive = (field[index] & ALIVE_MASK) != 0;
            if (wasAlive) {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (j == 0 && i == 0)
                        {
                            continue;
                        }
                        update(x + i, y + j, -1);
                    }
                }
                field[index] &= COUNT_MASK; // Only retain the count information...
            }
        }

        private void update(int x, int y, int value)
        {
            if (!wrap)
            {
                if (x<0 || x>=sizex || y<0 || y>=sizey)
                {
                    return;
                }
            } 
            else
            {
                if (x<0)
                {
                    x += sizex;
                }
                else if (x>=sizex)
                {
                    x -= sizex;
                }
                if (y<0)
                {
                    y += sizey;
                } else if (y>=sizey)
                {
                    y -= sizey;
                }
            }
            byte temp = field[y * sizex + x];
            int current = (temp & COUNT_MASK);
            current+=value;
            if (current>8)
            {
                throw new OverflowException("Increase to more than 8 is not allowed!");
            } else if (current<0)
            {
                throw new OverflowException("Decrease to negative is not allowed!");
            }
            field[y*sizex+x] = (byte)((temp & NOCNT_MASK) | (current & COUNT_MASK));
        }

        public void evaluate()
        {
            for (int i = 0; i < field.Length; i++)
            {
                byte temp = (byte)(field[i] & COUNT_MASK);
                field[i] &= STATE_MASK;
                if (temp<2)
                {
                    field[i] |= DYING_MASK;
                }
                else if (temp==3)
                {
                    field[i] |= BIRTH_MASK;
                }
                else if (temp>=4)
                {
                    field[i] |= DYING_MASK;
                }
            }
        }

        public void process()
        {
            for (int y = 0; y < sizey; y++)
            {
                for (int x = 0; x < sizex; x++)
                {
                    int index = y * sizex + x;
                    byte state = field[index];
                    if ((state&DYING_MASK)!=0)
                    {
                        setDead(x, y);
                    } 
                    else if ((state&BIRTH_MASK)!=0)
                    {
                        setAlive(x, y);
                    }
                }
            }
        }
    }
}
