using System.Collections.Generic;
using PropertyChanged;

namespace ReadAndLearnWithLinnea.WPF.WPF.PractiseView
{
    [ImplementPropertyChanged]
    public class QuestionViewModel
    {
        public string Text { get; set; }
        public IEnumerable<AnswerViewModel> AnswerViewModels { get; set; }
    }
}