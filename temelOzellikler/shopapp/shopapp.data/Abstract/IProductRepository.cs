using shopapp.entity;
using System.Collections.Generic;

namespace shopapp.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
       List<Product> GetPopularProducts();
       List<Product> GetTop5Products();
    }
}