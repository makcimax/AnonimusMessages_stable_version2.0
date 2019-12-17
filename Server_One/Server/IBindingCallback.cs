using System.ServiceModel;

namespace Server
{
    public interface IBindingCallback
    {

        IMessageCallback GetChannelCallback(OperationContext oper);
        
    }
}
