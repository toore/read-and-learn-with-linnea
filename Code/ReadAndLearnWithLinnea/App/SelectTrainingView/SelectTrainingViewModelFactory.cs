using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.SelectTrainingView
{
    public class SelectTrainingViewModelFactory
    {
        private readonly ApplicationController _applicationController;

        public SelectTrainingViewModelFactory(ApplicationController applicationController)
        {
            _applicationController = applicationController;
        }

        public SelectTrainingViewModel Create(IEnumerable<Vocabulary> trainingCategories)
        {
            var trainingCategoryViewModels = trainingCategories.Select(Create).ToList();
            var trainingCategoriesViewModel = new SelectTrainingViewModel(trainingCategoryViewModels);

            return trainingCategoriesViewModel;
        }

        private VocabularyTrainingViewModel Create(Vocabulary vocabulary)
        {
            var trainingCategoryViewModel = new VocabularyTrainingViewModel(vocabulary, _applicationController);
            return trainingCategoryViewModel;
        }
    }
}