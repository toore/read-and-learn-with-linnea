using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App
{
    public class VocabulariesViewModel
    {
        private readonly IEnumerable<VocabularyViewModel> _vocabularyViewModels;

        public VocabulariesViewModel(IEnumerable<VocabularyViewModel> vocabularyViewModels)
        {
            _vocabularyViewModels = vocabularyViewModels;
        }

        public IEnumerable<VocabularyViewModel> VocabularyViewModels
        {
            get { return _vocabularyViewModels; }
        }
    }
}