using System;
using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.Core.Common.Shuffle;

namespace ReadAndLearnWithLinnea.ConsoleApp
{
    static class Program
    {
        static void Main()
        {
            var random = new Random();
            var fisherYatesShuffleAlgorithm = new FisherYatesShuffleAlgorithm(random);
            var vocabularyRepository = new HardCodedVocabularyRepository();

            Startup.Run(new ConsoleView(), fisherYatesShuffleAlgorithm, vocabularyRepository);

            Console.ReadLine();
        }
    }
}
