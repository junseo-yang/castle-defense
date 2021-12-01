using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class JSDrawableGameComponent : DrawableGameComponent
    {
        public SpriteBatch spriteBatch;
        public Texture2D texture2D;
        public Rectangle srcRect;
        public Vector2 position;
        public Vector2 origin;
        public Vector2 speed;
        public float rotation = 0f;
        public float scale = 1.0f;
        public float layerDepth;

        public Random random = new Random();

        public JSDrawableGameComponent(Game game) : base(game)
        {
        }

        public virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;
        }
        public virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;
        }
    }
}
