using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class TrainingSessionViewModelFactory
    {
        public TrainingSessionViewModel Create(IList<Vocable> vocables)
        {
            var vocableToTranslate = vocables.First();
            var falseTranslationsCandidates = vocables.Skip(1);

            var text = vocableToTranslate.GetText(Language.English);
            var translation = vocableToTranslate.GetText(Language.Swedish);
            var falseTranslations = falseTranslationsCandidates.Select(x => x.GetText(Language.Swedish));

            var wordViewModels = CreateWordViewModels(translation, falseTranslations);
            var trainingSessionViewModel = new TrainingSessionViewModel(text, wordViewModels);

            return trainingSessionViewModel;
        }

        private static IEnumerable<TranslationCandidateViewModel> CreateWordViewModels(string translation, IEnumerable<string> falseTranslations)
        {
            yield return new TranslationCandidateViewModel(translation, CandidateResult.CorrectTranslation);

            foreach (var falseTranslation in falseTranslations)
            {
                yield return new TranslationCandidateViewModel(falseTranslation, CandidateResult.IncorrectTranslation);
            }
        }
    }

    public static class VocabularyExtensions
    {
        public static string GetText(this Vocable vocable, Language language)
        {
            return vocable.Words.Single(x => x.Language == language).Text;
        }
    }
}