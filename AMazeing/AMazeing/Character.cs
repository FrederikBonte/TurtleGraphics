using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace AMazeing
{
    public class Character
    {
        private SoundPlayer bonk = new SoundPlayer(Resource.bonk);
        private SoundPlayer yay = new SoundPlayer(Resource.yay);
        private SoundPlayer coin = new SoundPlayer(Resource.coin);
        private SoundPlayer nothing = new SoundPlayer(Resource.fail);

        public enum Sprite
        {
            NEUTRAL = 121,
            BLUE_HAIR = 155,
            SKELLETON = 189,
            DWARF = 223,
            NINJA = 257,
            EVIL_KNIGHT = 529,
            EVIL_WIZARD = 563,
            RED_SKELLETON = 1311,
            SPACE_MAN_BLUE = 359,
            SPACE_MAN_GREEN = 767,
            SPACE_MAN_YELLOW = 801,
            SPACE_MAN_RED = 835,
            TREASURE = 54,
            BLOB = 393
        };

        public const byte RIGHT = Room.EAST;
        public const byte LEFT = Room.WEST;
        public const byte UP = Room.NORTH;
        public const byte DOWN = Room.SOUTH;

        private int INDEX_RIGHT = 0;
        private int INDEX_LEFT = 0;
        private int INDEX_FRONT = 5;
        private int INDEX_BACK = 10;

        private Rectangle[] sprites =
        {
            new Rectangle( 0 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 1 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 2 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 3 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 4 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 5 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 6 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 7 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 8 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle( 9 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle(10 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle(11 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle(12 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle(13 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
            new Rectangle(14 * 35 + 7, (int)Sprite.NEUTRAL, 25, 25),
        };

        private int x, y;
        private byte direction;
        private string name;
        private Maze maze;
        private Room room;
        private int animationIndex, offsetX, offsetY;
        private int collected = 0;

        public Character()
        {
        }

        internal Character(int x, int y, Maze maze, byte direction = Room.EAST):this()
        {
            this.direction = direction;
            this.X = x;
            this.Y = y;
            init(maze, x, y);
        }

        /// <summary>
        /// The x coordinate of the character.
        /// Can only be set when the character hasn't been initialised into the maze yet.
        /// </summary>
        public int X
        {
            get { return this.x; }
            set
            {
                if (this.maze != null)
                {
                    throw new ArgumentException("Cannot change x position after character has entered the maze.");
                }
                this.x = value;
            }
        }

        /// <summary>
        /// The y coordinate of the character.
        /// Can only be set when the character hasn't been initialised into the maze yet.
        /// </summary>
        public int Y
        {
            get { return this.y; }
            set
            {
                if (this.maze != null)
                {
                    throw new ArgumentException("Cannot change y position after character has entered the maze.");
                }
                this.y = value;
            }
        }

        /// <summary>
        /// The direction the character is facing.
        /// You can either use Room.NORTH, EAST, SOUTH and Room.WEST
        /// Or you can use Character.UP, DOWN, LEFT and Character.RIGHT
        /// </summary>
        public byte Direction
        {
            get { return this.direction; }
            set
            {
                this.direction = value;
                this.animationIndex = getAnimationIndex();
            }
        }

        private int getAnimationIndex()
        {
            switch (this.direction)
            {
                case (Room.NORTH): { return INDEX_BACK; }
                case (Room.EAST): { return INDEX_RIGHT; }
                case (Room.SOUTH): { return INDEX_FRONT; }
                case (Room.WEST): { return INDEX_LEFT; }
                default: { return INDEX_FRONT; }
            }
        }

        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// The way the character looks.
        /// See Sprite.DWARF, Sprite.SKELETON, etc.
        /// </summary>
        public Sprite Appearance
        {
            get
            {
                switch (this.sprites[0].Y)
                {
                    case (int)Sprite.BLUE_HAIR: { return Sprite.BLUE_HAIR; }
                    case (int)Sprite.DWARF: { return Sprite.DWARF; }
                    case (int)Sprite.EVIL_KNIGHT: { return Sprite.EVIL_KNIGHT; }
                    case (int)Sprite.EVIL_WIZARD: { return Sprite.EVIL_WIZARD; }
                    case (int)Sprite.NINJA: { return Sprite.NINJA; }
                    case (int)Sprite.RED_SKELLETON: { return Sprite.RED_SKELLETON; }
                    case (int)Sprite.SKELLETON: { return Sprite.SKELLETON; }
                    default: return Sprite.NEUTRAL;
                }
            }
            set
            {
                for (int i=0;i<15;i++)
                {
                    this.sprites[i].Y = (int)value;
                }
            }
        }

        virtual internal void init(Maze maze, int x = 0, int y = 0)
        {
            this.collected = 0;
            this.maze = maze;
            this.x = x;
            this.y = y;
            try
            {
                this.room = maze.getRoom(x, y);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentException("Position of character doesn't match the provided maze.");
            }
        }

        internal void draw(Graphics g)
        {
            if (direction == Room.WEST)
            {
                g.TranslateTransform(48 + x * 64 , 0);
                g.ScaleTransform(-1, 1);
            }
            g.DrawImage(
                Resource.community_chars,
                (x * 32) + 13 + offsetX, (y * 48) + 21 + offsetY,
                this.sprites[animationIndex],
                GraphicsUnit.Pixel);
            // "undo" the transformation...
            if (direction == Room.WEST)
            {
                g.TranslateTransform(48 + x * 64, 0);
                g.ScaleTransform(-1, 1);
            }
        }

        /// <summary>
        /// Turns the character to the left.
        /// Note that this doesn't move the character. It only changes its direction.
        /// </summary>
        public void turnLeft()
        {
            this.Direction = Room.getLeft(this.direction);
            //            maze.Invalidate();
        }

        /// <summary>
        /// Turns the character to the right.
        /// Note that this doesn't move the character. It only changes its direction.
        /// </summary>
        public void turnRight()
        {
            this.Direction = Room.getRight(this.direction);
            //            maze.Invalidate();
        }

        /// <summary>
        /// Turns the character in the opposite direction.
        /// Note that this doesn't move the character. It only changes its direction.
        /// </summary>
        public void turnBack()
        {
            this.Direction = Room.getOpposite(this.direction);
            //            maze.Invalidate();
        }

        /// <summary>
        /// Returns true when the character can move forward.
        /// Or in other words returns false when facing a wall.
        /// </summary>
        /// <returns>true when not facing a wall.</returns>
        public bool canMoveForward()
        {
            return this.room.isConnected(this.direction);
        }

        /// <summary>
        /// Makes the character take a step forward.
        /// </summary>
        public void moveForward()
        {
            if (canMoveForward())
            {
                room = room.getRoom(this.direction);
                switch (this.direction)
                {
                    case LEFT: { x -= 1; break; }
                    case RIGHT: { x += 1; break; }
                    case UP: { y -= 1; break; }
                    case DOWN: { y += 1; break; }
                }
                if (this.room.isFinish())
                {
                    yay.Play();
                }
            } else
            {
                bonk.Play();
            }
        }

        /// <summary>
        /// Returns the current room in which the character is located.
        /// </summary>
        /// <returns>Returns the current room in which the character is located</returns>
        public Room getRoom()
        {
            return this.room;
        }

        /// <summary>
        /// Returns the number of treasures collected already.
        /// </summary>
        public int Collected
        {
            get { return this.collected; }
        }

        public bool seeTreasure()
        {
            return this.getRoom().containsTreasure();
        }

        /// <summary>
        /// Removes the treasure from the current room, and
        /// adds it to this characters inventory.
        /// </summary>
        public void pickUpTreasure()
        {
            if (this.seeTreasure())
            {
                coin.Play();
                this.getRoom().takeTreasure();
                this.collected++;
            }
            else
            {
                nothing.Play();
            }
        }
    }

    internal class CleverBlob : Character
    {
        private readonly Random RND;
        private bool _stop = true;

        public CleverBlob(int seed = -1)
        {
            RND = (seed == -1) ? new Random() : new Random(seed);
            this.Appearance = Sprite.BLOB;
        }

        override internal void init(Maze maze, int x = 0, int y = 0)
        {
            base.init(maze, RND.Next(maze.SizeX), RND.Next(maze.SizeY));
            this.start();
        }

        public void start()
        {
            if (this._stop)
            {
                Thread thread = new Thread(new ThreadStart(wander));
                thread.Start();
            } else
            {
                throw new Exception("Cannot start creature twice.");
            }
        }

        public void stop()
        {
            this._stop = true;
        }

        internal void wander()
        {
            Console.WriteLine("Blob starts wandering...");

            this._stop = false; 
            while (!this._stop)
            {
                bool stuck = true;
                this.turnRight();
                for (int i=0;i<4;i++)
                {
                    if (tryForward())
                    {
                        stuck = false;
                        break;
                    } else
                    {
                        this.turnLeft();
                    }
                }
                if (stuck)
                {
                    Console.WriteLine("Blob is stuck...");
                    this._stop = true;
                }
                Thread.Sleep(379);
            }
        }

        private bool tryForward()
        {
            Room dRoom = null;
            if (this.getRoom().isConnected(this.Direction))
            {
                dRoom = this.getRoom().getRoom(this.Direction);
            } else { 
                Console.WriteLine("Cannot move " + this.Direction);
                return false;
            } 
            if (dRoom.isDeadEnd())
            {
                Console.WriteLine("Direction " + this.Direction + " is a dead end.");
                return false;
            } else
            {
                Console.WriteLine("Blob moves " + this.Direction);
                this.moveForward();
                return true;
            }
        }
    }

    public class DNDCharacter:Character
    {
        public readonly int strength, dexterity, constitution, intelligence, wisdom, charisma;

        public DNDCharacter(int seed = -1)
        {
            Random RND = (seed==-1)?new Random():new Random(seed);
            strength = rollAbility(RND);
            dexterity = rollAbility(RND);
            constitution = rollAbility(RND);
            intelligence = rollAbility(RND);
            wisdom = rollAbility(RND);
            charisma = rollAbility(RND);
        }

        private int rollAbility(Random rnd)
        {
            int a1 = rnd.Next(6) + 1;
            int a2 = rnd.Next(6) + 1;
            int a3 = rnd.Next(6) + 1;
            int lowest = rnd.Next(6) + 1;
            int temp;
            if (a1<lowest)
            {
                temp = a1;
                a1 = lowest;
                lowest = temp;
            }
            if (a2 < lowest)
            {
                temp = a2;
                a2 = lowest;
                lowest = temp;
            }
            if (a3 < lowest)
            {
                temp = a3;
                a3 = lowest;
                lowest = temp;
            }
            return a1 + a2 + a3;
        }
    }
}
