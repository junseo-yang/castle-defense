using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public abstract class GameScene : DrawableGameComponent
    {
        public SpriteBatch spriteBatch;
        public Texture2D texture2D;

        public SpriteFont titleFont = Font.TitleFont;
        public SpriteFont regularFont = Font.RegularFont;
        public SpriteFont hilightFont = Font.HilightFont;
        public SpriteFont scoreFont = Font.ScoreFont;

        public List<GameComponent> SceneComponents { get; set; }

        public virtual void show()
        {
            this.Visible = true;
            this.Enabled = true;
        }
        public virtual void hide()
        {
            this.Visible = false;
            this.Enabled = false;
        }

        public GameScene(Game game) : base(game)
        {
            SceneComponents = new List<GameComponent>();
            hide();
        }
        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in SceneComponents)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in SceneComponents)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        public void DrawRightAlignedString(SpriteFont spriteFont, string text, float y)
        {
            var textWidth = spriteFont.MeasureString(text).X;
            spriteBatch.DrawString(spriteFont, text, new Vector2((Shared.stage.X - textWidth) / 2, y), Color.Black);
        }
    }
}
