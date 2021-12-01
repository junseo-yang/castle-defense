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

        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            spriteBatch = g._spriteBatch;

            arrowSound = g.Content.Load<SoundEffect>("sounds/shoot");

            Castle castle = new Castle(game);
            this.SceneComponents.Add(castle);

            Archer archer = new Archer(game);            
            this.SceneComponents.Add(archer);

            EnemyGenerator enemyGenerator = new EnemyGenerator(game);
            this.SceneComponents.Add(enemyGenerator);
            foreach (var item in enemyGenerator.Enemies)
            {
                this.SceneComponents.Add(item);
            }
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
