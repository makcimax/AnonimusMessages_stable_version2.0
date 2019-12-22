using System.ServiceModel;
namespace Server
{
    public interface IMessageCallback
    {
        [OperationContract(IsOneWay = true)]
        void cbSendMessage(string senderName, string message);
        
        [OperationContract(IsOneWay = true)]
        void cbShowAbonent(Abonent abonent);
    }
}
