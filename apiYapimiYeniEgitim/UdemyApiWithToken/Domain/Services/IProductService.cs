using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Responses;

namespace UdemyApiWithToken.Domain.Services
{
    public interface IProductService
    {
         
        Task<BaseResponse<IEnumerable<Product>>> ListAsync();

        Task<BaseResponse<Product>> AddProduct(Product product);

        Task<BaseResponse<Product>> RemoveProduct(int productId);

        Task<BaseResponse<Product>> UpdateProduct(Product product,int productId);

        Task<BaseResponse<Product>> FindByIdAsync(int productId);

    }
}