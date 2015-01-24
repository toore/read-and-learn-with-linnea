using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
{
    public class StartTrainingSessionMessage
    {
        private readonly Vocabulary _vocabulary;

        public StartTrainingSessionMessage(Vocabulary vocabulary)
        {
            _vocabulary = vocabulary;
        }
    }
}