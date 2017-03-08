using System.Collections.Generic;

namespace Xamarin.SelectVocabulary
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