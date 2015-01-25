using System;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class ApplicationController
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly FisherYatesShuffleAlgorithm _fisherYatesShuffleAlgorithm;

        public ApplicationController(IEventAggregator eventAggregator, FisherYatesShuffleAlgorithm fisherYatesShuffleAlgorithm)
        {
            _eventAggregator = eventAggregator;
            _fisherYatesShuffleAlgorithm = fisherYatesShuffleAlgorithm;
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
            var trainingSession = new TrainingSession(_fisherYatesShuffleAlgorithm, vocabulary);
            trainingSession.NewTranslationQuestionAsked = () => TranslationSelected(trainingSession);
            trainingSession.TrainingSessionCompleted = () => TrainingSessionCompleted(trainingSession);
            trainingSession.Start();

            ShowTrainingSessionView(trainingSession);
        }

        private void ShowTrainingSessionView(TrainingSession trainingSession)
        {
            _eventAggregator.Publish(new ShowTrainingSessionViewMessage(trainingSession));
        }

        private void TranslationSelected(TrainingSession trainingSession)
        {
            _eventAggregator.Publish(new UpdateTrainingSessionViewMessage(trainingSession));
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