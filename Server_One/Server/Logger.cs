using System;

namespace Server
{
    public class ConsoleLogger : ILogger
    {
        public void Logging(string message)
        {
            Console.WriteLine(message);
        }
    }
}
