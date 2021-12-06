using System;
using System.Collections.Generic;
using System.Text;

namespace CastleDefense
{
    static class ArcherStatus
    {
        public static bool IsGameOver = false;

        static ArcherStatus()
        {
            Reset();
        }

        public static void Reset()
        {
            IsGameOver = false;
        }
    }
}
