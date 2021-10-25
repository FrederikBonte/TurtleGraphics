using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace AMazeing
{
    public partial class Maze : UserControl
    {
        public enum GenerateAlgorithm
        {
            KRUSKAL,
            RANDOMPATH
        };

        private enum SolveAlgorithm
        {
            LEFTHANDED,
            RIGHTHANDED
        };

        private readonly Rectangle FLOOR = new Rectangle(16, 40, 16, 16);
        private readonly Rectangle FLOOR_SHADOW_TOP = new Rectangle(16, 56, 16, 16);
        private readonly Rectangle FLOOR_SHADOW_MIDDLE = new Rectangle(16, 72, 16, 16);
        private readonly Rectangle FLOOR_SHADOW_BOTTOM = new Rectangle(16, 88, 16, 16);
        private readonly Rectangle WALL = new Rectangle(32, 40, 16, 16);
        private readonly Rectangle WALL_MIDDLE = new Rectangle(48, 40, 16, 16);
        private readonly Rectangle WALL_LEFT = new Rectangle(64, 40, 16, 16);
        private readonly Rectangle WALL_RIGHT = new Rectangle(80, 40, 16, 16);
        private readonly Rectangle WALL_SHADOW = new Rectangle(32, 56, 16, 16);
        private readonly Rectangle TOP = new Rectangle(8*16, 56, 16, 16);

        private int sizex, sizey;
        private Image dungeon = null;
        // Blob is evil... Blob F*cks up the animation cycle...
        // Don't trust blob!
        private CleverBlob blob = null;
        private Room[] rooms;
        private readonly List<Character> kara = new List<Character>();
        private GenerateAlgorithm generate = GenerateAlgorithm.KRUSKAL;
        private SolveAlgorithm solve = SolveAlgorithm.LEFTHANDED;
        private bool treasure;
        private int treasureOffset = 0;
        private bool empty = true;
        private Rectangle treasureRectangle = new Rectangle(7, 53, 25, 25);
        private SoundPlayer victory = new SoundPlayer(Resource.victory);
        private SoundPlayer katching = new SoundPlayer(Resource.katching);

        public Maze() : this(12345)
        {
            this.ResizeRedraw = true;
        }

        private void animation(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public Maze(int seed)
        {
            InitializeComponent();
            this.sizex = 8;
            this.sizey = 5;
            prepareMaze();
            generateMaze(seed);
        }

        private void prepareMaze()
        {
            Room room;
            // Create a long list of "Rooms".
            this.rooms = new Room[sizex * sizey];
            if (this.rooms.Length==0)
            {
                throw new ArgumentException("Cannot create zero size maze!");
            }
            for (int y = 0; y < sizey; y++)
            {
                for (int x = 0; x < sizex; x++)
                {
                    room = new Room();
                    // Add each room.
                    rooms[y * sizex + x] = room;
                    // Create links between all Rooms.
                    // Links are POSSIBLE connections but are still blocked here.
                    if (x > 0)
                    {
                        rooms[y * sizex + x - 1].link(Room.EAST, room);
                    }
                    if (y > 0)
                    {
                        rooms[(y - 1) * sizex + x].link(Room.SOUTH, room);

                    }
                }
            }
            // One room is the start...
            rooms[0].setState(Room.State.START);
            // The other is the finish...
            rooms[rooms.Length - 1].setState(Room.State.FINISH);
        }

        public void initCharacter(Character character)
        {
            this.kara.Add(character);
            character.init(this, character.X, character.Y);
        }

        public void resetCharacter(Character character)
        {
            character.init(this);
        }

        #region Please don't activate the Evil Blob!
        public void addBlob()
        {
            if (this.blob != null)
            {
                throw new Exception("Dual blob not supported (yet).");
            }

            this.blob = new CleverBlob();
            this.initCharacter(this.blob);
        }

        public void removeBlob()
        {
            if (this.blob==null)
            {
                throw new Exception("There is no blob.");
            }
            else
            {
                this.blob.stop();
                this.blob = null;
            }
        }

        public void startBlob()
        {
            if (this.blob==null)
            {
                throw new Exception("There is no blob.");
            } else
            {
                this.blob.start();
            }
        }

        public void stopBlob()
        {
            if (this.blob==null)
            {
                return;
            } else
            {
                this.blob.stop();
            }
        }
        #endregion

        [Description("Width of in the maze in rooms."), Category("Data")]
        public int SizeX
        {
            get { return this.sizex; }
            set { this.sizex = Math.Max(8, value); this.Size = new Size(sizex*32+16, this.Size.Height); prepareMaze(); }
        }

        [Description("Height of the maze in rooms."), Category("Data")]
        public int SizeY
        {
            get { return this.sizey; }
            set { this.sizey = Math.Max(5, value); this.Size = new Size(this.Size.Width, (sizey*48)+16); prepareMaze(); }
        }

        [Description("Generation Algorithm"), Category("Behavior")]
        public GenerateAlgorithm Generate
        {
            get { return this.generate; }
            set { this.generate = value; }
        }

        [Description("Generate treasure"), Category("Behavior")]
        public bool Treasure
        {
            get { return this.treasure; }
            set { this.treasure = value; }
        }

        [Description("Solve Algorithm"), Category("Behavior")]
        private SolveAlgorithm Solver
        {
            get { return this.solve; }
            set { this.solve = value; }
        }

        /// <summary>
        /// Clears the current configuration of the maze and generates a new one.
        /// </summary>
        /// <param name="seed">Seed controls the final configuration of the maze.</param>
        public void generateMaze(int seed = -1) {
            Random RND;
            if (generate == GenerateAlgorithm.KRUSKAL)
            {
                RND = generateKruskal(seed);
            } else
            {
                RND = generateRDFB(seed);
            }

            if (treasure)
            {
                // Place treasures in the maze.
                int t = RND.Next(6) + 5 + RND.Next(6);
                this.empty = false;
                Room room = null;
                for (int i = 0; i < t; i++)
                {
                    do
                    {
                        room = this.rooms[RND.Next(this.rooms.Length)];
                    } while (!room.isEmpty());
                    room.setState(Room.State.TREASURE);
                }
            }

            // If a dungeon was already rendered...
            if (dungeon != null)
            {
                // ... then erase that image and render again in the next paint cycle.
                Image dispose = dungeon;
                this.dungeon = null;
                dispose.Dispose();
            }
//            this.Invalidate();
        }

        private Random generateRDFB(int seed=-1)
        {
            Random RND = (seed == -1) ? new Random() : new Random(seed);
            Stack<Room> path = new Stack<Room>();

            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i].disconnect();
            }

            // Choose a random room.
            path.Push(this.rooms[RND.Next(this.rooms.Length)]);
            // While the path is not empty.
            while (path.Count()>0)
            {
                // Take the last room in the path.
                Room current = path.Peek(), 
                    next = null, 
                    candidate;
                // Find unconnected neighbor.
                // Choose a random direction...
                byte direction = (byte)RND.Next(4);
                // Search for an unconnected neighbor in the first possible direction.
                for (int i=0;i<4;i++)
                {
                    candidate = current.getRoom(direction);
                    // If there is a room, and that room has no active connection yet...
                    if (candidate!=null && !candidate.isConnected())
                    {
                        // We're going to connect to that room.
                        next = candidate;
                        break;
                    } else
                    {
                        // Choose the next direction...
                        direction = Room.getLeft(direction);
                    }
                }
                // Id an ajacent room was found.
                if (next!=null)
                {
                    // Connect to it and add it to the path.
                    current.connect(direction);
                    path.Push(next);
                } else
                {
                    // This room has no more unconnected neighbors...
                    // Search for branches earlier in the stack.
                    path.Pop();
                }
            }
            return RND;
        }

        private Random generateKruskal(int seed = -1) { 
            Random RND = (seed==-1)?new Random():new Random(seed);
            Room current, target;
            byte direction = (byte)RND.Next(4);

            Dictionary<Room, List<Room>> connections = new Dictionary<Room, List<Room>>();
            List<Room> unconnected = new List<Room>();
            for (int i = 0; i < rooms.Length; i++)
            {
                List<Room> temp = new List<Room>()
                {
                    rooms[i]
                };
                connections.Add(rooms[i], temp);
                unconnected.Add(rooms[i]);
                rooms[i].disconnect();
            }

            while (true)
            {
                // Choose a random unconnected room...
                if (unconnected.Count()>0)
                {
                    current = unconnected[RND.Next(unconnected.Count())];
                } else {
                    current = connections.Keys.ElementAt(RND.Next(connections.Keys.Count));
                }
                List<Room> currentList = connections[current];
                // Choose a random direction...
                direction = (byte)RND.Next(4);
                bool connected = false;
                // See if we can connect to another set...
                for (int i=0;i<4;i++)
                {
                    target = current.getRoom(direction);
                    if (target == null || currentList.Contains(target))
                    {
                        direction = Room.getLeft(direction);
                    }
                    else
                    {
                        connected = true;
                        unconnected.Remove(current);
                        unconnected.Remove(target);
                        
//                        Console.WriteLine("New connection...");
                        List<Room> otherList = connections[target];
                        current.connect(direction);
                        currentList.AddRange(otherList);
//                        Console.WriteLine("List is " + currentList.Count + " elements long.");

                        foreach (Room room in otherList)
                        {
                            connections[room] = currentList;
                        }
                        break;
                    }
                }
                if (!connected)
                {
                    connections.Remove(current);
                } else if (currentList.Count == sizex*sizey)
                {
                    break;
                }
            }

            return RND;
        }

        /// <summary>
        /// Draw the maze as stored in memory.
        /// This is where the magic happens!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Maze_Paint(object sender, PaintEventArgs e)
        {
            if (this.dungeon == null)
            {
                // Recreate the dungeon image...
                this.dungeon = new Bitmap(sizex*32+16, sizey*48+16);
                Graphics dg = Graphics.FromImage(this.dungeon);
                // Actually draw the maze.
                this.renderDungeon(dg);
                Console.WriteLine("rerender dungeon.");
            }

            // Draw the dungeon image (background).
            e.Graphics.DrawImage(this.dungeon, 0, 0);
            // Draw all the (remaining) treasures over the maze image.
            this.drawTreasures(e.Graphics);
            // Show where the character is...
            // Please also don't use multiple characters.
            foreach (Character k in this.kara)
            {
                k.draw(e.Graphics);
            }
        }

        private void drawTreasures(Graphics graphics)
        {
            if (this.empty)
            {
                return;
            }
            int count = 0;
            this.treasureOffset++;
            for (int i = 0; i < this.rooms.Length; i++)
            {
                if (this.rooms[i].containsTreasure())
                {
                    count++;
                    drawTreasure(i, graphics, this.treasureOffset + count);
                }
            }
            if (count == 0)
            {
                this.empty = true;
                this.katching.Play();
            }
        }

        private void drawTreasure(int index, Graphics graphics, int offset = 0)
        {
            int x = index % this.sizex;
            int y = index / this.sizex;
            this.treasureRectangle.X = 8 +(offset % 15) * 35;
            graphics.DrawImage(
                Resource.community_chars,
                (x * 32) + 13, (y * 48) + 21,
                this.treasureRectangle,
                GraphicsUnit.Pixel);
        }

        private void renderDungeon(Graphics dg)
        {
            // Drawing
            Random RNG = new Random();
            for (int i = 0; i < (sizex*2) + 2 ;i++) {
//                dg.DrawImage(Resource.dungeon, i * 16, 0, TOP, GraphicsUnit.Pixel);
                dg.DrawImage(Resource.dungeon, i * 16, (sizey*3)*16, TOP, GraphicsUnit.Pixel);
            }
            for (int i = 0; i <= (sizey-1)*3; i++)
            {
//                dg.DrawImage(Resource.dungeon, 0, i * 16, TOP, GraphicsUnit.Pixel);
                dg.DrawImage(Resource.dungeon, (sizex*2)*16, i * 16, TOP, GraphicsUnit.Pixel);
            }
            bool up = this.rooms[this.rooms.Length-1].isConnected(Room.NORTH);
            dg.DrawImage(Resource.dungeon, (sizex * 2) * 16, (((sizey - 1) * 3) + 1) * 16, up?WALL_LEFT:WALL, GraphicsUnit.Pixel);
            dg.DrawImage(Resource.dungeon, (sizex * 2) * 16, (((sizey - 1) * 3) + 2) * 16, FLOOR, GraphicsUnit.Pixel);

            for (int y = 0; y <sizey; y++)
            {
                for (int x = 0; x <sizex; x++)
                {
                    Room room = this.rooms[y * sizex + x];
                    dg.DrawImage(Resource.dungeon, (x * 2) * 16, y * 48, TOP, GraphicsUnit.Pixel);
                    dg.DrawImage(Resource.dungeon, (x * 2) * 16, y * 48 + 16, getWestWall(room), GraphicsUnit.Pixel);
                    dg.DrawImage(Resource.dungeon, (x * 2) * 16, y * 48 + 32, getWestFloor(room), GraphicsUnit.Pixel);
                    dg.DrawImage(Resource.dungeon, (x * 2 + 1) * 16, y * 48, getNorthTop(room), GraphicsUnit.Pixel);
                    dg.DrawImage(Resource.dungeon, (x * 2 + 1) * 16, y * 48 + 16, getNorthWall(room), GraphicsUnit.Pixel);
                    dg.DrawImage(Resource.dungeon, (x * 2 + 1) * 16, y * 48 + 32, getFloor(room), GraphicsUnit.Pixel);
                }
            }
        }

        private Rectangle getFloor(Room room)
        {
            return room.isConnected(Room.WEST) ? FLOOR : FLOOR_SHADOW_MIDDLE;
        }

        private Rectangle getNorthWall(Room room)
        {
            if (room.isConnected(Room.NORTH))
            {
                return room.isConnected(Room.WEST) ? FLOOR_SHADOW_BOTTOM : FLOOR_SHADOW_MIDDLE;
            }
            else
            {
                return room.isConnected(Room.WEST) ? WALL : WALL_SHADOW;
            }
        }

        private Rectangle getNorthTop(Room room)
        {
            if (!room.isConnected(Room.NORTH))
            {
                return TOP;
            }
            bool NW = room.getRoom(Room.NORTH).isConnected(Room.WEST);
            return NW ? FLOOR_SHADOW_TOP : FLOOR_SHADOW_MIDDLE;
        }

        private Rectangle getWestFloor(Room room)
        {
            return room.isConnected(Room.WEST) ? FLOOR : TOP;
        }

        private Rectangle getWestWall(Room room)
        {
            if (!room.isConnected(Room.WEST))
            {
                return TOP;
            }
            bool NW = room.getRoom(Room.WEST).isConnected(Room.NORTH);
            bool N = room.isConnected(Room.NORTH);
            if (NW)
            {
                return N ? WALL_MIDDLE : WALL_LEFT;
            } else
            {
                return N ? WALL_RIGHT : WALL;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        internal Room getRoom(int x, int y)
        {
            return this.rooms[y * sizex + x];
        }
    }

    public class Room
    {
        public const byte NORTH = 0;
        public const byte EAST = 1;
        public const byte SOUTH = 2;
        public const byte WEST = 3;

        internal static byte getOpposite(byte direction)
        {
            return (byte)((direction + 2) % 4);
        }

        internal static byte getLeft(byte direction)
        {
            return (byte)((direction + 3) % 4);
        }

        internal static byte getRight(byte direction)
        {
            return (byte)((direction + 1) % 4);
        }

        private class Connection
        {
            public bool connected;
            public Room room;
        };

        public enum State
        {
            EMPTY,
            START,
            FINISH,
            TREASURE
        }

        private Connection[] connections = new Connection[4];
        private State state = State.EMPTY;
        private int connectionCount;

        public Room()
        {
            for (int i=0;i<4;i++)
            {
                connections[i] = new Connection();
            }
            this.connectionCount = -1;
        }

        internal void setState(State state)
        {
            this.state = state;
        }

        /// <summary>
        /// Returns true when this room contains nothing.
        /// The entrance and exit of the maze are considered to be something.
        /// </summary>
        /// <returns>true when this room contains nothing</returns>
        public bool isEmpty()
        {
            return this.state == State.EMPTY;
        }

        /// <summary>
        /// Returns true when this room is the "exit" of the maze.
        /// </summary>
        /// <returns>true when this room is the finish.</returns>
        public bool isFinish()
        {
            return this.state == State.FINISH;
        }

        /// <summary>
        /// Returns true when this room is the "start" of the maze.
        /// </summary>
        /// <returns>true when this room is the entrance.</returns>
        public bool isStart()
        {
            return this.state == State.START;
        }

        /// <summary>
        /// Returns true when this room contains a treasure.
        /// </summary>
        /// <returns>true when this room contains a treasure.</returns>
        public bool containsTreasure()
        {
            return this.state == State.TREASURE;
        }

        /// <summary>
        /// Removes the treasure from this room.
        /// </summary>
        public void takeTreasure()
        {
            if (this.containsTreasure())
            {
                this.state = State.EMPTY;
            } else
            {
                throw new NoTreasureException();
            }
        }

        internal int getConnectionCount()
        {
            if (this.connectionCount == -1)
            {
                this.connectionCount = 0;
                for (byte i = 0; i < 4; i++)
                {
                    if (isConnected(i))
                    {
                        this.connectionCount++;
                    }
                }
            }
            return this.connectionCount;
        }

        internal bool isConnected()
        {
            return this.getConnectionCount() > 0;
        }

        internal bool isDeadEnd()
        {
            return this.getConnectionCount() < 2;
        }

        internal bool isConnected(byte direction)
        {
            return this.connections[direction].connected;
        }

        internal bool isLinked(byte direction)
        {
            return getRoom(direction)!=null;
        }

        internal Room getRoom(byte direction)
        {
            return this.connections[direction].room;
        }

        /// <summary>
        /// Make rooms aware of their neighbors.
        /// This defines "walls" not "CONNECTIONS".
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="room"></param>
        internal void link(byte direction, Room room)
        {
            byte opposite = getOpposite(direction);
            Connection other = room.connections[opposite];
            if (other.room!=null) {
                throw new ArgumentException("Other room is already connected.");
            }
            this.connections[direction].room = room;
            other.room = this;
        }

        internal void connect(byte direction)
        {
            Connection connection = this.connections[direction];
            if (connection.room == null)
            {
                throw new ArgumentException("There is no room in that direction.");
            }
            Connection other = connection.room.connections[getOpposite(direction)];
            connection.connected = true;
            other.connected = true;
        }

        internal void disconnect()
        {
            for (int i = 0; i < 4; i++)
            {
                connections[i].connected = false;
            }
            this.connectionCount = -1;
            if (this.state==State.TREASURE)
            {
                this.state = State.EMPTY;
            }
        }
    }

    public class NoTreasureException:Exception
    {
        public NoTreasureException():base("There is no treasure to pick up.")
        { }
    }
}
