using System;
using System.Collections.Generic;

namespace test.Dataa.EfCore
{
    public partial class Users
    {
        public Users()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
