namespace ReadAndLearnWithLinnea.Core
{
    public class ShowTrainingSessionViewMessage
    {
        public ShowTrainingSessionViewMessage(TrainingSessionController trainingSessionController)
        {
            TrainingSessionController = trainingSessionController;
        }

        public TrainingSessionController TrainingSessionController { get; private set; }
    }
}