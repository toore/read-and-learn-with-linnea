using System.Windows.Input;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.WpfApp.PractiseView
{
    public class AnswerViewModel
    {
        private readonly IQuestion _question;
        private readonly IModerator _moderator;

        public AnswerViewModel(string text, IQuestion question, IModerator moderator)
        {
            _question = question;
            _moderator = moderator;
            Text = text;

            AnswerCommand = new DelegateCommand(x => Answer(), x => CanExecuteAnswer());
        }

        private void Answer()
        {
            _moderator.Answer(_question, Text);
        }

        private bool CanExecuteAnswer()
        {
            return _moderator.CanAnswerQuestion(_question);
        }

        public string Text { get; private set; }
        public ICommand AnswerCommand { get; private set; }
    }
}