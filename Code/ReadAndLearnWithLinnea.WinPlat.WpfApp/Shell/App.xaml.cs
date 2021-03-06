﻿using System;
using System.Windows;
using ReadAndLearnWithLinnea.WinPlat.WpfApp.PractiseView;
using ReadAndLearnWithLinnea.WinPlat.WpfApp.SelectPractiseView;

namespace ReadAndLearnWithLinnea.WinPlat.WpfApp.Shell
{
    public partial class App
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var windowManager = new WindowManager(mainWindow);
            var selectVocabularyViewModelFactory = new SelectVocabularyViewModelFactory();
            var questionViewModelFactory = new QuestionViewModelFactory();
            var viewConductor = new ViewConductor(windowManager, selectVocabularyViewModelFactory,
                questionViewModelFactory);

            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();

            try
            {
                var vocabularyTextParser = new VocabularyTextParser();
                var vocabularyRepository = new FileVocabularyRepository(vocabularyTextParser);

                Bootstrapper.Startup.Run(viewConductor, vocabularyRepository);
            }
            catch (Exception exception)
            {
                windowManager.ShowMessage(exception.Message);
            }
        }
    }
}