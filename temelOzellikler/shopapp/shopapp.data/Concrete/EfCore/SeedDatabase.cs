using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;
using shopapp.entity.obj;

namespace shopapp.data.Concrete.EfCore
{
    public class SeedDatabase
    {
     public static void Seed(){
         var db = new ShopContext();
         
         
         if(db.Database.GetPendingMigrations().Count() == 0){
             
             if(db.Categories.Count() == 0){
                 db.Categories.AddRange(Categories);
             }

             if(db.Products.Count() == 0){
                 db.Products.AddRange(Producties);
                 db.AddRange(ProductCategories);
             }
            db.SaveChanges();

         }


     }   

        private static Category[] Categories = {
            new Category(){Name = "Telefon", Url = "telefon"},
            new Category(){Name = "Bilgisayar",Url = "bilgisayar"},
            new Category(){Name = "Elektronik",Url = "elektronik"},
            new Category(){Name = "Beyaz Eşya",Url = "beyaz-esya"}
        };

        private static Product[] Producties = {
            new Product(){Name = "Samsung S5",Url = "samsung-s5",Price = 2000,ImageUrl = "1.jpeg",Description = "iyi telefon" , IsApproved = true},
            new Product(){Name = "Samsung S6",Url = "samsung-s6",Price = 3000,ImageUrl = "2.jpeg",Description = "iyi telefon" , IsApproved = false},
            new Product(){Name = "Samsung S7",Url = "samsung-s7",Price = 4000,ImageUrl = "3.jpeg",Description = "iyi telefon" , IsApproved = true},
            new Product(){Name = "Samsung S8",Url = "samsung-s8",Price = 5000,ImageUrl = "4.jpeg",Description = "iyi telefon" , IsApproved = false},
            new Product(){Name = "Samsung S9",Url = "samsung-s9",Price = 6000,ImageUrl = "5.jpeg",Description = "iyi telefon" , IsApproved = true},
        };

        private static ProductCategory[] ProductCategories = {
            new ProductCategory(){Product = Producties[0],Category = Categories[0]},
            new ProductCategory(){Product = Producties[0],Category = Categories[2]},
            new ProductCategory(){Product = Producties[1],Category = Categories[0]},
            new ProductCategory(){Product = Producties[1],Category = Categories[2]},
            new ProductCategory(){Product = Producties[2],Category = Categories[0]},
            new ProductCategory(){Product = Producties[2],Category = Categories[2]},
            new ProductCategory(){Product = Producties[3],Category = Categories[0]},
            new ProductCategory(){Product = Producties[3],Category = Categories[2]},
        };


    }
}