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


        public async Task<ProductResponse> AddProduct(Product product)
        {

            try{

                await this._productRepository.AddProductAsync(product);

                await this._unitOfWork.CompleteAsync();

                return new ProductResponse(product);

            }catch(Exception e){
                return new ProductResponse($"Ürün eklenirken hata oldu: {e.Message}");
            }

        }

        public async Task<ProductResponse> FindByIdAsync(int productId)
        {

            try{

                Product p = await this._productRepository.FindByIdAsync(productId);

                if(p == null){

                    return new ProductResponse("ürün bulunamadı");

                }

                return new ProductResponse(p);

            }catch(Exception e){
                
                return new ProductResponse($"ürün bulunurken bir hata meydana geldi: {e.Message}");

            }

        }

        public async Task<ProductListResponse> ListAsync()
        {
            
            try{

                IEnumerable<Product> products = await this._productRepository.ListAsync();
                return new ProductListResponse(products);

            }catch(Exception e){

                return new ProductListResponse($"rün listelinirken bir hata oldu: {e.Message}");

            }

        }

        public async Task<ProductResponse> RemoveProduct(int productId)
        {

            try{

                Product product = await this._productRepository.FindByIdAsync(productId);

                if(product == null){

                    return new ProductResponse("silmeye çalıştığınız ürün bulunamadı");
                }

                this._productRepository.RemoveProduct(productId);

                await this._unitOfWork.CompleteAsync();
                
                return new ProductResponse(product);


            }catch(Exception e){
                
                return new ProductResponse($"ürün silinmeye çalışırken bir hata meydana geldi: {e.Message}");

            }

        }

        public async Task<ProductResponse> UpdateResponse(Product product, int productId)
        {

            try{
                
                Product firstProduct = await this._productRepository.FindByIdAsync(productId);

                if(firstProduct == null){
                    return new ProductResponse("güncellemeye çalıştığınız ürün bulunamadı");
                }

                firstProduct.Name = product.Name;
                firstProduct.Category = product.Category;
                firstProduct.Price = product.Price;
                
                this._productRepository.UpdateProduct(firstProduct);

                await this._unitOfWork.CompleteAsync();

                return new ProductResponse(firstProduct);

            }catch(Exception e){
                return new ProductResponse($"ürün güncellenirken bir hata oldu: {e.Message}");
                
            }

        }
    }
}