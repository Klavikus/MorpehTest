using System;
using System.Collections.Generic;

namespace Modules.Common.Utils
{
    public static class Extensions
    {
        private static Random random = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static float AsPercentFactor(this float value) => value / 100;
    }
}