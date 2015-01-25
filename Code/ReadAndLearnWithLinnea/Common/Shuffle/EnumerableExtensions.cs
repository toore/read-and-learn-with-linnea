using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Common.Shuffle
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, FisherYatesShuffleAlgorithm fisherYatesShuffleAlgorithm)
        {
            var shuffledItems = fisherYatesShuffleAlgorithm.Shuffle(items);
            return shuffledItems;
        }
    }
}