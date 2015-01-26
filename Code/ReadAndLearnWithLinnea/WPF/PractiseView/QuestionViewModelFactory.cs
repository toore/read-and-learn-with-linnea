using System.Linq;
using ReadAndLearnWithLinnea.App;

namespace ReadAndLearnWithLinnea.WPF.PractiseView
{
    public class QuestionViewModelFactory
    {
        public QuestionViewModel Create()
        {
            return new QuestionViewModel();
        }

        public void UpdateViewModel(QuestionViewModel questionViewModel, IModerator moderator, IQuestion question)
        {
            var answerViewModels = question.Answers
                .Select(text => CreateAnswerViewModel(text, moderator, question));

            questionViewModel.Text = question.Text;
            questionViewModel.AnswerViewModels = answerViewModels;
        }

        private static AnswerViewModel CreateAnswerViewModel(string text, IModerator moderator, IQuestion question)
        {
            return new AnswerViewModel(text, question, moderator);
        }
    }
}