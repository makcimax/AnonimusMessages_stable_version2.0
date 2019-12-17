
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace UnitTest
{
    using Moq;
    using ServerHost;

    [TestClass]
    public class ServerTests
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

           Assert.AreEqual(result.Count,messagesInDb.Count);

           Assert.AreEqual(result[0].RecipientId,messagesInDb[0].RecipientId);
           Assert.AreEqual(result[0].SenderId,messagesInDb[0].SenderId);
           Assert.AreEqual(result[0].TextOfMessage,messagesInDb[0].TextOfMessage);


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

            Assert.AreEqual(result[0].id,abonentsInDb[0].id);
            Assert.AreEqual(result[0].name, abonentsInDb[0].name);
            Assert.AreEqual(result[0].status, abonentsInDb[0].status);

            dataBase.Messages.RemoveRange(dataBase.Messages);
            dataBase.SaveChanges();
        }






        [TestMethod]
        public void TestServerConnect()
        {
           var abonent = new Server.Abonent()
            {
                id = 1,
                name = "1",
                status = Server.Status.Online
            };

            Dictionary<int, Server.Abonent> allAbonents = new Dictionary<int, Server.Abonent>();

            Moq.Mock<Server.IDataBase> mockDataBase = new Moq.Mock<Server.IDataBase>();
            mockDataBase.Setup(r => r.AddAbonentToDb(1, "1"));
            mockDataBase.Setup(r => r.GetAbonentFromDb()).Returns(allAbonents);


            Moq.Mock<Server.ILogger> mockLogger = new Moq.Mock<Server.ILogger>();
            mockLogger.Setup(r => r.Logging("test"));

            Moq.Mock<Server.IMessageCallback> mockCallback = new Moq.Mock<Server.IMessageCallback>();
            mockCallback.Setup(r => r.cbShowAbonent(abonent));

            Moq.Mock<Server.IBindingCallback> mockOperationContext = new Moq.Mock<Server.IBindingCallback>();
            mockOperationContext.Setup(r => r.GetChannelCallback(It.IsAny<OperationContext>())).Returns(mockCallback.Object);

             //var server = new Server.Server(mockDataBase.Object,mockLogger.Object,mockOperationContext.Object);
            var server = new Server.Server(mockDataBase.Object, mockLogger.Object, mockOperationContext.Object);
            server.Connect("1");


            var allAbonentsTest = server.ShowAbonents(1);

            Assert.AreEqual(allAbonents.Count, 1);

            Assert.AreEqual(allAbonents[1].id, abonent.id);
            Assert.AreEqual(allAbonents[1].name, abonent.name);
            Assert.AreEqual(allAbonents[1].status, abonent.status);

        }




        //тестировать запуск cbShowAbonent
        [TestMethod]
        public void TestServerConnectVerifyCbShowAbonent()
        {
            var abonent = new Server.Abonent()
            {
                id = 2,
                name = "2",
                status = Server.Status.Online
            };

       

            Dictionary<int, Server.Abonent> allAbonents = new Dictionary<int, Server.Abonent>();

            Moq.Mock<Server.IDataBase> mockDataBase = new Moq.Mock<Server.IDataBase>();
            mockDataBase.Setup(r => r.AddAbonentToDb(1, "1"));
            mockDataBase.Setup(r => r.GetAbonentFromDb()).Returns(allAbonents);


            Moq.Mock<Server.ILogger> mockLogger = new Moq.Mock<Server.ILogger>();
            mockLogger.Setup(r => r.Logging("test"));

            Moq.Mock<Server.IMessageCallback> mockCallback = new Moq.Mock<Server.IMessageCallback>();
           // mockCallback.Setup(r => r.cbShowAbonent(abonent));

            Moq.Mock<Server.IBindingCallback> mockOperationContext = new Moq.Mock<Server.IBindingCallback>();
            mockOperationContext.Setup(r => r.GetChannelCallback(It.IsAny<OperationContext>())).Returns(mockCallback.Object);

                 var server = new Server.Server(mockDataBase.Object, mockLogger.Object, mockOperationContext.Object);

            server.Connect("1");
            server.Connect("2");
 //TODO заменить на нормальные параметры
            mockCallback.Verify(x => x.cbShowAbonent(It.IsAny<Server.Abonent>()));
        }




        //тестировать запуск cbShowAbonent
        [TestMethod]
        public void TestServerSendcbSendMessage()
        {
            var abonent = new Server.Abonent()
            {
                id = 1,
                name = "1",
                status = Server.Status.Online
            };

            var message = new Server.Message()
            {
                SenderId = 1,
                RecipientId = 2,
                TextOfMessage = "test"
            };

            List<Server.Message> messages = new List<Server.Message>();

            messages.Add(message);
        

            Dictionary<int, Server.Abonent> allAbonents = new Dictionary<int, Server.Abonent>();

            Moq.Mock<Server.IDataBase> mockDataBase = new Moq.Mock<Server.IDataBase>();
            mockDataBase.Setup(r => r.AddAbonentToDb(1, "1"));
            mockDataBase.Setup(r => r.GetAbonentFromDb()).Returns(allAbonents);
            mockDataBase.Setup(r => r.AddMessageToDb(1,2,"test"));
            mockDataBase.Setup(r => r.GetMessagesFromDb(2)).Returns(messages);


            Moq.Mock<Server.ILogger> mockLogger = new Moq.Mock<Server.ILogger>();
            mockLogger.Setup(r => r.Logging("test"));

            Moq.Mock<Server.IMessageCallback> mockCallback = new Moq.Mock<Server.IMessageCallback>();
            mockCallback.Setup(r => r.cbShowAbonent(abonent));


            Moq.Mock<Server.IBindingCallback> mockOperationContext = new Moq.Mock<Server.IBindingCallback>();
            mockOperationContext.Setup(r => r.GetChannelCallback(It.IsAny<OperationContext>())).Returns(mockCallback.Object);

            //var server = new Server.Server(mockDataBase.Object,mockLogger.Object,mockOperationContext.Object);
            var server = new Server.Server(mockDataBase.Object, mockLogger.Object, mockOperationContext.Object);
            server.Connect("1");
            server.Connect("2");



            List<int> recipient = new List<int>();
            recipient.Add(2);

            server.SendMessage(1, recipient, "test");

            mockCallback.Verify(x => x.cbSendMessage("1","test"));
        }




        [TestMethod]
        public void TestServerSendAddMessageInDb()
        {
            var abonent = new Server.Abonent()
            {
                id = 1,
                name = "1",
                status = Server.Status.Online
            };

            var message = new Server.Message()
            {
                SenderId = 1,
                RecipientId = 2,
                TextOfMessage = "test"
            };

            List<Server.Message> messages = new List<Server.Message>();

            messages.Add(message);


            Dictionary<int, Server.Abonent> allAbonents = new Dictionary<int, Server.Abonent>();

            Moq.Mock<Server.IDataBase> mockDataBase = new Moq.Mock<Server.IDataBase>();
            mockDataBase.Setup(r => r.AddAbonentToDb(1, "1"));
            mockDataBase.Setup(r => r.GetAbonentFromDb()).Returns(allAbonents);
            //mockDataBase.Setup(r => r.AddMessageToDb(1, 2, "test"));
            mockDataBase.Setup(r => r.GetMessagesFromDb(2)).Returns(messages);


            Moq.Mock<Server.ILogger> mockLogger = new Moq.Mock<Server.ILogger>();
            mockLogger.Setup(r => r.Logging("test"));

            Moq.Mock<Server.IMessageCallback> mockCallback = new Moq.Mock<Server.IMessageCallback>();
            mockCallback.Setup(r => r.cbShowAbonent(abonent));
            mockCallback.Setup(r => r.cbSendMessage("1", "test"));

            Moq.Mock<Server.IBindingCallback> mockOperationContext = new Moq.Mock<Server.IBindingCallback>();
            mockOperationContext.Setup(r => r.GetChannelCallback(It.IsAny<OperationContext>())).Returns(mockCallback.Object);

            //var server = new Server.Server(mockDataBase.Object,mockLogger.Object,mockOperationContext.Object);
            var server = new Server.Server(mockDataBase.Object, mockLogger.Object, mockOperationContext.Object);
            server.Connect("1");
            server.Connect("2");

            /////////////////
           // server.Disconnect(2);


            List<int> recipient = new List<int>();
            recipient.Add(2);

            server.SendMessage(1, recipient, "test");

           // mockDataBase.Verify(r => r.AddMessageToDb(1, 2, "test"));
        }



        [TestMethod]
        public void TestServerDelete()
        {
            var abonent = new Server.Abonent()
            {
                id = 1,
                name = "1",
                status = Server.Status.Online
            };

            var message = new Server.Message()
            {
                SenderId = 1,
                RecipientId = 2,
                TextOfMessage = "test"
            };

            List<Server.Message> messages = new List<Server.Message>();

            messages.Add(message);


            Dictionary<int, Server.Abonent> allAbonents = new Dictionary<int, Server.Abonent>();

            Moq.Mock<Server.IDataBase> mockDataBase = new Moq.Mock<Server.IDataBase>();
            mockDataBase.Setup(r => r.AddAbonentToDb(1, "1"));
            mockDataBase.Setup(r => r.GetAbonentFromDb()).Returns(allAbonents);
            mockDataBase.Setup(r => r.AddMessageToDb(1, 2, "test"));
            mockDataBase.Setup(r => r.GetMessagesFromDb(2)).Returns(messages);


            Moq.Mock<Server.ILogger> mockLogger = new Moq.Mock<Server.ILogger>();
            mockLogger.Setup(r => r.Logging("test"));

            Moq.Mock<Server.IMessageCallback> mockCallback = new Moq.Mock<Server.IMessageCallback>();
         //   mockCallback.Setup(r => r.cbShowAbonent(abonent));
            mockCallback.Setup(r => r.cbSendMessage("1", "test"));

            Moq.Mock<Server.IBindingCallback> mockOperationContext = new Moq.Mock<Server.IBindingCallback>();
            mockOperationContext.Setup(r => r.GetChannelCallback(It.IsAny<OperationContext>())).Returns(mockCallback.Object);

            //var server = new Server.Server(mockDataBase.Object,mockLogger.Object,mockOperationContext.Object);
            var server = new Server.Server(mockDataBase.Object, mockLogger.Object, mockOperationContext.Object);
            server.Connect("1");
            server.Connect("2");

            server.Disconnect(1);
            
        //  Assert.AreEqual(server.GetLinks())

        }

    }
}
