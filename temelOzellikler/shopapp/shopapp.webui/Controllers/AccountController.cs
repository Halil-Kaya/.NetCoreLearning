using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Identity;
using shopapp.webui.Models;
using Newtonsoft.Json;
using shopapp.webui.EmailServices;

namespace shopapp.webui.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        
        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,IEmailSender emailSender){
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._emailSender = emailSender;
        }

        public async  Task<IActionResult> Login(string ReturnUrl = null){
            var user = await _userManager.FindByIdAsync("1");
            

            System.Console.WriteLine("return url: " + ReturnUrl);
            
            return View(new LoginModel(){
                ReturnUrl = ReturnUrl
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model){

            var user = await _userManager.FindByEmailAsync(model.Email);
          
            var result = await _signInManager.PasswordSignInAsync(user,model.Password,true,false);

            if(result.Succeeded){
                return Redirect(model.ReturnUrl??"~/");
            }

            //var user = await _userManager.FindByNameAsync(model.UserName);
            
  
            
            if(user == null){
                ModelState.AddModelError("","bu kullanici yok");
                return View(model);
            }

            if(await _userManager.IsEmailConfirmedAsync(user)){
                System.Console.WriteLine("Maili onaylı");

                    result = await _signInManager.PasswordSignInAsync(user,model.Password,true,false);

                    if(result.Succeeded){
                        return Redirect(model.ReturnUrl??"~/");
                    }

            }else{
                ModelState.AddModelError("","Mailinizi onaylayın");
                System.Console.WriteLine("Maili onaylı değil");
    
            }



         

            

            ModelState.AddModelError("","girilen ad veya parola yanlış");


            return View(model);
        }




        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public IActionResult Register(){
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model){

            System.Console.WriteLine("???----------------------------???");
            System.Console.WriteLine("first name: " + model.FirstName);
            var user = new User(){
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            System.Console.WriteLine("firstName: " + user.FirstName);
            System.Console.WriteLine("LastName: " + user.LastName);
            System.Console.WriteLine("UserName: " + user.UserName);
            System.Console.WriteLine("Email: " + user.Email);

            var result = await _userManager.CreateAsync(user,model.Password);

            if(result.Succeeded){
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new {
                    userId = user.Id,
                    token = code
                });



                System.Console.WriteLine("url: " + url);
                System.Console.WriteLine("token! : " + code);
                

                await _emailSender.SendEmailAsync(model.Email,"Hesabınızı onaylayınız",$"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:5001{url}'>tiklayiniz</a>");
                return RedirectToAction("Login","Account");
            }

            return View(model);
        }


        

        public async Task<IActionResult> ConfirmEmail(string userId,string token){
            System.Console.WriteLine("confir email çalıştı");
            System.Console.WriteLine("userId: " + userId + " token: ");
            if(userId == null || token == null){
                CreateMessage("Geçersiz Token.","danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);

            if(user != null){
                
                //mailin onaylandığı yer
                var result = await _userManager.ConfirmEmailAsync(user,token);

                if(result.Succeeded){

                 
                    return View();
                }
                
            }
           

            System.Console.WriteLine("sanırım");
            return View();
        }

        public IActionResult ForgotPassword(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email){
            
            if(string.IsNullOrEmpty(Email)){
                return View();
            }
            
            var user = await _userManager.FindByEmailAsync(Email);

            if(user == null){
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword","Account",new {
                userId = user.Id,
                token = code
            });
            

            await _emailSender.SendEmailAsync(Email,"Şifre sıfırlama",$"Parolanızı yenilemek için linke <a href='https://localhost:5001{url}'>tiklayiniz</a>");
    

            return View();
        }


        public IActionResult ResetPassword(string userId,string token){

            if(userId == null || token == null){
                return RedirectToAction("Home","Index");

            }
            var model = new ResetPasswordModel{Token = token};


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model){
            
            
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null){
                return RedirectToAction("Home","Index");
            }


            //şifrenin resetlendiği yer
            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);

            if(result.Succeeded){
                return RedirectToAction("Login","Account");
            }

            return View(model);
        }



        private void CreateMessage(string message,string alerttype){
            var msg = new AlertMessage(){
                    Message =  $"mail onaylandi.",
                    AlertType = "success"
                };

            TempData["message"] = JsonConvert.SerializeObject(msg);
        }



    }
    
}