using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetPopularCategories();
        Category GetByIdWithProducts(int categoryId);
        void DeleteFromCategory(int productId, int categoryId);
    }
}