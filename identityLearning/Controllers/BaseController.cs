using identityLearning.EmailServices;
using identityLearning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identityLearning.Controllers
{
    public class BaseController : Controller
    {

        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly RoleManager<AppRole> _roleManager;
        protected readonly IEmailSender _emailSender;
        protected AppUser CurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;

        public BaseController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IEmailSender emailSender){
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._emailSender = emailSender;
        }

        public BaseController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager){
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public BaseController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager){
            this._userManager = userManager;
            this._roleManager = roleManager;
        }



        public void AddModelError(IdentityResult result){

            foreach (var item in result.Errors)
            {  
                
                ModelState.AddModelError("",item.Description);

            }

        }


    }
}