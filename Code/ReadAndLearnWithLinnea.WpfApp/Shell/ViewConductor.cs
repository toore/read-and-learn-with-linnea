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

        public async void PractiseCompleted(string name, IScore score, Action continueWith)
        {
            await _windowManager.ShowMessage(
                string.Format("Practies of {1} completed!{0}{0}You passed {2} of {3} ({4:P0}).",
                Environment.NewLine,
                name,
                score.NoOfCorrectAnswers,
                score.NoOfQuestions,
                score.PercentageCompleted));

            continueWith.Invoke();
        }
    }
}