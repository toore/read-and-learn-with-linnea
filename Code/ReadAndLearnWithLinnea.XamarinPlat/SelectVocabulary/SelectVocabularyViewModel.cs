using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.XamarinPlat.SelectVocabulary
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