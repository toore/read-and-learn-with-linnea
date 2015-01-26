using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.SelectVocabularyView
{
    public class SelectVocabularyViewModelFactory
    {
        private readonly ApplicationController _applicationController;

        public SelectVocabularyViewModelFactory(ApplicationController applicationController)
        {
            _applicationController = applicationController;
        }

        public SelectVocabularyViewModel Create(IEnumerable<Vocabulary> vocabularies)
        {
            var vocabularyTrainingViewModels = vocabularies.Select(Create).ToList();
            var trainingCategoriesViewModel = new SelectVocabularyViewModel(vocabularyTrainingViewModels);

            return trainingCategoriesViewModel;
        }

        private VocabularyViewModel Create(Vocabulary vocabulary)
        {
            var trainingCategoryViewModel = new VocabularyViewModel(vocabulary, _applicationController);
            return trainingCategoryViewModel;
        }
    }
}