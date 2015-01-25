using System.Collections.Generic;

namespace ReadAndLearnWithLinnea
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