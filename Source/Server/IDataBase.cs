using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IDataBase
    {
        void AddMessageToDb(int senderId, int recipientId, string textOfMessage);

        List<Message> GetMessagesFromDb(int recipientId);

        void AddAbonentToDb(int _id, string _name);

        Dictionary<int, Abonent> GetAbonentFromDb();
    }

 


}


