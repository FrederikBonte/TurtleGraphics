using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy0sv3
{
    public class BirdFrames
    {
        private const int FRAME_COUNT_X = 12;
        private const int FRAME_COUNT_Y = 8;
        private const int SIZE = 48;
        private const int CYCLE = 4;
        private const int BIRDS = 8;

        private readonly Rectangle[,] frames = new Rectangle[CYCLE, BIRDS];
        private int frame = 0;

        public const int BIRD_LIGHT_BROWN = 0;
        public const int BIRD_BROWN = 1;
        public const int BIRD_RED = 2;
        public const int BIRD_LIGHT_GREEN = 3;
        public const int BIRD_WHITE = 4;
        public const int BIRD_GREEN = 5;
        public const int BIRD_BLUE = 6;
        public const int BIRD_GRay = 7;

        public BirdFrames()
        {
            for (int i = 0; i < 24; i++)
            {
                int bird = i / 3;
                int frame_x = i % 3;
                frames[frame_x, bird] = getRectangle(i % 12, 2 + (i / 12) * 4);
            }
            for (int i = 0; i < 8; i++)
            {
                frames[3, i] = frames[1, i];
            }
        }

        private Rectangle getRectangle(int fx, int fy)
        {
            return new Rectangle(fx * SIZE, fy * SIZE, SIZE, SIZE);
        }

        public void nextFrame()
        {
            frame = frame + 1;
            if (frame >= CYCLE)
            {
                frame = 0;
            }

        }

        private Rectangle getFrame(int bird)
        {
            return frames[frame, bird];
        }

        public void drawBird(Graphics g, int bird, float x, float y)
        {
            g.DrawImage(
                Properties.Resources.birds, // Use the bird image.
                x, y, // Place the image here.
                getFrame(bird), // Retrieve the correct rectangle.
                GraphicsUnit.Pixel // #(&#$!! Micro$oft... :(
            );

        }
    }
}
