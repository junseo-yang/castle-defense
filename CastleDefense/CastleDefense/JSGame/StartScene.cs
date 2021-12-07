using System;
using System.Collections.Generic;
using System.Text;
using CastleDefense;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class StartScene : GameScene
    {
        private MenuComponent menu;
        public MenuComponent Menu { get => menu; set => menu = value; }

        string[] menuItems = { "Start game", "Load Game", "Help", "High Score", "Credit", "Quit" };

        SpriteFont regularFont;
        SpriteFont hilightFont;
        SpriteFont titleFont;

        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            spriteBatch = g._spriteBatch;

            regularFont = Art.RegularFont;
            hilightFont = Art.HilightFont;
            titleFont = Art.TitleFont;

            menu = new MenuComponent(g, spriteBatch, regularFont, hilightFont, menuItems);
            this.SceneComponents.Add(menu);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // spriteBatch.DrawString(titleFont, "Castle Defense", Shared.stage / 2, Color.Black, 0f, );
            DrawRightAlignedString(titleFont, "Castle Defense", 50f);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawRightAlignedString(SpriteFont spriteFont, string text, float y)
        {
            var textWidth = spriteFont.MeasureString(text).X;
            spriteBatch.DrawString(spriteFont, text, new Vector2((Shared.stage.X - textWidth) / 2, y), Color.Black);
        }
    }
}
