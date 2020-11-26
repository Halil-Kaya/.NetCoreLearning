using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repositories;

namespace UdemyNLayerProject.API.Controllers
{

    [Route("api/test/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        
        public TestController(IProductService productService,IMapper mapper,ICategoryService categoryService){
            this._productService = productService;
            this._mapper = mapper;
            this._categoryService = categoryService;
        }


        public async Task<IActionResult> getProductsWithCategory(){

            /*
            using(var db = new AppDbContext()){
                
                var products = await db.Products.Include(x => x.Category).SingleOrDefaultAsync(i => i.Id == 7);

                return Ok(products);
            }
            */
            var products = await _productService.GetWithCategoryByIdAsync(7);

            return Ok(_mapper.Map<ProductWithCategoryDto>(products));
        }


        public async Task<IActionResult> getCategoriesWithProducts(){


            var categories = await _categoryService.GetWithProductByIdAsync(5);



            return Ok(_mapper.Map<CategoryWithProductDto>(categories));

        }


    }
}