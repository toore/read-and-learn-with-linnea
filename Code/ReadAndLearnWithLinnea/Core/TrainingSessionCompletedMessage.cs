namespace ReadAndLearnWithLinnea.Core
{
    public class TrainingSessionCompletedMessage
    {
        public TrainingSessionCompletedMessage(TrainingSession trainingSession)
        {
            TrainingSession = trainingSession;
        }

        public TrainingSession TrainingSession { get; private set; }
    }
}