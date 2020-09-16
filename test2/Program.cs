using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using test2.Data.EfCore;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using(var db = new NothwindContext()) {

                var products = db.Products.ToList();

                products.ForEach(item => {
                    System.Console.WriteLine(item.Name);
                    var prcategory = item.ProductCategory.ToList();
                    prcategory.ForEach(item => {
                        System.Console.WriteLine("?");
                        System.Console.WriteLine(item.CategoryId);
                    });
                });

                System.Console.WriteLine("-----------------");

            }


            
            using(var db = new NothwindContext()) {

                var products = db.Products.Include(products => products.ProductCategory).ToList();

                 products.ForEach(item => {
                    System.Console.WriteLine(item.Name);
                    



                });

                System.Console.WriteLine("-----------------");

            }



        }
    }
}
