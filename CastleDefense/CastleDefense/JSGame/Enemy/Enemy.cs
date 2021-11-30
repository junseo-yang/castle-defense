using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class Enemy : DrawableGameComponent
    {
        /* Declare variables for Draw*/
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private float scale = 0.2f;


        /* Animation */
        // dimension of a frame
        private Vector2 dimension;
        // list of srcRect
        private Rectangle[,] frames;
        // draw frame index, list has indexer
        public int frameIndexRow = -1;
        private int frameIndexCol = -1;

        // fixed delay
        private int delay = 3;
        // fluctulating value
        private int delayCounter;

        private const int ROW = 5;
        private const int COL = 8;

        enum State
        {
            Idle,
            Move,
            Attack,
            Hurt,
            Die
        }

        public Enemy(Game game,
            Texture2D tex
            ) : base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g._spriteBatch;
            this.tex = tex;

            Random r = new Random();
            this.position = new Vector2(0, r.Next(0, 200));


            // Calculation
            this.dimension = new Vector2(tex.Width / COL, tex.Height / ROW);

            CreateFrames();
        }

        private void CreateFrames()
        {
            frames = new Rectangle[ROW, COL];
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int x = (int)(j * dimension.X);
                    int y = (int)(i * dimension.Y);
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames[i, j] = r;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // Safety Condition
            if (frameIndexRow >= 0)
            {
                if (frameIndexCol >= 0)
                {
                    spriteBatch.Draw(tex, position, frames[frameIndexRow, frameIndexCol], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                }
                else
                {
                    spriteBatch.Draw(tex, position, frames[frameIndexRow, 0], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0);
                }
            }
            else
            {
                // spriteBatch.Draw(tex, position, frames[(int)Direction.Up, 0], Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            // Get Castle's x value
            if (position.X < Shared.stage.X - 500)
            {
                frameIndexRow = (int)State.Move;
                position.X += 1;
            }
            if (position.X >= Shared.stage.X - 500)
            {
                frameIndexRow = (int)State.Idle;
            }

            // Increase delayCounter
            delayCounter++;
            // If delaycounter is greater than delay, then frameIndex++
            if (delayCounter > delay)
            {
                frameIndexCol++;

                // 12.4.	Prevent frameIndex increases beyond  maximum value, Initilaize, Hide
                if (frameIndexCol >= COL)
                {
                    frameIndexCol = 0;
                }

                delayCounter = 0;
            }

            base.Update(gameTime);
        }
    }
}
