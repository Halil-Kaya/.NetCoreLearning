using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using temelOzellikler.ViewModels;
using shopapp.entity;

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

        [HttpGet]
        public IActionResult List(int? id){
            
            
            return View();
        }

        public IActionResult Details(int id){
            return View();
        }


        [HttpGet]
        public IActionResult Create(){
            return View(new Product());
        }



        [HttpPost]
        public IActionResult Create(Product p){

            /*
            System.Console.WriteLine("name: " + p.Name); 
            System.Console.WriteLine("Price: " + p.Price);
            System.Console.WriteLine("Description: " + p.Description);
            System.Console.WriteLine("imageUrl: " + p.ImageUrl);
            System.Console.WriteLine("categoryId: " + p.CategoryId);
            */

            return View(p);
        }


        [HttpGet]
        public IActionResult Edit(int id){

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product p){
            return RedirectToAction("list");
        }

        [HttpPost]
        public IActionResult Delete(int ProductId){
            
            return RedirectToAction("list");
        }


    }
}