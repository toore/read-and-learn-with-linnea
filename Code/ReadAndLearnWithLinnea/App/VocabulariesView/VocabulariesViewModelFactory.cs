using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.App.Shell;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.VocabulariesView
{
    public class VocabulariesViewModelFactory
    {
        private readonly ApplicationController _applicationController;

        public VocabulariesViewModelFactory(ApplicationController applicationController)
        {
            _applicationController = applicationController;
        }

        public VocabulariesViewModel Create(IEnumerable<Vocabulary> trainingCategories)
        {
            var trainingCategoryViewModels = CreateVocabularyViewModels(trainingCategories);

            var trainingCategoriesViewModel = new VocabulariesViewModel(trainingCategoryViewModels);
            return trainingCategoriesViewModel;
        }

        private IEnumerable<VocabularyViewModel> CreateVocabularyViewModels(IEnumerable<Vocabulary> trainingCategories)
        {
            var trainingCategoryViewModels = trainingCategories.Select(Create).ToList();
            return trainingCategoryViewModels;
        }

        private VocabularyViewModel Create(Vocabulary vocabulary)
        {
            var trainingCategoryViewModel = new VocabularyViewModel(vocabulary, _applicationController);
            return trainingCategoryViewModel;
        }
    }
}