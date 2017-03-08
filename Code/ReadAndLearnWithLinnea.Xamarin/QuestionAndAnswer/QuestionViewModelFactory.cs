using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.Shared.QuestionAndAnswer
{
    public class QuestionViewModelFactory
    {
        public QuestionViewModel Create(IModerator moderator, IQuestion question)
        {
            var answerViewModels = question.Answers
                .Select(text => CreateAnswerViewModel(text, moderator, question)).ToList();

            return new QuestionViewModel(question.Text, answerViewModels);
        }

        private static AnswerViewModel CreateAnswerViewModel(string text, IModerator moderator, IQuestion question)
        {
            return new AnswerViewModel(text, question, moderator);
        }
    }
}