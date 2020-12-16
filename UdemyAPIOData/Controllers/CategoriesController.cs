using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using UdemyAPIOData.Models;

namespace UdemyAPIOData.Controllers
{

    public class CategoriesController : ODataController
    {
        
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context){
            _context = context;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Categories);
        }
        

    }
}