using System;
using System.Collections.Generic;

namespace test.Dataa.EfCore
{
    public partial class Customers
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
