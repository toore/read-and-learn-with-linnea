using System;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.Launcher
{
    public static class Startup
    {
        public static void Run(IConsumer consumer)
        {
            var random = new Random();
            var shuffleAlgorithm = new FisherYatesShuffleAlgorithm(random);
            var practiseInitializerFactory = new PractiseInitializerFactory(consumer, shuffleAlgorithm);
            var vocabularyTextParser = new VocabularyTextParser();
            var vocabularyRepository = new FileVocabularyRepository(vocabularyTextParser);

            var applicationInitializer = new ApplicationInitializer(consumer, vocabularyRepository, practiseInitializerFactory);
            
            applicationInitializer.Start();
        }
    }
}