using System.Collections.Generic;
using System.Linq;
using ReadAndLearnWithLinnea.App.SelectTrainingView;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class ViewConductor : IHandle<ShowSelectTrainingViewMessage>, IHandle<ShowTrainingSessionViewMessage>
    {
        private readonly SelectTrainingViewModelFactory _selectTrainingViewModelFactory;
        private readonly TrainingSessionViewModelFactory _trainingSessionViewModelFactory;

        public ViewConductor(SelectTrainingViewModelFactory selectTrainingViewModelFactory, TrainingSessionViewModelFactory trainingSessionViewModelFactory)
        {
            _selectTrainingViewModelFactory = selectTrainingViewModelFactory;
            _trainingSessionViewModelFactory = trainingSessionViewModelFactory;

            ViewModel = new MainViewModel();
        }

        public readonly MainViewModel ViewModel;

        public void Handle(ShowSelectTrainingViewMessage message)
        {
            ViewModel.Child = _selectTrainingViewModelFactory.Create(GetTrainingCategories());
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