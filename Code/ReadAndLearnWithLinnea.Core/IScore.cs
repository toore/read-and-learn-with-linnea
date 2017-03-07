namespace ReadAndLearnWithLinnea.Core
{
    public interface IScore
    {
        string Name { get; set; }
        int NumberOfCorrectAnswers { get; }
        int NumberOfQuestions { get; }
        double PercentageCompleted { get; }
    }
}