using System.Collections.Generic;

namespace ReadAndLearnWithLinnea
{
    public class TrainingCategory
    {
        private readonly string _name;
        private readonly IList<Vocable> _vocables = new List<Vocable>();

        public TrainingCategory(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public IList<Vocable> Vocables
        {
            get { return _vocables; }
        }

        public void AddVocable(Vocable vocable)
        {
            _vocables.Add(vocable);
        }
    }
}