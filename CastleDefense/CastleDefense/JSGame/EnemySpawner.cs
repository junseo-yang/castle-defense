using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    static class EnemySpawner
    {
        static Random rand = new Random();
        static float inverseSpawnChance = 90;
        static float inverseBlackHoleChance = 600;

		public static void Update()
		{
			if (!Archer.Instance.IsDead && EntityManager.Count < 200)
			{
                if (rand.Next((int)inverseSpawnChance) == 0)
                    EntityManager.Add(Enemy.CreateRandomEnemy(GetSpawnPosition()));
            }

			// slowly increase the spawn rate as time progresses
			if (inverseSpawnChance > 30)
				inverseSpawnChance -= 0.005f;
		}

		private static Vector2 GetSpawnPosition()
		{
			Vector2 pos = new Vector2(0, rand.Next(300, 500));
			//do
			//{
			//	pos = new Vector2(0 , rand.Next(0, (int)Shared.stage.Y));
			//}
			//while (Vector2.DistanceSquared(pos, Archer.Instance.Position) < 250 * 250);

			return pos;
		}

		public static void Reset()
		{
			inverseSpawnChance = 90;
		}
	}
}
