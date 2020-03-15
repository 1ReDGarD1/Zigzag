using System;
using System.Collections.Generic;

namespace MyZigzag.Scripts.Utility.Common
{
    public static class RandomUtils
    {
        #region RandomUtils

        private static readonly Random Random = new Random();

        private static int Range(int min, int max) => Random.Next(min, max + 1);

        public static bool RandomBool()
        {
            return Range(0, 1) == 0;
        }

        #endregion
    }
}