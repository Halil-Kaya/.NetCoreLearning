using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);

        Product GetProductDetails(string url);

        List<Product> GetProductsByCategory(string name,int page,int pageSize);
        List<Product> GetAll();
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);

        void Create(Product entity);

        void Update(Product entity);

        void Delete(Product entitiy);
        int GetCountByCategory(string category);

    }
}