using System.Linq;
using ReadAndLearnWithLinnea.Common.Shuffle;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class QuestionViewModelFactory
    {
        private readonly FisherYatesShuffleAlgorithm _fisherYatesShuffleAlgorithm;

        public QuestionViewModelFactory(FisherYatesShuffleAlgorithm fisherYatesShuffleAlgorithm)
        {
            _fisherYatesShuffleAlgorithm = fisherYatesShuffleAlgorithm;
        }

        public QuestionViewModel Create(TrainingSession trainingSession)
        {
            var questionViewModel = new QuestionViewModel();
            trainingSession.QuestionUpdated = () => UpdateViewModel(questionViewModel, trainingSession);

            UpdateViewModel(questionViewModel, trainingSession);

            return questionViewModel;
        }

        private void UpdateViewModel(QuestionViewModel questionViewModel, TrainingSession trainingSession)
        {
            var question = trainingSession.Question;

            var answerViewModels = question.Answers
                .Select(text => CreateAnswerViewModel(text, trainingSession))
                .Shuffle(_fisherYatesShuffleAlgorithm);

            questionViewModel.Text = question.Text;
            questionViewModel.AnswerViewModels = answerViewModels;
        }

        private AnswerViewModel CreateAnswerViewModel(string text, TrainingSession trainingSession)
        {
            return new AnswerViewModel(text, trainingSession.Question, trainingSession);
        }
    }
}