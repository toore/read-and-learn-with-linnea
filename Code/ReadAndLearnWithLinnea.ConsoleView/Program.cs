using System;
using ReadAndLearnWithLinnea.App;
using ReadAndLearnWithLinnea.App.Common.Shuffle;

namespace ReadAndLearnWithLinnea.ConsoleView
{
    static class Program
    {
        static void Main()
        {
            var random = new Random();
            var fisherYatesShuffleAlgorithm = new FisherYatesShuffleAlgorithm(random);
            var vocabularyRepository = new VocabularyRepository();

            Startup.Run(new ConsoleView(), fisherYatesShuffleAlgorithm, vocabularyRepository);

            Console.ReadLine();
        }
    }
}
