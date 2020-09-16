using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Models;
using temelOzellikler.ViewModels;

namespace shopapp.webui.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService){
            this._productService = productService;
        }


        //localhost/products/telefon?page=1
        public IActionResult List(string category,int page = 1){
            
            const int pageSize = 2;
            ProductListViewModel productViewModel = new ProductListViewModel(){
                PageInfo = new PageInfo(){
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                products = _productService.GetProductsByCategory(category,page,pageSize)
            };
            
            return View(productViewModel);
        }

        public IActionResult Details(string url){
            System.Console.WriteLine("----");
            if(url == null){
                System.Console.WriteLine("--++--");
                return NotFound();
            }
            Product product = _productService.GetProductDetails(url);

            if(product == null){
                System.Console.WriteLine("/--++--/");

                return NotFound();
            }

            return View(new ProductDetailModel(){
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }





        public IActionResult Search(string q){

            var productViewModel = new ProductListViewModel(){
                products = _productService.GetSearchResult(q)
            };

            return View(productViewModel);
        }
        
    }
}