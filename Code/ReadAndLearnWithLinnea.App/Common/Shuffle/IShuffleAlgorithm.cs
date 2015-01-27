using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App.Common.Shuffle
{
    public interface IShuffleAlgorithm
    {
        IEnumerable<T> Shuffle<T>(IEnumerable<T> items);
    }
}