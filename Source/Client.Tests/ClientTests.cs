using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClientWinForm;

namespace Client.Tests
{
    [TestClass]
    public class ClientTests
    {
        ClientWinForm.Service.Abonent abonent;


        void SetUp()
        {
            abonent = new ClientWinForm.Service.Abonent()
            {
                id = 0,
                name = "1",
                status = ClientWinForm.Service.Status.Online
            };

        }


        [TestMethod]
        public void TestClientConnect()
        {

          

            Dictionary<int, ClientWinForm.Service.Abonent> allAbonents = new Dictionary<int, ClientWinForm.Service.Abonent>();

            allAbonents.Add(1,abonent);

            Moq.Mock<ClientWinForm.Service.IServer> mockClient = new Moq.Mock<ClientWinForm.Service.IServer>();
            mockClient.Setup(x => x.ShowAbonents(0)).Returns(allAbonents);
            var chat = new ClientWinForm.Chat();
            chat.ConnectMethod(mockClient.Object, "1");
            mockClient.Verify(x => x.Connect("1"));
        }

        [TestMethod]
        public void TestClientSend()
        {
            Dictionary<int, ClientWinForm.Service.Abonent> allAbonents = new Dictionary<int, ClientWinForm.Service.Abonent>();

            allAbonents.Add(1, abonent);



            int[] destination = { 1,2};



            Moq.Mock<ClientWinForm.Service.IServer> mockClient = new Moq.Mock<ClientWinForm.Service.IServer>();
            mockClient.Setup(x => x.ShowAbonents(0)).Returns(allAbonents);
            var chat = new ClientWinForm.Chat();
            chat.ConnectMethod(mockClient.Object, "1");
            mockClient.Setup(x => x.Connect("1"));
            chat.ConnectMethod(mockClient.Object, "1");

            chat.SendMethod(0, destination, "Test");

            mockClient.Verify(x => x.SendMessage(0,destination,"Test"));
        }
    }
}
