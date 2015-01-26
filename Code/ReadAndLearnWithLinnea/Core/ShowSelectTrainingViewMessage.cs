using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class ShowSelectTrainingViewMessage
    {
        public ShowSelectTrainingViewMessage(IEnumerable<Vocabulary> vocabularies)
        {
            Vocabularies = vocabularies;
        }

        public IEnumerable<Vocabulary> Vocabularies { get; private set; }
    }
}