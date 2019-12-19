using System;
using System.ServiceModel;


namespace ServerHost
{
    public class Program
    {
        static void Main()
        {
            var dataBase = new Server.DataBase("OurNewDataBase");
            var logger = new Server.ConsoleLogger();
            var binding = new Server.BindingCallback();

            var server = new Server.Server(dataBase,logger,binding);
           
            using (var host = new ServiceHost(server))
            {
                host.Open();
                Console.WriteLine("Start host");
                Console.ReadLine();
            }
        }
    }
}
