using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(UdemyApiWithTokenDBContext dbContext) : base(dbContext){}
   

        public async Task AddProductAsync(Product product)
        {
            await this._dbContext.Product.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int productId)
        {
            return await this._dbContext.Product.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await this._dbContext.Product.ToListAsync();
        }

        public void RemoveProduct(int productId)
        {
            var product = FindByIdAsync(productId);
            this._dbContext.Remove(product);

        }

        public void UpdateProduct(Product product)
        {
            
            this._dbContext.Product.Update(product);

        }
    }
}