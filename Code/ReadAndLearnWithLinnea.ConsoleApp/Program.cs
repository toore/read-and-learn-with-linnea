using System;
using ReadAndLearnWithLinnea.Core;

namespace ReadAndLearnWithLinnea.ConsoleApp
{
    static class Program
    {
        static void Main()
        {
            Startup.Run(new ConsoleView());

            Console.ReadLine();
        }
    }
}
