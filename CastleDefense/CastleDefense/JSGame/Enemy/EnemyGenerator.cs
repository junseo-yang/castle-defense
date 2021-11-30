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
            
        }
    }
}
