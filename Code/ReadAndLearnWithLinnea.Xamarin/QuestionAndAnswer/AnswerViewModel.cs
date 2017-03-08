using ReadAndLearnWithLinnea.Core;
using Xamarin.Forms;

namespace Xamarin.QuestionAndAnswer
{
    public class AnswerViewModel
    {
        private readonly IQuestion _question;
        private readonly IModerator _moderator;

        public AnswerViewModel(string answer, IQuestion question, IModerator moderator)
        {
            Answer = answer;
            _question = question;
            _moderator = moderator;

            TappedCommand = new Command(x => SendAnswer(), x => CanExecuteAnswer());
        }

        private void SendAnswer()
        {
            _moderator.Answer(_question, Answer);
            TappedCommand.ChangeCanExecute();
        }

        private bool CanExecuteAnswer()
        {
            return _moderator.CanAnswerQuestion(_question);
        }

        public string Answer { get; }

        public Command TappedCommand { get; }
    }
}