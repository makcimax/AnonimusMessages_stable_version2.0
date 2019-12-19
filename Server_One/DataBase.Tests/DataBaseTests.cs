using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBase.Tests
{
    [TestClass]
    public class DataBaseTests
    {
        [TestMethod]
        public void TestAddMessageToDb()
        {
            var dataBase = new Server.DataBase("TestBaseAddMsg");

            dataBase.AddMessageToDb(1, 2, "test");

            List<Server.Message> result = new List<Server.Message>();


            var message = new Server.Message()
            {
                SenderId = 1,
                RecipientId = 2,
                TextOfMessage = "test"
            };

            result.Add(message);

            var messagesInDb = dataBase.Messages.Where(i => i.RecipientId == 2).ToList();

            Assert.AreEqual(result.Count, messagesInDb.Count);
            Assert.AreEqual(result[0].RecipientId, messagesInDb[0].RecipientId);
            Assert.AreEqual(result[0].SenderId, messagesInDb[0].SenderId);
            Assert.AreEqual(result[0].TextOfMessage, messagesInDb[0].TextOfMessage);


            dataBase.Messages.RemoveRange(dataBase.Messages);
            dataBase.SaveChanges();

        }


        [TestMethod]
        public void TestAddAbonentToDb()
        {
            var dataBase = new Server.DataBase("TestBaseAddAbonent");

            dataBase.AddAbonentToDb(1, "1");

            List<Server.Abonent> result = new List<Server.Abonent>();


            var abonent = new Server.Abonent
            {
                id = 1,
                name = "1",
                status = Server.Status.Offline
            };

            result.Add(abonent);

            var abonentsInDb = dataBase.Abonents.Where(i => i.id == 1).ToList();

            Assert.AreEqual(result.Count, abonentsInDb.Count);

            Assert.AreEqual(result[0].id, abonentsInDb[0].id);
            Assert.AreEqual(result[0].name, abonentsInDb[0].name);
            Assert.AreEqual(result[0].status, abonentsInDb[0].status);

            dataBase.Messages.RemoveRange(dataBase.Messages);
            dataBase.SaveChanges();
        }



    }
}
