using System.Data.Entity;

namespace Server
{
    public class DataBase : DbContext
    {
        public DataBase() : base("ConnectionStringToDbOfMsg1")
        {
        }

        public DbSet<Message> Messages
        {
            get; set;
        }
    }


    public class DataBaseOfAbonents : DbContext
    {
        public DataBaseOfAbonents() : base("ConnectionStringToDbOfAbonents1")
        {

        }

        public DbSet<Abonent> Abonents
        {
            get; set;

        }

    }

}
