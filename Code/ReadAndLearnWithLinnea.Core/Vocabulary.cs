using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Vocabulary : IVocabulary
    {
        private readonly string _name;
        private readonly IEnumerable<Vocable> _vocables = new List<Vocable>();

        public Vocabulary(string name, IEnumerable<Vocable> vocables)
        {
            _name = name;
            _vocables = vocables;
        }

        public string Name
        {
            get { return _name; }
        }

        public IEnumerable<Vocable> Vocables
        {
            get { return _vocables; }
        }
    }
}