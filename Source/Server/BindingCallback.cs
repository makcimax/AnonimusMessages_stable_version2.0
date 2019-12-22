using System.ServiceModel;

namespace Server
{
    public class BindingCallback : IBindingCallback
    {
        public IMessageCallback GetChannelCallback(OperationContext cur)
        {
            return cur.GetCallbackChannel<IMessageCallback>(); 
        }
    }
}
