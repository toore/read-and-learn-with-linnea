using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class AnswerViewModel
    {
        private readonly TrainingSession _trainingSession;

        public AnswerViewModel(TrainingSession trainingSession, string text)
        {
            Text = text;
            _trainingSession = trainingSession;
            SelectTranslationCommand = new DelegateCommand(x => SelectTranslation());
        }

        private void SelectTranslation()
        {
            _trainingSession.SelectAnswer(Text);
        }

        public string Text { get; private set; }
        public ICommand SelectTranslationCommand { get; private set; }
    }
}