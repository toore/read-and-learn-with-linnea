namespace ReadAndLearnWithLinnea.Core
{
    public interface IScore
    {
        int NoOfCorrectAnswers { get; }
        int NoOfQuestions { get; }
        double PercentageCompleted { get; }
    }
}