using ReadAndLearnWithLinnea.App.SelectTrainingView;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class MainViewModelTestData : MainViewModel
    {
        public MainViewModelTestData()
        {
            Child = new SelectTrainingViewModel(new SelectTrainingViewModelFactory(null).Create(
                new[] {new Vocabulary("animals"), new Vocabulary("cars"), new Vocabulary("science")})
                .VocabularyViewModels);

            Child = new TrainingSessionViewModelFactory().Create(
                new[]
                {
                    new Vocable(new Word(Language.English, "english word"), new Word(Language.Swedish, "svensk ord")),
                    new Vocable(new Word(Language.English, "english word 2"), new Word(Language.Swedish, "svensk ord 2")),
                    new Vocable(new Word(Language.English, "english word 3"), new Word(Language.Swedish, "svensk ord 3")),
                    new Vocable(new Word(Language.English, "english word 4"), new Word(Language.Swedish, "svensk ord 4"))
                });

        }
    }
}