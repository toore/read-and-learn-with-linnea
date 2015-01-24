using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
{
    public partial class App
    {
        private EventAggregator _eventAggregator;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _eventAggregator = new EventAggregator();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = new TrainingCategoriesViewModelFactory(_eventAggregator).Create(GetTrainingCategories());
            mainWindow.Show();
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
            houseAndGardenVocables.AddSwedishEnglish("Stake", "Fence");

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
    }

    public class TrainingCategoriesViewModelFactory
    {
        private readonly EventAggregator _eventAggregator;

        public TrainingCategoriesViewModelFactory(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public VocabulariesViewModel Create(IEnumerable<Vocabulary> trainingCategories)
        {
            var trainingCategoryViewModels = CreateTrainingCategoryViewModels(trainingCategories);

            var trainingCategoriesViewModel = new VocabulariesViewModel(trainingCategoryViewModels);
            return trainingCategoriesViewModel;
        }

        private IEnumerable<VocabularyViewModel> CreateTrainingCategoryViewModels(IEnumerable<Vocabulary> trainingCategories)
        {
            var trainingCategoryViewModels = trainingCategories.Select(Create).ToList();
            return trainingCategoryViewModels;
        }

        private VocabularyViewModel Create(Vocabulary vocabulary)
        {
            var trainingCategoryViewModel = new VocabularyViewModel(vocabulary, _eventAggregator);
            return trainingCategoryViewModel;
        }
    }

    public static class AppSetupExtensions
    {
        public static void AddSwedishEnglish(this Vocabulary category, string swedish, string english)
        {
            var vocable = new Vocable(new[]
            {
                new Word(Language.Swedish, swedish), 
                new Word(Language.English, english)
            });

            category.AddVocable(vocable);
        }

        public static void AddSwedishEnglishAndEnglishAlternative(this Vocabulary category, string swedish, string english, string englishAlternative)
        {
            var vocable = new Vocable(new[]
            {
                new Word(Language.Swedish, swedish), 
                new Word(Language.English, english),
                new Word(Language.English, englishAlternative)
            });
            category.AddVocable(vocable);
        }
    }
}