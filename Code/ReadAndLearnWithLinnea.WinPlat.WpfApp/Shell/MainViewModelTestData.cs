using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.WinPlat.WpfApp.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WinPlat.WpfApp.Shell
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