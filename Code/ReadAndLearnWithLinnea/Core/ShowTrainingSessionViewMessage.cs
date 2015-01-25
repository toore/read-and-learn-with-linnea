namespace ReadAndLearnWithLinnea.Core
{
    public class ShowTrainingSessionViewMessage
    {
        public ShowTrainingSessionViewMessage(TrainingSession trainingSession)
        {
            TrainingSession = trainingSession;
        }

        public TrainingSession TrainingSession { get; private set; }
    }
}