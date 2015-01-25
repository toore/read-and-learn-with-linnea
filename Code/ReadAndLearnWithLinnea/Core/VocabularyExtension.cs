using System.Linq;

namespace ReadAndLearnWithLinnea.Core
{
    public static class VocabularyExtension
    {
        public static void AddSwedishEnglish(this Vocabulary vocabulary, string swedish, string english)
        {
            var vocable = new Vocable();
            vocable.AddWord(new Word(Language.Swedish, swedish));
            vocable.AddWord(new Word(Language.English, english));

            vocabulary.AddVocable(vocable);
        }

        public static void AddSwedishEnglishAndEnglishAlternative(this Vocabulary vocabulary, string swedish, string english, string englishAlternative)
        {
            var vocable = new Vocable();
            vocable.AddWord(new Word(Language.Swedish, swedish));
            vocable.AddWord(new Word(Language.English, english));
            vocable.AddWord(new Word(Language.English, englishAlternative));

            vocabulary.AddVocable(vocable);
        }
    }
}