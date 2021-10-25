using ROCvanTwente.Sumpel.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROCvanTwente.Sumpel.Semester2.MazeGenerator
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class MazeExplorer
    {
        private readonly Maze maze;
        private int x, y;
        private Direction direction;

        public MazeExplorer(Maze maze)
        {
            this.maze = maze;
            this.x = LehmerRNG.Next(this.maze.getSizeX()/2);
            this.y = LehmerRNG.Next(this.maze.getSizeY()/2);
            this.direction = (Direction)LehmerRNG.Next(4);
        }

        private MazeExplorer(MazeExplorer other)
        {
            this.maze = other.maze;
            this.x = other.x;
            this.y = other.y;
            this.direction = other.direction;
        }

        public MazeExplorer clone() {
            return new MazeExplorer(this);
        }

        /// <summary>
        /// Returns true when the explorer is at the end of the maze.
        /// </summary>
        /// <returns>true when the explorer is at the end of the maze</returns>
        public bool isAtFinish()
        {
            return (this.x == this.maze.getSizeX() - 1) && (this.y == this.maze.getSizeY() - 1);
        }

        /// <summary>
        /// Returns the x position of the explorer.
        /// </summary>
        /// <returns>the x position of the explorer</returns>
        public int getX()
        {
            return this.x;
        }

        /// <summary>
        /// Returns the y position of the explorer.
        /// </summary>
        /// <returns>the y position of the explorer</returns>
        public int getY()
        {
            return this.y;
        }

        /// <summary>
        /// Returns the current direction of the explorer.
        /// </summary>
        /// <returns>the current direction of the explorer</returns>
        public Direction getDirection()
        {
            return this.direction;
        }

        /// <summary>
        /// Changes the direction of the explorer to the specified direction.
        /// Please use the <see cref="turnLeft"/> and <see cref="turnRight"/> methods instead.
        /// </summary>
        /// <param name="direction">the direction the explorer should be facing.</param>
        public void setDirection(Direction direction)
        {
            this.direction = direction;
        }

        /// <summary>
        /// Turns the explorer to the left.
        /// </summary>
        /// <returns>the explorers new direction</returns>
        public Direction turnLeft()
        {
            switch (this.direction)
            {
                case Direction.NORTH: { this.direction = Direction.WEST; break; }
                case Direction.EAST: { this.direction = Direction.NORTH; break; }
                case Direction.SOUTH: { this.direction = Direction.EAST; break; }
                case Direction.WEST: { this.direction = Direction.SOUTH; break; }
                default:
                    throw new NullReferenceException("No such direction.");
            }
            return this.direction;
        }

        /// <summary>
        /// Turns the explorer to the right.
        /// </summary>
        /// <returns>the explorers new direction</returns>
        public Direction turnRight()
        {
            switch (this.direction)
            {
                case Direction.NORTH: { this.direction = Direction.EAST; break; }
                case Direction.EAST: { this.direction = Direction.SOUTH; break; }
                case Direction.SOUTH: { this.direction = Direction.WEST; break; }
                case Direction.WEST: { this.direction = Direction.NORTH; break; }
                default:
                    throw new NullReferenceException("No such direction.");
            }
            return this.direction;
        }

        /// <summary>
        /// Returns true when the explorer is NOT facing a wall.
        /// </summary>
        /// <returns>true when the explorer can move forward</returns>
        public bool canMoveForward()
        {
            switch (this.direction)
            {
                case Direction.NORTH: { return this.maze.CanMoveNorthFrom(this.x,this.y); }
                case Direction.EAST: { return this.maze.CanMoveEastFrom(this.x, this.y); }
                case Direction.SOUTH: { return this.maze.CanMoveSouthFrom(this.x, this.y); }
                case Direction.WEST: { return this.maze.CanMoveWestFrom(this.x, this.y); }
                default:
                    throw new NullReferenceException("No such direction.");
            }
        }

        /// <summary>
        /// Attempt to move the explorer forward.
        /// WHEN the explorer is facing a wall this method will fail silently.
        /// </summary>
        public void moveForward()
        {
            if (!canMoveForward())
            {
                return;
            } else
            {
                switch (this.direction)
                {
                    case Direction.NORTH: { this.y--; break; }
                    case Direction.EAST: { this.x++; break; }
                    case Direction.SOUTH: { this.y++; break; }
                    case Direction.WEST: { this.x--; break; }
                    default:
                        throw new NullReferenceException("No such direction.");
                }
            }
        }
    }

    public class AutoExplorer
    {
        private MazeExplorer explorer;

        public AutoExplorer(Maze maze)
        {
            this.explorer = new MazeExplorer(maze);
        }

        public AutoExplorer(MazeExplorer explorer)
        {
            this.explorer = explorer.clone();
        }

        public void stepLeftHanded()
        {
            this.explorer.turnLeft();
            for (int i = 0; i < 4; i++)
            {
                if (this.explorer.canMoveForward())
                {
                    this.explorer.moveForward();
                    break;
                } else
                {
                    this.explorer.turnRight();
                }
            }
        }
        public void stepRightHanded()
        {
            this.explorer.turnRight();
            for (int i = 0; i < 4; i++)
            {
                if (this.explorer.canMoveForward())
                {
                    this.explorer.moveForward();
                    break;
                }
                else
                {
                    this.explorer.turnLeft();
                }
            }
        }

        public int getX()
        {
            return this.explorer.getX();
        }

        public int getY()
        {
            return this.explorer.getY();
        }

        public Direction getDirection()
        {
            return this.explorer.getDirection();
        }
    }
}
