using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IVocabulary
    {
        string Name { get; }
        IList<Vocable> Vocables { get; }
    }
}