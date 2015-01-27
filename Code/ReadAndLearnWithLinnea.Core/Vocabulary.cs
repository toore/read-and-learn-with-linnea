using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IVocabulary
    {
        string Name { get; }
        IEnumerable<Vocable> Vocables { get; }
    }

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