using System;
using ReadAndLearnWithLinnea.Caliburn.Micro;

namespace ReadAndLearnWithLinnea.Core
{
    public class ApplicationController
    {
        private readonly IEventAggregator _eventAggregator;

        public ApplicationController(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
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
            var trainingSession = new TrainingSession(vocabulary);
            trainingSession.TranslationSelected = () => TranslationSelected(trainingSession);
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