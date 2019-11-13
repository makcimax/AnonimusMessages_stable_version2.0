using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerHost
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(Server.Server)))
            {
                host.Open();
                Console.WriteLine("Start host");
                Console.ReadLine();
            }




        }
    }
}
