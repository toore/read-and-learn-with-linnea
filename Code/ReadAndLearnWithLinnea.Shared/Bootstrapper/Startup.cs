using System;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.Bootstrapper
{
    public static class Startup
    {
        public static void Run(IConsumer consumer)
        {
            var random = new Random();
            var shuffleAlgorithm = new FisherYatesShuffleAlgorithm(random);
            var practiseInitializerFactory = new PractiseInitializerFactory(consumer, shuffleAlgorithm);
            var vocabularyRepository = new StaticVocabularyRepository();

            var applicationInitializer = new ApplicationInitializer(consumer, vocabularyRepository, practiseInitializerFactory);
            
            applicationInitializer.Start();
        }
    }
}