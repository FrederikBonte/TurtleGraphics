using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class MazeRenderer : UserControl
    {
        private readonly Rectangle FLOOR = new Rectangle(16, 40, 16, 16);
        private readonly Rectangle FLOOR_SHADOW_TOP = new Rectangle(16, 56, 16, 16);
        private readonly Rectangle FLOOR_SHADOW_MIDDLE = new Rectangle(16, 72, 16, 16);
        private readonly Rectangle FLOOR_SHADOW_BOTTOM = new Rectangle(16, 88, 16, 16);
        private readonly Rectangle WALL = new Rectangle(32, 40, 16, 16);
        private readonly Rectangle WALL_MIDDLE = new Rectangle(48, 40, 16, 16);
        private readonly Rectangle WALL_LEFT = new Rectangle(64, 40, 16, 16);
        private readonly Rectangle WALL_RIGHT = new Rectangle(80, 40, 16, 16);
        private readonly Rectangle WALL_SHADOW = new Rectangle(32, 56, 16, 16);
        private readonly Rectangle TOP = new Rectangle(8 * 16, 56, 16, 16);

        private Maze maze;

        public MazeRenderer(): this(12345)
        {
        }

        public MazeRenderer(int seed)
        {
            InitializeComponent();
            this.ResizeRedraw = true;
        }

        private void MazeRenderer_Paint(object sender, PaintEventArgs e)
        {            
            if (this.dungeon == null)
            {
                int sizex = (Width - 16) / 32;
                int sizey = (Height - 16) / 48;
                maze = new Maze(sizex, sizey);
                // Recreate the dungeon image...
                this.dungeon = new Bitmap(sizex * 32 + 16, sizey * 48 + 16);
                Graphics dg = Graphics.FromImage(this.dungeon);
                // Actually draw the maze.
                renderDungeon(dg);
            }
            // Draw the dungeon image (background).
            e.Graphics.DrawImage(this.dungeon, 0, 0);
            // Draw all the (remaining) treasures over the maze image.
            this.drawTreasures(e.Graphics);
            // Show where the character is...
            // Please also don't use multiple characters.
            //foreach (Character k in this.kara)
            //{
            //    k.draw(e.Graphics);
            //}
        }

        private void MazeRenderer_Resize(object sender, EventArgs e)
        {
            int sizex = (Width - 16) / 32;
            int sizey = (Height - 16) / 48;
            if (maze==null || maze.getSizeX()!=sizex || maze.getSizeY()!=sizey)
            {
                dungeon = null;
            }
        }

        private Image dungeon = null;

        private bool treasure;
        private int treasureOffset = 0;
        private bool empty = true;
        private Rectangle treasureRectangle = new Rectangle(7, 53, 25, 25);
        private SoundPlayer victory = new SoundPlayer(Properties.Resources.victory);
        private SoundPlayer katching = new SoundPlayer(Properties.Resources.katching);

        [Description("Generate treasure"), Category("Behavior")]
        public bool Treasure
        {
            get { return this.treasure; }
            set { this.treasure = value; }
        }

        private void drawTreasures(Graphics graphics)
        {
            if (this.empty)
            {
                return;
            }
            int count = 0;
            this.treasureOffset++;
            //for (int i = 0; i < this.rooms.Length; i++)
            //{
            //    if (this.rooms[i].containsTreasure())
            //    {
            //        count++;
            //        drawTreasure(i, graphics, this.treasureOffset + count);
            //    }
            //}
            if (count == 0)
            {
                this.empty = true;
                this.katching.Play();
            }
        }

        //private void drawTreasure(int index, Graphics graphics, int offset = 0)
        //{
        //    int x = index % this.sizex;
        //    int y = index / this.sizex;
        //    this.treasureRectangle.X = 8 + (offset % 15) * 35;
        //    graphics.DrawImage(
        //        Properties.Resources.community_chars,
        //        (x * 32) + 13, (y * 48) + 21,
        //        this.treasureRectangle,
        //        GraphicsUnit.Pixel);
        //}

        private void renderDungeon(Graphics dg)
        {
            for (int i = 0; i < (maze.getSizeX() * 2) + 2; i++)
            {
                //                dg.DrawImage(Resource.dungeon, i * 16, 0, TOP, GraphicsUnit.Pixel);
                dg.DrawImage(Properties.Resources.dungeon, i * 16, (maze.getSizeY() * 3) * 16, TOP, GraphicsUnit.Pixel);
            }
            for (int i = 0; i <= (maze.getSizeY() - 1) * 3; i++)
            {
                //                dg.DrawImage(Resource.dungeon, 0, i * 16, TOP, GraphicsUnit.Pixel);
                dg.DrawImage(Properties.Resources.dungeon, (maze.getSizeX() * 2) * 16, i * 16, TOP, GraphicsUnit.Pixel);
            }
            bool up = maze.CanMoveNorthFrom(maze.getSizeX()-1, maze.getSizeY()-1);
            dg.DrawImage(Properties.Resources.dungeon, (maze.getSizeX() * 2) * 16, (((maze.getSizeY() - 1) * 3) + 1) * 16, up ? WALL_LEFT : WALL, GraphicsUnit.Pixel);
            dg.DrawImage(Properties.Resources.dungeon, (maze.getSizeX() * 2) * 16, (((maze.getSizeY() - 1) * 3) + 2) * 16, FLOOR, GraphicsUnit.Pixel);

            for (int y = 0; y < maze.getSizeY(); y++)
            {
                for (int x = 0; x < maze.getSizeX(); x++)
                {
                    dg.DrawImage(Properties.Resources.dungeon, (x * 2) * 16, y * 48, TOP, GraphicsUnit.Pixel);
                    dg.DrawImage(Properties.Resources.dungeon, (x * 2) * 16, y * 48 + 16, getWestWall(maze, x, y), GraphicsUnit.Pixel);
                    dg.DrawImage(Properties.Resources.dungeon, (x * 2) * 16, y * 48 + 32, getWestFloor(maze, x, y), GraphicsUnit.Pixel);
                    dg.DrawImage(Properties.Resources.dungeon, (x * 2 + 1) * 16, y * 48, getNorthTop(maze, x, y), GraphicsUnit.Pixel);
                    dg.DrawImage(Properties.Resources.dungeon, (x * 2 + 1) * 16, y * 48 + 16, getNorthWall(maze, x, y), GraphicsUnit.Pixel);
                    dg.DrawImage(Properties.Resources.dungeon, (x * 2 + 1) * 16, y * 48 + 32, getFloor(maze, x, y), GraphicsUnit.Pixel);
                }
            }
        }

        private Rectangle getFloor(Maze maze, int x, int y)
        {
            return maze.CanMoveWestFrom(x,y) ? FLOOR : FLOOR_SHADOW_MIDDLE;
        }

        private Rectangle getNorthWall(Maze maze, int x, int y)
        {
            if (maze.CanMoveNorthFrom(x,y))
            {
                return maze.CanMoveWestFrom(x,y) ? FLOOR_SHADOW_BOTTOM : FLOOR_SHADOW_MIDDLE;
            }
            else
            {
                return maze.CanMoveWestFrom(x, y) ? WALL : WALL_SHADOW;
            }
        }

        private Rectangle getNorthTop(Maze maze, int x, int y)
        {
            if (!maze.CanMoveNorthFrom(x,y))
            {
                return TOP;
            }
            bool NW = maze.CanMoveWestFrom(x, y - 1);
            return NW ? FLOOR_SHADOW_TOP : FLOOR_SHADOW_MIDDLE;
        }

        private Rectangle getWestFloor(Maze maze, int x, int y)
        {
            return maze.CanMoveWestFrom(x, y) ? FLOOR : TOP;
        }

        private Rectangle getWestWall(Maze maze, int x, int y)
        {
            if (!maze.CanMoveWestFrom(x, y))
            {
                return TOP;
            }
            bool NW = maze.CanMoveNorthFrom(x - 1, y);
            bool N = maze.CanMoveNorthFrom(x, y);
            if (NW)
            {
                return N ? WALL_MIDDLE : WALL_LEFT;
            }
            else
            {
                return N ? WALL_RIGHT : WALL;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}

