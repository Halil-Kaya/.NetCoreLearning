using System.Threading.Tasks;
using UdemyNLayerProject.Core.models;

namespace UdemyNLayerProject.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<Category> GetWithProductByIdAsync(int categoryId);
        
         
    }
}