using System.Collections.Generic;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class TrainingSessionViewModelFactory
    {
        private readonly FisherYatesShuffleAlgorithm _fisherYatesShuffleAlgorithm;

        public TrainingSessionViewModelFactory(FisherYatesShuffleAlgorithm fisherYatesShuffleAlgorithm)
        {
            _fisherYatesShuffleAlgorithm = fisherYatesShuffleAlgorithm;
        }

        public TrainingSessionViewModel Create(TrainingSession trainingSession)
        {
            var translationCandidateViewModels = CreateWordViewModels(trainingSession).Shuffle(_fisherYatesShuffleAlgorithm);

            var trainingSessionViewModel = new TrainingSessionViewModel(trainingSession.TextToTranslate, translationCandidateViewModels);

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