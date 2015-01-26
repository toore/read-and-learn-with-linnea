using System;
using System.Windows;
using ReadAndLearnWithLinnea.App.QuestionAndAnswerView;
using ReadAndLearnWithLinnea.App.SelectVocabularyView;
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
            var eventAggregator = new EventAggregator
            {
                PublicationThreadMarshaller = new GuiThreadDispatcher().Invoke
            };
            var shuffleAlgorithm = new FisherYatesShuffleAlgorithm(new Random());

            var applicationController = new ApplicationController(eventAggregator, shuffleAlgorithm, new VocabularyRepository());

            var vocabulariesViewModelFactory = new SelectVocabularyViewModelFactory(applicationController);
            var trainingSessionViewModelFactory = new QuestionViewModelFactory();

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