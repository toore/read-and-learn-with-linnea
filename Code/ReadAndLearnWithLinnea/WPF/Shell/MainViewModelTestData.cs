using ReadAndLearnWithLinnea.App;
using ReadAndLearnWithLinnea.WPF.WPF.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WPF.WPF.Shell
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