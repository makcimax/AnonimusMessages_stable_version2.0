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
        private ILogger logger;
        private int idAbonent;

        public Server()
        {
   
            allAbonents = GetAbonentFromDb();

            links = new Dictionary<int, IMessageCallback>();
            foreach (var abonent in allAbonents)
            links[abonent.Key] = null;
            logger = new ConsoleLogger();
            idAbonent = allAbonents.Count+1;
        }

        private void AddMessageToDb(int senderId, int recipientId, string textOfMessage)
        {
            using (var context = new DataBase())
            {
                var message = new Message()
                {
                    SenderId = senderId,
                    RecipientId = recipientId,          
                    TextOfMessage = textOfMessage
                };

                context.Messages.Add(message);
                context.SaveChanges();
            }
        }

        private List<Message> TakeMessagesFromDb(int recipientId)
        {
            using (var context = new DataBase())
            {
                List<Message> messagesInDb = (context.Messages.Where(i => i.RecipientId == recipientId)).ToList();

                foreach (Message message in messagesInDb)
                    context.Messages.Remove(message);

                context.SaveChanges();
                return messagesInDb;
            }
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
                        AddMessageToDb(sender.id, allAbonents[index].id, message);
                    }
                }

                logger.Logging(sender.name + " отправил всем сообщение");
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
                        AddMessageToDb(senderId, index, message); //сохранить сообщение в базу данных
                    }
                }
            }
        }
        public Dictionary<int, Abonent> ShowAbonents(int id) //убрать аргумент
        {


            return allAbonents;

         //  return null;
        }

        public List<Message> ProvideMessage(int id)
        {   
            return TakeMessagesFromDb(allAbonents[id].id); 
        }


        private void AddAbonentInDb(int _id,string _name)
        {
            using (var context = new DataBaseOfAbonents())
            {

                var abonent = new Abonent
                {
                    id = _id,
                    name = _name,
                    status = Status.Offline
                };

                context.Abonents.Add(abonent);
                context.SaveChanges();
            }
        }
        private Dictionary<int, Abonent> GetAbonentFromDb()
        {
            using (var context = new DataBaseOfAbonents())
            {

                Dictionary<int,Abonent> abonentsInDb = context.Abonents.ToDictionary(x => x.id , x => x);

                return abonentsInDb;
            }
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
                    logger.Logging("Попытка повторного входа!");
                    return -1;
                }

                typeConnect = "существующий ";
                links[abonent.id] = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
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

                AddAbonentInDb(abonent.id,abonent.name);

                allAbonents.Add(idAbonent++,abonent);
                links[abonent.id] = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
            }

            //Дать знать остальным пользователям о подключении нового
            foreach (var index in  links.Keys)
            {
                if (allAbonents[index].status == Status.Online && allAbonents[index].id != abonent.id)
                {

                    var i = links[index];
                    links[index].cbShowAbonent(abonent);
                }
            }

            logger.Logging("Подключился " + typeConnect + abonent.name);
            return abonent.id;

        }
        public void Disconnect(int id)
        {
            Abonent abonent = allAbonents[id];
            if(abonent.status == Status.Offline)
            {
                logger.Logging("Клиент уже отключен");
                return;
            }

            logger.Logging("Отключился " + abonent.name);
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
