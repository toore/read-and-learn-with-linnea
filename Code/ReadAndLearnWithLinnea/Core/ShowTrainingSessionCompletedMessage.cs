namespace ReadAndLearnWithLinnea.Core
{
    public class ShowTrainingSessionCompletedMessage
    {
        public ShowTrainingSessionCompletedMessage(TrainingSession trainingSession)
        {
            TrainingSession = trainingSession;
        }

        public TrainingSession TrainingSession { get; private set; }
    }
}