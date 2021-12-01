using System;
using System.Collections.Generic;
using System.Text;
using CastleDefense;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class EnemyGenerator : GameComponent
    {
        public List<Enemy> Enemies { get; set; }
        public int Level { get; set; }
        public int NumberOfEnemies { get; set; }

        private Random r;

        public EnemyGenerator(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            /* Enemy */
            Texture2D texEnemy1 = g.Content.Load<Texture2D>("images/Enemy/01Wolf");
            Enemy e1 = new Enemy(game, texEnemy1);


            Texture2D texEnemy2 = g.Content.Load<Texture2D>("images/Enemy/02RedBat");
            Enemy e2 = new Enemy(game, texEnemy2);

            Enemies = new List<Enemy>();

            Enemies.Add(e2);
            Enemies.Add(e1);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed)
            {
                Dispose();
            }

            base.Update(gameTime);
        }
    }
}
