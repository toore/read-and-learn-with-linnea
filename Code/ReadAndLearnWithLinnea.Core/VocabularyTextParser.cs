using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadAndLearnWithLinnea.Core
{
    public class VocabularyTextParser
    {
        public IVocabulary Parse(string name, StreamReader streamReader)
        {
            var content = streamReader.ReadToEnd();
            var textFormat = ParseTextFormat(content);

            var vocables = textFormat.Data
                .Select(x => GetVocable(x, textFormat.Languages))
                .ToList();

            var vocabulary = new Vocabulary(name, vocables);

            return vocabulary;
        }

        private TextFormat ParseTextFormat(string content)
        {
            var languages = ParseLanguages(content);

            var columnDefinitions = languages
                .Select(x => Convert(x))
                .ToList();

            var data =
                SplitLines(content)
                .Skip(1)
                .ToList();

            return new TextFormat(columnDefinitions, data);
        }

        private Vocable GetVocable(string data, IEnumerable<Language> languages)
        {
            var words = SplitColumns(data)
                .SelectMany((x, index) => GetWords(x, languages.ElementAt(index)))
                .ToList();

            var vocable = new Vocable(words);

            return vocable;
        }

        private IEnumerable<Word> GetWords(string data, Language language)
        {
            return SplitColumn(data)
                .Select(text => new Word(language, text));
        }

        private static IEnumerable<string> ParseLanguages(string content)
        {
            var languages = SplitLines(content)
                .Take(1)
                .Select(x => SplitColumns(x))
                .Single();

            return languages;
        }

        private IEnumerable<string> SplitColumn(string data)
        {
            return data.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static IEnumerable<string> SplitLines(string data)
        {
            return data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static IEnumerable<string> SplitColumns(string data)
        {
            return data.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static Language Convert(string language)
        {
            var languageKey = language.ToLowerInvariant();

            var validLanguages = new Dictionary<string, Language>
            {
                {"svenska", Language.Swedish},
                {"english", Language.English}
            };

            return validLanguages[languageKey];
        }

        private class TextFormat
        {
            public IEnumerable<Language> Languages { get; private set; }
            public IEnumerable<string> Data { get; private set; }

            public TextFormat(IEnumerable<Language> languages, IEnumerable<string> data)
            {
                Languages = languages;
                Data = data;
            }
        }
    }


}
