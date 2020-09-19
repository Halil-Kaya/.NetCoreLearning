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

        public IActionResult Login(string ReturnUrl = null){
            return View(new LoginModel(){
                ReturnUrl = ReturnUrl
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model){


            //var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Email);


            if(user == null){
                ModelState.AddModelError("","bu kullanici yok");
                return View();
            }

            if(await _userManager.IsEmailConfirmedAsync(user)){
                System.Console.WriteLine("Maili onaylı");
                return View();
            }else{
                ModelState.AddModelError("","Mailinizi onaylayın");
                System.Console.WriteLine("Maili onaylı değil");
    
            }

            if( await _userManager.IsEmailConfirmedAsync(user)){
                ModelState.AddModelError("","Mailinizi onaylayın");

                return View(model);
            }


            var result = await _signInManager.PasswordSignInAsync(user,model.Password,true,false);

            if(result.Succeeded){
                return Redirect(model.ReturnUrl??"~/");
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
            if(userId == null || token == null){
                CreateMessage("Geçersiz Token.","danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);

            if(user != null){
                
                
                var result = await _userManager.ConfirmEmailAsync(user,token);

                if(result.Succeeded){

                 
                    return View();
                }
                
            }
           

            System.Console.WriteLine("sanırım");
            return View();
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