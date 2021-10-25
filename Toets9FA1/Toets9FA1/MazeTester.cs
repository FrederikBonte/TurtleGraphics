using ROCvanTwente.Sumpel.Semester2.MazeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toets9FA1
{
    /// <summary>
    /// Dit is de class die JOUW code test...
    /// Deze class is goed en volkomen perfect.
    /// Wijzigingen in deze code zijn ABSOLUUT NIET TOEGESTAAN!!!
    /// </summary>
    public class MazeTester
    {
        public static int testCanTurnLeft(ToetsOpdracht opdracht, Maze maze, MazeExplorer explorer)
        {
            // Store initial position.
            int sx = explorer.getX();
            int sy = explorer.getY();
            Direction sd = explorer.getDirection();
            // Store the users result.
            bool result = opdracht.tryTurnLeft();
            int ex = explorer.getX();
            int ey = explorer.getY();
            Direction ed = explorer.getDirection();

            return maandag(sx, sy, sd, result, ex, ey, ed, maze);
        }

        public static int testCanTurnRight(ToetsOpdracht opdracht, Maze maze, MazeExplorer explorer)
        {
            // Store initial position.
            int sx = explorer.getX();
            int sy = explorer.getY();
            Direction sd = explorer.getDirection();
            // Store the users result.
            bool result = opdracht.tryTurnRight();
            int ex = explorer.getX();
            int ey = explorer.getY();
            Direction ed = explorer.getDirection();

            return dinsdag(sx, sy, sd, result, ex, ey, ed, maze);
        }

        public static int testCanGoForward(ToetsOpdracht opdracht, Maze maze, MazeExplorer explorer)
        {
            // Store initial position.
            int sx = explorer.getX();
            int sy = explorer.getY();
            Direction sd = explorer.getDirection();
            // Store the users result.
            bool result = opdracht.tryForward();
            int ex = explorer.getX();
            int ey = explorer.getY();
            Direction ed = explorer.getDirection();

            return woensdag(sx, sy, sd, result, ex, ey, ed, maze);
        }

        public static int testCanGoBack(ToetsOpdracht opdracht, Maze maze, MazeExplorer explorer)
        {
            // Store initial position.
            int sx = explorer.getX();
            int sy = explorer.getY();
            Direction sd = explorer.getDirection();
            // Store the users result.
            bool result = opdracht.tryTurnBack();
            int ex = explorer.getX();
            int ey = explorer.getY();
            Direction ed = explorer.getDirection();

            return donderdag(sx, sy, sd, result, ex, ey, ed, maze);
        }

        public static int testOneStep(ToetsOpdracht opdracht, Maze maze, MazeExplorer explorer)
        {
            // Store initial position.
            int sx = explorer.getX();
            int sy = explorer.getY();
            Direction sd = explorer.getDirection();
            opdracht.takeOneStep();
            int ex = explorer.getX();
            int ey = explorer.getY();
            Direction ed = explorer.getDirection();

            return takeOneStep(sx, sy, sd, ex, ey, ed, maze);
        }

        private static int maandag(int sx, int sy, Direction sd, bool result, int ex, int ey, Direction ed, Maze maze)
        {
            bool expected = maart(maze, sx, sy, sd);
            if (expected == false)
            {
                return (ex == sx ? 1 : 0) + (ey == sy ? 1 : 0) + (sd == ed ? 1 : 0) + (expected==result?5:0);
            } else
            {
                Direction td = december(sd);
                int tx = sx+oktober(td);
                int ty = sy+november(td);
                return (ex == tx ? 1 : 0) + (ey == ty ? 1 : 0) + (td == ed ? 1 : 0) + (expected == result ? 5 : 0);
            }
        }

        private static int dinsdag(int sx, int sy, Direction sd, bool result, int ex, int ey, Direction ed, Maze maze)
        {
            bool expected = mei(maze, sx, sy, sd);
            if (expected == false)
            {
                return (ex == sx ? 1 : 0) + (ey == sy ? 1 : 0) + (sd == ed ? 1 : 0) + (expected == result ? 5 : 0);
            }
            else
            {
                Direction td = januari(sd);
                int tx = sx + oktober(td);
                int ty = sy + november(td);
                return (ex == tx ? 1 : 0) + (ey == ty ? 1 : 0) + (td == ed ? 1 : 0) + (expected == result ? 5 : 0);
            }
        }

        private static int woensdag(int sx, int sy, Direction sd, bool result, int ex, int ey, Direction ed, Maze maze)
        {
            bool expected = april(maze, sx, sy, sd);
            if (expected == false)
            {
                return (ex == sx ? 1 : 0) + (ey == sy ? 1 : 0) + (sd == ed ? 1 : 0) + (expected == result ? 5 : 0);
            }
            else
            {
                Direction td = sd;
                int tx = sx + oktober(td);
                int ty = sy + november(td);
                return (ex == tx ? 1 : 0) + (ey == ty ? 1 : 0) + (td == ed ? 1 : 0) + (expected == result ? 5 : 0);
            }
        }

        private static int donderdag(int sx, int sy, Direction sd, bool result, int ex, int ey, Direction ed, Maze maze)
        {
            bool expected = juni(maze, sx, sy, sd);
            if (expected == false)
            {
                return (ex == sx ? 1 : 0) + (ey == sy ? 1 : 0) + (sd == ed ? 1 : 0) + (expected == result ? 5 : 0);
            }
            else
            {
                Direction td = februari(sd);
                int tx = sx + oktober(td);
                int ty = sy + november(td);
                return (ex == tx ? 1 : 0) + (ey == ty ? 1 : 0) + (td == ed ? 1 : 0) + (expected == result ? 5 : 0);
            }
        }

        private static int takeOneStep(int sx, int sy, Direction sd, int ex, int ey, Direction ed, Maze maze)
        {
            int tx=-1, ty=-1;
            Direction td=sd;
            switch (sd)
            {
                case Direction.NORTH:
                    {
                        if (maze.CanMoveWestFrom(sx,sy)) {
                            tx = sx - 1;
                            ty = sy;
                            td = december(sd);
                        } else if (maze.CanMoveNorthFrom(sx,sy))
                        {
                            tx = sx;
                            ty = sy - 1;
                            td = sd;
                        } else if (maze.CanMoveEastFrom(sx,sy))
                        {
                            tx = sx + 1;
                            ty = sy;
                            td = januari(sd);
                        }
                        else if (maze.CanMoveSouthFrom(sx, sy))
                        {
                            tx = sx;
                            ty = sy + 1;
                            td = februari(sd);
                        }
                        break;
                    }
                case Direction.EAST:
                    {
                        if (maze.CanMoveNorthFrom(sx, sy))
                        {
                            tx = sx;
                            ty = sy - 1;
                            td = december(sd);
                        }
                        else if (maze.CanMoveEastFrom(sx, sy))
                        {
                            tx = sx + 1;
                            ty = sy;
                            td = sd;
                        }
                        else if (maze.CanMoveSouthFrom(sx, sy))
                        {
                            tx = sx;
                            ty = sy + 1;
                            td = januari(sd);
                        }
                        else if (maze.CanMoveWestFrom(sx, sy))
                        {
                            tx = sx - 1;
                            ty = sy;
                            td = februari(sd);
                        }
                        break;
                    }
                case Direction.SOUTH:
                    {
                        if (maze.CanMoveEastFrom(sx, sy))
                        {
                            tx = sx + 1;
                            ty = sy;
                            td = december(sd);
                        }
                        else if (maze.CanMoveSouthFrom(sx, sy))
                        {
                            tx = sx;
                            ty = sy + 1;
                            td = sd;
                        }
                        else if (maze.CanMoveWestFrom(sx, sy))
                        {
                            tx = sx - 1;
                            ty = sy;
                            td = januari(sd);
                        }
                        else if (maze.CanMoveNorthFrom(sx, sy))
                        {
                            tx = sx;
                            ty = sy - 1;
                            td = februari(sd);
                        }
                        break;
                    }
                case Direction.WEST:
                    {
                        if (maze.CanMoveSouthFrom(sx, sy))
                        {
                            tx = sx;
                            ty = sy + 1;
                            td = december(sd);
                        }
                        else if (maze.CanMoveWestFrom(sx, sy))
                        {
                            tx = sx - 1;
                            ty = sy;
                            td = sd;
                        }
                        else if (maze.CanMoveNorthFrom(sx, sy))
                        {
                            tx = sx;
                            ty = sy - 1;
                            td = januari(sd);
                        }
                        else if (maze.CanMoveEastFrom(sx, sy))
                        {
                            tx = sx + 1;
                            ty = sy;
                            td = februari(sd);
                        }
                        break;
                    }
                default: throw new Exception("Something is very wrong here!");

            }
            if (tx==-1 || ty==-1)
            {
                throw new Exception("Testing function is broken!");
            }
            return (ex == tx && ey==ty && td==ed? 8 : 0);
        }

        private static int oktober(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return 0;
                case Direction.EAST: return 1;
                case Direction.SOUTH: return 0;
                case Direction.WEST: return -1;
                default: throw new Exception("Something is very wrong here!");
            }

        }

        private static int november(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return -1;
                case Direction.EAST: return 0;
                case Direction.SOUTH: return 1;
                case Direction.WEST: return 0;
                default: throw new Exception("Something is very wrong here!");
            }

        }

        private static Direction december(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return Direction.WEST;
                case Direction.EAST: return Direction.NORTH;
                case Direction.SOUTH: return Direction.EAST;
                case Direction.WEST: return Direction.SOUTH;
                default: throw new Exception("Something is very wrong here!");
            }
        }

        private static Direction januari(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return Direction.EAST;
                case Direction.EAST: return Direction.SOUTH;
                case Direction.SOUTH: return Direction.WEST;
                case Direction.WEST: return Direction.NORTH;
                default: throw new Exception("Something is very wrong here!");
            }
        }
        private static Direction februari(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return Direction.SOUTH;
                case Direction.EAST: return Direction.WEST;
                case Direction.SOUTH: return Direction.NORTH;
                case Direction.WEST: return Direction.EAST;
                default: throw new Exception("Something is very wrong here!");
            }
        }

        private static bool maart(Maze maze, int x, int y, Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return maze.CanMoveWestFrom(x, y);
                case Direction.EAST: return maze.CanMoveNorthFrom(x, y);
                case Direction.SOUTH: return maze.CanMoveEastFrom(x, y);
                case Direction.WEST: return maze.CanMoveSouthFrom(x, y);
                default: throw new Exception("Something is very wrong here!");
            }
        }

        private static bool april(Maze maze, int x, int y, Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return maze.CanMoveNorthFrom(x, y);
                case Direction.EAST: return maze.CanMoveEastFrom(x, y);
                case Direction.SOUTH: return maze.CanMoveSouthFrom(x, y);
                case Direction.WEST: return maze.CanMoveWestFrom(x, y);
                default: throw new Exception("Something is very wrong here!");
            }
        }

        private static bool mei(Maze maze, int x, int y, Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return maze.CanMoveEastFrom(x, y);
                case Direction.EAST: return maze.CanMoveSouthFrom(x, y);
                case Direction.SOUTH: return maze.CanMoveWestFrom(x, y);
                case Direction.WEST: return maze.CanMoveNorthFrom(x, y);
                default: throw new Exception("Something is very wrong here!");
            }
        }
        private static bool juni(Maze maze, int x, int y, Direction d)
        {
            switch (d)
            {
                case Direction.NORTH: return maze.CanMoveSouthFrom(x, y);
                case Direction.EAST: return maze.CanMoveWestFrom(x, y);
                case Direction.SOUTH: return maze.CanMoveNorthFrom(x, y);
                case Direction.WEST: return maze.CanMoveEastFrom(x, y);
                default: throw new Exception("Something is very wrong here!");
            }
        }

    }
}
