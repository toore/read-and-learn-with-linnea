using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class TranslationCandidateViewModel
    {
        private readonly TrainingSession _trainingSession;

        public TranslationCandidateViewModel(TrainingSession trainingSession, string text)
        {
            Text = text;
            _trainingSession = trainingSession;
            SelectTranslationCommand = new DelegateCommand(x => SelectTranslation());
        }

        private void SelectTranslation()
        {
            _trainingSession.SelectTranslation(Text);
        }

        public string Text { get; private set; }
        public ICommand SelectTranslationCommand { get; private set; }
    }
}