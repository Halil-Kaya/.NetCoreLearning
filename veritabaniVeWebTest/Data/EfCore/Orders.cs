using System;
using System.Collections.Generic;

namespace veritabaniVeWebTest.Data.EfCore
{
    public partial class Orders
    {
        public Orders()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
            Invoices = new HashSet<Invoices>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipperId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipStateProvince { get; set; }
        public string ShipZipPostalCode { get; set; }
        public string ShipCountryRegion { get; set; }
        public decimal? ShippingFee { get; set; }
        public decimal? Taxes { get; set; }
        public string PaymentType { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Notes { get; set; }
        public double? TaxRate { get; set; }
        public sbyte? TaxStatusId { get; set; }
        public sbyte? StatusId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Shippers Shipper { get; set; }
        public virtual OrdersStatus Status { get; set; }
        public virtual OrdersTaxStatus TaxStatus { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
