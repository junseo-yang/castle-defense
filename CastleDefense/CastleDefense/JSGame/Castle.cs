using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleDefense
{
    class Castle : Entity
    {
        private static Castle instance;
        public static Castle Instance
        {
            get
            {
                if (instance == null)
                    instance = new Castle();

                return instance;
            }
        }

        public List<Texture2D> CastleImageList = new List<Texture2D> { Art.Castle1, Art.Castle2, Art.Castle3, Art.Castle1Destroyed, Art.Castle2Destroyed, Art.Castle3Destroyed };
        public int imageIndex = 0;

        private Random rand = new Random();

        public Castle()
        {
            imageIndex = rand.Next(0, 2);
            image = CastleImageList[imageIndex];
            Position = new Vector2(1400 - image.Width / 2, 600 - image.Height / 2);
        }

        public override void Update()
        {
            if (ArcherStatus.IsGameOver)
            {
                image = CastleImageList[imageIndex + 3];
            }
            else
            {
                image = CastleImageList[imageIndex];
            }
        }

        public void CastleReset()
        {
            imageIndex = rand.Next(0, 2);
        }
    }
}
