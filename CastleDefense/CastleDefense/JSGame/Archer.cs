using System;
using System.Collections.Generic;
using System.Text;
using CastleDefense;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CastleDefense
{
    class Archer : Entity
    {
        private static Archer instance;
        public static Archer Instance
        {
            get
            {
                if (instance == null)
                    instance = new Archer();

                return instance;
            }
        }

        int framesUntilRespawn = 0;
        public bool IsDead { get { return framesUntilRespawn > 0; } }

        /* Animation */
        // list of srcRect
        private Rectangle[] frames;
        // draw frame index, list has indexer
        public int frameIndex = 0;

        // fixed delay
        private int delay = 5;
        // fluctulating value
        private int delayCounter;

        private const int COL = 13;

        private bool reload = false;

        private Archer()
        {
            image = Art.Archer;
            CreateFrames();
            Position = new Vector2(1360, 390);
        }

        private void CreateFrames()
        {
            frames = new Rectangle[COL];
            for (int i = 0; i < COL; i++)
            {
                frames[i] = new Rectangle(i * (image.Width / COL), 0, image.Width / COL, image.Height);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
                base.Draw(spriteBatch);
        }

        public override void Update()
        {
            MouseState ms = Mouse.GetState();

            if (!reload)
            {
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
                    // Cancel
                    if (frameIndex < 8)
                    {
                        frameIndex = 0;
                    }
                    // Reload
                    else
                    {
                        reload = true;
                    }
                }
            }
            else
            {
                if (delayCounter >= delay)
                {
                    frameIndex++;
                    delayCounter = 0;
                }
                delayCounter++;
                if (frameIndex >= COL)
                {
                    frameIndex = 0;
                    reload = false;
                }
            }

            srcRectangle = frames[frameIndex];
        }
    }


}
