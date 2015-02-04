using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IConsumer
    {
        void SelectVocabularyToPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer);
        void NewQuestion(IQuestion question, IModerator moderator);
        void PractiseCompleted(IScore score, IApplicationInitializer applicationInitializer);
    }
}