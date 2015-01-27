using System;
using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IConsumer
    {
        void SelectVocabularyToPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer);
        void NewQuestion(IQuestion question, IModerator moderator);
        void PractiseCompleted(string name, IScore score, Action continueWith);
    }
}