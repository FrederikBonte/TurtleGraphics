using ROCvanTwente.Sumpel.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester2.MazeGenerator
{
    public class Maze
    {
        private static byte VISITED = (byte)0b1111;
        private static byte NORTH = (byte)0b0001;
        private static byte EAST = (byte)0b0010;
        private static byte SOUTH = (byte)0b0100;
        private static byte WEST = (byte)0b1000;

        private readonly Point[] DIRECTIONS =
        {
            new Point(0,-1),
            new Point( 1,0),
            new Point(0, 1),
            new Point(-1,0)
        };
        private readonly byte[] MASKS = {
            NORTH,
            EAST,
            SOUTH,
            WEST
        };

        private int sizex, sizey;
        private byte[] rooms;
        private int startx, starty;

        public Maze(int sizex, int sizey)
        {
            this.sizex = sizex;
            this.sizey = sizey;
            rooms = new byte[sizex * sizey];
            Stack<Point> path = new Stack<Point>();
            path.Push(new Point(sizex / 2, sizey / 2));
            int max = 0;
            int visited = 1;
            while (visited < rooms.Length)
            {
                while (IsLocked(path.Peek()))
                {
                    path.Pop();
                }
                path.Push(ChooseStep(path.Peek()));
                if (path.Count > max)
                {
                    max = path.Count();
                    startx = path.Peek().X;
                    starty = path.Peek().Y;
                }
                visited++;
            }
        }

        public int getSizeX()
        {
            return this.sizex;
        }

        public int getSizeY()
        {
            return this.sizey;
        }

        public bool CanMoveNorthFrom(int x, int y)
        {
            return CanMoveFrom(x, y, NORTH);
        }

        public bool CanMoveEastFrom(int x, int y)
        {
            return CanMoveFrom(x, y, EAST);
        }

        public bool CanMoveSouthFrom(int x, int y)
        {
            return CanMoveFrom(x, y, SOUTH);
        }

        public bool CanMoveWestFrom(int x, int y)
        {
            return CanMoveFrom(x, y, WEST);
        }

        private bool CanMoveFrom(int x, int y, byte direction)
        { 
            if (x < 0 || y < 0 || x >= sizex || y >= sizey)
            {
                return false;
            }
            else
            {
                return (rooms[y * sizex + x] & direction)!=0;
            }
        }

        public bool HasTreasure(int x, int y)
        {
            return false;
        }

        private Point ChooseStep(Point current)
        {
            int index = LehmerRNG.Next(4);
            Point result;
            for (int i = 0; i < 4; i++)
            {
                result = new Point(
                    current.X + DIRECTIONS[index].X,
                    current.Y + DIRECTIONS[index].Y
                    );
                if (GetRoom(result.X, result.Y) == 0)
                {
                    rooms[current.Y * sizex + current.X] |= MASKS[index];
                    rooms[result.Y * sizex + result.X] |= MASKS[(index + 2) % 4];
                    return result;
                }
                index = (index + 1) % 4;
            }
            Console.WriteLine("System should have found a valid room from " + current);
            return current;
        }

        private byte GetRoom(int x, int y)
        {
            if (x < 0 || y < 0 || x >= sizex || y >= sizey)
            {
                return VISITED;
            }
            else
            {
                return rooms[y * sizex + x];
            }
        }

        private bool IsLocked(Point point)
        {
            return
                GetRoom(point.X + 1, point.Y) != 0 &&
                GetRoom(point.X - 1, point.Y) != 0 &&
                GetRoom(point.X, point.Y - 1) != 0 &&
                GetRoom(point.X, point.Y + 1) != 0;
        }
    }
}
