using System;
using System.Collections.Generic;
using ReadAndLearnWithLinnea.App;
using ReadAndLearnWithLinnea.WPF.QuestionAndAnswerView;
using ReadAndLearnWithLinnea.WPF.SelectVocabularyView;

namespace ReadAndLearnWithLinnea.WPF.Shell
{
    public class ViewConductor : IConsumer
    {
        private readonly WindowManager _windowManager;
        private readonly SelectVocabularyViewModelFactory _selectVocabularyViewModelFactory;
        private readonly QuestionViewModelFactory _questionViewModelFactory;

        public ViewConductor(
            WindowManager windowManager,
            SelectVocabularyViewModelFactory selectVocabularyViewModelFactory,
            QuestionViewModelFactory questionViewModelFactory)
        {
            _windowManager = windowManager;
            _selectVocabularyViewModelFactory = selectVocabularyViewModelFactory;
            _questionViewModelFactory = questionViewModelFactory;

            ViewModel = new MainViewModel();
        }

        public readonly MainViewModel ViewModel;

        public void SelectPractise(IEnumerable<IVocabulary> vocabularies, IPractiseInitializer practiseInitializer)
        {
            ViewModel.Child = _selectVocabularyViewModelFactory.Create(vocabularies, practiseInitializer);
        }

        public void PractiseStarted(TrainingSessionController trainingSessionController)
        {
            ViewModel.Child = _questionViewModelFactory.Create(trainingSessionController);
        }

        public async void PractiseCompleted(string name, int noOfCorrectAnswers, int noOfQuestions, Action continueWith)
        {
            await _windowManager.ShowMessage(
                string.Format("Practies of {1} completed!{0}{0}You passed {2} of {3} ({4:P0}).",
                    Environment.NewLine, name, noOfCorrectAnswers, noOfQuestions, noOfCorrectAnswers / (double)noOfQuestions));

            continueWith.Invoke();
        }
    }
}