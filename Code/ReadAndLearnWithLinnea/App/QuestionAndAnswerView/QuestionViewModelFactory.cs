﻿using System.Linq;
using ReadAndLearnWithLinnea.Common.Shuffle;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.QuestionAndAnswerView
{
    public class QuestionViewModelFactory
    {
        public QuestionViewModel Create(TrainingSessionController trainingSessionController)
        {
            var questionViewModel = new QuestionViewModel();
            trainingSessionController.QuestionUpdated = () => UpdateViewModel(questionViewModel, trainingSessionController);

            UpdateViewModel(questionViewModel, trainingSessionController);

            return questionViewModel;
        }

        private void UpdateViewModel(QuestionViewModel questionViewModel, TrainingSessionController trainingSessionController)
        {
            var question = trainingSessionController.Question;

            var answerViewModels = question.Answers
                .Select(text => CreateAnswerViewModel(text, trainingSessionController));

            questionViewModel.Text = question.Text;
            questionViewModel.AnswerViewModels = answerViewModels;
        }

        private AnswerViewModel CreateAnswerViewModel(string text, TrainingSessionController trainingSessionController)
        {
            return new AnswerViewModel(text, trainingSessionController.Question, trainingSessionController);
        }
    }
}