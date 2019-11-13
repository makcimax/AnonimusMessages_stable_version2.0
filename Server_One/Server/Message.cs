namespace Server
{
    public class Message
    {


        public int Id { get; set; }

        public int SenderId { get; set; }
        public int RecipientId{get; set;}
        public string TextOfMessage{ get; set; }

            //    public int SenderId { get { return _senderId; } set { _senderId= value; } }
           //   public int RecipientId { get { return _recipientId; } set { _recipientId = value; } }
       //   public string TextOfMessage { get { return _textOfMessage; } set { _textOfMessage = value; } }


        //  private int _id;
        //private int _senderId;
        // private int _recipientId;
        //private string _textOfMessage;


        // public int Id { get { return _id; ;  } set { _id = value; } }

        //        public int SenderId { get { return _senderId; } set { _senderId= value; } }
        //      public int RecipientId { get { return _recipientId; } set { _recipientId = value; } }
        //    public string TextOfMessage { get { return _textOfMessage; } set { _textOfMessage = value; } }

    }
}
