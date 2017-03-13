using ReadAndLearnWithLinnea.Bootstrapper;
using ReadAndLearnWithLinnea.XamarinPlat.QuestionAndAnswer;
using ReadAndLearnWithLinnea.XamarinPlat.SelectVocabulary;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ReadAndLearnWithLinnea.XamarinPlat
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