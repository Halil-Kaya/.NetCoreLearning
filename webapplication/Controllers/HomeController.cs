using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapplication.Models;
using webapplication.ViewModels;

namespace webapplication.Controllers
{
    public class HomeController : Controller
    {
        
        public readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager){
            this._userManager = userManager;
        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult LogIn(){
            return View();
        }

        public IActionResult SignUp(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel){


            if(ModelState.IsValid){

                AppUser user = new AppUser();
                user.UserName = userViewModel.UserName;
                user.Email = user.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;

                IdentityResult result = await this._userManager.CreateAsync(user,userViewModel.Password);
                
                if(result.Succeeded){

                    return RedirectToAction("Login");

                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                    
                }


            }


            return View(userViewModel);

        }



    }
}