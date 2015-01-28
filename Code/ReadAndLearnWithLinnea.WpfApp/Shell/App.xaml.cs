﻿using System;
using System.Windows;
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
            var viewConductor = new ViewConductor(windowManager, selectVocabularyViewModelFactory,
                questionViewModelFactory);

            mainWindow.DataContext = viewConductor.ViewModel;
            mainWindow.Show();
 
            try
            {
                Core.Startup.Run(viewConductor);
            }
            catch (Exception exception)
            {
                new WindowManager(mainWindow).ShowMessage(exception.Message);
            }
        }
    }
}