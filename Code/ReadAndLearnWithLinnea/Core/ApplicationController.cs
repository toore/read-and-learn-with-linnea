using System;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class ApplicationController
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;

        public ApplicationController(IEventAggregator eventAggregator, IShuffleAlgorithm shuffleAlgorithm)
        {
            _eventAggregator = eventAggregator;
            _shuffleAlgorithm = shuffleAlgorithm;
        }

        public void StartApplication()
        {
            ShowSelectTrainingView();
        }

        private void ShowSelectTrainingView()
        {
            _eventAggregator.Publish(new ShowSelectTrainingViewMessage());
        }

        public void StartTrainingSession(Vocabulary vocabulary)
        {
            var trainingSession = new TrainingSession(_shuffleAlgorithm, vocabulary);
            trainingSession.TrainingSessionCompleted = () => TrainingSessionCompleted(trainingSession);
            trainingSession.Start();

            ShowTrainingSessionView(trainingSession);
        }

        private void ShowTrainingSessionView(TrainingSession trainingSession)
        {
            _eventAggregator.Publish(new ShowTrainingSessionViewMessage(trainingSession));
        }

        private void TrainingSessionCompleted(TrainingSession trainingSession)
        {
            ShowTrainingSessionCompletedMessage(trainingSession, () => ShowSelectTrainingView());
        }

        private void ShowTrainingSessionCompletedMessage(TrainingSession trainingSession, Action continueWith)
        {
            _eventAggregator.Publish(new ShowTrainingSessionCompletedMessage(trainingSession, continueWith));
        }
    }
}