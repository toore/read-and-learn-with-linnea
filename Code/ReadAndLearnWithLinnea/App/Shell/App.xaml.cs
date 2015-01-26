using System;
using System.Windows;
using ReadAndLearnWithLinnea.App.SelectTrainingView;
using ReadAndLearnWithLinnea.App.TrainingSessionView;
using ReadAndLearnWithLinnea.Caliburn.Micro;
using ReadAndLearnWithLinnea.Common;
using ReadAndLearnWithLinnea.Common.Shuffle;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.App.Shell
{
    // Linnea... This is for you! Love you! xx oo /pappa

    public partial class App
    {
        // Reference must be kept to prevent garbage collection
        private ViewConductor _viewConductor;

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var guiThreadDispatcher = new GuiThreadDispatcher();
            var eventAggregator = new EventAggregator
            {
                PublicationThreadMarshaller = guiThreadDispatcher.Invoke
            };
            var shuffleAlgorithm = new FisherYatesShuffleAlgorithm(new Random());

            var applicationController = new ApplicationController(eventAggregator, shuffleAlgorithm, new VocabularyRepository());

            var vocabulariesViewModelFactory = new SelectVocabularyTrainingViewModelFactory(applicationController);
            var trainingSessionViewModelFactory = new QuestionViewModelFactory(shuffleAlgorithm);

            var mainWindow = new MainWindow();
            var windowManager = new WindowManager(mainWindow);
            _viewConductor = new ViewConductor(windowManager, vocabulariesViewModelFactory, trainingSessionViewModelFactory);
            eventAggregator.Subscribe(_viewConductor);

            applicationController.StartApplication();

            mainWindow.DataContext = _viewConductor.ViewModel;
            mainWindow.Show();
        }
    }
}