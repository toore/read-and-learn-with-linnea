using System.Threading.Tasks;
using System.Windows.Input;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
{
    public class VocabularyViewModel
    {
        private readonly Vocabulary _vocabulary;
        private readonly IEventAggregator _eventAggregator;

        public VocabularyViewModel(Vocabulary vocabulary, IEventAggregator eventAggregator)
        {
            _vocabulary = vocabulary;
            _eventAggregator = eventAggregator;

            StartTrainingSessionCommand = new AsyncDelegateCommand(x => StartTraining(_vocabulary));
        }

        public ICommand StartTrainingSessionCommand { get; set; }

        private Task StartTraining(Vocabulary vocabulary)
        {
            return Task.Run(() => _eventAggregator.Publish(new StartTrainingSessionMessage(vocabulary)));
        }

        public string Name
        {
            get { return _vocabulary.Name; }
        }

        public int VocablesCount
        {
            get { return _vocabulary.Vocables.Count; }
        }
    }

    public class StartTrainingSessionMessage
    {
        private readonly Vocabulary _vocabulary;

        public StartTrainingSessionMessage(Vocabulary vocabulary)
        {
            _vocabulary = vocabulary;
        }
    }
}