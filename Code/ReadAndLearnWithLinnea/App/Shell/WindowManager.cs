using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ReadAndLearnWithLinnea.App.Shell
{
    public class WindowManager
    {
        private readonly MetroWindow _window;

        public WindowManager(MetroWindow window)
        {
            _window = window;
        }

        public void ShowMessage(string message)
        {
            _window.ShowMessageAsync("ReadAndLearnWithLinnea", message);
        }
    }
}