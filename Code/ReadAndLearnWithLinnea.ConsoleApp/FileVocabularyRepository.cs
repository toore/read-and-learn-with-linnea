using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadAndLearnWithLinnea.Core.Tools
{
    public class FileVocabularyRepository : IVocabularyRepository
    {
        private readonly VocabularyTextParser _vocabularyTextParser;

        public FileVocabularyRepository(VocabularyTextParser vocabularyTextParser)
        {
            _vocabularyTextParser = vocabularyTextParser;
        }

        public IEnumerable<IVocabulary> GetAll()
        {
            var currentDirectory = Environment.CurrentDirectory;
            const string vocabularyFileSearchPattern = "*.txt";

            var vocabularyFiles = Directory.EnumerateFiles(currentDirectory, vocabularyFileSearchPattern);

            var vocabularies = vocabularyFiles
                .Select(path => CreateVocabulary(path))
                .ToList();

            return vocabularies;
        }

        private IVocabulary CreateVocabulary(string path)
        {
            var name = Path.GetFileNameWithoutExtension(path);
            var streamReader = new StreamReader(path);

            var vocabulary = _vocabularyTextParser.Parse(name, streamReader);

            return vocabulary;
        }
    }
}