using System.Threading.Tasks;
using UdemyNLayerProject.Core.models;

namespace UdemyNLayerProject.Core.Services
{
    public interface IProductService : IService<Product>
    {

        Task<Product> GetWithCategoryByIdAsync(int productId);

    }
}