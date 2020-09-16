using System.Collections.Generic;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        
        public List<Category> GetPopularCategories()
        {
            throw new System.NotImplementedException();
        }

    }
}