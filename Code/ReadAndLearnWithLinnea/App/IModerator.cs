namespace ReadAndLearnWithLinnea.App
{
    public interface IModerator
    {
        void Answer(IQuestion question, string text);
        bool CanAnswerQuestion(IQuestion question);
    }
}