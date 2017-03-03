namespace ReadAndLearnWithLinnea.Core
{
    public class Score : IScore
    {
        public Score(string name, int noOfCorrectAnswers, int noOfQuestions)
        {
            Name = name;
            NumberOfQuestions = noOfQuestions;
            NumberOfCorrectAnswers = noOfCorrectAnswers;
        }

        public string Name { get; set; }
        public int NumberOfCorrectAnswers { get; private set; }
        public int NumberOfQuestions { get; private set; }

        public double PercentageCompleted
        {
            get
            {
                return NumberOfCorrectAnswers / (double)NumberOfQuestions;
            }
        }
    }
}