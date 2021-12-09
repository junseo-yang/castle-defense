using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    class Bomb : Entity
    {
        /* Animation */
        // dimension of a frame
        private Vector2 dimension;
        // list of srcRect
        private Rectangle[] frames;
        // draw frame index, list has indexer
        private int frameIndexCol = 0;

        // fixed delay
        private int delay = 1;
        // fluctulating value
        private int delayCounter;

        private const int ROW = 5;
        private const int COL = 5;

        public Bomb(Vector2 position)
        {
            // Generate Random Enemy by Level
            image = Art.Bomb;
            Position = position;
            color = Color.White;

            // Calculation
            this.dimension = new Vector2(image.Width / COL, image.Height / ROW);

            Origin = new Vector2(dimension.X / 2, dimension.Y / 2);

            CreateFrames();
        }

        private void CreateFrames()
        {
            frames = new Rectangle[ROW * COL];
            for (int i = 0, k = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++, k++)
                {
                    int x = (int)(j * dimension.X);
                    int y = (int)(i * dimension.Y);
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames[k] = r;
                }
            }
        }

        public override void Update()
        {
            // Increase delayCounter
            delayCounter++;
            // If delaycounter is greater than delay, then frameIndex++
            if (delayCounter > delay)
            {
                frameIndexCol++;

                // Prevent frameIndex increases beyond  maximum value, Initilaize, Hide
                if (frameIndexCol >= COL * ROW)
                {
                    IsExpired = true;
                }

                delayCounter = 0;
            }

            if (frameIndexCol < COL * ROW)
            {
                srcRectangle = frames[frameIndexCol];
            }
        }

        public void WasDone()
        {
            IsExpired = true;
        }
    }
}
