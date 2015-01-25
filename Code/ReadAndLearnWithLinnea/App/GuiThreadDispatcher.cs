using System;
using System.Windows;

namespace ReadAndLearnWithLinnea.App
{
    public class GuiThreadDispatcher
    {
        public void Invoke(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}