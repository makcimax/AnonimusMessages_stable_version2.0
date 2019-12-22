using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;


namespace Server
{
  
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Server : IServer
    {
        private Dictionary<int, IMessageCallback> links;
        private Dictionary<int, Abonent> allAbonents;
        private ILogger _logger;
        private IDataBase _dataBase;
        private IBindingCallback _binding;


        private int idAbonent;


        //Logger
        public Server(IDataBase dataBase, ILogger logger, IBindingCallback binding )
        {

            _binding = binding;
            _logger = logger;
            _dataBase = dataBase;
           
            allAbonents = _dataBase.GetAbonentFromDb();

            links = new Dictionary<int, IMessageCallback>();
            foreach (var abonent in allAbonents)
            links[abonent.Key] = null;
            _logger = new ConsoleLogger();
          
            idAbonent = allAbonents.Count + 1;
        }
        public Dictionary<int, IMessageCallback> GetLinks()
        {
            return links;
        }
        public void SendMessage(int senderId, List<int> recipientNames, string message)
        {
            Abonent sender = allAbonents[senderId];
            if (recipientNames == null) //оправить всем
            {
                foreach (var index in links.Keys)
                {
                    if (allAbonents[index].status == Status.Online)
                    {
                        links[index].cbSendMessage(sender.name, message);
                    }
                    else
                    {
                        _dataBase.AddMessageToDb(sender.id, allAbonents[index].id, message);
                    }
                }

                _logger.Logging(sender.name + " отправил всем сообщение");
            }
            else
            {
                foreach (var index in recipientNames)
                {
                    if (allAbonents[index].status == Status.Online)
                    {
                       links[index].cbSendMessage(sender.name, message);
                    }
                    else
                    {
                       _dataBase.AddMessageToDb(senderId, index, message); //сохранить сообщение в базу данных
                    }
                }
                links[senderId].cbSendMessage(sender.name, message);
            }
        }
        public Dictionary<int, Abonent> ShowAbonents(int id) 
        {
            return allAbonents;
        }

        public List<Message> ProvideMessage(int id)
        {   
            return _dataBase.GetMessagesFromDb(allAbonents[id].id); 
        }

        public int Connect(string name)
        {
            Abonent abonent;
            string typeConnect;
            if (allAbonents.ToList().Exists(ab => ab.Value.name == name))    
            {
                abonent = allAbonents.ToList().Find(ab => ab.Value.name == name).Value;
                if (abonent.status == Status.Online)
                {
                    _logger.Logging("Попытка повторного входа!");
                    return -1;
                }

                typeConnect = "существующий ";
                links[abonent.id] = _binding.GetChannelCallback(OperationContext.Current); ;// OperationContext.Current.GetCallbackChannel<IMessageCallback>();
                abonent.status = Status.Online;
            }
            else
            {
                typeConnect = "новый ";
                abonent = new Abonent()
                {
                    id = idAbonent,
                    name = name,
                    status = Status.Online 
                };

                _dataBase.AddAbonentToDb(abonent.id,abonent.name);

                allAbonents.Add(idAbonent++,abonent);
                links[abonent.id] = _binding.GetChannelCallback(OperationContext.Current);//OperationContext.Current.GetCallbackChannel<IMessageCallback>();
            }

            //Дать знать остальным пользователям о подключении нового
            foreach (var index in  links.Keys)
            {
                if (allAbonents[index].status == Status.Online && allAbonents[index].id != abonent.id)
                {
                   
                    links[index].cbShowAbonent(abonent);
                }
            }

            _logger.Logging("Подключился " + typeConnect + abonent.name);
            return abonent.id;

        }
        public void Disconnect(int id)
        {
            Abonent abonent = allAbonents[id];
            if(abonent.status == Status.Offline)
            {
                _logger.Logging("Клиент уже отключен");
                return;
            }

            _logger.Logging("Отключился " + abonent.name);
            abonent.status = Status.Offline;
            links[abonent.id] = null;
            foreach (var index in links.Keys)
            {
                if (allAbonents[index].status == Status.Online && allAbonents[index].id != abonent.id)
                {
                    links[index].cbShowAbonent(abonent);
                }
            }
        }
    }
}
