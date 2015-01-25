using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    public class TrainingSessionViewModel
    {
        public TrainingSessionViewModel(string text, IEnumerable<AnswerViewModel> translationCandidateViewModels)
        {
            TranslationCandidateViewModels = translationCandidateViewModels;
            Text = text;
        }

        public string Text { get; set; }
        public IEnumerable<AnswerViewModel> TranslationCandidateViewModels { get; set; }
    }
}