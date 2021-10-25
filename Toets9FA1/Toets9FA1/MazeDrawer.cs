using ROCvanTwente.Sumpel.Semester2.MazeGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toets9FA1
{
    /// <summary>
    /// Deze class tekent het doolhof en de locatie van de explorer.
    /// </summary>
    public partial class MazeDrawer : UserControl
    {
        private Maze maze;
        private MazeExplorer explorer;
        private AutoExplorer aix;
        private ToetsOpdracht to;
        // The maze fills the screen.
        // Left over space is used to center the maze.
        private int size = 50, // Room size.
            mx, // Margin x (left)
            my; // Margin y (top)

        public Maze getMaze()
        {
            return this.maze;
        }

        public MazeExplorer getExplorer()
        {
            return this.explorer;
        }

        public AutoExplorer getAutoExplorer()
        {
            return this.aix;
        }

        public ToetsOpdracht getToetsOpdracht()
        {
            return this.to;
        }


        public MazeDrawer()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        /// <summary>
        /// Deze functie is goed! Wijzig deze functie niet!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MazeDrawer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.Black);

            if (maze==null)
            {
                return;
            }

            Pen p = new Pen(Color.White, 4);
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            g.DrawRectangle(p, mx, my, maze.getSizeX() * size, maze.getSizeY() * size);
            this.to.tekenExplorer(g, mx, my, size);
            Pen r = new Pen(Color.Red);
            g.FillEllipse(r.Brush, this.aix.getX() * size + mx + 5, this.aix.getY() * size + my+5, size-10, size-10);

            for (int y = 0; y < maze.getSizeY(); y++)
            {
                for (int x = 0; x < maze.getSizeX(); x++)
                {
                    if (x>0 && !maze.CanMoveWestFrom(x,y))
                    {
                        g.DrawLine(p, mx + x * size, my + y * size, mx + x * size, my + (y + 1) * size);
                    }
                    if (y > 0 && !maze.CanMoveNorthFrom(x, y))
                    {
                        g.DrawLine(p, mx + x * size, my + y * size, mx + (x+1) * size, my + y * size);
                    }
                }
            }
        }

        private void MazeDrawer_Resize(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            this.maze = new Maze(this.Width / size, this.Height / size);
            mx = (this.Width - this.maze.getSizeX() * size) / 2;
            my = (this.Height - this.maze.getSizeY() * size) / 2;
            this.explorer = new MazeExplorer(this.maze);
            this.aix = new AutoExplorer(this.explorer);
            this.to = new ToetsOpdracht(this.maze, this.explorer);
        }

        public void autoStep()
        {
            this.aix.stepLeftHanded();
        }
    }
}
