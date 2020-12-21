using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.API.Models;

namespace UdemyAndroidKotlin.API.Controllers
{
    [Authorize]
    public class CategoriesController : ODataController
    {

        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context) {
            _context = context;
        }

        //odata/categories
        [EnableQuery]
        public IActionResult Get() {
            return Ok(_context.Categories.AsQueryable());
        }


    }
}
