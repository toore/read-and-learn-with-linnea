using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadAndLearnWithLinnea.Core
{
    public class Vocable
    {
        private readonly IEnumerable<Word> _words;

        public Vocable(params Word[] words)
        {
            if (!IsAllLanguagesSet(words))
            {
                throw new AllLanguagesNeedsToBeDefinedException(words);
            }

            _words = words;
        }

        private static bool IsAllLanguagesSet(IEnumerable<Word> words)
        {
            IEnumerable<Language> allLanguages = (Language[])Enum.GetValues(typeof(Language));

            var languages = words.Select(x => x.Language);

            var isAllLanguagesSet = allLanguages
                .All(x => languages.Contains(x));

            return isAllLanguagesSet;
        }
    }

    public class AllLanguagesNeedsToBeDefinedException : ApplicationException
    {
        public Word[] Words { get; private set; }

        public AllLanguagesNeedsToBeDefinedException(Word[] words)
        {
            Words = words;
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