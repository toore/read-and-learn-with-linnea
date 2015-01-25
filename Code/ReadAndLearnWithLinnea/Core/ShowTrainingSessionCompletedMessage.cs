using System;

namespace ReadAndLearnWithLinnea.Core
{
    public class ShowTrainingSessionCompletedMessage
    {
        public ShowTrainingSessionCompletedMessage(TrainingSession trainingSession, Action continueWith)
        {
            TrainingSession = trainingSession;
            ContinueWith = continueWith;
        }

        public TrainingSession TrainingSession { get; private set; }
        public Action ContinueWith { get; set; }
    }
}