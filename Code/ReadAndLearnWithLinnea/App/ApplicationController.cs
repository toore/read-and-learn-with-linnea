using ReadAndLearnWithLinnea.App.Shell;
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
            _eventAggregator.Publish(new ShowSelectTrainingViewMessage());
        }

        public void StartTrainingSession(Vocabulary vocabulary)
        {
            _eventAggregator.Publish(new ShowTrainingSessionViewMessage(vocabulary));
        }
    }
}