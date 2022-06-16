using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAD_IoT_Programming_Test.Models
{
    public class User
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public Address Address { get; set; }
        public String Phone { get; set; }

    }
}
