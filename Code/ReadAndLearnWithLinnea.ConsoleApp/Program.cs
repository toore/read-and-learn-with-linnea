using ReadAndLearnWithLinnea.Core;
using ReadAndLearnWithLinnea.Launcher;

namespace ReadAndLearnWithLinnea.ConsoleApp
{
    static class Program
    {
        static void Main()
        {
            Startup.Run(new ConsoleView());
        }
    }
}
