using System;
using System.Collections.Generic;

namespace test.Data.EfCore
{
    public partial class Products
    {
        public Products()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
            OrderDetails = new HashSet<OrderDetails>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public string SupplierIds { get; set; }
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int? ReorderLevel { get; set; }
        public int? TargetLevel { get; set; }
        public string QuantityPerUnit { get; set; }
        public bool Discontinued { get; set; }
        public int? MinimumReorderQuantity { get; set; }
        public string Category { get; set; }
        public byte[] Attachments { get; set; }

        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
