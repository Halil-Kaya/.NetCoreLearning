using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Models;
using temelOzellikler.ViewModels;

namespace shopapp.webui.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        
        public AdminController(IProductService productService,ICategoryService categoryService){
            this._productService = productService;
            this._categoryService = categoryService;
        }

        public IActionResult ProductList(){
            return View(new ProductListViewModel(){
                products = _productService.GetAll()
            });
        }

        public IActionResult CategoryList(){
            return View(new CategoryListViewModel(){
                Categories = _categoryService.GetAll()
            });
        }

        public IActionResult ProductCreate(){
            return View();
        }

        [HttpPost]
        public IActionResult ProductCreate(Product product){
            
            if( _productService.Create(product)){
                var msg = new AlertMessage(){
                    Message =  $"{product.Name} isimli ürün oluşturuldu.",
                    AlertType = "success"
                };

                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("ProductList");


            }
            
            return View();      

        }


        public IActionResult CategoryCreate(){
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model){
            
            
            var entity = new Category(){
                Name = model.Name,
                Url = model.Url
            };

            _categoryService.Create(entity);
            
            

            var msg = new AlertMessage(){
                Message =  $"{entity.Name} isimli kategori oluşturuldu.",
                AlertType = "success"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);


            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult ProductEdit(int? id){
            
            if(id == null){
                return NotFound();
            }

            var product =_productService.GetByIdWithCategories((int)id);
            
            if(product == null){
                return NotFound();
            } 

            var model = new ProductModel(){
                ProductId = product.ProductId,
                Name = product.Name,
                Url = product.Url,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                SelectedCategories = product.ProductCategories.Select(i => i.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();

            return View(model);    
        }
         

        [HttpPost]
        public async Task<IActionResult> ProductEdit(Product model,int[] categoryIds,IFormFile file){
            
            var product = _productService.GetById(model.ProductId);

            if(product == null){
                return NotFound();
            }
                
            if(file != null){

                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                product.ImageUrl = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot//img",randomName);

                using(var stream = new FileStream(path,FileMode.Create)){
                    await file.CopyToAsync(stream);
                }

            }
            _productService.Update(product,categoryIds);

            var msg = new AlertMessage(){
                Message =  $"{product.Name} isimli ürün güncellendi.",
                AlertType = "success"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");    
        }


        [HttpGet]
        public IActionResult CategoryEdit(int? id){
            
            if(id == null){
                return NotFound();
            }

            var category =_categoryService.GetByIdWithProducts((int)id);

            var model = new CategoryModel(){
                CategoryId = category.CategoryId,
                Name = category.Name,
                Url = category.Url,
                Products = category.ProductCategories.Select(p => p.Product).ToList()
            };
            
            if(category == null){
                return NotFound();
            } 

            return View(model);    
        }



         

        [HttpPost]
        public IActionResult CategoryEdit(Category model){
            
            var category = _categoryService.GetById(model.CategoryId);

            if(category == null){
                return NotFound();
            }

            _categoryService.Update(model);

            var msg = new AlertMessage(){
                Message =  $"{category.Name} isimli ürün güncellendi.",
                AlertType = "success"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");    
        }

        public IActionResult Deleteproduct(int productId){
            _productService.Delete(_productService.GetById(productId));
            
            var msg = new AlertMessage(){
                Message =  $"{productId} id li ürün silindi.",
                AlertType = "danger"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteCategory(int categoryId){
            _categoryService.Delete(_categoryService.GetById(categoryId));
            
            var msg = new AlertMessage(){
                Message =  $"{categoryId} id li ürün silindi.",
                AlertType = "danger"
            };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult Deletefromcategory(int productId,int categoryId){
            _categoryService.DeleteFromCategory(productId,categoryId);
            return Redirect("/admin/categories/" + categoryId);
        }

    }
}