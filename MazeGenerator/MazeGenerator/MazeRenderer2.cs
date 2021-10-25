using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class MazeRenderer2 : UserControl
    {
        private readonly Random RNG = new Random();

        private readonly Rectangle FLOOR = new Rectangle(16, 40, 16, 16);
        private readonly Rectangle WALL = new Rectangle(32, 40, 16, 16);
        private readonly Rectangle TOP = new Rectangle(8 * 16, 56, 16, 16);

        private readonly Rectangle THINGY = new Rectangle(12, 126, 16, 16);

        private readonly Maze maze = new Maze(9, 6);

        public MazeRenderer2()
        {
            InitializeComponent();
        }

        private void MazeRenderer2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int y = 0; y < maze.getSizeY(); y++)
            {
                for (int x = 0; x < maze.getSizeX(); x++)
                {
                    int image_x = x * 32 + 16;
                    int image_y = y * 48 + 32;
                    g.DrawImage(Properties.Resources.dungeon, image_x, image_y, FLOOR, GraphicsUnit.Pixel);
                    g.DrawImage(Properties.Resources.dungeon, image_x+16, image_y+16, TOP, GraphicsUnit.Pixel);
                    g.DrawImage(Properties.Resources.dungeon, image_x + 16, image_y - 32, TOP, GraphicsUnit.Pixel);

                    if (maze.CanMoveNorthFrom(x, y))
                    {
                        g.DrawImage(Properties.Resources.dungeon, image_x, image_y-16, FLOOR, GraphicsUnit.Pixel);
                        g.DrawImage(Properties.Resources.dungeon, image_x, image_y - 32, FLOOR, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(Properties.Resources.dungeon, image_x, image_y-16, WALL, GraphicsUnit.Pixel);
                        g.DrawImage(Properties.Resources.dungeon, image_x, image_y - 32, TOP, GraphicsUnit.Pixel);
                    }

                    if (maze.CanMoveEastFrom(x, y))
                    {
                        g.DrawImage(Properties.Resources.dungeon, image_x + 16, image_y - 16, WALL, GraphicsUnit.Pixel);
                        g.DrawImage(Properties.Resources.dungeon, image_x+16, image_y, FLOOR, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(Properties.Resources.dungeon, image_x + 16, image_y - 16, TOP, GraphicsUnit.Pixel);
                        g.DrawImage(Properties.Resources.dungeon, image_x+16, image_y, TOP, GraphicsUnit.Pixel);
                    }

                    if (RNG.Next(100) < 10)
                    {
                        g.DrawImage(Properties.Resources.community_chars, image_x, image_y - 4, THINGY, GraphicsUnit.Pixel);
                    }

                }
            }


        }
    }
}
