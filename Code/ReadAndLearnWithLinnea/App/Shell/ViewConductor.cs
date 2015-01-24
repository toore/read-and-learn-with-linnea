using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.App.VocabulariesView;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class ViewConductor : IHandle<ShowVocabulariesViewMessage>, IHandle<ShowTrainingSessionViewMessage>
    {
        private readonly VocabulariesViewModelFactory _vocabulariesViewModelFactory;
        private readonly TrainingSessionViewModelFactory _trainingSessionViewModelFactory;

        public ViewConductor(VocabulariesViewModelFactory vocabulariesViewModelFactory, TrainingSessionViewModelFactory trainingSessionViewModelFactory)
        {
            _vocabulariesViewModelFactory = vocabulariesViewModelFactory;
            _trainingSessionViewModelFactory = trainingSessionViewModelFactory;

            ViewModel = new MainViewModel();
        }

        public readonly MainViewModel ViewModel;

        public void Handle(ShowVocabulariesViewMessage message)
        {
            ViewModel.Child = _vocabulariesViewModelFactory.Create(GetTrainingCategories());
        }

        private static IEnumerable<Vocabulary> GetTrainingCategories()
        {
            yield return CreateHouseAndGardenVocables();
            yield return CreateFurnitureVocables();

            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
            //yield return CreateHouseAndGardenVocables();
            //yield return CreateFurnitureVocables();
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
            ViewModel.Child = _trainingSessionViewModelFactory.Create(message.Vocables);
        }
    }
}