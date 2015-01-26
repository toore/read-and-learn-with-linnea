using ReadAndLearnWithLinnea.Common.Shuffle;

namespace ReadAndLearnWithLinnea.App
{
    public class Startup : IPractiseInitializer
    {
        private readonly IConsumer _readAndLearnWithLinneaApplicationConsumer;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;
        private readonly IVocabularyRepository _vocabularyRepository;

        private Startup(IConsumer readAndLearnWithLinneaApplicationConsumer, IShuffleAlgorithm shuffleAlgorithm, IVocabularyRepository vocabularyRepository)
        {
            _readAndLearnWithLinneaApplicationConsumer = readAndLearnWithLinneaApplicationConsumer;
            _shuffleAlgorithm = shuffleAlgorithm;
            _vocabularyRepository = vocabularyRepository;
        }

        public static object Run(IConsumer readAndLearnWithLinneaApplicationConsumer, IShuffleAlgorithm shuffleAlgorithm, IVocabularyRepository vocabularyRepository)
        {
            var startup = new Startup(readAndLearnWithLinneaApplicationConsumer, shuffleAlgorithm, vocabularyRepository);

            startup.ShowSelectTrainingView();

            return startup;
        }

        private void ShowSelectTrainingView()
        {
            var vocabularies = _vocabularyRepository.GetAll();

            _readAndLearnWithLinneaApplicationConsumer.SelectPractise(vocabularies, this);
        }

        void IPractiseInitializer.Start(IVocabulary vocabulary)
        {
            var trainingSession = new TrainingSession(_shuffleAlgorithm, vocabulary);

            var trainingSessionController = new TrainingSessionController(trainingSession);
            trainingSessionController.TrainingSessionCompleted = () => TrainingSessionCompleted(trainingSessionController);
            trainingSessionController.Start();

            ShowTrainingSessionView(trainingSessionController);
        }

        private void ShowTrainingSessionView(TrainingSessionController trainingSessionController)
        {
            _readAndLearnWithLinneaApplicationConsumer.PractiseStarted(trainingSessionController);
        }

        private void TrainingSessionCompleted(TrainingSessionController trainingSessionController)
        {
            ShowTrainingSessionCompletedMessage(trainingSessionController);
        }

        private void ShowTrainingSessionCompletedMessage(TrainingSessionController trainingSessionController)
        {
            var name = trainingSessionController.Name;
            var trainingSessionResult = trainingSessionController.GetResult();
            var noOfCorrectAnswers = trainingSessionResult.NoOfCorrectAnswers;
            var noOfQuestions = trainingSessionResult.NoOfQuestions;

            _readAndLearnWithLinneaApplicationConsumer.PractiseCompleted(
                name,
                noOfCorrectAnswers,
                noOfQuestions,
                () => ShowSelectTrainingView());
        }
    }
}