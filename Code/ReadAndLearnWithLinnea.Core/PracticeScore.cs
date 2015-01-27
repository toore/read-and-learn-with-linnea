namespace ReadAndLearnWithLinnea.Core
{
    public class PracticeScore
    {
        public PracticeScore(int noOfCorrectAnswers, int noOfQuestions)
        {
            NoOfQuestions = noOfQuestions;
            NoOfCorrectAnswers = noOfCorrectAnswers;
        }

        public int NoOfCorrectAnswers { get; private set; }
        public int NoOfQuestions { get; private set; }
    }
}