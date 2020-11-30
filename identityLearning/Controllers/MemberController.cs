using System;
using System.IO;
using System.Threading.Tasks;
using identityLearning.Enums;
using identityLearning.Models;
using identityLearning.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace identityLearning.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {
        
        public MemberController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager):base(userManager,signInManager){
        }



        public IActionResult Index(){

            //eğer şuan sistemde kişi giriş yapmışsa 
            //User.Identity.IsAuthenticated -> true oluyor  
            //true olduğunda User.Identity.Name içinde kullanıcı adı oluyor o kullanıcı adıyla kullanıcıyı buluyorum
            //CurrentUser BaseControllerin içinde!
            AppUser user = CurrentUser;

            //Adapt metodu Mapster kütüphanesinden geliyor AutoMapper in yaptığını yapıyor AutoMapper dan daha performanslı çalıştığı söyleniliyor
            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            return View(userViewModel);
        }


        public IActionResult UserEdit(){
            
            AppUser user = CurrentUser;

            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserViewModel userViewModel,IFormFile userPicture){

            //UserViewModel kismini birkac yerde daha kullaniyorum edit kismi için password bilgisi gereksiz eğer bu kismi çikartmazsam
            //ModelState.IsValid kısmı hatalı olucak o yüzden Password kısmını çıkartıp görmezden geliyorum
            ModelState.Remove("Password");

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));


            if(ModelState.IsValid){

                AppUser user = CurrentUser;


                if(userPicture != null && userPicture.Length > 0){

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/UserPicture",fileName);

                    using(var stream = new FileStream(path,FileMode.Create)){
                        await userPicture.CopyToAsync(stream);
                        user.Picture = "/UserPicture/" + fileName;
                    }

                }

                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;

                user.City = userViewModel.City;
                user.BirthDay = userViewModel.BirthDay;
                user.Gender = (int) userViewModel.Gender;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if(result.Succeeded){

                    //kullanıcının kullanıcı adını da güncellettiğim için securityStampi güncelliyorum
                    await _userManager.UpdateSecurityStampAsync(user);
                    //securityStampi güncellediğim için kullanıcıyı sistemden çıkartıp bir daha sokuyorum böylece cookie tekrar oluşuyor
                    await _signInManager.SignOutAsync();
                    //2. parametredeki true nun anlamı session oturumu değil normal oturum açma anlamına geliyor yani 60 gün
                    await _signInManager.SignInAsync(user,true);

                    ViewBag.success = "true";

                }else{

                    AddModelError(result);

                }

            }

            return View(userViewModel);
        }


        public IActionResult PasswordChange(){
            return View();
        }

        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeViewModel passwordChangeViewModel){
            
            if(ModelState.IsValid){

                AppUser user = CurrentUser;

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

                            AddModelError(result);

                        }

                    }else{

                        ModelState.AddModelError("","Eski Şifreniz Yanlış");

                    }

                }

            }

            
            return View(passwordChangeViewModel);
        }


        public void Logout(){
            _signInManager.SignOutAsync();
        }

    }
}