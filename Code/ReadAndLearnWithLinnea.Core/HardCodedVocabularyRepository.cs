using System.Collections.Generic;

namespace ReadAndLearnWithLinnea.Core
{
    public class HardCodedVocabularyRepository : IVocabularyRepository
    {
        public IEnumerable<IVocabulary> GetAll()
        {
            yield return CreateHouseAndGardenVocables();
            yield return CreateFurnitureVocables();
        }

        private static Vocabulary CreateHouseAndGardenVocables()
        {
            var houseAndGardenVocables = new Vocabulary("House and garden");

            houseAndGardenVocables.AddSwedishEnglish("Hus", "House");
            houseAndGardenVocables.AddSwedishEnglish("Trädgård", "Garden");
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
    }
}