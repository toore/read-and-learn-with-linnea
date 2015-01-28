using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.WpfApp.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WpfApp.Shell
{
    public class MainViewModelTestData : MainViewModel
    {
        public MainViewModelTestData()
        {
            Child = new SelectVocabularyViewModel(new SelectVocabularyViewModelFactory().Create(
                new[] {new Vocabulary("animals", null), new Vocabulary("cars", null), new Vocabulary("science", null)},
                null)
                .VocabularyViewModels);
        }
    }
}