namespace ReadAndLearnWithLinnea.Core
{
    public class UpdateTrainingSessionViewMessage
    {
        public UpdateTrainingSessionViewMessage(TrainingSession trainingSession)
        {
            TrainingSession = trainingSession;
        }

        public TrainingSession TrainingSession { get; private set; }
    }
}