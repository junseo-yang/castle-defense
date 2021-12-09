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

        string[] menuItems = { "Start new game", "Load Game", "Help", "High Score", "Credit", "Quit" };

        SpriteFont regularFont;
        SpriteFont hilightFont;
        SpriteFont titleFont;

        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            spriteBatch = g._spriteBatch;

            regularFont = Font.RegularFont;
            hilightFont = Font.HilightFont;
            titleFont = Font.TitleFont;

            menu = new MenuComponent(g, spriteBatch, regularFont, hilightFont, menuItems);
            this.SceneComponents.Add(menu);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            DrawRightAlignedString(titleFont, "Castle Defense", 50f);
            DrawRightAlignedString(hilightFont, "Welcome, " + Game1.PlayerName + ". Select a menu by using arrow keys and hit enter.", 200f);
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
