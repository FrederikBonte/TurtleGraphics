using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator
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
        private static readonly Random RNG = new Random();
        private readonly Maze maze;
        private int x, y;
        private Direction direction;

        public MazeExplorer(Maze maze)
        {
            this.maze = maze;
            this.x = MazeExplorer.RNG.Next(this.maze.getSizeX()/2);
            this.y = MazeExplorer.RNG.Next(this.maze.getSizeY()/2);
            this.direction = (Direction)MazeExplorer.RNG.Next(4);
        }

        public bool isAtFinish()
        {
            return (this.x == this.maze.getSizeX() - 1) && (this.y == this.maze.getSizeY() - 1);
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public Direction getDirection()
        {
            return this.direction;
        }

        public void setDirection(Direction direction)
        {
            this.direction = direction;
        }

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
}
