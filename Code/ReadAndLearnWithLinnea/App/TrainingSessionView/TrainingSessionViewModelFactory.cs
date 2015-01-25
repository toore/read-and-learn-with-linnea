using System.Linq;
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
            var translationCandidateViewModels = trainingSession.Answers
                .Select(candidate => new AnswerViewModel(trainingSession, candidate))
                .Shuffle(_fisherYatesShuffleAlgorithm);

            var trainingSessionViewModel = new TrainingSessionViewModel(trainingSession.Text, translationCandidateViewModels);

            return trainingSessionViewModel;
        }
    }
}