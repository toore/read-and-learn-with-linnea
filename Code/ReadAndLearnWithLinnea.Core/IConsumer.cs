using System;
using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public interface IConsumer
    {
        void SelectPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer);
        void NewPractise(IModerator moderator, IQuestion question);
        void PractiseCompleted(string name, int noOfCorrectAnswers, int noOfQuestions, Action continueWith);
    }
}