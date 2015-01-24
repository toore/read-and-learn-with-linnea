using System.Collections;
using System.Collections.Generic;

namespace ReadAndLearnWithLinnea
{
    public class TrainingCategoriesViewModel
    {
        private readonly IEnumerable<TrainingCategory> _trainingCategories;

        public TrainingCategoriesViewModel(IEnumerable<TrainingCategory> trainingCategories)
        {
            _trainingCategories = trainingCategories;
        }

        public IEnumerable TrainingCategories
        {
            get { return _trainingCategories; }
        }
    }
}