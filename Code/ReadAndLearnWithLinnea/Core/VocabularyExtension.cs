using System.Linq;

namespace ReadAndLearnWithLinnea.Core
{
    public static class VocabularyExtension
    {
        public static void AddSwedishEnglish(this Vocabulary vocabulary, string swedish, string english)
        {
            var vocable = new Vocable(new[]
            {
                new Word(Language.Swedish, swedish), 
                new Word(Language.English, english)
            });

            vocabulary.AddVocable(vocable);
        }

        public static void AddSwedishEnglishAndEnglishAlternative(this Vocabulary vocabulary, string swedish, string english, string englishAlternative)
        {
            var vocable = new Vocable(new[]
            {
                new Word(Language.Swedish, swedish), 
                new Word(Language.English, english),
                new Word(Language.English, englishAlternative)
            });
            vocabulary.AddVocable(vocable);
        }

        public static string GetText(this Vocable vocable, Language language)
        {
            return vocable.Words.Single(x => x.Language == language).Text;
        }
    }
}