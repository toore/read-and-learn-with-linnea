using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.App;

namespace ReadAndLearnWithLinnea.WPF.WPF.SelectPractiseView
{
    public class SelectVocabularyViewModelFactory
    {
        public SelectVocabularyViewModel Create(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer)
        {
            var vocabularyTrainingViewModels = vocabularies.Select(x => Create(x, practiseInitializer)).ToList();
            var selectVocabularyViewModel = new SelectVocabularyViewModel(vocabularyTrainingViewModels);

            return selectVocabularyViewModel;
        }

        private VocabularyViewModel Create(IVocabulary vocabulary, IPractiseInitializer practiseInitializer)
        {
            var trainingCategoryViewModel = new VocabularyViewModel(vocabulary, practiseInitializer);
            return trainingCategoryViewModel;
        }
    }
}