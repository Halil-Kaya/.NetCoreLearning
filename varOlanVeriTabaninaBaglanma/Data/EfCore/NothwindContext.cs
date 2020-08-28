using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace varOlanVeriTabaninaBaglanma.Data.EfCore
{
    public partial class NothwindContext : DbContext
    {
        public NothwindContext()
        {
        }

        public NothwindContext(DbContextOptions<NothwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeePrivileges> EmployeePrivileges { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<InventoryTransactionTypes> InventoryTransactionTypes { get; set; }
        public virtual DbSet<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderDetailsStatus> OrderDetailsStatus { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersStatus> OrdersStatus { get; set; }
        public virtual DbSet<OrdersTaxStatus> OrdersTaxStatus { get; set; }
        public virtual DbSet<Privileges> Privileges { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderStatus> PurchaseOrderStatus { get; set; }
        public virtual DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public virtual DbSet<SalesReports> SalesReports { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Strings> Strings { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3305;username=root;database=northwind", x => x.ServerVersion("10.4.13-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.City)
                    .HasName("city");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.FirstName)
                    .HasName("first_name");

                entity.HasIndex(e => e.LastName)
                    .HasName("last_name");

                entity.HasIndex(e => e.StateProvince)
                    .HasName("state_province");

                entity.HasIndex(e => e.ZipPostalCode)
                    .HasName("zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnName("business_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnName("country_region")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("email_address")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("fax_number")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnName("home_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobile_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnName("state_province")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnName("web_page")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnName("zip_postal_code")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<EmployeePrivileges>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.PrivilegeId })
                    .HasName("PRIMARY");

                entity.ToTable("employee_privileges");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("employee_id");

                entity.HasIndex(e => e.PrivilegeId)
                    .HasName("privilege_id_2");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrivilegeId)
                    .HasColumnName("privilege_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePrivileges)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_privileges_employees1");

                entity.HasOne(d => d.Privilege)
                    .WithMany(p => p.EmployeePrivileges)
                    .HasForeignKey(d => d.PrivilegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_privileges_privileges1");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.City)
                    .HasName("city");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.FirstName)
                    .HasName("first_name");

                entity.HasIndex(e => e.LastName)
                    .HasName("last_name");

                entity.HasIndex(e => e.StateProvince)
                    .HasName("state_province");

                entity.HasIndex(e => e.ZipPostalCode)
                    .HasName("zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnName("business_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnName("country_region")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("email_address")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("fax_number")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnName("home_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobile_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnName("state_province")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnName("web_page")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnName("zip_postal_code")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<InventoryTransactionTypes>(entity =>
            {
                entity.ToTable("inventory_transaction_types");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("type_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<InventoryTransactions>(entity =>
            {
                entity.ToTable("inventory_transactions");

                entity.HasIndex(e => e.CustomerOrderId)
                    .HasName("customer_order_id");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("purchase_order_id");

                entity.HasIndex(e => e.TransactionType)
                    .HasName("transaction_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerOrderId)
                    .HasColumnName("customer_order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnName("purchase_order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TransactionCreatedDate)
                    .HasColumnName("transaction_created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionModifiedDate)
                    .HasColumnName("transaction_modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("transaction_type")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("fk_inventory_transactions_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_transactions_products");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("fk_inventory_transactions_purchase_orders");

                entity.HasOne(d => d.TransactionTypeNavigation)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.TransactionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_transactions_inventory_transaction_types");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.ToTable("invoices");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_invoices_orders1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AmountDue)
                    .HasColumnName("amount_due")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Shipping)
                    .HasColumnName("shipping")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_invoices_orders");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("order_details");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("inventory_id");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_order_details_orders_idx");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("purchase_order_id");

                entity.HasIndex(e => e.StatusId)
                    .HasName("fk_order_details_order_details_status_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateAllocated)
                    .HasColumnName("date_allocated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnName("purchase_order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18,4)");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_order_details_products");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_order_details_order_details_status");
            });

            modelBuilder.Entity<OrderDetailsStatus>(entity =>
            {
                entity.ToTable("order_details_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("employee_id");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.HasIndex(e => e.ShipZipPostalCode)
                    .HasName("ship_zip_postal_code");

                entity.HasIndex(e => e.ShipperId)
                    .HasName("shipper_id");

                entity.HasIndex(e => e.StatusId)
                    .HasName("fk_orders_orders_status");

                entity.HasIndex(e => e.TaxStatusId)
                    .HasName("tax_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaidDate)
                    .HasColumnName("paid_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentType)
                    .HasColumnName("payment_type")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipAddress)
                    .HasColumnName("ship_address")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipCity)
                    .HasColumnName("ship_city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipCountryRegion)
                    .HasColumnName("ship_country_region")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipName)
                    .HasColumnName("ship_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipStateProvince)
                    .HasColumnName("ship_state_province")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShipZipPostalCode)
                    .HasColumnName("ship_zip_postal_code")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippedDate)
                    .HasColumnName("shipped_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipperId)
                    .HasColumnName("shipper_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShippingFee)
                    .HasColumnName("shipping_fee")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TaxStatusId)
                    .HasColumnName("tax_status_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Taxes)
                    .HasColumnName("taxes")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_orders_employees");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("fk_orders_shippers");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_orders_orders_status");

                entity.HasOne(d => d.TaxStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TaxStatusId)
                    .HasConstraintName("fk_orders_orders_tax_status");
            });

            modelBuilder.Entity<OrdersStatus>(entity =>
            {
                entity.ToTable("orders_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<OrdersTaxStatus>(entity =>
            {
                entity.ToTable("orders_tax_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.TaxStatusName)
                    .IsRequired()
                    .HasColumnName("tax_status_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Privileges>(entity =>
            {
                entity.ToTable("privileges");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrivilegeName)
                    .HasColumnName("privilege_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.ProductCode)
                    .HasName("product_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                entity.Property(e => e.ListPrice)
                    .HasColumnName("list_price")
                    .HasColumnType("decimal(19,4)");

                entity.Property(e => e.MinimumReorderQuantity)
                    .HasColumnName("minimum_reorder_quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QuantityPerUnit)
                    .HasColumnName("quantity_per_unit")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnName("reorder_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StandardCost)
                    .HasColumnName("standard_cost")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.SupplierIds)
                    .HasColumnName("supplier_ids")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TargetLevel)
                    .HasColumnName("target_level")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PurchaseOrderDetails>(entity =>
            {
                entity.ToTable("purchase_order_details");

                entity.HasIndex(e => e.Id)
                    .HasName("id");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("inventory_id");

                entity.HasIndex(e => e.ProductId)
                    .HasName("product_id");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("purchase_order_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateReceived)
                    .HasColumnName("date_received")
                    .HasColumnType("datetime");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PostedToInventory).HasColumnName("posted_to_inventory");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnName("purchase_order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18,4)");

                entity.Property(e => e.UnitCost)
                    .HasColumnName("unit_cost")
                    .HasColumnType("decimal(19,4)");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("fk_purchase_order_details_inventory_transactions");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_purchase_order_details_products");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_purchase_order_details_purchase_orders");
            });

            modelBuilder.Entity<PurchaseOrderStatus>(entity =>
            {
                entity.ToTable("purchase_order_status");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PurchaseOrders>(entity =>
            {
                entity.ToTable("purchase_orders");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("created_by");

                entity.HasIndex(e => e.StatusId)
                    .HasName("status_id");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("supplier_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApprovedBy)
                    .HasColumnName("approved_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApprovedDate)
                    .HasColumnName("approved_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpectedDate)
                    .HasColumnName("expected_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnName("payment_amount")
                    .HasColumnType("decimal(19,4)")
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShippingFee)
                    .HasColumnName("shipping_fee")
                    .HasColumnType("decimal(19,4)");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SubmittedBy)
                    .HasColumnName("submitted_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubmittedDate)
                    .HasColumnName("submitted_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplier_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Taxes)
                    .HasColumnName("taxes")
                    .HasColumnType("decimal(19,4)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_purchase_orders_employees");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_purchase_orders_purchase_order_status");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("fk_purchase_orders_suppliers");
            });

            modelBuilder.Entity<SalesReports>(entity =>
            {
                entity.HasKey(e => e.GroupBy)
                    .HasName("PRIMARY");

                entity.ToTable("sales_reports");

                entity.Property(e => e.GroupBy)
                    .HasColumnName("group_by")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Default).HasColumnName("default");

                entity.Property(e => e.Display)
                    .HasColumnName("display")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FilterRowSource)
                    .HasColumnName("filter_row_source")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.ToTable("shippers");

                entity.HasIndex(e => e.City)
                    .HasName("city");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.FirstName)
                    .HasName("first_name");

                entity.HasIndex(e => e.LastName)
                    .HasName("last_name");

                entity.HasIndex(e => e.StateProvince)
                    .HasName("state_province");

                entity.HasIndex(e => e.ZipPostalCode)
                    .HasName("zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnName("business_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnName("country_region")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("email_address")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("fax_number")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnName("home_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobile_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnName("state_province")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnName("web_page")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnName("zip_postal_code")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Strings>(entity =>
            {
                entity.HasKey(e => e.StringId)
                    .HasName("PRIMARY");

                entity.ToTable("strings");

                entity.Property(e => e.StringId)
                    .HasColumnName("string_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StringData)
                    .HasColumnName("string_data")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.ToTable("suppliers");

                entity.HasIndex(e => e.City)
                    .HasName("city");

                entity.HasIndex(e => e.Company)
                    .HasName("company");

                entity.HasIndex(e => e.FirstName)
                    .HasName("first_name");

                entity.HasIndex(e => e.LastName)
                    .HasName("last_name");

                entity.HasIndex(e => e.StateProvince)
                    .HasName("state_province");

                entity.HasIndex(e => e.ZipPostalCode)
                    .HasName("zip_postal_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachments).HasColumnName("attachments");

                entity.Property(e => e.BusinessPhone)
                    .HasColumnName("business_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CountryRegion)
                    .HasColumnName("country_region")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("email_address")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("fax_number")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HomePhone)
                    .HasColumnName("home_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobile_phone")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StateProvince)
                    .HasColumnName("state_province")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WebPage)
                    .HasColumnName("web_page")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipPostalCode)
                    .HasColumnName("zip_postal_code")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
