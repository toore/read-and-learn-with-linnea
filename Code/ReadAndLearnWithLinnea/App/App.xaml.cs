using System.Windows;
using ReadAndLearnWithLinnea.Caliburn.Micro;

namespace ReadAndLearnWithLinnea.App
{
    public partial class App
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var eventAggregator = new EventAggregator();

            var applicationController = new ApplicationController(eventAggregator);

            var viewConductor = new ViewConductor(applicationController);
            eventAggregator.Subscribe(viewConductor);

            applicationController.StartApplication();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}