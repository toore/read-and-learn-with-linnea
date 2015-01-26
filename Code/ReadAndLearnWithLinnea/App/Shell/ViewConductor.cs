using System;
using ReadAndLearnWithLinnea.App.SelectTrainingView;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class ViewConductor :
        IHandle<ShowSelectTrainingViewMessage>,
        IHandle<ShowTrainingSessionViewMessage>,
        IHandle<ShowTrainingSessionCompletedMessage>
    {
        private readonly WindowManager _windowManager;
        private readonly SelectVocabularyTrainingViewModelFactory _selectVocabularyTrainingViewModelFactory;
        private readonly QuestionViewModelFactory _questionViewModelFactory;

        public ViewConductor(
            WindowManager windowManager, 
            SelectVocabularyTrainingViewModelFactory selectVocabularyTrainingViewModelFactory, 
            QuestionViewModelFactory questionViewModelFactory)
        {
            _windowManager = windowManager;
            _selectVocabularyTrainingViewModelFactory = selectVocabularyTrainingViewModelFactory;
            _questionViewModelFactory = questionViewModelFactory;

            ViewModel = new MainViewModel();
        }

        public readonly MainViewModel ViewModel;

        public void Handle(ShowSelectTrainingViewMessage message)
        {
            ViewModel.Child = _selectVocabularyTrainingViewModelFactory.Create(message.Vocabularies);
        }

        public void Handle(ShowTrainingSessionViewMessage message)
        {
            ViewModel.Child = _questionViewModelFactory.Create(message.TrainingSessionController);
        }

        public async void Handle(ShowTrainingSessionCompletedMessage message)
        {
            var name = message.Name;
            var noOfCorrectTranslations = message.NoOfCorrectAnswers;
            var totalWords = message.NoOfQuestions;
            var continueWith = message.ContinueWith;

            await _windowManager.ShowMessage(
                string.Format("Practies of {1} completed!{0}{0}You passed {2} of {3} ({4:P0}).",
                    Environment.NewLine, name, noOfCorrectTranslations, totalWords, noOfCorrectTranslations/(double) totalWords));

            continueWith.Invoke();
        }
    }
}