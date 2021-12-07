using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CastleDefense
{
    class Enemy : Entity
    {
        /* Animation */
        // dimension of a frame
        private Vector2 dimension;
        // list of srcRect
        private Rectangle[,] frames;
        // draw frame index, list has indexer
        public int frameIndexRow = -1;
        private int frameIndexCol = -1;

        // fixed delay
        private int delay = 4;
        // fluctulating value
        private int delayCounter;

        private const int ROW = 5;
        private const int COL = 8;

        /* Enemey Image List */
        public List<Texture2D> EnemyImageList = new List<Texture2D> { Art.RedBat, Art.Samurai, Art.NormalZombie, Art.MadZombie, };

        private Random rand = new Random();

        private int timeUntilStart = 90;
        public bool IsActive { get { return timeUntilStart <= 0; } }
        public int PointValue { get; private set; }
        public int EnemyState { get; set; }

        enum State
        {
            Idle,
            Move,
            Attack,
            Hurt,
            Die
        }

        public Enemy(Vector2 position)
        {
            // Generate Random Enemy by Level
            image = EnemyImageList[rand.Next(0, ActionScene.Level) % EnemyImageList.Count];
            Position = position;
            //Radius = image.Width / 2f;
            color = Color.White;
            PointValue = 1;

            // Calculation
            this.dimension = new Vector2(image.Width / COL, image.Height / ROW);

            Origin = new Vector2(dimension.X / 2, dimension.Y / 2);

            CreateFrames();
        }

        public static Enemy CreateRandomEnemy(Vector2 position)
        {
            var enemy = new Enemy(position);
            enemy.PointValue = 2;
            return enemy;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (timeUntilStart < 0)
            {
                // Safety Condition
                if (frameIndexRow >= 0)
                {
                    if (frameIndexCol >= 0)
                    {
                        spriteBatch.Draw(image, Position, frames[frameIndexRow, frameIndexCol], Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
                    }
                    else
                    {
                        spriteBatch.Draw(image, Position, frames[frameIndexRow, 0], Color.White, 0f, Origin, 1f, SpriteEffects.None, 0);
                    }
                }
                else
                {
                    // spriteBatch.Draw(tex, position, frames[(int)Direction.Up, 0], Color.White);
                }
            }

            // base.Draw(spriteBatch);
        }

        public override void Update()
        {
            if (timeUntilStart < 0)
            {
                // Get Castle's x value
                if (Position.X < Shared.stage.X - 500 && frameIndexRow != (int)State.Move)
                {
                    ChangeState(State.Move);
                }
                //if (Position.X >= Shared.stage.X - 500)
                //{
                //    ChangeState(State.Idle);
                //}

                // Increase delayCounter
                delayCounter++;
                // If delaycounter is greater than delay, then frameIndex++
                if (delayCounter > delay)
                {
                    frameIndexCol++;

                    // 12.4.	Prevent frameIndex increases beyond  maximum value, Initilaize, Hide
                    if (frameIndexCol >= COL)
                    {
                        frameIndexCol = -1;
                    }

                    delayCounter = 0;
                }

                Position += Velocity;
            }
            else
            {
                timeUntilStart--;
            }            

            // srcRectangle = frames[frameIndexRow, frameIndexCol];
        }        

        private void ChangeState(State state)
        {
            frameIndexRow = (int)state;
            if (state == State.Move)
            {
                Velocity = new Vector2(rand.Next(1, ActionScene.Level), 0);
            }
            else
            {
                Velocity = Vector2.Zero;
            }
        }

        public void HandleCollision(Enemy other)
        {
            var d = Position - other.Position;
            Velocity += 10 * d / (d.LengthSquared() + 1);
        }

        public void WasShot()
        {
            IsExpired = true;
        }
    }
}
