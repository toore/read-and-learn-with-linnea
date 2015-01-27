using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.WPF.WPF.SelectPractiseView
{
    public class SelectVocabularyViewModel
    {
        private readonly IEnumerable<VocabularyViewModel> _vocabularyViewModels;

        public SelectVocabularyViewModel(IEnumerable<VocabularyViewModel> vocabularyViewModels)
        {
            _vocabularyViewModels = vocabularyViewModels;
        }

        public IEnumerable<VocabularyViewModel> VocabularyViewModels
        {
            get { return _vocabularyViewModels; }
        }
    }
}