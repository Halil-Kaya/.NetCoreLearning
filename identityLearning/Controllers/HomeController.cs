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
using System.Security.Claims;
using identityLearning.Enums;
using identityLearning.TwoFactorService;
using Microsoft.AspNetCore.Http;

namespace identityLearning.Controllers
{
    public class HomeController : BaseController 
    {

        private readonly TwoFactorService.TwoFactorService _twoFactorService;
        private readonly EmailSender _email;

        public HomeController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IEmailSender emailSender,TwoFactorService.TwoFactorService twoFactorService,EmailSender email):base(userManager,signInManager,emailSender){
            this._twoFactorService = twoFactorService; 
            this._email = email;
        }

        public IActionResult Index()
        {

            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index","Member");
            }

            return View();
        }

        //ReturnUrl de default olarak baslangic dizinine gidecek ordan da eğer kayıtlıysa memberin index sayfasına
        public IActionResult LogIn(string ReturnUrl = "/"){
            
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

                    
                    bool userCheck = await _userManager.CheckPasswordAsync(user,loginViewModel.Password);

                    if(userCheck){

                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _signInManager.SignOutAsync();

                        var result = await _signInManager.PasswordSignInAsync(user,loginViewModel.Password,loginViewModel.RememberMe,false);

                        if(result.RequiresTwoFactor){

                            if(user.TwoFactor == (int)TwoFactor.Email ||user.TwoFactor == (int)TwoFactor.Phone){

                                HttpContext.Session.Remove("currentTime");

                            }

                            return RedirectToAction("TwoFactorLogIn");
                            
                        }else{

                            return Redirect(TempData["ReturnUrl"].ToString());
                            
                        }

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

        public async Task<IActionResult> TwoFactorLogIn(string ReturnUrl = "/"){
            
            //burda kullaniciyi cookie den aliyor
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            TempData["ReturnUrl"] = ReturnUrl;

            switch((TwoFactor)user.TwoFactor){
                case TwoFactor.MicrosoftGoogle:
                    break;

                case TwoFactor.Email:
                    
                    if(_twoFactorService.TimeLeft(HttpContext) == 0){
                        return RedirectToAction("LogIn");
                    }

                    ViewBag.timeLeft = _twoFactorService.TimeLeft(HttpContext);

                    HttpContext.Session.SetString("codeverification",_email.Send(user.Email));

                    break;
                
                default:
                    break;
            }

            return View(new TwoFactorLoginViewModel(){TwoFactorType = (TwoFactor)user.TwoFactor,isRecoverCode = false,isRememberMe = false,VerificationCode = string.Empty});
        }

        [HttpPost]
        public async Task<IActionResult> TwoFactorLogIn(TwoFactorLoginViewModel twoFactorLoginViewModel){

            //burda kullaniciyi cookie den aliyor
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            ModelState.Clear();

            bool isSuccessAuth = false;

            if((TwoFactor)user.TwoFactor == TwoFactor.MicrosoftGoogle){


                Microsoft.AspNetCore.Identity.SignInResult result;

                if(twoFactorLoginViewModel.isRecoverCode){

                    result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(twoFactorLoginViewModel.VerificationCode);

                }else{

                    result = await _signInManager.TwoFactorAuthenticatorSignInAsync(twoFactorLoginViewModel.VerificationCode,twoFactorLoginViewModel.isRememberMe,false);

                }

                if(result.Succeeded){
                
                    isSuccessAuth = true;
                
                }else{

                    ModelState.AddModelError("","Doğrulama Kodu Yanlış");
                
                }


            }

            if(isSuccessAuth){

                return Redirect(TempData["ReturnUrl"].ToString());

            }

            twoFactorLoginViewModel.TwoFactorType = (TwoFactor)user.TwoFactor;

            return View(twoFactorLoginViewModel);
        }



        public IActionResult SignUp(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel){

            if(ModelState.IsValid){

                if(_userManager.Users.Any(u => u.PhoneNumber == userViewModel.PhoneNumber)){

                    ModelState.AddModelError("","Bu Telefon Numarası Kayıtlıdır");

                    return View(userViewModel);
                }


                AppUser user = new AppUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.TwoFactor = 0;

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

        public IActionResult FacebookLogin(string ReturnUrl){
            
            string RedirectUrl = Url.Action("ExternalResponse","Home",new {
                ReturnUrl = ReturnUrl
            });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook",RedirectUrl);

            return new ChallengeResult("Facebook",properties);
        }

        public async Task<IActionResult> ExternalResponse(string ReturnUrl = "/"){

            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();

            if(info == null){

                return RedirectToAction("LogIn");

            }else{

                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,info.ProviderKey,true);

                if(result.Succeeded){

                    return Redirect(ReturnUrl);

                }else{

                    AppUser user = new AppUser();

                    user.Email = info.Principal.FindFirst(ClaimTypes.Email).Value;
                    string ExternalUserId = info.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                    
                    if(info.Principal.HasClaim(x => x.Type == ClaimTypes.Name)){

                        string userName = info.Principal.FindFirst(ClaimTypes.Name).Value;
                        userName = userName.Replace(' ','-').ToLower() + ExternalUserId.Substring(0,5).ToString();

                        user.UserName = userName;

                    }else{

                        user.UserName = info.Principal.FindFirst(ClaimTypes.Email).Value;

                    }

                    IdentityResult createResult = await _userManager.CreateAsync(user);

                    if(createResult.Succeeded){
                        
                        IdentityResult loginResult = await _userManager.AddLoginAsync(user,info);

                        if(loginResult.Succeeded){

                            //await _signInManager.SignInAsync(user,true);
                            await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,info.ProviderKey,true);
                            
                            return Redirect(ReturnUrl);

                        }else{

                            AddModelError(loginResult);

                        }

                    }else{

                        AddModelError(createResult);

                    }




                }


            }

            List<string> errors = ModelState.Values.SelectMany(x => x.Errors).Select(y => y.ErrorMessage).ToList();

            return View("Error",errors);
        }

        public IActionResult Error(){



            return View();
        }




    }
}
