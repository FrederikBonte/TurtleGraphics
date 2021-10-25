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
    public partial class Form1 : Form
    {
        private const int STEPS = 100;
        private MazeExplorer explorer;
        private ToetsOpdracht to;
        private int timedScore;
        private int count;

        public Form1()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Test 1 stap met het doolhof op het scherm...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            Direction d = mazeDrawer.getExplorer().getDirection();
            int p1 = MazeTester.testCanTurnLeft(mazeDrawer.getToetsOpdracht(), mazeDrawer.getMaze(), mazeDrawer.getExplorer());
            int p2 = MazeTester.testCanTurnRight(mazeDrawer.getToetsOpdracht(), mazeDrawer.getMaze(), mazeDrawer.getExplorer());
            int p3 = MazeTester.testCanGoBack(mazeDrawer.getToetsOpdracht(), mazeDrawer.getMaze(), mazeDrawer.getExplorer());
            int p4 = MazeTester.testCanGoForward(mazeDrawer.getToetsOpdracht(), mazeDrawer.getMaze(), mazeDrawer.getExplorer());
            mazeDrawer.getExplorer().setDirection(d);
            mazeDrawer.autoStep();
            int p5 = MazeTester.testOneStep(mazeDrawer.getToetsOpdracht(), mazeDrawer.getMaze(), mazeDrawer.getExplorer());
            txtPart1.Text = "" + p1;
            txtPart2.Text = "" + p2;
            txtPart3.Text = "" + p3;
            txtPart4.Text = "" + p4;
            txtPart5.Text = "" + p5;
            this.mazeDrawer.Invalidate();
        }

        /// <summary>
        /// Deze test functie geneert willekeurige doolhoven.
        /// De explorer wordt op een willekeurige plek gezet.
        /// Daarna wordt alles een aantal keer getest.
        /// Deze functie tekent de test doolhoven NIET!!!
        /// </summary>
        private void testMultiple()
        {
            int p1 = 0, p3 = 0, p2 = 0, p4 = 0, p5 = 0;
            for (int i = 0; i < 250; i++)
            {
                Maze maze = new Maze(50, 50);
                MazeExplorer explorer = new MazeExplorer(maze);
                ToetsOpdracht to = new ToetsOpdracht(maze, explorer);

                p1 += MazeTester.testCanTurnLeft(to, maze, explorer);
                p2 += MazeTester.testCanTurnRight(to, maze, explorer);
                p3 += MazeTester.testCanGoBack(to, maze, explorer);
                p4 += MazeTester.testCanGoForward(to, maze, explorer);
                p5 += MazeTester.testOneStep(to, maze, explorer);
            }
            p1 /= 20;
            p2 /= 20;
            p3 /= 20;
            p4 /= 20;
            p5 /= 20;
            txtPart1.Text = "" + (p1 == 100 ? p1 : p5) + "%";
            txtPart2.Text = "" + (p2 == 100 ? p2 : p5) + "%";
            txtPart3.Text = "" + (p3 == 100 ? p3 : p5) + "%";
            txtPart4.Text = "" + (p4 == 100 ? p4 : p5) + "%";
            txtPart5.Text = "" + p5 + "%";

            if (p5 / 20 == 100)
            {
                MessageBox.Show("Je hebt het doolhof probleem opgelost!", "Gefeliciteerd!");
            }
        }

        private void btnTestMulti_Click(object sender, EventArgs e)
        {
            testMultiple();
        }

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestTimer_Click(object sender, EventArgs e)
        {
            // Je start met een score van 0.
            this.timedScore = 0;
            // Er worden een aantal stappen getest.
            this.count = STEPS;

            // Start het doolhof,
            this.explorer = mazeDrawer.getExplorer();
            this.to = mazeDrawer.getToetsOpdracht();

            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            count--;
            this.to.takeOneStep();
            this.mazeDrawer.autoStep();
            if (this.explorer.getX() == this.mazeDrawer.getAutoExplorer().getX() &&
                this.explorer.getY() == this.mazeDrawer.getAutoExplorer().getY() &&
                this.explorer.getDirection() == this.mazeDrawer.getAutoExplorer().getDirection())
            {
                timedScore++;
            }
            this.mazeDrawer.Invalidate();
            if (count<=0)
            {
                timer.Enabled = false;
                this.txtTimedScore.Text = "" + ((timedScore*100)/STEPS) + "%";
            }
        }
    }
}
