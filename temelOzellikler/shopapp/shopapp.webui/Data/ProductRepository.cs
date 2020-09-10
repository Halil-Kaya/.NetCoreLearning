using System.Collections.Generic;
using System.Linq;
using temelOzellikler.Models;

namespace temelOzellikler.Data
{
    public static class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository(){

            _products = new List<Product>(){
                new Product(){ProductId = 1,Name = "samsung s6",Price = 3000,Description = "iyi tel",ImageUrl = "1.jpeg",CategoryId = 1},
                new Product(){ProductId = 2,Name = "samsung s7",Price = 4000,Description = "eh işte tel",IsApproved = true,ImageUrl = "2.jpeg",CategoryId = 1},
                new Product(){ProductId = 3,Name = "samsung s6",Price = 5000,Description = "çok iyi tel",ImageUrl = "3.jpeg",CategoryId = 1},
                new Product(){ProductId = 4,Name = "samsung s6",Price = 5000,Description = "tl iyi tel",ImageUrl = "5.jpeg",CategoryId = 1},
                new Product(){ProductId = 5,Name = "Lenova s6",Price = 3000,Description = "iyi tel",ImageUrl = "1.jpeg",CategoryId = 2},
                new Product(){ProductId = 6,Name = "Dell s7",Price = 4000,Description = "eh işte tel",IsApproved = true,ImageUrl = "2.jpeg",CategoryId = 2},
                new Product(){ProductId = 7,Name = "Dell s6",Price = 5000,Description = "çok iyi tel",ImageUrl = "3.jpeg",CategoryId = 2},
                new Product(){ProductId = 8,Name = "Dell s6",Price = 5000,Description = "tl iyi tel",ImageUrl = "5.jpeg",CategoryId = 2}
            
            };

        }


        public static List<Product> Products{

            get{
                return _products;
            }

        }

        public static void AddProduct(Product product){
            _products.Add(product);
        }

        public static Product GetProductById(int id){

            return _products.FirstOrDefault( p => p.ProductId == id );

        }       

        public static void EditProduct(Product p){
            
            Product product = GetProductById(p.ProductId);
            product.Name = p.Name;
            product.CategoryId = p.CategoryId;
            product.ImageUrl = p.ImageUrl;
            product.Price = p.Price;
            product.Description = p.Description;
        
        }


        public static void DeleteProduct(int id){

            var product = GetProductById(id);

            if(product != null){
                _products.Remove(product);
            }

        }

    }
}