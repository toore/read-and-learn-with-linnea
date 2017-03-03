using System;
using System.Collections.Generic;
using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.WpfApp.PractiseView;
using ReadAndLearnWithLinnea.WpfApp.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WpfApp.Shell
{
    public class ViewConductor : IConsumer
    {
        private readonly WindowManager _windowManager;
        private readonly SelectVocabularyViewModelFactory _selectVocabularyViewModelFactory;
        private readonly QuestionViewModelFactory _questionViewModelFactory;
        private readonly Lazy<QuestionViewModel> _questionViewModel;

        public ViewConductor(
            WindowManager windowManager,
            SelectVocabularyViewModelFactory selectVocabularyViewModelFactory,
            QuestionViewModelFactory questionViewModelFactory)
        {
            _windowManager = windowManager;
            _selectVocabularyViewModelFactory = selectVocabularyViewModelFactory;
            _questionViewModelFactory = questionViewModelFactory;

            _questionViewModel = new Lazy<QuestionViewModel>(() => CreateQuestionViewModel());

            ViewModel = new MainViewModel();
        }

        public readonly MainViewModel ViewModel;

        public void SelectVocabularyToPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer)
        {
            ViewModel.Child = _selectVocabularyViewModelFactory.Create(vocabularies, practiseInitializer);
        }

        public void NewQuestion(IQuestion question, IModerator moderator)
        {
            var questionViewModel = _questionViewModel.Value;
            _questionViewModelFactory.UpdateViewModel(questionViewModel, moderator, question);

            ViewModel.Child = questionViewModel;
        }

        private QuestionViewModel CreateQuestionViewModel()
        {
            return _questionViewModelFactory.Create();
        }

        public async void PractiseCompleted(IScore score, IApplicationInitializer applicationInitializer)
        {
            var name = score.Name;
            var numberOfCorrectAnswers = score.NumberOfCorrectAnswers;
            var numberOfQuestions = score.NumberOfQuestions;
            var percentageCompleted = score.PercentageCompleted;

            var newLine = Environment.NewLine;

            await _windowManager.ShowMessage(
                $"Practies of {name} completed!{newLine}{newLine}You passed {numberOfCorrectAnswers} of {numberOfQuestions} ({percentageCompleted:P0}).");

            applicationInitializer.StartOver();
        }
    }
}