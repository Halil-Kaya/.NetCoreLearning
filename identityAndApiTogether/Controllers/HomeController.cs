using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace againAndAgainWhenWillYouStop.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Login(){

            return View();
        }

        [Authorize]
        public IActionResult Check(){

            return View();
        }

        public IActionResult AccessDenied(){
            return View();
        }


    }
}