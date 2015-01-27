namespace ReadAndLearnWithLinnea.Core
{
    public interface IScore
    {
        int NoOfCorrectAnswers { get; }
        int NoOfQuestions { get; }
        double PercentageCompleted { get; }
    }

    public class Score : IScore
    {
        public Score(int noOfCorrectAnswers, int noOfQuestions)
        {
            NoOfQuestions = noOfQuestions;
            NoOfCorrectAnswers = noOfCorrectAnswers;
        }

        public int NoOfCorrectAnswers { get; private set; }
        public int NoOfQuestions { get; private set; }

        public double PercentageCompleted
        {
            get
            {
                return NoOfCorrectAnswers / (double)NoOfQuestions;
            }
        }
    }
}