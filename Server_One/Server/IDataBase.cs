using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface IDataOfMessages
    {
        void AddMessageToDb(int senderId, int recipientId, string textOfMessage);
        List<Message> GetMessagesFromDb(int recipientId);
    }

    interface IDataOfAbonents
    {
        void AddAbonentToDb(int _id, string _name);
        Dictionary<int, Abonent> GetAbonentFromDb();
    }


}


