using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Shared.SelectVocabulary
{
    public class SelectVocabularyViewModel
    {
        public SelectVocabularyViewModel(IList<VocabularyViewModel> vocabularies)
        {
            Vocabularies = vocabularies;
        }

        public IList<VocabularyViewModel> Vocabularies { get; }
    }
}