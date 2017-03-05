using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Vocable
    {
        public Vocable(IList<Word> words)
        {
            Words = words;
        }

        public IList<Word> Words { get; }
    }

    public class Word
    {
        public string Text { get; private set; }
        public Language Language { get; private set; }

        public Word(Language language, string text)
        {
            Language = language;
            Text = text;
        }
    }

    public enum Language
    {
        Swedish,
        English
    }
}