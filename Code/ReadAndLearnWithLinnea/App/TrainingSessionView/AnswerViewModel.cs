using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class AnswerViewModel
    {
        private readonly Question _question;
        private readonly TrainingSessionController _trainingSessionController;

        public AnswerViewModel(string text, Question question, TrainingSessionController trainingSessionController)
        {
            _question = question;
            _trainingSessionController = trainingSessionController;
            Text = text;

            AnswerCommand = new DelegateCommand(x => Answer());
        }

        private void Answer()
        {
            _trainingSessionController.AnswerQuestion(_question, Text);
        }

        public string Text { get; private set; }
        public ICommand AnswerCommand { get; private set; }
    }
}