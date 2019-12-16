
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{


    using ServerHost;

    [TestClass]
    public class ServerTests
    {
        //ServerTests()
        //{
        //    Program a = new Program();
        //}

        [TestMethod]
        public void TestMethod1()
        {
            Moq.Mock<Server.IDataBase> mock = new Moq.Mock<Server.IDataBase>();

            //void AddMessageToDb(int senderId, int recipientId, string textOfMessage);
            //List<Message> GetMessagesFromDb(int recipientId);

            mock.Setup(r => r.AddMessageToDb(1,2,"test"));

            mock.Setup(r => r.GetMessagesFromDb(2)).Returns("test");
            var dataBase = new Server.DataBase("BD");
            var server = new Server.Server(dataBase);
            var client = new Client10.Chat();

            client.ConnectMethod();
            //server.Connect("max");
        }
    }
}
