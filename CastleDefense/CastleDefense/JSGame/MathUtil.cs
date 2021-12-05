using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    static class MathUtil
    {
        public static Vector2 FromPolar(float angle, float magnitude)
        {
            return magnitude * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }
    }
}
