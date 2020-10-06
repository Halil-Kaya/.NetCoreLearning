using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositories
{
    public interface IProductRepository
    {
        
        Task<IEnumerable<Product>> ListAsync();

        Task AddProductAsync(Product product);

        Task RemoveProduct(int productId);

        void UpdateProduct(Product product);

        Task<Product> FindByIdAsync(int productId);

    }
}