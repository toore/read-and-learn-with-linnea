﻿using System;
using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.Core
{
    public static class Startup
    {
        public static void Run(IView view)
        {
            var random = new Random();
            var shuffleAlgorithm = new FisherYatesShuffleAlgorithm(random);
            var practiseInitializerFactory = new PractiseInitializerFactory(view, shuffleAlgorithm);
            var vocabularyTextParser = new VocabularyTextParser();
            var vocabularyRepository = new FileVocabularyRepository(vocabularyTextParser);

            var applicationInitializer = new ApplicationInitializer(view, vocabularyRepository, practiseInitializerFactory);
            
            applicationInitializer.Start();
        }
    }
}