using System.Linq;
using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;
using Xamarin.Forms;

namespace ReadAndLearnWithLinnea.Shared.SelectVocabulary
{
    public class VocabularyViewModel
    {
        private readonly IVocabulary _vocabulary;
        private readonly IPractiseInitializer _practiseInitializer;

        public VocabularyViewModel(IVocabulary vocabulary, IPractiseInitializer practiseInitializer)
        {
            _vocabulary = vocabulary;
            _practiseInitializer = practiseInitializer;

            TappedCommand = new Command(x => StartTrainingSession());
        }

        public ICommand TappedCommand { get; set; }

        private void StartTrainingSession()
        {
            _practiseInitializer.StartPractise(_vocabulary);
        }

        public string Name => _vocabulary.Name;

        public int VocablesCount => _vocabulary.Vocables.Count();
    }
}