﻿using System.Collections.Generic;
using PropertyChanged;

namespace ReadAndLearnWithLinnea.WpfApp.PractiseView
{
    [ImplementPropertyChanged]
    public class QuestionViewModel
    {
        public string Text { get; set; }
        public IEnumerable<AnswerViewModel> AnswerViewModels { get; set; }
    }
}