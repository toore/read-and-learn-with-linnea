namespace ReadAndLearnWithLinnea.App
{
    public class TrainingSessionResult
    {
        public TrainingSessionResult(int noOfCorrectAnswers, int noOfQuestions)
        {
            NoOfQuestions = noOfQuestions;
            NoOfCorrectAnswers = noOfCorrectAnswers;
        }

        public int NoOfCorrectAnswers { get; private set; }
        public int NoOfQuestions { get; private set; }
    }
}