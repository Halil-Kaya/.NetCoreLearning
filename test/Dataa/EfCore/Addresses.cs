using System;
using System.Collections.Generic;

namespace test.Dataa.EfCore
{
    public partial class Addresses
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
