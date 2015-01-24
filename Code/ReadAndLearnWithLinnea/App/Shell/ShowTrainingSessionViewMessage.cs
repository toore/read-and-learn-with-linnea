using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class ShowTrainingSessionViewMessage
    {
        private readonly Vocabulary _vocabulary;

        public ShowTrainingSessionViewMessage(Vocabulary vocabulary)
        {
            _vocabulary = vocabulary;
        }

        public IList<Vocable> Vocables
        {
            get { return _vocabulary.Vocables.Take(4).ToList(); }
        }
    }
}