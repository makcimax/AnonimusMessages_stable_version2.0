using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    [ServiceContract(CallbackContract = typeof(IMessageCallback))]
    public interface IServer
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(int senderId, List<int> recipientsId, string message);

        [OperationContract(IsOneWay = false)]
        Dictionary<int, Abonent> ShowAbonents(int id);

        [OperationContract(IsOneWay = false)]
        List<Message> ProvideMessage(int id);

        [OperationContract(IsOneWay = false)]
        int Connect(string name);

        [OperationContract(IsOneWay = true)]
        void Disconnect(int id);
    }

}
