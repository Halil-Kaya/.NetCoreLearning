using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using temelOzellikler.Data;
using temelOzellikler.Models;
using temelOzellikler.ViewModels;

namespace temelOzellikler.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(){
            

            ProductViewModel productViewModel = new ProductViewModel(){
                products = ProductRepository.Products
            };
            
            return View(productViewModel);
        }

        public IActionResult About(){
            return View();
        }

        public IActionResult Contact(){
            return View("MyView");
        }

      
        
    }
}