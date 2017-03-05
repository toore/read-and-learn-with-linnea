using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Vocabulary : IVocabulary
    {
        public Vocabulary(string name, IList<Vocable> vocables)
        {
            Name = name;
            Vocables = vocables;
        }

        public string Name { get; }

        public IList<Vocable> Vocables { get; }
    }
}