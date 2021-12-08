using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace CastleDefense
{
    static class Sound
    {
        public static Song Music { get; private set; }
		public static SoundEffect ArrowShootSoundEffect { get; private set; }
		public static SoundEffect ExplosionSoundEffect { get; private set; }

		public static void Load(ContentManager content)
		{
			Music = content.Load<Song>("songs/Song");

			ArrowShootSoundEffect = content.Load<SoundEffect>("sounds/Shoot");
			ExplosionSoundEffect = content.Load<SoundEffect>("sounds/Explosion");
		}
	}
}
