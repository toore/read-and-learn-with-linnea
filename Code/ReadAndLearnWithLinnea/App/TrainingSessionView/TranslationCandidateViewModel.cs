namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class TranslationCandidateViewModel
    {
        private readonly CandidateResult _candidateResult;

        public TranslationCandidateViewModel(string text, CandidateResult candidateResult)
        {
            Text = text;
            _candidateResult = candidateResult;
        }

        public readonly string Text;
    }
}