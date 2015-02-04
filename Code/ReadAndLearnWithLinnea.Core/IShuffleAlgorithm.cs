using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core.Common.Shuffle
{
    public interface IShuffleAlgorithm
    {
        IEnumerable<T> Shuffle<T>(IEnumerable<T> items);
    }
}