using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    class Arrow : Entity
    {
        public int ArrowSpeed { get; set; } = 1;

        public Arrow(Vector2 position, Vector2 velocity)
        {
            image = Art.Arrow;
            Position = position;
            // Velocity = velocity * ArrowSpeed;
            Velocity = velocity * 10;
            Orientation = Velocity.ToAngle();
            Radius = image.Width / 2;
        }

        public override void Update()
        {
            if (Velocity.LengthSquared() > 0)
                Orientation = Velocity.ToAngle();

            Position += Velocity;

            // delete bullets that go off-screen
            if (Position.X < Vector2.Zero.X || Position.Y < Vector2.Zero.Y || Position.X > Shared.stage.X || Position.Y > Shared.stage.Y)
            {
                IsExpired = true;
            }
        }

        //public Arrow(Game game,
        //    float rotation,
        //    Vector2 speed) : base(game)
        //{
        //    Game1 g = (Game1)game;

        //    spriteBatch = g._spriteBatch;
        //    texture2D = g.Content.Load<Texture2D>("images/Arrow");
        //    this.speed = speed;
        //    position = new Vector2(990, 365);
        //    this.rotation = rotation;
        //    origin = new Vector2(texture2D.Width / 2, texture2D.Height / 2);
        //    srcRect = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
        //    // rotation
        //    // scale = 1.0f;
        //}

        //public override void Draw(GameTime gameTime)
        //{
        //    spriteBatch.Begin();
        //    spriteBatch.Draw(texture2D, position, srcRect, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
        //    spriteBatch.End();

        //    base.Draw(gameTime);
        //}

        //public override void Update(GameTime gameTime)
        //{
        //    position += speed;
        //    //top wall
        //    if (position.Y <= 0)
        //    {
        //        this.Enabled = false;
        //        this.Visible = false;
        //    }
        //    //down wall
        //    if (position.Y >= Shared.stage.Y)
        //    {
        //        this.Enabled = false;
        //        this.Visible = false;
        //    }
        //    //left wall
        //    if (position.X <= 0)
        //    {
        //        this.Enabled = false;
        //        this.Visible = false;
        //    }

        //    if (timeCounter >= existTime)
        //    {
        //        this.Enabled = false;
        //        this.Visible = false;
        //    }
        //    timeCounter++;


        //    base.Update(gameTime);
        //}
    }
}
