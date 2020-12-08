using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
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

        private readonly TwoFactorService.TwoFactorService _twoFactorService;

        public MemberController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,TwoFactorService.TwoFactorService twoFactorService):base(userManager,signInManager){
            this._twoFactorService = twoFactorService;
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

                string phone = _userManager.GetPhoneNumberAsync(user).Result;

                if (phone != userViewModel.PhoneNumber)
                {
                    if (_userManager.Users.Any(u => u.PhoneNumber == userViewModel.PhoneNumber))
                    {
                        ModelState.AddModelError("", "Bu telefon numarası başka üye tarafından kullanılmaktadır.");
                        return View(userViewModel);
                    }
                }



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

        //NOT AcessDenied kullanici yok giris yapamaz anlamina degil kullanicinin yetkisi yok anlamina gelmekte o mantikla calisiyor!
        public IActionResult AccessDenied(string ReturnUrl){

            //ReturnUrl yi identity otomatik kendisi koyuyor bundan nereye gitmeye calistigi geliyor ona gore bilgi bastircam

            ReturnUrl = ReturnUrl.ToLower();
            
            if(ReturnUrl.Contains("violencepage")){
                
                ViewBag.message = "Erişmeye çalıştığınız sayfa şiddet videoları içerdiğinizden dolayı 15 yaşından büyük olmanız gerekmektedir";

            }else if(ReturnUrl.Contains("ankarapage")){

                ViewBag.message = "Bu Sayfaya sadece şehir alanı Ankara olan kullanıcılar erişebilir";

            }else if(ReturnUrl.Contains("exchange")){

                ViewBag.message = "30 günlük ücretsiz deneme hakkınız sona ermiştir";

            }



            return View();
        }

        //bu sayfaya sadece editorler ve adminler erisebilir
        [Authorize(Roles = "editor,admin")]
        public IActionResult Editor(){
            return View();
        }

        //bu sayfaya sadece manager ve adminler erisebilir
        [Authorize(Roles = "manager,admin")]
        public IActionResult Manager(){
            return View();
        }

        //claims bazli bir yetkilendirme yaptim buranin anlami sadece cityi ankara olanlar buraya erisebilir
        [Authorize(Policy = "AnkaraPolicy")]
        public IActionResult AnkaraPage(){
            return View();
        }

        [Authorize(Policy = "ViolencePolicy")]
        public IActionResult ViolencePage(){
            return View();
        }


        //istek attigim yer bura ilk burdan geciyor
        public async Task<IActionResult> ExchangeRedirect(){

            //kullanicida boyle bir claim var mi diye kontrol ediyorum
            bool result = User.HasClaim(x => x.Type == "ExpireDateExchange");

            //yoksa giriyorum
            if(!result){
                //boyle bir claim olusturup deger olarakta tarih atiyorum(30 gün sonrası)
                Claim ExpireDateExchange = new Claim("ExpireDateExchange",DateTime.Now.AddDays(30).Date.ToShortDateString(),ClaimValueTypes.String,"Internal");

                //claimi ekliyorum
                await _userManager.AddClaimAsync(CurrentUser,ExpireDateExchange);

                //cookie guncellensin diye kullaniciyi gir cik yaptiriyorum
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(CurrentUser,true);

            } 

            return RedirectToAction("Exchange");
        }

        [Authorize(Policy = "ExchangePolicy")]
        public IActionResult Exchange(){
            return View();
        }


        public async Task<IActionResult> TwoFactorWithAuthenticator(){
            
            string unformattedKey = await _userManager.GetAuthenticatorKeyAsync(CurrentUser);

            if(string.IsNullOrEmpty(unformattedKey)){

                await _userManager.ResetAuthenticatorKeyAsync(CurrentUser);

                unformattedKey = await _userManager.GetAuthenticatorKeyAsync(CurrentUser);


            }

            AuthenticatorViewModel authenticatorViewModel = new AuthenticatorViewModel();

            authenticatorViewModel.SharedKey = unformattedKey;

            authenticatorViewModel.AuthenticatorUri = _twoFactorService.GenerateQrCodeUri(CurrentUser.Email,unformattedKey);

            return View(authenticatorViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> TwoFactorWithAuthenticator(AuthenticatorViewModel authenticatorViewModel){
            
            
            var verificationCode = authenticatorViewModel.VerificationCode.Replace(" ",string.Empty).Replace("-",string.Empty);
            
            var is2FATokenValid = await _userManager.VerifyTwoFactorTokenAsync(CurrentUser,_userManager.Options.Tokens.AuthenticatorTokenProvider,verificationCode);
            

            if(is2FATokenValid){

                CurrentUser.TwoFactorEnabled = true;
                CurrentUser.TwoFactor = (sbyte) TwoFactor.MicrosoftGoogle;

                var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(CurrentUser,5);

                TempData["recoveryCodes"] = recoveryCodes;
                TempData["message"] = "iki adımlı kimlik doğrulama tipiniz Microsoft/Google olarak belirlenmiştir";

                return RedirectToAction("TwoFactorAuth");


            }else{

                ModelState.AddModelError("","Girdiğiniz Doğrulama Kodu Yanlıştır");

                return View(authenticatorViewModel);

            }


        }

        public IActionResult TwoFactorAuth(){
            return View(new AuthenticatorViewModel(){TwoFactorType = (TwoFactor)CurrentUser.TwoFactor});
        }

        [HttpPost]
        public async Task<IActionResult> TwoFactorAuth(AuthenticatorViewModel authenticatorViewModel){

            switch(authenticatorViewModel.TwoFactorType){

                case TwoFactor.None:
                    CurrentUser.TwoFactorEnabled = false;
                    CurrentUser.TwoFactor = (sbyte)TwoFactor.None;                    
                    TempData["message"] = "iki adımlı kimlik doğrulama tipiniz hiç biri olarak belirlenmiştir";

                    break;

                case TwoFactor.MicrosoftGoogle:

                    return RedirectToAction("TwoFactorWithAuthenticator");


                default:
                    break;
            }

            await _userManager.UpdateAsync(CurrentUser);

            return View(authenticatorViewModel);

        }



    }
}