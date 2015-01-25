using System.Windows;
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
            _eventAggregator.Publish(new ShowSelectTrainingViewMessage());
        }

        public void StartTrainingSession(Vocabulary vocabulary)
        {
            var trainingSession = new TrainingSession(vocabulary);
            trainingSession.TranslationSelected = () => TranslationSelected(trainingSession);
            trainingSession.TrainingSessionCompleted = () => TrainingSessionCompleted(trainingSession);
            trainingSession.Start();

            _eventAggregator.Publish(new ShowTrainingSessionViewMessage(trainingSession));
        }

        private void TranslationSelected(TrainingSession trainingSession)
        {
            _eventAggregator.Publish(new UpdateTrainingSessionViewMessage(trainingSession));
        }

        private void TrainingSessionCompleted(TrainingSession trainingSession)
        {
            _eventAggregator.Publish(
                new ShowTrainingSessionCompletedMessage(trainingSession),
                x => Application.Current.Dispatcher.Invoke(x));
        }
    }
}