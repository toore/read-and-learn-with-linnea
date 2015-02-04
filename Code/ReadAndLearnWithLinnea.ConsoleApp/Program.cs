using ReadAndLearnWithLinnea.Bootstrapper;

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
