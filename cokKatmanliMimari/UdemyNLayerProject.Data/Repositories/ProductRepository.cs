using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {   
        private AppDbContext _appDbContext  { get => this._db as AppDbContext; }

        public ProductRepository(DbContext db) : base(db)
        {
            
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await this._appDbContext.Products
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == productId);
        }

    }
}