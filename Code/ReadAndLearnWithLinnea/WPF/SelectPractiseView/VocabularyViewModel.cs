using System.Linq;
using System.Windows.Input;
using ReadAndLearnWithLinnea.App;

namespace ReadAndLearnWithLinnea.WPF.WPF.SelectPractiseView
{
    public class VocabularyViewModel
    {
        private readonly IVocabulary _vocabulary;
        private readonly IPractiseInitializer _practiseInitializer;

        public VocabularyViewModel(IVocabulary vocabulary, IPractiseInitializer practiseInitializer)
        {
            _vocabulary = vocabulary;
            _practiseInitializer = practiseInitializer;

            StartTrainingSessionCommand = new DelegateCommand(x => StartTrainingSession());
        }

        public ICommand StartTrainingSessionCommand { get; set; }

        private void StartTrainingSession()
        {
            _practiseInitializer.Start(_vocabulary);
        }

        public string Name
        {
            get { return _vocabulary.Name; }
        }

        public int VocablesCount
        {
            get { return _vocabulary.Vocables.Count(); }
        }
    }
}