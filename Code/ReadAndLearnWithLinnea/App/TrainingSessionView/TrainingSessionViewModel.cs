using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class TrainingSessionViewModel
    {
        public TrainingSessionViewModel(string text, IEnumerable<TranslationCandidateViewModel> translationCandidateViewModels)
        {
            TranslationCandidateViewModels = translationCandidateViewModels;
            Text = text;
        }

        public readonly string Text;
        public readonly IEnumerable<TranslationCandidateViewModel> TranslationCandidateViewModels;
    }
}