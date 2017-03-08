using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.Shared.SelectVocabulary
{
    public class SelectVocabularyViewModelFactory
    {
        public SelectVocabularyViewModel Create(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer)
        {
            var vocabularyTrainingViewModels = vocabularies.Select(x => Create(x, practiseInitializer)).ToList();

            return new SelectVocabularyViewModel(vocabularyTrainingViewModels);
        }

        private static VocabularyViewModel Create(IVocabulary vocabulary, IPractiseInitializer practiseInitializer)
        {
            return new VocabularyViewModel(vocabulary, practiseInitializer);
        }
    }
}