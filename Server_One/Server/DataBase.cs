using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Server
{
    public class DataBase : DbContext,IDataBase
    {
        public DataBase(string connectionString = "DataBase") : base(connectionString)
        {
        }

        public DbSet<Message> Messages
        {
            get; set;
        }


        public DbSet<Abonent> Abonents
        {
            get; set;
        }

        public void AddMessageToDb(int senderId, int recipientId, string textOfMessage)
        {
            
            
                var message = new Message()
                {
                    SenderId = senderId,
                    RecipientId = recipientId,
                    TextOfMessage = textOfMessage
                };

                this.Messages.Add(message);
                this.SaveChanges();
        }

        public List<Message> GetMessagesFromDb(int recipientId)
        {

                List<Message> messagesInDb = (this.Messages.Where(i => i.RecipientId == recipientId)).ToList();

                foreach (Message message in messagesInDb)
                    this.Messages.Remove(message);

                this.SaveChanges();
                return messagesInDb;
            
        }


      

        public void AddAbonentToDb(int _id, string _name)
        {
            var abonent = new Abonent
            {
                id = _id,
                name = _name,
                status = Status.Offline
            };

            this.Abonents.Add(abonent);
            this.SaveChanges();

        }
        public Dictionary<int, Abonent> GetAbonentFromDb()
        {
            Dictionary<int, Abonent> abonentsInDb = this.Abonents.ToDictionary(x => x.id, x => x);
            return abonentsInDb;

        }

    }
}
