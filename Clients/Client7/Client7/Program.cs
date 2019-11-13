using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client7.Server1;

namespace Client7
{

    class MessageCallback: Server1.IServerCallback
    {
        public void cbSendMessage(string senderName, string message)
        {
            Console.WriteLine(senderName+ ":"+ message);
        }
        public void cbShowAbonent(Abonent abonent)
        {
            Console.WriteLine(abonent.name+" " + abonent.status);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new MessageCallback());
            var client = new ServerClient(instanceContext);
            Console.WriteLine("Введите имя для подключения:");
            string name = Console.ReadLine();
            int connectId = client.Connect(name);
            var allAbonents = client.ShowAbonents(connectId);

            while (true)
            {
                string a = Console.ReadLine();
                if (a == "s")
                {
                    allAbonents = client.ShowAbonents(connectId);
                    foreach(var index in allAbonents)
                    {
                        Console.WriteLine(index.Value.id + " "+ index.Value.name + " " + index.Value.status);
                    }
                }
                if (a == "d") client.Disconnect(connectId);
                if (a == "c") client.Connect(name);
                if (a == "send") client.SendMessage(connectId, null, "Привет всем");
                if (a == "p")
                {
                    var d = client.ProvideMessage(connectId);
                    allAbonents = client.ShowAbonents(connectId);
                    foreach (var index in d)
                    {

                        Console.WriteLine(allAbonents[index.SenderId].name + " : " +index.TextOfMessage);
                    }
                }
            }
        }
    }
}
