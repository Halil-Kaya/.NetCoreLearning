using identityLearning.Models;
using identityLearning.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace identityLearning.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public MemberController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager){
            this._userManager = userManager;
            this._signInManager = signInManager;
        }



        public IActionResult Index(){
            
            //eğer şuan sistemde kişi giriş yapmışsa 
            //User.Identity.IsAuthenticated -> true oluyor  
            //true olduğunda User.Identity.Name içinde kullanıcı adı oluyor o kullanıcı adıyla kullanıcıyı buluyorum

            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            //Adapt metodu Mapster kütüphanesinden geliyor AutoMapper in yaptığını yapıyor AutoMapper dan daha performanslı çalıştığı söyleniliyor
            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            return View(userViewModel);
        }


        public IActionResult PasswordChange(){
            return View();
        }

        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeViewModel passwordChangeViewModel){
            
            if(ModelState.IsValid){

                AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;

                if(user != null){

                    bool exist = _userManager.CheckPasswordAsync(user,passwordChangeViewModel.PasswordOld).Result;

                    if(exist){

                        IdentityResult result = _userManager.ChangePasswordAsync(user,passwordChangeViewModel.PasswordOld,passwordChangeViewModel.PasswordNew).Result;

                        if(result.Succeeded){
                            
                            //önemli bir bilgi değiştiği için securityStampi güncelliyorum böylece bir şeylerin değiştiğini anlamış olucam
                            _userManager.UpdateSecurityStampAsync(user);

                            //cookienin tekrar oluşması için kişiyi sistemden çıkartıp tekrar sokuyorum
                            _signInManager.SignOutAsync();
                            _signInManager.PasswordSignInAsync(user,passwordChangeViewModel.PasswordNew,true,false);


                            ViewBag.success = "true";


                        }else{

                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError("",item.Description);
                            }

                        }

                    }else{

                        ModelState.AddModelError("","Eski Şifreniz Yanlış");

                    }

                }

            }

            
            return View(passwordChangeViewModel);
        }


    }
}