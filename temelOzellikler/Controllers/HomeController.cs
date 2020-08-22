using Microsoft.AspNetCore.Mvc;

namespace temelOzellikler.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(){
            ViewBag.isim = "Halil Kaya";
            return View();
        }

        public IActionResult About(){
            return View();
        }

        public IActionResult Contact(){
            return View("MyView");
        }


        
    }
}