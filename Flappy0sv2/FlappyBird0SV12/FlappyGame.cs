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

namespace FlappyBird0SV12
{
    public partial class FlappyGame : UserControl
    {
        const float MAX_SPEED = 5;
        const float OBS_SPEED = 15;

        float bird_y = 150;
        float bird_speed = MAX_SPEED; // + is down... - is up...

        float obstacle_x = 1000;

        SoundPlayer musicPlayer;
        //FlappyDB database;

        // Store the frame rectangles.
        Rectangle[] parrot_frames = new Rectangle[9];
        // Store which frame is being shown.
        int frame_i = 0;

        int score = 0;

        public FlappyGame()
        {
            InitializeComponent();
        }

        private void FlappyGame_Load(object sender, EventArgs e)
        {
            // store the array index
            int index = 0;
            // Loop over the three rows.
            for (int y = 0; y < 3; y++)
            {
                // Loop over the three columns.
                for (int x = 0; x < 3; x++)
                {
                    // Calculate the next frame.
                    parrot_frames[index] = new Rectangle(
                        x*286, y*264,
                        286, 264
                        );
                    // Move to the next frame.
                    index++;
                }
            }


            musicPlayer = new SoundPlayer(Properties.Resources.music);
                musicPlayer.PlayLooping();

            //database = new FlappyDB();
            //database.init();
            //database.readHighScore();
        }

        private void FlappyGame_Paint(object sender, PaintEventArgs e)
        {
            // Store the graphics environment.
            Graphics g = e.Graphics;
            if (timer.Enabled)
            {
                // Toon de score
                drawScore(g);
                // Draw obstacles (make them move left.)
                drawObstacles(g);
                // Draw a bird
                drawBird(g);
            }
            // Draw the floor
            // Detect botsing
            // Geluid!
        }

        private void drawObstacles(Graphics g)
        {
            g.DrawImage(
                Properties.Resources.top,
                obstacle_x, -300
                );

            g.DrawImage(
                Properties.Resources.bottom,
                obstacle_x, Height+300-Properties.Resources.bottom.Height
                );
        }

        private void drawScore(Graphics g)
        {
            // Store the score message.
            string text = "Score : " + score;

            // Draw the shadows first.
            for (int i = 5; i > 0; i--)
            {
                // Create a pen to draw with.
                Pen black = new Pen(Color.FromArgb(250-(i*40), Color.Black));
                // Draw the score on the screen.
                g.DrawString(
                    text,       // The text to show.
                    Font,       // Choose the font of the control.
                    black.Brush,  // Use a brush based on the pen.
                    30+i, 20+i      // Draw the text here.
                    );

            }

            // Create a pen to draw with.
            Pen pen = new Pen(ForeColor);
            // Draw the score on the screen.
            g.DrawString(
                text,       // The text to show.
                Font,       // Choose the font of the control.
                pen.Brush,  // Use a brush based on the pen.
                30, 20       // Draw the text here.
                );

        }

        private void drawBird(Graphics g)
        {
            //// Create a black pen
            //Pen p = new Pen(Color.Black, 3);

            //// Draw something...
            //g.DrawEllipse(
            //    p,              // Use the black pen.
            //    20, bird_y,     // Draw at this position.
            //    70, 50          // Bird is this big.
            //);

            // Draw the parrot image.
            g.DrawImage(
                Properties.Resources.parrot,    // Use the parrot image.
                20, bird_y,                     // Draw at this position.
                parrot_frames[frame_i],
                GraphicsUnit.Pixel              // Fu Micro$oft
                );

            //g.DrawImage(
            //    bitmap_frames[frame_i],
            //    20, bird_y
            //    );
        }

        private void FlappyGame_KeyDown(object sender, KeyEventArgs e)
        {
            // Make the bird go up.
            bird_speed = -MAX_SPEED;
        }

        private void FlappyGame_KeyUp(object sender, KeyEventArgs e)
        {
            // Make the bird fall again.
            bird_speed = +MAX_SPEED;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Award one point per tick.
            score = score + 1;

            // Make the bird move down (or up).
            bird_y = bird_y + bird_speed;

            advanceObstacles();

            // Move to the next animation frame.
            advanceFrame();

            // Check if the bird hit anything...
            checkGameOver();

            // Trigger the paint event.
            Invalidate();
        }

        private void advanceObstacles()
        {
            // Move the obstacles
            obstacle_x = obstacle_x - OBS_SPEED;
            if (obstacle_x < -175)
            {
                // @TODO: Also choose a random height!
                obstacle_x = Width;
            }
        }

        private void checkGameOver()
        {
            // Check bovenkant
            if (bird_y<-80)
            {
                timer.Enabled = false;
            }
            // Check onderkant
            else if (bird_y>(Height-180))
            {
                timer.Enabled = false;
            }
            // Check obstakels

            // Toon game over scherm.
            if (timer.Enabled==false)
            {
                BackgroundImage = Properties.Resources.gameover;
                musicPlayer.Stop();
                // @TODO: Iets met reset of zo...
            }
        }

        private void advanceFrame()
        {
            // Move to the next frame.
            frame_i = frame_i + 1;
            // Check if the end of the animation has been reached.
            if (frame_i >= parrot_frames.Length)
            {
                // Loop back to the start of the animation.
                frame_i = 0;
            }
        }

        private void FlappyGame_Leave(object sender, EventArgs e)
        {
            musicPlayer.Stop();
        }
    }
}
