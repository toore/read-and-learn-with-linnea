using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.SelectTrainingView
{
    public class SelectVocabularyTrainingViewModelFactory
    {
        private readonly ApplicationController _applicationController;

        public SelectVocabularyTrainingViewModelFactory(ApplicationController applicationController)
        {
            _applicationController = applicationController;
        }

        public SelectVocabularyTrainingViewModel Create(IEnumerable<Vocabulary> trainingCategories)
        {
            var vocabularyTrainingViewModels = trainingCategories.Select(Create).ToList();
            var trainingCategoriesViewModel = new SelectVocabularyTrainingViewModel(vocabularyTrainingViewModels);

            return trainingCategoriesViewModel;
        }

        private VocabularyTrainingViewModel Create(Vocabulary vocabulary)
        {
            var trainingCategoryViewModel = new VocabularyTrainingViewModel(vocabulary, _applicationController);
            return trainingCategoryViewModel;
        }
    }
}