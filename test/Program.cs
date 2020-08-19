using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace test
{

    public class ShopContext : DbContext{

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            .UseMySql("server=127.0.0.1;port=3305;username=root;password=;database=shop");
            
        }

        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

    }


    public class User{

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Address> Addresses { get; set; }
        
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

        public Product(){

        }
        public Product(string name,decimal price){
            this.Name = name;
            this.Price = price;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public void PrintInfo(){
            System.Console.WriteLine($"id: {Id} Name: {Name} Price: {Price}");
        }
        
        public void PrintInfoWithoutId(){
            System.Console.WriteLine($"Name: {Name} Price: {Price}");
        }

        public void PrintId(){
            System.Console.WriteLine($"id: {Id}");
        }

        public void PrintName(){
            System.Console.WriteLine($"Name: {Name}");
        }

        public void PrintPrice(){
            System.Console.WriteLine($"Name: {Price}");
        }

    }


    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            
            //AddProduct(new Product("Samsung 6",50   ));
            
            /*
            List<Product> products = new List<Product>(){
                new Product("Lenove",8972),
                new Product("S5",2579),
                new Product("Sahin",9760)
            };
            AddProducts(products);
            */

            /*
            GetAllProducts().ForEach(p =>{
                
                p.PrintInfo();

            });
            */

            //GetAllProductsNames();

            //GetProductById(3).PrintInfo();

            //GetProductsByName("sa");

            //UpdateProduct1(1,"Halil Kaya",9999);
            
            //UpdateProduct2(1,"----",452);
            
            //UpdateProduct2(1,"Halil Kaya",999);
            DeleteProductById(12);
            

        }


        public static void DeleteProductById(int id){
           
            using(var db = new ShopContext()){

                Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();

                if(product != null){

                    //bu sekilde de silinebiliyor kendisi otomatik hangi tabloda oldugunu buluyor
                    //db.Remove(product);
                    db.Products.Remove(product);


                    db.SaveChanges();
                }

            }

        }

        public static void UpdateProduct1(int id,string newName,decimal newPrice){

            using(var db = new ShopContext()){
                
                Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();
                
                product.Name = newName;
                product.Price = newPrice;

                db.SaveChanges();

            }

        }

        public static void UpdateProduct2(int id,string newName,decimal newPrice){

            using(var db = new ShopContext()){
                
                Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();

                product.Name = newName;
                product.Price = newPrice;

                db.Products.Update(product);

                db.SaveChanges();
            }
                
        }


        public static List<Product> GetAllProducts(){

            List<Product> products = null; 

            using(var db = new ShopContext()){
                products = db.Products.ToList();
            }

            return products;

        }

        public static void GetAllProductsNames(){
            
            using(var db = new ShopContext()){
                
                var productsNames = db.Products.Select(p => new {p.Name}).ToList();
                
                productsNames.ForEach(p => {
                    System.Console.WriteLine($"-Name: {p.Name}");
                });    
                
            }
        }

        public static Product GetProductById(int id){
            
            Product product = null;

            using(var db = new ShopContext()){
                product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            }

            return product;
        }

        public static void GetProductsByName(string name){

            using(var db = new ShopContext()){

                var result = db.Products.Select(p => new {p.Name})
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();

                result.ForEach(p =>{
                    System.Console.WriteLine($"name: {p.Name}");
                });

            }

        }


        //dizi olarak Product objelerini veri tabanına ekliyorum
        public static void AddProducts(List<Product> products){

            //veri tabanı bağlantısı oluşturuyorum
            using(var db = new ShopContext()){

                
                db.Products.AddRange(products);
                db.SaveChanges();
                
                System.Console.WriteLine("topluca kaydedildi");
            }

        }


        //gonderdigim Product objesini veri tabanına kaydediyorum
        public static void AddProduct(Product p){

            //veri tabanına bağlantı oluşturuyorum
            using(var db = new ShopContext()){

                //veri tabanına objeyi ekliyorum
                db.Products.Add(p);
                //değişiklikleri kaydediyorum
                db.SaveChanges();
                //eklendiği bilgisini veriyorum
                System.Console.WriteLine("veri eklendi");
            }

        }

    }
}
