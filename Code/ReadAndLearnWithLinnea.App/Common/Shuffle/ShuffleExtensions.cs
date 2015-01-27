using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App.Common.Shuffle
{
    public static class ShuffleExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, IShuffleAlgorithm shuffleAlgorithm)
        {
            var shuffledItems = shuffleAlgorithm.Shuffle(items);
            return shuffledItems;
        }
    }
}