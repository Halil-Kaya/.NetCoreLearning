using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper){
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        //abc.com/api/catogeroy/2/products
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id){
            var category = await _categoryService.GetWithProductByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto){

            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty,_mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto){
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var category = _categoryService.GetByIdAsync(id).Result; 
            _categoryService.Remove(category);
            return NoContent();
        }



    }
}