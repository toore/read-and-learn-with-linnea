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
        private readonly SelectVocabularyTrainingViewModelFactory _selectVocabularyTrainingViewModelFactory;
        private readonly TrainingSessionViewModelFactory _trainingSessionViewModelFactory;

        public ViewConductor(WindowManager windowManager, SelectVocabularyTrainingViewModelFactory selectVocabularyTrainingViewModelFactory, TrainingSessionViewModelFactory trainingSessionViewModelFactory)
        {
            _windowManager = windowManager;
            _selectVocabularyTrainingViewModelFactory = selectVocabularyTrainingViewModelFactory;
            _trainingSessionViewModelFactory = trainingSessionViewModelFactory;

            ViewModel = new MainViewModel();
        }

        public readonly MainViewModel ViewModel;

        public void Handle(ShowSelectTrainingViewMessage message)
        {
            ViewModel.Child = _selectVocabularyTrainingViewModelFactory.Create(GetTrainingCategories());
        }

        private static IEnumerable<Vocabulary> GetTrainingCategories()
        {
            yield return CreateHouseAndGardenVocables();
            yield return CreateFurnitureVocables();
        }

        private static Vocabulary CreateHouseAndGardenVocables()
        {
            var houseAndGardenVocables = new Vocabulary("House and garden");

            houseAndGardenVocables.AddSwedishEnglish("Hus", "House");
            houseAndGardenVocables.AddSwedishEnglishAndEnglishAlternative("Lägenhet", "Apartment", "Flat");
            houseAndGardenVocables.AddSwedishEnglish("Grind", "Gate");
            houseAndGardenVocables.AddSwedishEnglish("Fönster", "Window");
            houseAndGardenVocables.AddSwedishEnglish("Dörr (entré)", "Frontdoor");
            houseAndGardenVocables.AddSwedishEnglish("Tak (ute)", "Roof");
            houseAndGardenVocables.AddSwedishEnglish("Tak (inne)", "Ceiling");
            houseAndGardenVocables.AddSwedishEnglish("Balkong", "Balcony");
            houseAndGardenVocables.AddSwedishEnglish("Brevlåda", "Letter box");
            houseAndGardenVocables.AddSwedishEnglish("Staket", "Fence");

            return houseAndGardenVocables;
        }

        private static Vocabulary CreateFurnitureVocables()
        {
            var furnitureVocables = new Vocabulary("Furniture");

            furnitureVocables.AddSwedishEnglish("Möbler", "Furniture");
            furnitureVocables.AddSwedishEnglish("Soffa", "Sofa");
            furnitureVocables.AddSwedishEnglish("Bord", "Table");
            furnitureVocables.AddSwedishEnglish("Gardin", "Curtain");
            furnitureVocables.AddSwedishEnglish("Bokhylla", "Bookshelf");
            furnitureVocables.AddSwedishEnglish("Stol", "Chair");
            furnitureVocables.AddSwedishEnglish("Säng", "Bed");
            furnitureVocables.AddSwedishEnglish("Byrå", "Drawer");
            furnitureVocables.AddSwedishEnglish("Matta", "Carpet");
                
            return furnitureVocables;
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
            var wordsTranslated = trainingSession.NoOfCorrectTranslations;
            var totalWords = trainingSession.TotalWords;

            await _windowManager.ShowMessage(
                string.Format("Training of {0} completed!{1}{1}You passed {2} of {3} ({4:P0}).",
                name, Environment.NewLine, wordsTranslated, totalWords, wordsTranslated / (double)totalWords));

            message.ContinueWith();
        }
    }
}