using ReadAndLearnWithLinnea.Bootstrapper;

namespace ReadAndLearnWithLinnea.ConsoleApp
{
    static class Program
    {
        static void Main()
        {
            var vocabularyTextParser = new VocabularyTextParser();
            var vocabularyRepository = new FileVocabularyRepository(vocabularyTextParser);

            Startup.Run(new ConsoleView(), vocabularyRepository);
        }
    }
}