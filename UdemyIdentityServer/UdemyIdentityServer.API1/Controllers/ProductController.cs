using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyIdentityServer.API1.Models;

namespace UdemyIdentityServer.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public IActionResult GetProducts(){
            
            var productList = new List<Product>(){
                new Product(){Id = 1,Name = "Kalem",Price = 100,Stock = 500},
                new Product(){Id = 2,Name = "Silgi",Price = 100,Stock = 500},
                new Product(){Id = 3,Name = "Defter",Price = 100,Stock = 500},
                new Product(){Id = 4,Name = "Kitap",Price = 100,Stock = 500},
                new Product(){Id = 5,Name = "Bant",Price = 100,Stock = 500},
            };

            return Ok(productList);
        }
        
        
    }
}