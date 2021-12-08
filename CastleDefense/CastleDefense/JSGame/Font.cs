using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    class Font
    {
        public static SpriteFont RegularFont { get; private set; }
        public static SpriteFont HilightFont { get; private set; }
        public static SpriteFont TitleFont { get; private set; }
        public static SpriteFont ScoreFont { get; private set; }

        public static void Load(ContentManager content)
        {
            RegularFont = content.Load<SpriteFont>("fonts/regularFont");
            HilightFont = content.Load<SpriteFont>("fonts/hilightFont");
            TitleFont = content.Load<SpriteFont>("fonts/titleFont");
            ScoreFont = content.Load<SpriteFont>("fonts/scoreFont");
        }
    }
}
