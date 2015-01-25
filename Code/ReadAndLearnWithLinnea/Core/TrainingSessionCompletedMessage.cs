namespace ReadAndLearnWithLinnea.Core
{
    public class TrainingSessionCompletedMessage
    {
        public TrainingSessionCompletedMessage(TrainingSessionController trainingSessionController)
        {
            TrainingSessionController = trainingSessionController;
        }

        public TrainingSessionController TrainingSessionController { get; private set; }
    }
}