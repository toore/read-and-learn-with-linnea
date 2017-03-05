using ReadAndLearnWithLinnea.Bootstrapper;
using ReadAndLearnWithLinnea.Shared.QuestionAndAnswer;
using ReadAndLearnWithLinnea.Shared.SelectVocabulary;

namespace ReadAndLearnWithLinnea.Shared
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

            Startup.Run(consumer);
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