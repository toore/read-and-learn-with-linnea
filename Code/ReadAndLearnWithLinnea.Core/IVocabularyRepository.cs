using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IVocabularyRepository
    {
        IEnumerable<IVocabulary> GetAll();
    }
}