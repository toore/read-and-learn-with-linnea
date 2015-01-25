using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class AnswerViewModel
    {
        private readonly Question _question;
        private readonly TrainingSession _trainingSession;

        public AnswerViewModel(string text, Question question, TrainingSession trainingSession)
        {
            _question = question;
            _trainingSession = trainingSession;
            Text = text;

            AnswerCommand = new DelegateCommand(x => Answer());
        }

        private void Answer()
        {
            _trainingSession.SetAnswer(_question, Text);
        }

        public string Text { get; private set; }
        public ICommand AnswerCommand { get; private set; }
    }
}