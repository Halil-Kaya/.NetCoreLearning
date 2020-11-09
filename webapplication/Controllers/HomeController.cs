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
        public readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager){
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult LogIn(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel userLogin){
            
            if(ModelState.IsValid){
                
                AppUser user = await this._userManager.FindByEmailAsync(userLogin.Email);

                if(user != null){

                    await this._signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await this._signInManager.PasswordSignInAsync(user,userLogin.Password,false,false);

                    if(result.Succeeded){
                        
                        return RedirectToAction("Index","Member");

                    }


                }else{
                    ModelState.AddModelError(nameof(LoginViewModel.Email),"Geçersiz email adresi veya şifresi");
                }



            }
            
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