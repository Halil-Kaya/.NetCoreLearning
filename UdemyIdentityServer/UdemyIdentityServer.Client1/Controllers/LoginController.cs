using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using UdemyIdentityServer.Client1.Models;
using UdemyIdentityServer.Client1.Services;

namespace UdemyIdentityServer.Client1.Controllers
{
    public class LoginController : Controller
    {


        private readonly IApiResourceHttpClient _apiResourceHttpClient;
        
        public LoginController(IApiResourceHttpClient apiResourceHttpClient) {
            this._apiResourceHttpClient = apiResourceHttpClient;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {

            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44372/");

            if (disco.IsError)
            {
                
                //hata ve loglama kismi

            }

            var password = new PasswordTokenRequest();

            password.Address = disco.TokenEndpoint;
            password.UserName = loginViewModel.Email;
            password.Password = loginViewModel.Password;
            password.ClientId = "Client1-ResourceOwner-Mvc";
            password.ClientSecret = "secret";

            var token = await client.RequestPasswordTokenAsync(password);

            if (token.IsError)
            {

                ModelState.AddModelError("","Email Veya Şifreniz Yanlış");
                return View();
            }

            var userInfoRequest = new UserInfoRequest();

            userInfoRequest.Token = token.AccessToken;
            userInfoRequest.Address = disco.UserInfoEndpoint;

            var userInfo = await client.GetUserInfoAsync(userInfoRequest);

            if (userInfo.IsError)
            {
                //logla
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfo.Claims,"Cookies", "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>() { 
                
                //acces tokeni aliyorum
                new AuthenticationToken(){Name = OpenIdConnectParameterNames.AccessToken,Value = token.AccessToken},
                //refresh tokeni aliyorum
                new AuthenticationToken(){Name = OpenIdConnectParameterNames.RefreshToken,Value = token.RefreshToken},
                //zamani aliyorum bana saniye cinsinden geliyoru onu tarihe geciriyorum
                new AuthenticationToken(){Name = OpenIdConnectParameterNames.ExpiresIn,Value = DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)},


            });



            await HttpContext.SignInAsync("Cookies",claimsPrincipal,authenticationProperties);

            return RedirectToAction("Index","User");
        }


        
        public IActionResult SignUp() {




            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSaveViewModel userSaveViewModel)
        {

            if (ModelState.IsValid)
            {
                return View();
            }


            var result = await _apiResourceHttpClient.SaveUserViewModel(userSaveViewModel);

            if(result != null)
            {

                result.ForEach(x => {

                    ModelState.AddModelError("",x);
                
                });
                return View();
            }


            return RedirectToAction("Index");
        }


    }
}
