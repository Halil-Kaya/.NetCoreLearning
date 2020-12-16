using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using UdemyAPIOData.Models;

namespace UdemyAPIOData.Controllers
{
    public class ProductsController : ODataController
    {

        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context){
            _context = context;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Products);
        }
        
    } 
}