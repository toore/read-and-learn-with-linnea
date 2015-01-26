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
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var windowManager = new WindowManager(mainWindow);
            var selectVocabularyViewModelFactory = new SelectVocabularyViewModelFactory();
            var questionViewModelFactory = new QuestionViewModelFactory();
            var viewConductor = new ViewConductor(windowManager, selectVocabularyViewModelFactory, questionViewModelFactory);

            var fisherYatesShuffleAlgorithm = new FisherYatesShuffleAlgorithm(new Random());
            var vocabularyRepository = new VocabularyRepository();

            ReadAndLearnWithLinnea.App.Startup.Run(viewConductor, fisherYatesShuffleAlgorithm, vocabularyRepository);

            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}