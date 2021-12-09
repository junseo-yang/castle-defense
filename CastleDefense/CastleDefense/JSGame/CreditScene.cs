using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CastleDefense
{
    public class CreditScene : GameScene
    {
        public CreditScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            DrawRightAlignedString(titleFont, "Castle Defense", 50f);
            DrawRightAlignedString(regularFont, "Credit", 150f);
            DrawRightAlignedString(regularFont, "Press ESC to quit.", 180f);
            DrawRightAlignedString(scoreFont, "Game Creator: Junseo Yang ", 250f);
            DrawRightAlignedString(scoreFont, "Learning Course: PROG2370 - Game Programming with Data Structures", 300f);
            DrawRightAlignedString(scoreFont, "Professor: Sabbir Ahmed", 350f);
            DrawRightAlignedString(scoreFont, "Background Music: Eldon - Pink cheeks", 400f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
