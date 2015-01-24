using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App.SelectTrainingView
{
    public class SelectTrainingViewModel
    {
        private readonly IEnumerable<VocabularyTrainingViewModel> _vocabularyViewModels;

        public SelectTrainingViewModel(IEnumerable<VocabularyTrainingViewModel> vocabularyViewModels)
        {
            _vocabularyViewModels = vocabularyViewModels;
        }

        public IEnumerable<VocabularyTrainingViewModel> VocabularyViewModels
        {
            get { return _vocabularyViewModels; }
        }
    }
}