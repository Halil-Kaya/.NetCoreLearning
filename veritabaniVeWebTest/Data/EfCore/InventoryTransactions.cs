using System;
using System.Collections.Generic;

namespace veritabaniVeWebTest.Data.EfCore
{
    public partial class InventoryTransactions
    {
        public InventoryTransactions()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public int Id { get; set; }
        public sbyte TransactionType { get; set; }
        public DateTime? TransactionCreatedDate { get; set; }
        public DateTime? TransactionModifiedDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? PurchaseOrderId { get; set; }
        public int? CustomerOrderId { get; set; }
        public string Comments { get; set; }

        public virtual Orders CustomerOrder { get; set; }
        public virtual Products Product { get; set; }
        public virtual PurchaseOrders PurchaseOrder { get; set; }
        public virtual InventoryTransactionTypes TransactionTypeNavigation { get; set; }
        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
