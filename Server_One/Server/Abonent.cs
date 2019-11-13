using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Server
{
    public enum Status
    {
        Online,
        Offline
    }

    [DataContract]
    public class Abonent
    {
        [DataMember,Key]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public Status status { get; set; }
    }
}