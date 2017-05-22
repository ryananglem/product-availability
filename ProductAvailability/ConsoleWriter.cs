using System;

namespace ProductAvailability
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void ConsoleReadKey()
        {
            Console.ReadKey();
        }

        public void ConsoleWriteLine(string lineOfText)
        {
            Console.WriteLine(lineOfText);
        }
    }
}
