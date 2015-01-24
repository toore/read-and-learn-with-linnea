using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadAndLearnWithLinnea
{
    public class Vocable
    {
        private readonly IEnumerable<LanguageWord> _words;

        public Vocable(params LanguageWord[] words)
        {
            if (!IsAllLanguagesSet(words))
            {
                throw new NotAllLanguagesWasSetException(words);
            }

            _words = words;
        }

        private bool IsAllLanguagesSet(IEnumerable<LanguageWord> words)
        {
            IEnumerable<Language> allLanguages = (Language[]) Enum.GetValues(typeof (Language));

            var languages = words.Select(x => x.Language);

            var isAllLanguagesSet = allLanguages
                .All(x => languages.Contains(x) );

            return isAllLanguagesSet;
        }
    }

    public class NotAllLanguagesWasSetException : ApplicationException
    {
        public LanguageWord[] Words { get; private set; }

        public NotAllLanguagesWasSetException(LanguageWord[] words)
        {
            Words = words;
        }
    }

    public class LanguageWord
    {
        public string Text { get; private set; }
        public Language Language { get; private set; }

        public LanguageWord(Language language, string text)
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