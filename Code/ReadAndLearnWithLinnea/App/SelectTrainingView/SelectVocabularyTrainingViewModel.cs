using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App.SelectTrainingView
{
    public class SelectVocabularyTrainingViewModel
    {
        private readonly IEnumerable<VocabularyTrainingViewModel> _vocabularyViewModels;

        public SelectVocabularyTrainingViewModel(IEnumerable<VocabularyTrainingViewModel> vocabularyViewModels)
        {
            _vocabularyViewModels = vocabularyViewModels;
        }

        public IEnumerable<VocabularyTrainingViewModel> VocabularyViewModels
        {
            get { return _vocabularyViewModels; }
        }
    }
}