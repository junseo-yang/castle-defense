using System;
using System.Collections.Generic;
using System.Text;
using CastleDefense;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    public class EnemyManager : JSDrawableGameComponent
    {
        public List<Enemy> Enemies { get; set; }

        private Random r;

        public EnemyManager(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            Enemies = new List<Enemy>();

            /* Enemy */
            Texture2D texEnemy1 = g.Content.Load<Texture2D>("images/Enemy/01Wolf");
            Enemy e1 = new Enemy(game, texEnemy1);
            Enemies.Add(e1);

            Texture2D texEnemy2 = g.Content.Load<Texture2D>("images/Enemy/02RedBat");
            Enemy e2 = new Enemy(game, texEnemy2);
            Enemies.Add(e2);
        }

        public void CreateEnemies()
        {

        }
    }
}
