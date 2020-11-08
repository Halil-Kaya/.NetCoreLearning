using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapplication.Models;

namespace webapplication.Controllers
{
    public class AdminController : Controller
    {

        private UserManager<AppUser> userMAnager { get; }
        
        public AdminController(UserManager<AppUser> userMAnager){
            this.userMAnager = userMAnager;
        }
        
        public IActionResult Index(){
            return View(userMAnager.Users.ToList());
        }
        
    }
}