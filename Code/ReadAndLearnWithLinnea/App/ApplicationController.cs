using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
{
    public class ApplicationController
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly GuiThreadDispatcher _guiThreadDispatcher;

        public ApplicationController(IEventAggregator eventAggregator, GuiThreadDispatcher guiThreadDispatcher)
        {
            _eventAggregator = eventAggregator;
            _guiThreadDispatcher = guiThreadDispatcher;
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
                x => _guiThreadDispatcher.Invoke(x));

            StartApplication();
        }
    }
}