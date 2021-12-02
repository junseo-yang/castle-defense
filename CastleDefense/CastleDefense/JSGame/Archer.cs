using System;
using System.Collections.Generic;
using System.Text;
using CastleDefense;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CastleDefense
{
    public class Archer : JSDrawableGameComponent
    {
        /* Animation */
        // dimension of a frame
        private Vector2 dimension;
        // list of srcRect
        private Rectangle[] frames;
        // draw frame index, list has indexer
        public int frameIndex = -1;

        // fixed delay
        private int delay = 5;
        // fluctulating value
        private int delayCounter;

        private const int COL = 13;

        private MouseState oldMouseState;

        public Archer(Game game): base(game)
        {
            Game1 g = (Game1)game;

            spriteBatch = g._spriteBatch;

            texture2D = g.Content.Load<Texture2D>("images/Archer");

            position = new Vector2(990, 365);

            origin = new Vector2((texture2D.Width / COL) / 2, texture2D.Height / 2);

            CreateFrames();
        }

        private void CreateFrames()
        {
            frames = new Rectangle[COL];
            for (int i = 0; i < COL; i++)
            {
                frames[i] = new Rectangle(i * (texture2D.Width / COL), 0, texture2D.Width / COL, texture2D.Height);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (frameIndex > 0)
            {
                spriteBatch.Draw(texture2D, position, frames[frameIndex], Color.White, rotation, origin, scale, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(texture2D, position, frames[0], Color.White, rotation, origin, scale, SpriteEffects.None, 0);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed)
            {
                if (frameIndex < 8)
                {
                    if (delayCounter >= delay)
                    {
                        frameIndex++;
                        delayCounter = 0;
                    }
                    delayCounter++;
                }
            }
            if (ms.LeftButton == ButtonState.Released)
            {
                if (frameIndex >= 8)
                {
                    if (delayCounter >= delay)
                    {
                        frameIndex++;
                        delayCounter = 0;
                    }
                    delayCounter++;
                    if (frameIndex >= COL)
                    {
                        frameIndex = -1;
                    }
                }
            }
            // Cancel
            if (frameIndex < 8 && ms.LeftButton == ButtonState.Released)
            {
                frameIndex = -1;
            }

            base.Update(gameTime);
        }
    }


}
