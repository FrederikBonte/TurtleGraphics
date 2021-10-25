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

namespace FlappyTrial2
{
    public partial class FlappyViewer : UserControl
    {
        private const float DELTA = 0.7f;
        private const float BIRD_SPEED = 7;
        private const int PIPE_SPEED = -25;
        private readonly Random RNG = new Random();
        private readonly Font FONT = new Font("Ravie", 26);
        private readonly Pen PEN = new Pen(Color.DarkBlue);

        private float gravity = BIRD_SPEED;
        private float delta = DELTA;
        private int movement = PIPE_SPEED;

        private float bird_y = 200;
        private int pipe_x = 1200;
        private int gap = 300;
        private int floor_x = 0;
        private int score = 0;
        private SoundPlayer music;
        private SoundPlayer bonk;

        public FlappyViewer()
        {
            InitializeComponent();
            ResizeRedraw = true;
            music = new SoundPlayer(Properties.Resources.music);
            bonk = new SoundPlayer(Properties.Resources.bonk);
        }

        private void FlappyViewer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            drawImage(g, Properties.Resources.flappy_pipe_bottom, pipe_x, gap+100);
            drawImage(g, Properties.Resources.flappy_pipe_top, pipe_x, gap-100-Properties.Resources.flappy_pipe_top.Height);
            drawImage(g, Properties.Resources.flappy_floor, floor_x, Height - Properties.Resources.flappy_floor.Height);
            drawImage(g, Properties.Resources.flappy_floor, floor_x+Properties.Resources.flappy_floor.Width, Height - Properties.Resources.flappy_floor.Height);
            drawImage(g, Properties.Resources.flappy_bird, 100, bird_y, gravity*1.5f);

            g.DrawString("Score : " + score, FONT, PEN.Brush, 20, 20);

            if (bird_y<50 || bird_y>Height-150)
            {
                timer.Enabled = false;
            }
            if (pipe_x<100 && pipe_x>-150)
            {
                if (bird_y<gap-100 || bird_y>gap+100)
                {
                    timer.Enabled = false;
                }
            }

            if (!timer.Enabled)
            {
                music.Stop();
                drawImage(g, Properties.Resources.flappy_baf, 120, bird_y, (RNG.Next(9)-4)*5);
                bonk.Play();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gravity = clamp(-BIRD_SPEED, gravity + delta, BIRD_SPEED);
            bird_y += gravity;
            pipe_x += movement;
            floor_x += movement;
            if (floor_x+Properties.Resources.flappy_floor.Width<0)
            {
                floor_x += Properties.Resources.flappy_floor.Width;
            }

            if (pipe_x<-300)
            {
                pipe_x = Width + 20;
                gap = RNG.Next((Height * 50) / 100) + ((Height * 20) / 100);
                score++;
                movement -= (RNG.Next(100) < 2)?1:0;
            }
            this.Invalidate();
        }

        public void drawImage(Graphics g, Image image, float x, float y)
        {
            float dx = 1;
            float dy = 0;
            PointF[] points = new PointF[3];
            points[0] = new PointF(x, y);
            points[1] = new PointF(points[0].X + image.Width * dx, points[0].Y + image.Height * dy);
            points[2] = new PointF(points[0].X - image.Height * dy, points[0].Y + image.Height * dx);

            g.DrawImage(image, points);
        }

        public void drawImage(Graphics g, Image image, float x, float y, float angle)
        {
            float w2 = image.Width / 2;
            float h2 = image.Height / 2;
            float dx = 1;
            float dy = 0;
            if (angle!=0)
            {
                dx = (float)Math.Cos(angle * Math.PI / 180);
                dy = -(float)Math.Sin(angle * Math.PI / 180);
            }
            PointF[] points = new PointF[3];
            points[0] = new PointF(x - w2 * dx + dy * h2, y - w2 * dy - dx * h2);
            points[1] = new PointF(x + w2 * dx + dy * h2, y + dy * w2 - dx * h2);
            points[2] = new PointF(x - w2 * dx - dy * h2, y - w2 * dy + dx * h2);

            g.DrawImage(image, points);
        }

        private float clamp(float min, float value, float max)
        {
            if (value<min)
            {
                return min;
            } else if (value>max)
            {
                return max;
            } else
            {
                return value;
            }
        }

        private void FlappyViewer_KeyDown(object sender, KeyEventArgs e)
        {
            delta = -DELTA;
        }

        private void FlappyViewer_KeyUp(object sender, KeyEventArgs e)
        {
            delta = DELTA;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void FlappyViewer_Load(object sender, EventArgs e)
        {
            music.PlayLooping();
        }

        private void FlappyViewer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible==false)
            {
                music.Stop();
            }
        }
    }
}
