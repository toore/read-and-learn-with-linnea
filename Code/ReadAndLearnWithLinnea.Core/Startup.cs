﻿using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class Startup : IPractiseInitializer
    {
        private readonly IConsumer _consumer;
        private readonly IShuffleAlgorithm _shuffleAlgorithm;
        private readonly IVocabularyRepository _vocabularyRepository;

        private Startup(IConsumer consumer, IShuffleAlgorithm shuffleAlgorithm, IVocabularyRepository vocabularyRepository)
        {
            _consumer = consumer;
            _shuffleAlgorithm = shuffleAlgorithm;
            _vocabularyRepository = vocabularyRepository;
        }

        public static void Run(IConsumer consumer, IShuffleAlgorithm shuffleAlgorithm, IVocabularyRepository vocabularyRepository)
        {
            var startup = new Startup(consumer, shuffleAlgorithm, vocabularyRepository);

            startup.ShowSelectTrainingView();
        }

        private void ShowSelectTrainingView()
        {
            var vocabularies = _vocabularyRepository.GetAll();

            _consumer.SelectPractise(vocabularies, this);
        }

        void IPractiseInitializer.Start(IVocabulary vocabulary)
        {
            var practise = new Practise(_shuffleAlgorithm, vocabulary);

            var moderator = new Moderator(practise);
            moderator.QuestionUpdated = () => QuestionUpdated(moderator);
            moderator.PractiseCompleted = () => PractiseCompleted(moderator);

            moderator.StartPractise();
        }

        private void QuestionUpdated(Moderator moderator)
        {
            _consumer.NewPractise(moderator, moderator.Question);
        }

        private void PractiseCompleted(Moderator moderator)
        {
            var name = moderator.Name;
            var score = moderator.GetScore();

            _consumer.PractiseCompleted(
                name,
                score,
                () => ShowSelectTrainingView());
        }
    }
}