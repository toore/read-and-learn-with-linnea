namespace ReadAndLearnWithLinnea.Core
{
    public interface IScore
    {
        string Name { get; set; }
        int NoOfCorrectAnswers { get; }
        int NoOfQuestions { get; }
        double PercentageCompleted { get; }
    }
}