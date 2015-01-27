using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App
{
    public class Vocable
    {
        private readonly List<Word> _words = new List<Word>();

        public void AddWord(Word word)
        {
            _words.Add(word);
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