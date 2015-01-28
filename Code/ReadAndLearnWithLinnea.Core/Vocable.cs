using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Vocable
    {
        private readonly IEnumerable<Word> _words = new List<Word>();

        public Vocable(IEnumerable<Word> words)
        {
            _words = words;
        }

        public IEnumerable<Word> Words
        {
            get { return _words; }
        }
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