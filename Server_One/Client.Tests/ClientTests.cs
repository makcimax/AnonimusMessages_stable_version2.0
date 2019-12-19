using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client.Tests
{
    using System.Collections.Generic;

    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void TestClientConnect()
        {

            var abonent = new Client10.Service.Abonent()
            {
                id = 0,
                name = "1",
                status = Client10.Service.Status.Online
            };

            Dictionary<int, Client10.Service.Abonent> allAbonents = new Dictionary<int, Client10.Service.Abonent>();

            allAbonents.Add(1,abonent);

            Moq.Mock<Client10.Service.IServer> mockClient = new Moq.Mock<Client10.Service.IServer>();
            mockClient.Setup(x => x.ShowAbonents(0)).Returns(allAbonents);
            var chat = new Client10.Chat();
            chat.ConnectMethod(mockClient.Object, "1");
            mockClient.Verify(x => x.Connect("1"));
        }

        [TestMethod]
        public void TestClientSend()
        {
            var abonent = new Client10.Service.Abonent()
            {
                id = 0,
                name = "1",
                status = Client10.Service.Status.Online
            };

            Dictionary<int, Client10.Service.Abonent> allAbonents = new Dictionary<int, Client10.Service.Abonent>();

            allAbonents.Add(1, abonent);



            int[] destination = { 1,2};



            Moq.Mock<Client10.Service.IServer> mockClient = new Moq.Mock<Client10.Service.IServer>();
            mockClient.Setup(x => x.ShowAbonents(0)).Returns(allAbonents);
            var chat = new Client10.Chat();
            chat.ConnectMethod(mockClient.Object, "1");
            mockClient.Setup(x => x.Connect("1"));
            chat.ConnectMethod(mockClient.Object, "1");

            chat.SendMethod(0, destination, "Test");

            mockClient.Verify(x => x.SendMessage(0,destination,"Test"));
        }
    }
}
