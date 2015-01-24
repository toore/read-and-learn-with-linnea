using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.App.VocabulariesView;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class MainViewModelTestData : MainViewModel
    {
        public MainViewModelTestData()
        {
            Child = new VocabulariesViewModel(new VocabulariesViewModelFactory(null).Create(
                new[] {new Vocabulary("animals"), new Vocabulary("cars"), new Vocabulary("science")})
                .VocabularyViewModels);

            Child = new TrainingSessionViewModelFactory().Create(
                new[]
                {new Vocable(new Word(Language.English, "english word"), new Word(Language.Swedish, "svensk ord"))});

        }
    }
}