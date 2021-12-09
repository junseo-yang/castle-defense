using System;
using System.Collections.Generic;
using System.Text;
using CastleDefense;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, hilightFont;
        private string[] menuItems;

        public int SelectedIndex { get; set; }
        private Vector2 position;

        private KeyboardState oldState;

        public MenuComponent(Game game,
           SpriteBatch spriteBatch,
           SpriteFont regularFont,
           SpriteFont hilightFont,
           string[] menuItems) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.hilightFont = hilightFont;
            this.menuItems = menuItems;
            position = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                SelectedIndex++;
                if (SelectedIndex == menuItems.Length)
                {
                    SelectedIndex = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Length - 1;
                }
            }

            oldState = ks;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            spriteBatch.Begin();
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (SelectedIndex == i)
                {
                    DrawRightAlignedString(hilightFont, menuItems[i], tempPos.Y);
                    tempPos.Y += hilightFont.LineSpacing;
                }
                else
                {
                    DrawRightAlignedString(regularFont, menuItems[i], tempPos.Y);
                    tempPos.Y += regularFont.LineSpacing;
                }
            }

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
