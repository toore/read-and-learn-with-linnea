using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.SelectTrainingView
{
    public class VocabularyTrainingViewModel
    {
        private readonly Vocabulary _vocabulary;
        private readonly ApplicationController _applicationController;

        public VocabularyTrainingViewModel(Vocabulary vocabulary, ApplicationController applicationController)
        {
            _vocabulary = vocabulary;
            _applicationController = applicationController;

            StartTrainingSessionCommand = new DelegateCommand(x => StartTraining());
        }

        public ICommand StartTrainingSessionCommand { get; set; }

        private void StartTraining()
        {
            new GuiThreadDispatcher().Invoke(() => _applicationController.StartTrainingSession(_vocabulary));
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