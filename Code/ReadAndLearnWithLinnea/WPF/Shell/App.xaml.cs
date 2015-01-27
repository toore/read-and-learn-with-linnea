using System;
using System.Windows;
using ReadAndLearnWithLinnea.App;
using ReadAndLearnWithLinnea.App.Common.Shuffle;
using ReadAndLearnWithLinnea.WPF.WPF.PractiseView;
using ReadAndLearnWithLinnea.WPF.WPF.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WPF.WPF.Shell
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

            var random = new Random();
            var fisherYatesShuffleAlgorithm = new FisherYatesShuffleAlgorithm(random);
            var vocabularyRepository = new VocabularyRepository();

            ReadAndLearnWithLinnea.App.Startup.Run(viewConductor, fisherYatesShuffleAlgorithm, vocabularyRepository);

            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}