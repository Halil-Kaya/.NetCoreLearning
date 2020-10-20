using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Repositories;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;

namespace UdemyApiWithToken.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork){
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }


        public async Task<BaseResponse<Product>> AddProduct(Product product)
        {

            try{

                await this._productRepository.AddProductAsync(product);

                await this._unitOfWork.CompleteAsync();

                return new BaseResponse<Product>(product);

            }catch(Exception e){
                return new BaseResponse<Product>($"Ürün eklenirken hata oldu: {e.Message}");
            }

        }

        public async Task<BaseResponse<Product>> FindByIdAsync(int productId)
        {

            try{

                Product p = await this._productRepository.FindByIdAsync(productId);

                if(p == null){

                    return new BaseResponse<Product>("ürün bulunamadı");

                }

                return new BaseResponse<Product>(p);

            }catch(Exception e){
                
                return new BaseResponse<Product>($"ürün bulunurken bir hata meydana geldi: {e.Message}");

            }

        }

        public async Task<BaseResponse<IEnumerable<Product>>> ListAsync()
        {
            
            try{

                IEnumerable<Product> products = await this._productRepository.ListAsync();
                return new BaseResponse<IEnumerable<Product>>(products);

            }catch(Exception e){

                return new BaseResponse<IEnumerable<Product>>($"rün listelinirken bir hata oldu: {e.Message}");

            }

        }

        public async Task<BaseResponse<Product>> RemoveProduct(int productId)
        {

            try{

                Product product = await this._productRepository.FindByIdAsync(productId);

                if(product == null){

                    return new BaseResponse<Product>("silmeye çalıştığınız ürün bulunamadı");
                }
                await this._productRepository.RemoveProduct(productId);

                await this._unitOfWork.CompleteAsync();
                
                return new BaseResponse<Product>(product);


            }catch(Exception e){
                
                return new BaseResponse<Product>($"ürün silinmeye çalışırken bir hata meydana geldi: {e.Message}");

            }

        }

        public async Task<BaseResponse<Product>> UpdateProduct(Product product, int productId)
        {

            try{
                
                Product firstProduct = await this._productRepository.FindByIdAsync(productId);

                if(firstProduct == null){
                    return new BaseResponse<Product>("güncellemeye çalıştığınız ürün bulunamadı");
                }

                firstProduct.Name = product.Name;
                firstProduct.Category = product.Category;
                firstProduct.Price = product.Price;
                
                this._productRepository.UpdateProduct(firstProduct);

                await this._unitOfWork.CompleteAsync();

                return new BaseResponse<Product>(firstProduct);

            }catch(Exception e){
                return new BaseResponse<Product>($"ürün güncellenirken bir hata oldu: {e.Message}");
                
            }

        }
    }
}