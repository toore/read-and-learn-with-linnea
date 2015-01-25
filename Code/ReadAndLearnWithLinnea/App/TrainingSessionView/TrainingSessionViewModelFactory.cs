using System.Collections.Generic;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class TrainingSessionViewModelFactory
    {
        public TrainingSessionViewModel Create(TrainingSession trainingSession)
        {
            var wordViewModels = CreateWordViewModels(trainingSession);
            var trainingSessionViewModel = new TrainingSessionViewModel(trainingSession.TextToTranslate, wordViewModels);

            return trainingSessionViewModel;
        }

        private static IEnumerable<TranslationCandidateViewModel> CreateWordViewModels(TrainingSession trainingSession)
        {
            yield return new TranslationCandidateViewModel(trainingSession, trainingSession.CorrectTranslation);

            foreach (var falseTranslation in trainingSession.FalseTranslations)
            {
                yield return new TranslationCandidateViewModel(trainingSession, falseTranslation);
            }
        }
    }
}