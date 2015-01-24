using System.Threading.Tasks;
using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
{
    public class VocabularyViewModel
    {
        private readonly Vocabulary _vocabulary;
        private readonly ApplicationController _applicationController;

        public VocabularyViewModel(Vocabulary vocabulary, ApplicationController applicationController)
        {
            _vocabulary = vocabulary;
            _applicationController = applicationController;

            StartTrainingSessionCommand = new AsyncDelegateCommand(x => StartTraining(_vocabulary));
        }

        public ICommand StartTrainingSessionCommand { get; set; }

        private Task StartTraining(Vocabulary vocabulary)
        {
            return Task.Run(() => _applicationController.StartTrainingSession(vocabulary));
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
}