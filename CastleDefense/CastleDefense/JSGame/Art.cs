using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CastleDefense
{
    static class Art
    {
		public static Texture2D Archer { get; private set; }
		public static Texture2D Arrow { get; private set; }

		public static Texture2D Bomb { get; private set; }

		public static Texture2D Castle1 { get; private set; }
		public static Texture2D Castle2 { get; private set; }
		public static Texture2D Castle3 { get; private set; }
		public static Texture2D Castle1Destroyed { get; private set; }
		public static Texture2D Castle2Destroyed { get; private set; }
		public static Texture2D Castle3Destroyed { get; private set; }

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

		public static Texture2D HelpScene1 { get; private set; }
		public static Texture2D HelpScene2 { get; private set; }

		public static void Load(ContentManager content)
		{
			Archer = content.Load<Texture2D>("images/Archer");
			Arrow = content.Load<Texture2D>("images/Arrow");

			Bomb = content.Load<Texture2D>("images/Bomb");

			Castle1 = content.Load<Texture2D>("images/Castle/Castle1");
			Castle2 = content.Load<Texture2D>("images/Castle/Castle2");
			Castle3 = content.Load<Texture2D>("images/Castle/Castle3");
			Castle1Destroyed = content.Load<Texture2D>("images/Castle/Castle1Destoryed");
			Castle2Destroyed = content.Load<Texture2D>("images/Castle/Castle2Destoryed");
			Castle3Destroyed = content.Load<Texture2D>("images/Castle/Castle3Destoryed");

			RedBat = content.Load<Texture2D>("images/Enemy/RedBat");
			Samurai = content.Load<Texture2D>("images/Enemy/Samurai");
			NormalZombie = content.Load<Texture2D>("images/Enemy/NormalZombie");
			MadZombie = content.Load<Texture2D>("images/Enemy/MadZombie");

			Background1 = content.Load<Texture2D>("images/Background/Background1");
			Background2 = content.Load<Texture2D>("images/Background/Background2");
			Background3 = content.Load<Texture2D>("images/Background/Background3");
			Background4 = content.Load<Texture2D>("images/Background/Background4");
			Background5 = content.Load<Texture2D>("images/Background/Background5");

			HelpScene1 = content.Load<Texture2D>("help/HelpScene1");
			HelpScene2 = content.Load<Texture2D>("help/HelpScene2");
		}
	}
}
