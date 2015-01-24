using System.Collections.Generic;
using System.Windows;

namespace ReadAndLearnWithLinnea
{
    public partial class App
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.DataContext = new TrainingCategoriesViewModel(GetTrainingCategories());
            mainWindow.Show();
        }

        private static IEnumerable<TrainingCategory> GetTrainingCategories()
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

        private static TrainingCategory CreateHouseAndGardenVocables()
        {
            var houseAndGardenVocables = new TrainingCategory("House and garden");

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

        private static TrainingCategory CreateFurnitureVocables()
        {
            var furnitureVocables = new TrainingCategory("Furniture");
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

    public static class AppSetupExtensions
    {
        public static void AddSwedishEnglish(this TrainingCategory category, string swedish, string english)
        {
            var vocable = new Vocable(new[]
            {
                new LanguageWord(Language.Swedish, swedish), 
                new LanguageWord(Language.English, english)
            });

            category.AddVocable(vocable);
        }

        public static void AddSwedishEnglishAndEnglishAlternative(this TrainingCategory category, string swedish, string english, string englishAlternative)
        {
            var vocable = new Vocable(new[]
            {
                new LanguageWord(Language.Swedish, swedish), 
                new LanguageWord(Language.English, english),
                new LanguageWord(Language.English, englishAlternative)
            });
            category.AddVocable(vocable);
        }
    }
}