using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
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
            _eventAggregator.Publish(new ShowVocabulariesViewMessage());
        }

        public void StartTrainingSession(Vocabulary vocabulary)
        {
            _eventAggregator.Publish(new StartTrainingSessionMessage(vocabulary));
        }
    }
}