using System.Linq;
using identityLearning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identityLearning.Controllers
{
    public class AdminController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager){
            this._userManager = userManager;
        }


        public IActionResult Index(){
            return View(_userManager.Users.ToList());
        }
        
    }
}