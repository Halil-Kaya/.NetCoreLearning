using System;
using System.Collections.Generic;

namespace veritabaniVeWebTest.Data.EfCore
{
    public partial class InventoryTransactionTypes
    {
        public InventoryTransactionTypes()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
        }

        public sbyte Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
    }
}
