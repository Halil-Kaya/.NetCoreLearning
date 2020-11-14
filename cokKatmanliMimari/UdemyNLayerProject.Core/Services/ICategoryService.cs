using System.Threading.Tasks;
using UdemyNLayerProject.Core.models;

namespace UdemyNLayerProject.Core.Services
{
    public interface ICategoryService : IService<Category>
    {

        Task<Category> GetWithProductByIdAsync(int categoryId);

         
    }
}