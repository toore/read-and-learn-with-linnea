using System.Collections.Generic;

namespace ReadAndLearnWithLinnea
{
    public class TrainingCategoriesViewModelTestData : TrainingCategoriesViewModel
    {
        public TrainingCategoriesViewModelTestData()
            : this(
                new[] {new TrainingCategory("animals"), new TrainingCategory("cars"), new TrainingCategory("science"),})
        {
        }

        private TrainingCategoriesViewModelTestData(IEnumerable<TrainingCategory> trainingCategories)
            : base(trainingCategories)
        {
        }
    }
}