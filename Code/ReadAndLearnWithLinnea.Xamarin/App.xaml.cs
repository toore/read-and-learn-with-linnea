using ReadAndLearnWithLinnea.Bootstrapper;
using Xamarin.QuestionAndAnswer;
using Xamarin.SelectVocabulary;

namespace Xamarin
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            var consumer = new ViewConductor(
                this,
                new SelectVocabularyViewModelFactory(),
                new QuestionViewModelFactory());

            var vocabularyRepository = new HardcodedVocabularyRepository();

            Startup.Run(consumer, vocabularyRepository);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}