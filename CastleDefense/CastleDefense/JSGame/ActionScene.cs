using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using CastleDefense;

namespace CastleDefense
{
    public class ActionScene : GameScene
    {
        private SoundEffect arrowSound;

        bool paused = false;

        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;

            arrowSound = g.Content.Load<SoundEffect>("sounds/shoot");

            EntityManager.Add(Castle.Instance);
            EntityManager.Add(Archer.Instance);
        }

        public override void Update(GameTime gameTime)
        {
            if (!paused)
            {
                // PlayerStatus.Update();
                EntityManager.Update();
                EnemySpawner.Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            EntityManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
