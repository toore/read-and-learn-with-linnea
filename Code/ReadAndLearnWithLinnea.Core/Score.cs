namespace ReadAndLearnWithLinnea.Core
{
    public class Score : IScore
    {
        public Score(string name, int noOfCorrectAnswers, int noOfQuestions)
        {
            Name = name;
            NoOfQuestions = noOfQuestions;
            NoOfCorrectAnswers = noOfCorrectAnswers;
        }

        public string Name { get; set; }
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