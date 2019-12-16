using System;
using System.ServiceModel;


namespace ServerHost
{
    public class Program
    {
        static void Main()
        {
            var dataBase = new Server.DataBase("dataBase");
            var server = new Server.Server(dataBase);
            using (var host = new ServiceHost(server))
            {
                host.Open();
                Console.WriteLine("Start host");
                Console.ReadLine();
            }
        }
    }
}
