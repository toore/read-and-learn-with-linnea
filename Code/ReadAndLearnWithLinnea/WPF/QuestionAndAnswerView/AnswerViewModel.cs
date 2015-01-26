using System.Windows.Input;
using ReadAndLearnWithLinnea.App;
using ReadAndLearnWithLinnea.Common;

namespace ReadAndLearnWithLinnea.WPF.QuestionAndAnswerView
{
    public class AnswerViewModel
    {
        private readonly Question _question;
        private readonly IModerator _readAndLearnWithLinneaModerator;

        public AnswerViewModel(string text, Question question, IModerator readAndLearnWithLinneaModerator)
        {
            _question = question;
            _readAndLearnWithLinneaModerator = readAndLearnWithLinneaModerator;
            Text = text;

            AnswerCommand = new DelegateCommand(x => Answer(), x => CanExecuteAnswer());
        }

        private void Answer()
        {
            _readAndLearnWithLinneaModerator.Answer(_question, Text);
        }

        private bool CanExecuteAnswer()
        {
            return _readAndLearnWithLinneaModerator.CanAnswerQuestion(_question);
        }

        public string Text { get; private set; }
        public ICommand AnswerCommand { get; private set; }
    }
}