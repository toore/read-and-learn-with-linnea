﻿using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ReadAndLearnWithLinnea.WinPlat.WpfApp.Shell
{
    public class WindowManager
    {
        private readonly MetroWindow _window;

        public WindowManager(MetroWindow window)
        {
            _window = window;
        }

        public Task<MessageDialogResult> ShowMessage(string message)
        {
            return _window.ShowMessageAsync("ReadAndLearnWithLinnea", message);
        }
    }
}