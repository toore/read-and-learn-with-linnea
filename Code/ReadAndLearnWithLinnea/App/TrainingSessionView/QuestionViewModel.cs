using System.Collections.Generic;
using PropertyChanged;

namespace ReadAndLearnWithLinnea.App.TrainingSessionView
{
    [ImplementPropertyChanged]
    public class QuestionViewModel
    {
        public string Text { get; set; }
        public IEnumerable<AnswerViewModel> AnswerViewModels { get; set; }
    }
}