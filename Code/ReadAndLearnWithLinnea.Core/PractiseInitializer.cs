namespace ReadAndLearnWithLinnea.Core
{
    public class PractiseInitializer : IPractiseInitializer
    {
        private readonly IApplicationInitializer _applicationInitializer;
        private readonly IConsumer _consumer;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;

        public PractiseInitializer(IApplicationInitializer applicationInitializer, IConsumer consumer, IShuffleAlgorithm shuffleAlgorithm)
        {
            _applicationInitializer = applicationInitializer;
            _consumer = consumer;
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
            _consumer.NewQuestion(moderator.Question, moderator);
        }

        private void PractiseCompleted(Moderator moderator)
        {
            var score = moderator.GetScore();

            _consumer.PractiseCompleted(score, _applicationInitializer);
        }
    }
}