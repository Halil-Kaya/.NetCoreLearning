using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService : IValidator<Product>
    {
        Product GetById(int id);

        Product GetProductDetails(string url);

        Product GetByIdWithCategories(int id);
        
        List<Product> GetProductsByCategory(string name,int page,int pageSize);
        List<Product> GetAll();
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);

        bool Create(Product entity);

        void Update(Product entity);
        void Update(Product enttity,int[] CategoryIds);
        void Delete(Product entitiy);
        int GetCountByCategory(string category);

    }
}