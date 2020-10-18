using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Extensions;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,IMapper mapper){
            this._productService = productService;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetList(){

            var productListResponse = await this._productService.ListAsync();
            
            if(productListResponse.Success){

                return Ok(productListResponse.ProductList);

            }

            return BadRequest(productListResponse.Message);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int? id){

            if(id == null){
                return BadRequest("int sayi girmedin!");
            }

            ProductResponse productResponse = await this._productService.FindByIdAsync((int)id);

            if(productResponse.Success){
                return Ok(productResponse.Product);
            }

            return BadRequest(productResponse.Message);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource){

            if(!ModelState.IsValid){


                return BadRequest(ModelState.GetErrorMessages());
            
            }
            Product product = this._mapper.Map<ProductResource,Product>(productResource);
            
            var productResponse = await this._productService.AddProduct(product);

            if(productResponse.Success){

                return Ok(productResponse.Product);
            
            }

            return BadRequest(productResponse.Message);

        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource,int id){

            if(!ModelState.IsValid){
                
                return BadRequest(ModelState.GetErrorMessages());

            }

            Product product = this._mapper.Map<ProductResource,Product>(productResource);

            var productResponse = await this._productService.UpdateProduct(product,id);

            if(productResponse.Success){
                return Ok(productResponse.Product);
            }

            return BadRequest(productResponse.Message);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id){

            var productResponse = await this._productService.RemoveProduct(id);

            if(productResponse.Success){
                return Ok(productResponse.Product);
            }


            return BadRequest(productResponse.Message);
        }


/*
        [HttpDelete("{name:string}/{category:string}")]
        public async Task<IActionResult> RemoveProduct(string name,string category){

            var productResponse = await this._productService.RemoveProduct(id);

            if(productResponse.Success){
                return Ok(productResponse.Product);
            }


            return BadRequest(productResponse.Message);
        }
*/
        

    }
}