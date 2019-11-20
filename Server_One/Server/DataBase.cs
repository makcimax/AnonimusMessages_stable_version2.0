using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server
{
    public class DataBaseOfMessages : DbContext,IDataOfMessages
    {
        public DataBaseOfMessages() : base("ConnectionStringToDbOfMsg1")
        {
        }

        public DbSet<Message> Messages
        {
            get; set;
        }

     public void AddMessageToDb(int senderId, int recipientId, string textOfMessage)
        {
            var context = new DataBaseOfMessages();
            
                var message = new Message()
                {
                    SenderId = senderId,
                    RecipientId = recipientId,
                    TextOfMessage = textOfMessage
                };

                context.Messages.Add(message);
                context.SaveChanges();
         
        }

        public List<Message> TakeMessagesFromDb(int recipientId)
        {
            var context = new DataBaseOfMessages();
            
                List<Message> messagesInDb = (context.Messages.Where(i => i.RecipientId == recipientId)).ToList();

                foreach (Message message in messagesInDb)
                    context.Messages.Remove(message);

                context.SaveChanges();
                return messagesInDb;
            
        }

    }


    public class DataBaseOfAbonents : DbContext, IDataOfAbonents
    {
        public DataBaseOfAbonents() : base("ConnectionStringToDbOfAbonents1")
        {

        }

        public DbSet<Abonent> Abonents
        {
            get; set;

        }

        public void AddAbonentInDb(int _id, string _name)
        {
            var context = new DataBaseOfAbonents();
           

                var abonent = new Abonent
                {
                    id = _id,
                    name = _name,
                    status = Status.Offline
                };

                context.Abonents.Add(abonent);
                context.SaveChanges();
            
        }
      public Dictionary<int, Abonent> GetAbonentFromDb()
        {
            var context = new DataBaseOfAbonents();

                Dictionary<int, Abonent> abonentsInDb = context.Abonents.ToDictionary(x => x.id, x => x);

                return abonentsInDb;
            
        }
    }
}
