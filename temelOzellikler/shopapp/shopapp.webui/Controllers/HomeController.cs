using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using temelOzellikler.ViewModels;

namespace temelOzellikler.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService){
            this._productService = productService;
        }

        public IActionResult Index(){
            

            ProductListViewModel productViewModel = new ProductListViewModel(){
                products = _productService.GetHomePageProducts()
            };
            
            return View(productViewModel);
        }

        public IActionResult About(){
            return View();
        }

        public IActionResult Contact(string message){
            System.Console.WriteLine("message: "+message);
            return View("MyView");
        }

      
        
    }
}