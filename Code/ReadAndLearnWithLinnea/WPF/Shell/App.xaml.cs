using System;
using System.Windows;
using ReadAndLearnWithLinnea.App;
using ReadAndLearnWithLinnea.Common.Shuffle;
using ReadAndLearnWithLinnea.WPF.QuestionAndAnswerView;
using ReadAndLearnWithLinnea.WPF.SelectVocabularyView;

namespace ReadAndLearnWithLinnea.WPF.Shell
{
    public partial class App
    {
        // Reference must be kept to prevent garbage collection
        private ViewConductor _viewConductor;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var windowManager = new WindowManager(mainWindow);
            var selectVocabularyViewModelFactory = new SelectVocabularyViewModelFactory();
            var questionViewModelFactory = new QuestionViewModelFactory();
            _viewConductor = new ViewConductor(windowManager, selectVocabularyViewModelFactory, questionViewModelFactory);

            var fisherYatesShuffleAlgorithm = new FisherYatesShuffleAlgorithm(new Random());
            var vocabularyRepository = new VocabularyRepository();
            var startup = new Startup(_viewConductor, fisherYatesShuffleAlgorithm, vocabularyRepository);

            startup.Run();

            mainWindow.DataContext = _viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}