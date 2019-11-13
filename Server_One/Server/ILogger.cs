using System;

namespace Server
{
    interface ILogger
    {
        void Logging(string message);
    }

    public class ConsoleLogger: ILogger
    {
        public void Logging(string message)
        {
            Console.WriteLine(message);
        }
    }
}
