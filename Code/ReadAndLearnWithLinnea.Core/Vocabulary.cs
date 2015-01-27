using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class Vocabulary : IVocabulary
    {
        private readonly string _name;
        private readonly List<Vocable> _vocables = new List<Vocable>();

        public Vocabulary(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public IEnumerable<Vocable> Vocables
        {
            get { return _vocables; }
        }

        public void AddVocable(Vocable vocable)
        {
            _vocables.Add(vocable);
        }
    }
}