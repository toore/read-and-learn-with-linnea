using System.Threading.Tasks;
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
            SelectTranslationCommand = new AsyncDelegateCommand(x => SelectTranslation());
        }

        private Task SelectTranslation()
        {
            return Task.Run(() => _trainingSession.SelectTranslation(Text));
        }

        public string Text { get; private set; }
        public ICommand SelectTranslationCommand { get; private set; }
    }
}