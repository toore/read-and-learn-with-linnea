﻿using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public class Startup : IPractiseInitializer, IApplicationInitializer
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

            startup.SelectVocabularyToPractise();
        }

        private void SelectVocabularyToPractise()
        {
            var vocabularies = _vocabularyRepository.GetAll();

            _consumer.SelectVocabularyToPractise(vocabularies, this);
        }

        void IPractiseInitializer.StartPractise(IVocabulary vocabulary)
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

            _consumer.PractiseCompleted(score, this);
        }

        void IApplicationInitializer.StartOver()
        {
            SelectVocabularyToPractise();
        }
    }
}