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
using identityLearning.EmailServices;

namespace identityLearning.Controllers
{
    public class HomeController : BaseController 
    {


        public HomeController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IEmailSender emailSender):base(userManager,signInManager,emailSender){
        }

        public IActionResult Index()
        {

            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index","Member");
            }

            return View();
        }

        public IActionResult LogIn(string ReturnUrl){
            
            //kullanici zaten varsa member/index sayfasina gonderiyorum
            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index","Member");
            }
            

            TempData["ReturnUrl"] = ReturnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel){


            
            if(ModelState.IsValid){

                AppUser user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if(user != null){
                    

                    if(await _userManager.IsLockedOutAsync(user)){
                        ModelState.AddModelError("","Hesabınız bir süreliğine kitlenmiştir Lütfen daha sonra tekrar deneyiniz");
                        return View(loginViewModel);  
                    }


                    if(_userManager.IsEmailConfirmedAsync(user).Result == false){
                        
                        ModelState.AddModelError("","Lutfen mailinizi onaylayiniz!");
                        return View(loginViewModel);

                    }

                    await _signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user,loginViewModel.Password,loginViewModel.RememberMe,false);
                    
                    if(result.Succeeded){


                        await _userManager.ResetAccessFailedCountAsync(user);


                        if(TempData["ReturnUrl"] != null){

                            return Redirect(TempData["ReturnUrl"].ToString());

                        }

                        return RedirectToAction("Index","Member");

                    }else{

                        await _userManager.AccessFailedAsync(user);


                        int fail = await _userManager.GetAccessFailedCountAsync(user);
                        ModelState.AddModelError("",$"{fail} kez başarısız giriş.");
                        if(fail == 3){

                            await _userManager.SetLockoutEndDateAsync(user,new System.DateTimeOffset(DateTime.Now.AddMinutes(20)));
                            
                            ModelState.AddModelError("","Hesabınız 3 başarısız girişten dolayı 20 dakika süreyle kitlenmiştir lütfen daha sonra tekrar deneyiniz");


                        }else{

                            ModelState.AddModelError("","Geçersiz email yada şifresi");
                        
                        }

                    }

                }else{
                    
                    ModelState.AddModelError("","Geçersiz email yada şifresi");

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
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(user,userViewModel.Password);
                
                if(result.Succeeded){
                    
                    string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    
                    string link = Url.Action("ConfirmEmail","Home",new {
                        
                        userId = user.Id,
                        token = confirmationToken
                    
                    },HttpContext.Request.Scheme);

                    await _emailSender.SendEmailAsync(user.Email,"Mail Onaylama",$"<h2>Mailinizi onaylamak için lütfen aşağıdaki linke tıklayınız</h2><hr/><a href='{link}'>mail onaylama yenileme linki</a>");

                    return RedirectToAction("LogIn");

                }else{

                    AddModelError(result);

                }
                

            }


            return View(userViewModel);
        }


        public IActionResult ResetPassword(){
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(PasswordResetViewModel passwordResetViewModel){
            
            AppUser user = _userManager.FindByEmailAsync(passwordResetViewModel.Email).Result;

            if(user != null){

                string passwordResetToken = _userManager.GeneratePasswordResetTokenAsync(user).Result;

                string passwordResetLink = Url.Action("ResetPasswordConfirm","Home",new {
                    userId = user.Id,
                    token = passwordResetToken
                },HttpContext.Request.Scheme);

                _emailSender.SendEmailAsync(passwordResetViewModel.Email,"mail sifirlama",$"<h2>Şifrenizi Yenilemek için lütfen aşağıdaki linke tıklayınız</h2><hr/><a href='{passwordResetLink}'>şifre yenileme linki</a>");

                ViewBag.status = "success";

            }else{
                ModelState.AddModelError("","Sistemde kayıtlı email adresi bulunamamıştır.");
            }



            return View(passwordResetViewModel);
        }

        public IActionResult ResetPasswordConfirm(string userId,string token){
            
            TempData["userId"] = userId;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]//Bind[PasswordNew in anlami su icindeki viewModelinin icindeki sadece PasswordNew kismini al diger kisimlara gerek yok anlamina geliyor]
        public async Task<IActionResult> ResetPasswordConfirm([Bind("PasswordNew")]PasswordResetViewModel passwordResetViewModel){
            
            string userId = TempData["userId"].ToString();
            string token = TempData["token"].ToString();

            AppUser user = await _userManager.FindByIdAsync(userId);

            if(user != null){

                IdentityResult result = await _userManager.ResetPasswordAsync(user,token,passwordResetViewModel.PasswordNew);

                if(result.Succeeded){

                    await _userManager.UpdateSecurityStampAsync(user);

                    TempData["passwordResetInfo"] = "şifreniz başarılıyla yenilenmiştir.Yeni şifreniz ile giriş yapabilirsiniz";

                    ViewBag.status = "success";  

                }else{

                    AddModelError(result);

                }
                
            }else{


                ModelState.AddModelError("","Bir Hata Meydana Geldi Lütfen Daha Sonra Tekrar Deneyiniz");

            }


            return View(passwordResetViewModel);
        }


        public async Task<IActionResult> ConfirmEmail(string userId,string token){

            var user = await _userManager.FindByIdAsync(userId);

            IdentityResult result = await _userManager.ConfirmEmailAsync(user,token);

            if(result.Succeeded){
                
                ViewBag.status = "Email Adresiniz Onaylanmistir. Login ekranindan giris yapabilirsiniz";

            }else{

                ViewBag.status = "Bir hata meydana geldi.Lütfen daha sonra tekrar deneyiniz.";

            }

            return View();

        }






    }
}
