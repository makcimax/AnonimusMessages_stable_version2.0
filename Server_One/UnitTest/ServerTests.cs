
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
            var dataBase = new Server.DataBase("BD");
            var server = new Server.Server(dataBase);
            var client = new Client10.Chat();

            client.ConnectMethod();
            //server.Connect("max");
        }
    }
}
