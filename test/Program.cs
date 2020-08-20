using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using test.Data.EfCore;

namespace test
{

    public class ShopContext : DbContext{

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            .UseMySql("server=127.0.0.1;port=3305;username=root;password=;database=shop");
            
        }

        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        //tablolalarım oluşturulurken kuralları burda belirtiyorum
        protected override void OnModelCreating(ModelBuilder modelBuilder){ 
        
        /*
            modelBuilder.Entity<User>()
                            .HasIndex(u => u.Username)
                            .IsUnique();
            
            modelBuilder.Entity<Customer>()
                            .Property(p => p.IdentityNumber)
                            .HasMaxLength(11)
                            .IsRequired();
*/
            //Bu işlemleri yapmamın sebebi Many to Many için!


            //veri tabanında birbirini tekrallayan veriler olmasın diye
            //ör: 
            /*
            ProductCategory
            [1,1]
            [1,2]
            [2,3]
            [2,1]
            [1,1] !! -> hata vercek yukarıda zaten bundan var bu yüzden bunu eklemiyecek
            */
            modelBuilder.Entity<ProductCategory>()
                            .HasKey(pc => new {pc.ProductId,pc.CategoryId});
            


            /*burda iki tablo içinde beliriyorum bunlar tekrallayabilir diye*/

            //önce buna diyorum ki product tun id si 1 tane ama category birden fazla olabilir
            modelBuilder.Entity<ProductCategory>()
                            .HasOne(pc => pc.Product)//bundan bir tane
                            .WithMany(p => p.ProductCategories)//bundan bir çok olabilir
                            .HasForeignKey(pc => pc.ProductId);

            //aşağıda tam tersini söylüyorum category nin id si bir ama productun id si birden fazla olabilir diyorum
            modelBuilder.Entity<ProductCategory>()
                            .HasOne(pc => pc.Category)
                            .WithMany(c => c.ProductCategories)
                            .HasForeignKey(pc => pc.CategoryId);
            //bunu dediğimde ikiside birden fazla olabiliyor yani:
            /*
            [1,1]
            [1,2]
            [2,3]
            [2,1]
            gibi verim olabiliyor
            */
        }

    }


    public class User{

        public int Id { get; set; }

/*
        [Required]
        [MaxLength(15)]
        [MinLength(8)]
  
  */
        public string Username { get; set; }
        public string Email { get; set; }

        public Customer Customer { get; set; }

        public List<Address> Addresses { get; set; }
        
    }

    public class Customer{

        //[Column("customer_id")]
        public int Id { get; set; }
        //[Required]
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[NotMapped]
        //public string FullName { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }

    public class Supplier{

        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }

    }

    public class Address{

        public int Id { get; set; }
        public string Fullname { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

    }


    public class Product
    {

        
        
        //id değiştirilmesin
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[MaxLength(100)]
        //[Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        //oluşturulma tarihi değiştirilmesin
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        
        //güncellenme tarihi değiştirilebilrsin
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;

        public List<ProductCategory> ProductCategories { get; set; }

    }


    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class ProductCategory{

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }



    class Program
    {
        static void Main(string[] args)
        {   
            
            using(var db = new NorthwindContext()){
            
            /*
                var customers = db.Customers.ToList();
                customers.ForEach(c => {
                    System.Console.WriteLine(c.FirstName +" "+ c.LastName);
                });
            */
                /*
                var customers = db.Customers.Select(c => new {
                    c.FirstName,
                    c.LastName
                }).ToList();
                
                customers.ForEach(c => {
                    System.Console.WriteLine(c.FirstName +" "+c.LastName);
                });
                */
                    
                /*
                var customers = db.Customers 
                            .Where(c => c.City == "New York")
                            .ToList();

                customers.ForEach(c => {
                    System.Console.WriteLine(c.FirstName +" "+c.LastName+" city: "+c.City);
                });
                */
/*
                var product = db.Products
                            .Where(p => p.Category == "Beverages")
                            .Select(p => p.ProductName)
                            .ToList();
                
                product.ForEach(p => {
                   System.Console.WriteLine("name: "+p); 
                });
*/
/*
                //id ye göre tersi sıralayıp ilk 5i alıyorum
                var products = db.Products
                            .OrderByDescending(p => p.Id)
                            .Take(5)
                            .ToList();

                products.ForEach(p => {
                    System.Console.WriteLine("name: "+p.ProductName);
                });
*/
/*
                var products = db.Products
                            .Where(p => p.ListPrice > 0 && p.ListPrice <= 30)
                            .OrderBy(p => p.ListPrice)
                            .Select(p => new {p.ProductName,p.ListPrice})
                            .ToList();
  
                products.ForEach(p => {
                    System.Console.WriteLine("name: " + p.ProductName + "price: "+p.ListPrice);
                });
*/
            /*
                var ortalama = db.Products.Average(p => p.ListPrice);
                
                System.Console.WriteLine("fiyatların ortalaması: "+ortalama);
            */

/*
                var adet = db.Products.Count();
                System.Console.WriteLine("toplam adet: "+adet);
*/
/*
                var adet = db.Products.Count(p => p.Category == "Beverages");
                System.Console.WriteLine("Beverages kategorisine sahip ürün adeti: "+adet);
*/
/*
                var toplamFiyat = db.Products
                        .Where(p => p.Category == "Beverages" || p.Category == "Condiments")
                        .Sum(p => p.ListPrice);
                
                System.Console.WriteLine("toplamFiyat: "+toplamFiyat);
*/
/*
                var products = db.Products
                            .Where(p => p.ProductName.Contains("Tea"))
                            .ToList();

                products.ForEach(p => {
                    System.Console.WriteLine("id: "+p.Id+" name: "+p.ProductName);
                });
*/
/*
                var enPahaliUrun = db.Products.Max(p => p.ListPrice);
                
                System.Console.WriteLine("en pahalı urun: "+ enPahaliUrun);

                var enUcuzUrun = db.Products.Min(p => p.ListPrice);

                System.Console.WriteLine("en ucuz ürün: "+ enUcuzUrun);
*/
/*
                var enPahaliUrun = db.Products
                        .Where(p => p.ListPrice == (db.Products.Max(p => p.ListPrice)))
                        .FirstOrDefault();
                
                System.Console.WriteLine("en pahalı urun adı: "+ enPahaliUrun.ProductName+" fiyatı: "+enPahaliUrun.ListPrice);

                var enUcuzUrun = db.Products
                        .Where(p => p.ListPrice == (db.Products.Min(p => p.ListPrice)))
                        .FirstOrDefault();

                System.Console.WriteLine("en ucuz ürün adı: "+ enUcuzUrun+" fiyatı: "+enUcuzUrun.ListPrice);
*/


                //iç içe istek yapma: 

                var customers = db.Customers
                        .Where(c => c.Orders.Count > 0)
                        .Select(c => new CustomerDemo{
                            CustomerId = c.Id,
                            Name = c.FirstName,
                            OrderCount = c.Orders.Count(),
                            Orders = c.Orders.Select(co => new OrderDemo{

                                OrderId = co.Id,
                                Total = (decimal)co.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                                Products = co.OrderDetails.Select(p => new ProductDemo{
                                    ProductId = (int)p.ProductId,
                                    Name = p.Product.ProductName
                                })
                                .ToList()
                            
                            }).ToList()

                        })
                        .ToList();



                    //bilgileri ekrana basıyorum
                    customers.ForEach(c => {


                        System.Console.WriteLine($"id: {c.CustomerId} name: {c.Name} count: {c.OrderCount}");
                        c.Orders.ForEach(o => {
                            System.Console.WriteLine($"order id: {o.OrderId} total: {o.Total}");
                            
                            o.Products.ForEach(p => {
                                System.Console.WriteLine($"product id: {p.ProductId} Name: {p.Name}");
                            });                            
                        });
                        
                    });

            }

        }

        public class CustomerDemo{

            public CustomerDemo(){
                this.Orders = new List<OrderDemo>();
            }

            public int CustomerId;
            public string Name;
            public int OrderCount;
            
            public List<OrderDemo> Orders;

        }

        public class OrderDemo{
            public int OrderId;
            public decimal Total;

            public List<ProductDemo> Products;
        }

        public class ProductDemo{
            public int ProductId;
            public string Name;
        }


    }
}
