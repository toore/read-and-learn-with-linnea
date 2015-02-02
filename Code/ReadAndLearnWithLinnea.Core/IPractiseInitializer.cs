using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IPractiseInitializer
    {
        void StartPractise(IVocabulary vocabulary);
    }

    public class PractiseInitializer : IPractiseInitializer
    {
        private readonly IApplicationInitializer _applicationInitializer;
        private readonly IView _view;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;

        public PractiseInitializer(IApplicationInitializer applicationInitializer, IView view, IShuffleAlgorithm shuffleAlgorithm)
        {
            _applicationInitializer = applicationInitializer;
            _view = view;
            _shuffleAlgorithm = shuffleAlgorithm;
        }

        public void StartPractise(IVocabulary vocabulary)
        {
            var practise = new Practise(_shuffleAlgorithm, vocabulary);

            var moderator = new Moderator(practise);
            moderator.QuestionUpdated = () => QuestionUpdated(moderator);
            moderator.PractiseCompleted = () => PractiseCompleted(moderator);

            moderator.StartPractise();
        }

        private void QuestionUpdated(Moderator moderator)
        {
            _view.ShowNewQuestionView(moderator.Question, moderator);
        }

        private void PractiseCompleted(Moderator moderator)
        {
            var score = moderator.GetScore();

            _view.ShowPractiseCompletedView(score, _applicationInitializer);
        }
    }
}