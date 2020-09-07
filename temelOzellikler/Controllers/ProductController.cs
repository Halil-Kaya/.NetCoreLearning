using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using temelOzellikler.Models;
using temelOzellikler.ViewModels;

namespace temelOzellikler.Controllers
{

    //localhost:5001/product
    public class ProductController : Controller
    {
        
        public IActionResult Index(){

            Product p = new Product();
            p.Name = "samsung s6";
            p.Price = 3000;
            p.Description = "iyi telefon idare eder";

            return View(p);
        }

        public IActionResult List(){
            
            List<Product> products = new List<Product>(){
                new Product(){Name = "samsung s6",Price = 3000,Description = "iyi tel"},
                new Product(){Name = "samsung s7",Price = 4000,Description = "eh işte tel",IsApproved = true},
                new Product(){Name = "samsung s6",Price = 5000,Description = "çok iyi tel"},
                new Product(){Name = "samsung s6",Price = 5000,Description = "q iyi tel",IsApproved = true},
                new Product(){Name = "samsung s6",Price = 5000,Description = "tl iyi tel"}
            };




            ProductViewModel productViewModel = new ProductViewModel(){
                products = products,
            };
            
            return View(productViewModel);
        }

        public IActionResult Details(int id){
            ViewBag.id = id;
            return View();
        }

    }
}