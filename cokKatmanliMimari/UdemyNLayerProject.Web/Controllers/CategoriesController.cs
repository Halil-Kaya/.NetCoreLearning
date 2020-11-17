using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService,IMapper mapper){
            this._categoryService = categoryService;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index(){

            var categories = await _categoryService.GetAllAsync(); 

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto){
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id){
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto){

            _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id){
            
            var category = _categoryService.GetByIdAsync(id).Result;
            System.Console.WriteLine("category: " + category.Id);
            _categoryService.Remove(category);
            System.Console.WriteLine("burasi calisti");
            return RedirectToAction("Index");
        }


    }
}