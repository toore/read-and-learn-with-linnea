using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IShuffleAlgorithm
    {
        IEnumerable<T> Shuffle<T>(IEnumerable<T> items);
    }
}