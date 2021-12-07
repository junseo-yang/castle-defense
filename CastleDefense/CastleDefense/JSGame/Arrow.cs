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

        public void WasShot()
        {
            IsExpired = true;
        }
    }
}
