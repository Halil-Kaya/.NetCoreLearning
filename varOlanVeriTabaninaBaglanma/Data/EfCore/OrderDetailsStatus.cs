using System;
using System.Collections.Generic;

namespace varOlanVeriTabaninaBaglanma.Data.EfCore
{
    public partial class OrderDetailsStatus
    {
        public OrderDetailsStatus()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
