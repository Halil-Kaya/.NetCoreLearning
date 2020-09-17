using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;
using shopapp.entity.obj;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using(var db = new ShopContext()){
                return db.Products
                            .Where(i =>i.ProductId == id)
                            .Include(i => i.ProductCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            
            using(var db = new ShopContext()){
            
            
                var products = db.Products.Where(i => i.IsApproved).AsQueryable();

                if(!string.IsNullOrEmpty(category)){
                    
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Name == category));
                                    
                }

                return products.Count();
            
            } 

        }

        public List<Product> GetHomePageProducts()
        {
            using(var db = new ShopContext()){
                return db.Products.Where(i => i.IsApproved && i.IsHome ).ToList();
            }
        }

        public List<Product> GetPopularProducts()
        {
            using(var db = new ShopContext()){
                return db.Products.ToList();
            }
        }

      

        public Product GetProductDetails(string url)
        {
             using(var db = new ShopContext()){
                return db.Products
                    .Where(p => p.Url == url)
                    .Include(p => p.ProductCategories)
                    .ThenInclude(p => p.Category)
                    .FirstOrDefault();
            }    
        }

        public List<Product> GetProductsByCategory(string name,int page,int pageSize)
        {
            
            using(var db = new ShopContext()){
                
                
                var products = db.Products
                        .Where(i => i.IsApproved).AsQueryable();

                if(!string.IsNullOrEmpty(name)){
                    
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));
                                    
                }

                return products.Skip( (page - 1) * pageSize ).Take(pageSize).ToList();
            } 


        }

        public List<Product> GetSearchResult(string searchString)
        {
            using(var db = new ShopContext()){
                
                
                var products = db.Products
                        .Where(i => i.IsApproved && ( i.Name.ToLower().Contains(searchString) || i.Description.ToLower().Contains(searchString) )).AsQueryable();

               

                return products.ToList();
            } 
        }

        public List<Product> GetTop5Products()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product entity, int[] CategoryIds)
        {
            using(var db = new ShopContext()){
                var product = db.Products
                                    .Include(i => i.ProductCategories)
                                    .FirstOrDefault(i => i.ProductId == entity.ProductId);

                if(product != null){
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;

                    product.ProductCategories = CategoryIds.Select(catid => new ProductCategory(){
                        ProductId = entity.ProductId,
                        CategoryId = catid
                    }).ToList();

                    db.SaveChanges();
                }
            }   
        }
    }
}