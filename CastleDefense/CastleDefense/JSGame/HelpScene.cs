using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class HelpScene : GameScene
    {
        // private Texture2D helpTex;
        public HelpScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;
            texture2D = g.Content.Load<Texture2D>("help");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture2D, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
