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
    public partial class RandomField : UserControl
    {
        public const int ROOMSIZE = 20;

        private Bitmap image = null;

        private MazeExplorer explorer;

        public RandomField()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void RandomField_Resize(object sender, EventArgs e)
        {
            // Clear the current maze, force a new generation...
            image = null;
        }

        private void RandomField_Paint(object sender, PaintEventArgs e)
        {
            if (image==null)
            {
                int sizex = Math.Max((Width - 1) / ROOMSIZE, 10);
                int sizey = Math.Max((Height - 1) / ROOMSIZE, 10);
                Maze maze = new Maze(sizex, sizey);
                this.explorer = new MazeExplorer(maze);
                RenderImage(maze);
            }
            Graphics g = e.Graphics;
            g.DrawImage(image, 0, 0);

            Pen p = new Pen(Color.Blue);
            g.DrawRectangle(p, this.explorer.getX()*ROOMSIZE+2, this.explorer.getY()*ROOMSIZE+2, ROOMSIZE-4, ROOMSIZE-4);
        }

        private void RenderImage(Maze maze)
        {
            image = new Bitmap(maze.getSizeX() * ROOMSIZE + 1, maze.getSizeY() * ROOMSIZE + 1);
            Graphics g = Graphics.FromImage(image);
            Pen p = new Pen(Color.Black, 1);
            g.DrawRectangle(p, 0, 0, image.Width-1, image.Height-1);
            for (int y = 0; y < maze.getSizeY(); y++)
            {
                for (int x = 0; x < maze.getSizeX(); x++)
                {
                    if (!maze.CanMoveEastFrom(x,y))
                    {
                        g.DrawLine(p, (x+1) * ROOMSIZE, y * ROOMSIZE, (x+1) * ROOMSIZE, (y + 1) * ROOMSIZE);
                    }
                    if (!maze.CanMoveSouthFrom(x,y))
                    {
                        g.DrawLine(p, x * ROOMSIZE, (y+1) * ROOMSIZE, (x+1) * ROOMSIZE, (y+1) * ROOMSIZE);
                    }
                }
            }

//            g.DrawRectangle(p, startx*ROOMSIZE + 2, starty*ROOMSIZE + 2, ROOMSIZE-4, ROOMSIZE-4);
        }

        private void RandomField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.D)
            {
                this.explorer.setDirection(Direction.EAST);
                this.explorer.moveForward();
                this.Invalidate();
            }
            if (e.KeyCode == Keys.A)
            {
                this.explorer.setDirection(Direction.WEST);
                this.explorer.moveForward();
                this.Invalidate();
            }
            if (e.KeyCode == Keys.W)
            {
                this.explorer.setDirection(Direction.NORTH);
                this.explorer.moveForward();
                this.Invalidate();
            }
            if (e.KeyCode == Keys.S)
            {
                this.explorer.setDirection(Direction.SOUTH);
                this.explorer.moveForward();
                this.Invalidate();
            }
            if (e.KeyCode == Keys.Space)
            {
                this.timer.Enabled = !this.timer.Enabled;
            }
            if (e.KeyCode == Keys.E)
            {
                this.timer.Interval--;
                if (timer.Interval<10)
                {
                    timer.Interval = 10;
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                this.timer.Interval++;
                if (timer.Interval > 250)
                {
                    timer.Interval = 250;
                }
            }
            if (this.explorer.isAtFinish())
            {
                MessageBox.Show("You have found the end!", "We must go deeper");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
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
            if (this.explorer.isAtFinish())
            {
                timer.Enabled = false;
            }
            this.Invalidate();
        }
    }
}
