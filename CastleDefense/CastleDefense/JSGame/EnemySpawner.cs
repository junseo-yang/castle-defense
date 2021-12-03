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
			if (!PlayerShip.Instance.IsDead && EntityManager.Count < 200)
			{
				if (rand.Next((int)inverseSpawnChance) == 0)
					EntityManager.Add(Enemy.CreateSeeker(GetSpawnPosition()));

				if (rand.Next((int)inverseSpawnChance) == 0)
					EntityManager.Add(Enemy.CreateWanderer(GetSpawnPosition()));

				if (EntityManager.BlackHoleCount < 2 && rand.Next((int)inverseBlackHoleChance) == 0)
					EntityManager.Add(new BlackHole(GetSpawnPosition()));
			}

			// slowly increase the spawn rate as time progresses
			if (inverseSpawnChance > 30)
				inverseSpawnChance -= 0.005f;
		}
	}
}
