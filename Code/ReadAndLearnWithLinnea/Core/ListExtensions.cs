using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadAndLearnWithLinnea.Core
{
    public static class ListExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
        {
            var random = new Random();

            var list = items.ToList();
            var n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                var j = random.Next(i, n);

                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }

            return list;

            // http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

            //To shuffle an array a of n elements (indices 0..n-1):
            //  for i from 0 to n − 1 do
            //       j ← random integer with i ≤ j < n
            //       exchange a[j] and a[i]
        }
    }
}