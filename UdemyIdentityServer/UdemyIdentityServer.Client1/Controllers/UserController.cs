using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyIdentityServer.Client1.Controllers
{

    [Authorize]
    public class UserController : Controller
    {

        public IActionResult Index(){

            return View();
        }
        
    }
}