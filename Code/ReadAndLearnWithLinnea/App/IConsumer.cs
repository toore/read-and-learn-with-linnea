using System;
using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App
{
    public interface IConsumer
    {
        void SelectPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer);
        void PractiseStarted(TrainingSessionController trainingSessionController);
        void PractiseCompleted(string name, int noOfCorrectAnswers, int noOfQuestions, Action continueWith);
    }
}