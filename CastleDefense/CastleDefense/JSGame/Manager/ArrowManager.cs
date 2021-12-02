using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    public class ArrowManager : JSDrawableGameComponent
    {
        Archer archer;
        public List<Arrow> Arrows { get; set; }

        MouseState oldMouseState;

        Game1 g;

        public ArrowManager(Game game,
            Archer archer) : base(game)
        {
            g = (Game1)game;

            Arrows = new List<Arrow>();

            this.archer = archer;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            float xDiff = ms.X - archer.position.X;
            float yDiff = ms.Y - archer.position.Y;
            if (xDiff < 0)
            {
                if (ms.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed)
                {
                    Vector2 speed = new Vector2(xDiff * 0.02f, yDiff * 0.02f);
                    float rotation = (float)Math.Atan(yDiff / xDiff);
                    Arrow arrow = new Arrow(g, rotation, speed);
                    Arrows.Add(arrow);
                    // arrowSound.Play();
                }
            }

            oldMouseState = ms;

            base.Update(gameTime);
        }
    }
}
