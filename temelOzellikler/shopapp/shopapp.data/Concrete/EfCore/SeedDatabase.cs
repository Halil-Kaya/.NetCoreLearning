using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

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
             }
            db.SaveChanges();

         }


     }   

        private static Category[] Categories = {
            new Category(){Name = "Telefon"},
            new Category(){Name = "Bilgisayar"},
            new Category(){Name = "Elektronik"}
        };

        private static Product[] Producties = {
            new Product(){Name = "Samsung S5",Price = 2000,ImageUrl = "1.jpeg",Description = "iyi telefon" , IsApproved = true},
            new Product(){Name = "Samsung S6",Price = 3000,ImageUrl = "2.jpeg",Description = "iyi telefon" , IsApproved = false},
            new Product(){Name = "Samsung S7",Price = 4000,ImageUrl = "3.jpeg",Description = "iyi telefon" , IsApproved = true},
            new Product(){Name = "Samsung S8",Price = 5000,ImageUrl = "4.jpeg",Description = "iyi telefon" , IsApproved = false},
            new Product(){Name = "Samsung S9",Price = 6000,ImageUrl = "5.jpeg",Description = "iyi telefon" , IsApproved = true},
        };




    }
}