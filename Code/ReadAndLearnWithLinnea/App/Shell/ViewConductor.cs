using System;
using System.Collections.Generic;
using ReadAndLearnWithLinnea.App.SelectTrainingView;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class ViewConductor :
        IHandle<ShowSelectTrainingViewMessage>,
        IHandle<ShowTrainingSessionViewMessage>,
        IHandle<UpdateTrainingSessionViewMessage>,
        IHandle<ShowTrainingSessionCompletedMessage>
    {
        private readonly WindowManager _windowManager;
        private readonly VocabularyRepository _vocabularyRepository;
        private readonly SelectVocabularyTrainingViewModelFactory _selectVocabularyTrainingViewModelFactory;
        private readonly TrainingSessionViewModelFactory _trainingSessionViewModelFactory;

        public ViewConductor(
            WindowManager windowManager, 
            VocabularyRepository vocabularyRepository,
            SelectVocabularyTrainingViewModelFactory selectVocabularyTrainingViewModelFactory, 
            TrainingSessionViewModelFactory trainingSessionViewModelFactory)
        {
            _windowManager = windowManager;
            _vocabularyRepository = vocabularyRepository;
            _selectVocabularyTrainingViewModelFactory = selectVocabularyTrainingViewModelFactory;
            _trainingSessionViewModelFactory = trainingSessionViewModelFactory;

            ViewModel = new MainViewModel();
        }

        public readonly MainViewModel ViewModel;

        public void Handle(ShowSelectTrainingViewMessage message)
        {
            var vocabularies = _vocabularyRepository.GetAll();
            ViewModel.Child = _selectVocabularyTrainingViewModelFactory.Create(vocabularies);
        }

        public void Handle(ShowTrainingSessionViewMessage message)
        {
            ViewModel.Child = _trainingSessionViewModelFactory.Create(message.TrainingSession);
        }

        public void Handle(UpdateTrainingSessionViewMessage message)
        {
            ViewModel.Child = _trainingSessionViewModelFactory.Create(message.TrainingSession);
        }

        public async void Handle(ShowTrainingSessionCompletedMessage message)
        {
            var trainingSession = message.TrainingSession;
            var name = trainingSession.Name;
            var noOfCorrectTranslations = trainingSession.NoOfCorrectAnswers;
            var totalWords = trainingSession.NoOfQuestions;
            var continueWith = message.ContinueWith;

            await _windowManager.ShowMessage(
                string.Format("Practies of {1} completed!{0}{0}You passed {2} of {3} ({4:P0}).",
                    Environment.NewLine, name, noOfCorrectTranslations, totalWords, noOfCorrectTranslations/(double) totalWords));

            continueWith.Invoke();
        }
    }
}