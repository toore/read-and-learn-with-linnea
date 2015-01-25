using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Common.Shuffle
{
    public interface IShuffleAlgorithm
    {
        IEnumerable<T> Shuffle<T>(IEnumerable<T> items);
    }
}