using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using temelOzellikler.Models;
using temelOzellikler.ViewModels;

namespace temelOzellikler.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(){
             List<Product> products = new List<Product>(){
                new Product(){Name = "samsung s6",Price = 3000,Description = "iyi tel"},
                new Product(){Name = "samsung s7",Price = 4000,Description = "eh işte tel",IsApproved = true},
                new Product(){Name = "samsung s6",Price = 5000,Description = "çok iyi tel"},
                new Product(){Name = "samsung s6",Price = 5000,Description = "q iyi tel",IsApproved = true},
                new Product(){Name = "samsung s6",Price = 5000,Description = "tl iyi tel"}
            };

            List<Category> categories = new List<Category>(){
                new Category(){Name = "Telefon",Description = "Telefon kategorisi"},
                new Category(){Name = "Bilgisayar",Description = "Bilgisayar kategorisi"},
                new Category(){Name = "Elektronik",Description = "Elektronik kategorisi"}
            };
            

            ProductViewModel productViewModel = new ProductViewModel(){
                products = products,
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