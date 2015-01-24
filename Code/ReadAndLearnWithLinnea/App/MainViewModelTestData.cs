using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App
{
    public class MainViewModelTestData : MainViewModel
    {
        public MainViewModelTestData()
        {
            Child = new VocabulariesViewModel(new VocabulariesViewModelFactory(null).Create(
                new[] {new Vocabulary("animals"), new Vocabulary("cars"), new Vocabulary("science")})
                .VocabularyViewModels);
        }
    }
}