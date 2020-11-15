using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private AppDbContext _appDbContext { get => this._db as AppDbContext;}

        public CategoryRepository(DbContext db) : base(db)
        {
        }

        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await this._appDbContext.Categories
                .Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}