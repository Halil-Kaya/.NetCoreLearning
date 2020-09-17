using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int productId, int categoryId)
        {
            using(var db = new ShopContext()){
                
                var cmd = "delete from ProductCategory where ProductId=@p0 and CategoryId=@p1";
                db.Database.ExecuteSqlRaw(cmd,productId,categoryId);

            }
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            using(var db = new ShopContext()){
                return db.Categories
                        .Where(i => i.CategoryId == categoryId)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault();
            }
        }

        public List<Category> GetPopularCategories()
        {
            throw new System.NotImplementedException();
        }

    }
}