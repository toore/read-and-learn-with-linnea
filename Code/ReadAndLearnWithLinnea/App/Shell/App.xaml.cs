using System.Windows;
using ReadAndLearnWithLinnea.App.SelectTrainingView;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    // Linnea... This is for you! Love you! xx oo /pappa

    public partial class App
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var eventAggregator = new EventAggregator();

            var applicationController = new ApplicationController(eventAggregator);

            var vocabulariesViewModelFactory = new SelectVocabularyTrainingViewModelFactory(applicationController);
            var trainingSessionViewModelFactory = new TrainingSessionViewModelFactory();

            var mainWindow = new MainWindow();
            var windowManager = new WindowManager(mainWindow);
            var viewConductor = new ViewConductor(windowManager, vocabulariesViewModelFactory, trainingSessionViewModelFactory);
            eventAggregator.Subscribe(viewConductor);

            applicationController.StartApplication();
            
            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}