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
        private Texture2D helpScene1;
        private Texture2D helpScene2;

        public HelpScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;

            helpScene1 = Art.HelpScene1;
            helpScene2 = Art.HelpScene2;
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 pos = new Vector2((Shared.stage.X / 2) - (helpScene1.Width + helpScene2.Width) / 2, Shared.stage.Y - helpScene1.Height);

            spriteBatch.Begin();
            DrawRightAlignedString(titleFont, "Castle Defense", 50f);
            spriteBatch.Draw(helpScene1, pos, Color.White);
            spriteBatch.Draw(helpScene2, new Vector2(pos.X + helpScene1.Width, pos.Y), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
