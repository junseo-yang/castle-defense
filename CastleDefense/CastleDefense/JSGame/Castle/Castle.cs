using System;
using System.Collections.Generic;
using System.Text;
using CastleDefense;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class Castle : JSDrawableGameComponent
    {
        private Texture2D texCastleDestoryed;

        public Castle(Game game) : base(game)
        {
            int castleNumber = random.Next(1, 3);

            Game1 g = (Game1)game;
            
            spriteBatch = g._spriteBatch;

            texture2D = g.Content.Load<Texture2D>("images/Castle/Castle" + castleNumber);
            texCastleDestoryed = g.Content.Load<Texture2D>("images/Castle/Castle" + castleNumber + "Destoryed");

            position = new Vector2(Shared.stage.X- texture2D.Width + 100, Shared.stage.Y - texture2D.Height - 20);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture2D, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
