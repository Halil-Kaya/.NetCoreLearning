using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using temelOzellikler.Data;
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

        public IActionResult List(int? id){
            
            var products = ProductRepository.Products;

            if(id != null){
                products = products.Where(p => p.CategoryId == id).ToList();
            }

            string q = HttpContext.Request.Query["q"];

            if(!string.IsNullOrEmpty(q)){
                products = products.Where(p => p.Name.ToLower().Contains(q.ToLower())).ToList();
            }



            ProductViewModel productViewModel = new ProductViewModel(){
                products = products,
            };
            
            return View(productViewModel);
        }

        public IActionResult Details(int id){
            return View(ProductRepository.GetProductById(id));
        }


        [HttpGet]
        public IActionResult Create(){
            ViewBag.Categories = CategoryRepository.Categories;
            return View();
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
            ProductRepository.AddProduct(p);
            
            return RedirectToAction("list");
        }


        [HttpGet]
        public IActionResult Edit(int id){

            ViewBag.Categories = CategoryRepository.Categories;
            return View(ProductRepository.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product p){
            ProductRepository.EditProduct(p);
            return RedirectToAction("list");
        }


    }
}