using shopapp.entity;
using System.Collections.Generic;

namespace shopapp.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
       Product GetProductDetails(string productname);
        Product GetByIdWithCategories(int id);
       List<Product> GetProductsByCategory(string name,int page,int pageSize);
       List<Product> GetPopularProducts();
       List<Product> GetTop5Products();
       List<Product> GetHomePageProducts();
       List<Product> GetSearchResult(string searchString);
        
        void Update(Product enttity,int[] CategoryIds);
       
        int GetCountByCategory(string category);
        
    }
}