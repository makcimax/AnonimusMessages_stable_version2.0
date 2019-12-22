using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class AbonentDb
    {

        [Key]
        public int ID { get; set; }


        public string name { get; set; }


     
    }

}
