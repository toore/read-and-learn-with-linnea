using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.WpfApp.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WpfApp.Shell
{
    public class MainViewModelTestData : MainViewModel
    {
        public MainViewModelTestData()
        {
            Child = new SelectVocabularyViewModel(new SelectVocabularyViewModelFactory().Create(
                new[] {new Vocabulary("animals"), new Vocabulary("cars"), new Vocabulary("science")},
                null)
                .VocabularyViewModels);
        }
    }
}