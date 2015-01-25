using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, Shuffler shuffler)
        {
            var shuffledItems = shuffler.Shuffle(items);
            return shuffledItems;
        }
    }
}