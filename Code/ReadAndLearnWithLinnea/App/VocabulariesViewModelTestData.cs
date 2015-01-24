using System.Collections.Generic;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
{
    public class VocabulariesViewModelTestData : VocabulariesViewModel
    {
        public VocabulariesViewModelTestData()
            : this(new TrainingCategoriesViewModelFactory(null).Create(
                new[] {new Vocabulary("animals"), new Vocabulary("cars"), new Vocabulary("science")}).VocabularyViewModels)
        {
        }

        private VocabulariesViewModelTestData(IEnumerable<VocabularyViewModel> vocabularyViewModels)
            : base(vocabularyViewModels)
        {
        }
    }
}