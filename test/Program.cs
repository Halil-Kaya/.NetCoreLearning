using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

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
            /*
            List<User> users = new List<User>(){
                new User(){Username = "Halil Kaya",Email = "hl@gmail.com"},
                new User(){Username = "Semih Parlak",Email = "qq@gmail.com"},
                new User(){Username = "muco",Email = "ttt@gmail.com"}
            };

            InsertUser(users);
*/
/*
            List<Address> addresses = new List<Address>(){
                new Address(){Fullname = "Muci",Title = "iş adresi",Body = "fatih",UserId = 1},
                new Address(){Fullname = "Hasan",Title = "iş adresi",Body = "Balat",UserId = 2},
                new Address(){Fullname = "Mahmut",Title = "Ev adresi",Body = "fatih",UserId = 1},
                new Address(){Fullname = "Habib",Title = "iş adresi",Body = "fatih",UserId = 3},
                new Address(){Fullname = "Erkam",Title = "Ev adresi",Body = "fatih",UserId = 2}
            };

            InsertAddress(addresses);
*/  

            //AddAdressToUser(1);
            
            /*
            using (var db = new ShopContext())
            {
                
                List<User> users = new List<User>(){
                    new User(){Username = "Halil",Email = "asf@gmail.com"},
                    new User(){Username = "Semih",Email = "qqq@gmail.com"},
                    new User(){Username = "Erkam",Email = "ccc@gmail.com"}
                };

                db.Users.AddRange(users);
                db.SaveChanges();

            }
*/

/*
            using(var db = new ShopContext()){

                Customer customer = new Customer(){
                    IdentityNumber = "66adsasd5",
                    FirstName = "asd",
                    LastName = "asdasdasdasd",
                    UserId = 1
                };

                db.Customers.Add(customer);
                db.SaveChanges();
            }
*/

/*
            using(var db = new ShopContext()){

                //ekleyeceğim idler
                int[] ids = new int[2]{3,4};


                //burda şunu yapıyorum
                /*
                    [1,1]
                    [1,2]
                    [1,3]
                    
                    yani producttan categoriye 
                */
                /*
                var product = db.Products.Where(p => p.Id == 3).FirstOrDefault();

                product.ProductCategories = ids.Select(cid => new ProductCategory(){
                    CategoryId = cid,
                    ProductId = product.Id
                }).ToList();
                */

                //burda şunu yapıyorum
                /*
                    [1,1]
                    [2,1]
                    [3,1]

                    yani category den producta
                */
                /*
                var category = db.Categories.Where(c => c.Id ==1).FirstOrDefault();

                category.ProductCategories = ids.Select(pid => new ProductCategory(){
                    CategoryId = category.Id,
                    ProductId = pid
                }).ToList();
*/

                //db.SaveChanges();


            




        }



        

        public static void AddAdressToUser(int id){

            
            

            using(var db = new ShopContext()){
                
                var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            

                user.Addresses = new List<Address>();
                user.Addresses.AddRange(new List<Address>(){
                    new Address(){Fullname = "---",Title = "iş adresi",Body = "Balat"},
                    new Address(){Fullname = "...",Title = "Ev adresi",Body = "fatih"},
                    new Address(){Fullname = "<___>",Title = "iş adresi",Body = "fatih"}
                });

                db.SaveChanges();

            }


        }

        public static User GetUser(int id){
            User user = null;
            
            using(var db = new ShopContext()){
                user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            }
           
            return user;
        }


        public static void InsertAddress(List<Address> addresses){

            using(var db = new ShopContext()){

                db.Addresses.AddRange(addresses);
                db.SaveChanges();

            }

        }



        public static void InsertUser(List<User> users){
            
            using(var db = new ShopContext()){

                db.Users.AddRange(users);
                db.SaveChanges();

            }

        }


    }
}
