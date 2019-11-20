namespace Server
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public int RecipientId{get; set;}
        public string TextOfMessage{ get; set; }

    }
}
