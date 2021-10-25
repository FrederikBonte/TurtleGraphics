using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy0sv3
{
    public partial class FlappyBird : UserControl
    {
        private const float MAX_SPEED = 8.7f;

        private float bird_height = 100; // Position of the bird in the y position.
        private float bird_speed = MAX_SPEED; // Where does the bird go? (1 is down.)

        private Rectangle[] parrot_frames = new Rectangle[9];
        private int frame = 0;

        // Store true if the parrot is dead. :)
        private bool gameOver = false;
        private int score = 0;

        private FlappyDB database = new FlappyDB();

        public FlappyBird()
        {
            InitializeComponent();

        }

        private void FlappyBird_Paint(object sender, PaintEventArgs e)
        {
            // Store the Graphics environment.
            Graphics g = e.Graphics;
            //            g.Clear(Color.LightGray);

            // @TODO:
            // Teken de vogel
            drawBird(g);
            // Teken de score
            drawScore(g);
            // Vogel valt naar beneden.
            // Tenzij toets is ingedrukt. (Dan omhoog.)
            // Teken een coole achtergrond!
            // Teken de obstakels. (Die moeten naar links bewegen.)
            // Check of de vogel botst. :)
            // Teken de vloer.
            // Teken de score.
        }

        private void drawScore(Graphics g)
        {
            // First draw the shadows...
            for (int i = 5; i > 0; i--)
            {
                // Create a new pen with the chosen color.
                Pen black = new Pen(Color.FromArgb(250-i*40, Color.Black));
                g.DrawString(
                    "Score : " + score, // What should be printed.
                    Font,               // Use the chosen Font (property)
                    black.Brush,        // Use the brush based on the pen.
                    30+i*1, 20+i*1              // Draw the text here.
                );
            }
            // Then draw the actual text.
            // Create a new pen with the chosen color.
            Pen pen = new Pen(ForeColor);
            g.DrawString(
                "Score : " + score, // What should be printed.
                Font,               // Use the chosen Font (property)
                pen.Brush,          // Use the brush based on the pen.
                30, 20              // Draw the text here.
            );
        }

        private void drawBird(Graphics g)
        {
            // Check if the bird should be drawn.
            if (gameOver)
            {
                // Don't draw the bird when the game is over.
                return;
            }
            //frames.drawBird(g, BirdFrames.BIRD_WHITE, 20, bird_height);
            // Create a pen to draw with.
            Pen p = new Pen(Color.Black, 3);
            // Draw a bird. :)
            //g.DrawEllipse(p,
            //    20, bird_height, // position of the circle
            //    50, 50); // Size of the circle

            g.DrawImage(
                Properties.Resources.parrot,    // This image...
                20, bird_height,                // at this location.
                parrot_frames[frame],           // But only this piece.
                GraphicsUnit.Pixel              // Make microsoft happy. :(
            );
        }

        private void FlappyBird_Load(object sender, EventArgs e)
        {
            // Which rectangle is being created.
            int index = 0;
            // Loop over all rows.
            for (int y = 0; y < 3; y++)
            {
                // Loop over all columns.
                for (int x = 0; x < 3; x++)
                {
                    // Create the rectangle for this frame.
                    parrot_frames[index] = new Rectangle(
                        x * 286, y * 264,
                        286, 264
                        );
                    // Move to the next frame position in the array.
                    index++;
                }
            }

            database.readHighScore();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // IF the game has ended.
            if (gameOver)
            {
                // THEN do nothing.
                return;
            }
            else
            {
                // Award one point every tick...
                score = score + 1;

                advanceAnimation();

                // Move the bird with the specified speed.
                bird_height = bird_height + bird_speed;

                checkGameOver();

                // Move the picturebox to the correct position. (Point)
                //picBird.Location = new Point(25, (int)bird_height);
                //            picBird.Image = // Go go zoek ergens frame 2...

                // Move the obstacles.

                // Trigger the paint event.
                Invalidate();
            }
        }

        private void checkGameOver()
        {
            if (bird_height < -80)
            {
                gameOver = true;
            }
            else if (bird_height > (Height - 150))
            {
                gameOver = true;
            }
            // @TODO: Also check obstakels!

            if (gameOver)
            {
                // Show the game over image.
                BackgroundImage = Properties.Resources.gameOver;
            }
        }

        private void advanceAnimation()
        {
            // Advance the parrot animation...
            frame = frame + 1;
            // Check if the frame is too high...
            if (frame >= parrot_frames.Length)
            {
                // Loop back.
                frame = 0;
            }
        }

        private void FlappyBird_KeyDown(object sender, KeyEventArgs e)
        {
            // Bird goes up.
            bird_speed = -(MAX_SPEED * 2);
        }

        private void FlappyBird_KeyUp(object sender, KeyEventArgs e)
        {
            // Bird starts falling again.
            bird_speed = +MAX_SPEED;
        }
    }
}
