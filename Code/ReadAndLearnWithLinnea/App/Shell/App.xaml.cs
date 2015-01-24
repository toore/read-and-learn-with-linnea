using System.Windows;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.App.VocabulariesView;
using ReadAndLearnWithLinnea.Caliburn.Micro;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public partial class App
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var eventAggregator = new EventAggregator();

            var applicationController = new ApplicationController(eventAggregator);

            var vocabulariesViewModelFactory = new VocabulariesViewModelFactory(applicationController);
            var trainingSessionViewModelFactory = new TrainingSessionViewModelFactory();
            var viewConductor = new ViewConductor(vocabulariesViewModelFactory, trainingSessionViewModelFactory);
            eventAggregator.Subscribe(viewConductor);

            applicationController.StartApplication();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}