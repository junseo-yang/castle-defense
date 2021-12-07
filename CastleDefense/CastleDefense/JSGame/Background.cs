using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    class Background : Entity
    {
        private static Background instance;
        public static Background Instance
        {
            get
            {
                if (instance == null)
                    instance = new Background();

                return instance;
            }
        }

        public List<Texture2D> BackgroundImageList = new List<Texture2D> { Art.Background1, Art.Background2, Art.Background3, Art.Background4, Art.Background5 };
        public int imageIndex = 0;

        private Random rand = new Random();

        public Background()
        {
            imageIndex = rand.Next(0, BackgroundImageList.Count - 1);
            image = BackgroundImageList[imageIndex];
            Position = Shared.stage / 2;
        }

        public void BackgroundReset()
        {
            imageIndex = rand.Next(0, BackgroundImageList.Count - 1);
        }

        public override void Update()
        {
            image = BackgroundImageList[imageIndex];
        }
    }
}
