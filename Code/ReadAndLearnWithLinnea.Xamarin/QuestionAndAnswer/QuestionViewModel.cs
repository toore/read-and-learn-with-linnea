using System.Collections.Generic;

namespace Xamarin.QuestionAndAnswer
{
    public class QuestionViewModel
    {
        public QuestionViewModel(string question, IList<AnswerViewModel> answers)
        {
            Question = question;
            Answers = answers;
        }

        public string Question { get; }

        public IList<AnswerViewModel> Answers { get; }
    }
}