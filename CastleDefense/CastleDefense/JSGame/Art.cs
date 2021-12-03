using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    static class Art
    {
		public static Texture2D Archer { get; private set; }
		public static Texture2D Arrow { get; private set; }

		public static Texture2D Castle1 { get; private set; }
		public static Texture2D Castle2 { get; private set; }
		public static Texture2D Castle3 { get; private set; }
		public static Texture2D Castle1Destroyed { get; private set; }
		public static Texture2D Castle2Destroyed { get; private set; }
		public static Texture2D Castle3Destroyed { get; private set; }

		public static Texture2D Wolf { get; private set; }
		public static Texture2D RedBat { get; private set; }
		public static Texture2D Samurai { get; private set; }
		public static Texture2D NormalZombie { get; private set; }
		public static Texture2D MadZombie { get; private set; }

		public static Texture2D Background1 { get; private set; }
		public static Texture2D Background2 { get; private set; }
		public static Texture2D Background3 { get; private set; }
		public static Texture2D Background4 { get; private set; }
		public static Texture2D Background5 { get; private set; }
		public static Texture2D Background6 { get; private set; }
		public static Texture2D Background7 { get; private set; }
		public static Texture2D Background8 { get; private set; }
		public static Texture2D Background9 { get; private set; }

		public static SpriteFont RegularFont { get; private set; }
		public static SpriteFont HilightFont { get; private set; }

		public static void Load(ContentManager content)
		{
			Archer = content.Load<Texture2D>("images/Archer");
			Arrow = content.Load<Texture2D>("images/Arrow");

			Castle1 = content.Load<Texture2D>("images/Castle/Castle1");
			Castle2 = content.Load<Texture2D>("images/Castle/Castle2");
			Castle3 = content.Load<Texture2D>("images/Castle/Castle3");
			Castle1Destroyed = content.Load<Texture2D>("images/Castle/Castle1Destroyed");
			Castle2Destroyed = content.Load<Texture2D>("images/Castle/Castle2Destroyed");
			Castle3Destroyed = content.Load<Texture2D>("images/Castle/Castle3Destroyed");

			Wolf = content.Load<Texture2D>("images/Enemy/Wolf");
			RedBat = content.Load<Texture2D>("images/Enemy/RedBat");
			Samurai = content.Load<Texture2D>("images/Enemy/Samurai");
			NormalZombie = content.Load<Texture2D>("images/Enemy/NormalZombie");
			MadZombie = content.Load<Texture2D>("images/Enemy/MadZombie");

			Background1 = content.Load<Texture2D>("images/Background/Background1");
			Background2 = content.Load<Texture2D>("images/Background/Background2");
			Background3 = content.Load<Texture2D>("images/Background/Background3");
			Background4 = content.Load<Texture2D>("images/Background/Background4");
			Background5 = content.Load<Texture2D>("images/Background/Background5");
			Background6 = content.Load<Texture2D>("images/Background/Background6");
			Background7 = content.Load<Texture2D>("images/Background/Background7");
			Background8 = content.Load<Texture2D>("images/Background/Background8");
			Background9 = content.Load<Texture2D>("images/Background/Background9");

			RegularFont = content.Load<SpriteFont>("fonts/regularFont");
			HilightFont = content.Load<SpriteFont>("fonts/hilightFont");
		}
	}
}
