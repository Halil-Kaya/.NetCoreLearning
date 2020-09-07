using System;
using System.Collections.Generic;

namespace veritabaniVeWebTest.Data.EfCore
{
    public partial class PurchaseOrders
    {
        public PurchaseOrders()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? StatusId { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Taxes { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? SubmittedBy { get; set; }

        public virtual Employees CreatedByNavigation { get; set; }
        public virtual PurchaseOrderStatus Status { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
