using System;

namespace ReadAndLearnWithLinnea.Core
{
    public class ShowTrainingSessionCompletedMessage
    {
        public ShowTrainingSessionCompletedMessage(string name, int noOfCorrectAnswers, int noOfQuestions, Action continueWith)
        {
            NoOfQuestions = noOfQuestions;
            NoOfCorrectAnswers = noOfCorrectAnswers;
            Name = name;
            ContinueWith = continueWith;
        }

        public string Name { get; private set; }
        public int NoOfCorrectAnswers { get; private set; }
        public int NoOfQuestions { get; private set; }

        public Action ContinueWith { get; private set; }
    }
}