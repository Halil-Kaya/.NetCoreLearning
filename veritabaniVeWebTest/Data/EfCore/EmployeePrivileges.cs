using System;
using System.Collections.Generic;

namespace veritabaniVeWebTest.Data.EfCore
{
    public partial class EmployeePrivileges
    {
        public int EmployeeId { get; set; }
        public int PrivilegeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Privileges Privilege { get; set; }
    }
}
