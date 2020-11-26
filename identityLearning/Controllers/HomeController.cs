using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using identityLearning.Models;
using identityLearning.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace identityLearning.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public HomeController(UserManager<AppUser> userManager){
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
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

                AppUser appUser = new AppUser();
                appUser.UserName = userViewModel.UserName;
                appUser.Email = userViewModel.Email;
                appUser.PhoneNumber = userViewModel.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(appUser,userViewModel.Password);
                
                if(result.Succeeded){

                    return RedirectToAction("LogIn");

                }else{

                    foreach (IdentityError item in result.Errors)
                    {
                        
                        ModelState.AddModelError("",item.Description);

                    }

                }
                

            }


            return View(userViewModel);
        }

    }
}
