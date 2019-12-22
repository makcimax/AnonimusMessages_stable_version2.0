using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClientWinForm;

namespace Client.Tests
{
    [TestClass]
    public class ClientTests
    {
        ClientWinForm.Service.Abonent abonent;
        Dictionary<int, ClientWinForm.Service.Abonent> allAbonents;
        Moq.Mock<ClientWinForm.Service.IServer> mockClient;
        ClientWinForm.Chat chat;

        void SetUp()
        {
            abonent = new ClientWinForm.Service.Abonent()
            {
                id = 0,
                name = "1",
                status = ClientWinForm.Service.Status.Online
            };

            allAbonents = new Dictionary<int, ClientWinForm.Service.Abonent>();
            allAbonents.Add(1, abonent);

            mockClient = new Moq.Mock<ClientWinForm.Service.IServer>();
             chat = new ClientWinForm.Chat();
        }


        [TestMethod]
        public void TestClientConnect()
        {
           /// allAbonents.Count;
            mockClient.Setup(x => x.ShowAbonents(0)).Returns(allAbonents);
            chat.ConnectMethod(mockClient.Object, "1");

            mockClient.Verify(x => x.Connect("1"));
        }

        [TestMethod]
        public void TestClientSendToOne()
        {
            int[] destination = { 1,2};

            mockClient.Setup(x => x.ShowAbonents(0)).Returns(allAbonents);
            chat.ConnectMethod(mockClient.Object, "1");
            mockClient.Setup(x => x.Connect("1"));
            chat.ConnectMethod(mockClient.Object, "1");
            chat.SendMethod(0, destination, "Test");

            mockClient.Verify(x => x.SendMessage(0,destination,"Test"));
        }



        public void TestClientSendAll()
        {
            int[] destination = { 1, 2 };

            mockClient.Setup(x => x.ShowAbonents(0)).Returns(allAbonents);
           // mockClient.Setup(x => x.(0)).Returns(allAbonents);
            chat.ConnectMethod(mockClient.Object, "1");
            mockClient.Setup(x => x.Connect("1"));
            chat.ConnectMethod(mockClient.Object, "1");
            chat.SendMethod(0, destination, "Test");

            mockClient.Verify(x => x.SendMessage(0, destination, "Test"));
        }
    }
}
