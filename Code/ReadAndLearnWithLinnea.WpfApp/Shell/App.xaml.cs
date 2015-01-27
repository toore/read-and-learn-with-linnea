using System;
using System.Windows;
using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.Core.Common.Shuffle;
using ReadAndLearnWithLinnea.WpfApp.PractiseView;
using ReadAndLearnWithLinnea.WpfApp.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WpfApp.Shell
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
            var vocabularyRepository = new HardCodedVocabularyRepository();

            Core.Startup.Run(viewConductor, fisherYatesShuffleAlgorithm, vocabularyRepository);

            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}