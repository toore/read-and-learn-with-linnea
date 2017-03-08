using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Shared.QuestionAndAnswer
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