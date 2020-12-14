using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace UdemyIdentityServer.Client1.Controllers
{

    [Authorize]
    public class UserController : Controller
    {

        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        public IActionResult Index(){

            return View();
        }

        //cikis yapiyorum
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Cookies");
            //await HttpContext.SignOutAsync("oidc");

            return RedirectToAction("Index","Home");
        }


        //refresh token aliyor!
        public async Task<IActionResult> GetRefreshToken()
        {

            //bu obje araciligiyla istekte bulunuyorum
            HttpClient httpClient = new HttpClient();
            //disco objesi sayesinde identityServer umun endpoinlerini bulabiliyorum
            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:44372/");

            if (disco.IsError)
            {
                //loglama yap
            }

            //cookiemden simdiki refresh tokenimi aliyorum
            var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            //refresh token istekte bulunacagim o yuzden onun objesini olusturuyorum
            RefreshTokenRequest refreshTokenRequest = new RefreshTokenRequest();

            //clientin id sini aliyorum
            refreshTokenRequest.ClientId = _configuration["ClientMvc:ClientId"];
            //clientin sifresini aliyorum
            refreshTokenRequest.ClientSecret = _configuration["ClientMvc:ClientSecret"];
            
            //su anki cookie deki refresh tokeni aliyorum
            refreshTokenRequest.RefreshToken = refreshToken;

            //gidecegi adresi disco sayesinde veriyorum disco yerine elle <url>/connect/token girmek yerine TokenEndpoint giriyorum
            //disco objesi isimi kolaylastiriyor
            refreshTokenRequest.Address = disco.TokenEndpoint;
               
            //istekte bulunup tokeni aliyorum bunun icinde yeni acces token,token-id, refresh token ve suresini aldim 
            var token = await httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

            if (token.IsError)
            {
                //loglama yap
            }

            //tokenin icindeki tokenleri aliyorum
            var tokens = new List<AuthenticationToken>()
            {
                //token id yi alip ekliyorum
                new AuthenticationToken(){Name = OpenIdConnectParameterNames.IdToken,Value = token.IdentityToken},
                //acces tokeni aliyorum
                new AuthenticationToken(){Name = OpenIdConnectParameterNames.AccessToken,Value = token.AccessToken},
                //refresh tokeni aliyorum
                new AuthenticationToken(){Name = OpenIdConnectParameterNames.RefreshToken,Value = token.RefreshToken},
                //zamani aliyorum bana saniye cinsinden geliyoru onu tarihe geciriyorum
                new AuthenticationToken(){Name = OpenIdConnectParameterNames.ExpiresIn,Value = DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)},

            };

            //authentication bilgilerini aliyorum
            var authenticationResult = await HttpContext.AuthenticateAsync();

            
            var properties = authenticationResult.Properties;
            //propertilerini aliyorum peki ne bu propertiyleri key value iliskisi yani
            /*
            .checkSessionIFrame = https://localhost:44372/connect/checksession
            .Token.access_token =  eyJhbGciOiJSUzI1NiIsImtpZCI6IkYyNEEwRkM1MTRENEQ1NkFBNjQ0QkZBMkZGRDdCMjBDIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MDc3MDYxMTAsImV4cCI6MTYwNzcxMzMxMCwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNzIiLCJhdWQiOiJyZXNvdXJjZV9hcGkxIiwiY2xpZW50X2lkIjoiQ2xpZW50MS1NdmMiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNjA3NzA2MTA5LCJpZHAiOiJsb2NhbCIsImp0aSI6IjEzODEwMzc0MUYyREFDNTNGOERFQzhBNDE3RTNEODlCIiwic2lkIjoiM0JFMzkzMTE3MDQ4ODJGQzIzMTk2Qjc3MUNBQzNBNjMiLCJpYXQiOjE2MDc3MDYxMTAsInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJhcGkxLnJlYWQiLCJvZmZsaW5lX2FjY2VzcyJdLCJhbXIiOlsicHdkIl19.R3rGGegOyX4G67AzYAexV_9BO9MivTfwCDEdczQdFnpDHzxbQ7iLpWzrip_atkS4XWPey6JYVlndx8SwZQ6JTBxDp4PxULqDe3nbzKkkYqzTxa1roMq9 - N - yxLrIuyc1w0ubc5HE9Jx034c_HECVI5Gl8 - LwACeGE_IQjK4jauJpBl_rJDsJYg0iIferm8rE9D6cJPjEPD3AagC5XU95m7Va3Y3fV6KRC5WAbNTqrXBkKdo7Ck_s - WFRmblT4BPkSQdsmUWOgqk2oeUtd7ogrWrrEjhbrF8j96ZyC6sAjNGG0kwKdQDSDIUsVPaYvbJNQonu_nv924AiiRi5ptXSNg
            .Token.id_token =  eyJhbGciOiJSUzI1NiIsImtpZCI6IkYyNEEwRkM1MTRENEQ1NkFBNjQ0QkZBMkZGRDdCMjBDIiwidHlwIjoiSldUIn0.eyJuYmYiOjE2MDc3MDYxMTAsImV4cCI6MTYwNzcwNjQxMCwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNzIiLCJhdWQiOiJDbGllbnQxLU12YyIsIm5vbmNlIjoiNjM3NDMzMDI5MDUyMTE4NzIzLk9HWmlNV1ZtTTJJdFlqRTFZaTAwWVRRMkxXSTBOamd0WlRCa04ySTNZekExTURreFlXRXpOV1l6TkdFdE4yUTNPQzAwWWpBNExUazVNekV0TkRBME9EQmlNVFpsT1RrMyIsImlhdCI6MTYwNzcwNjExMCwiYXRfaGFzaCI6InFFTG15VzNjenNFTTZTc2xSNU10N3ciLCJzX2hhc2giOiJ1eVRudHAyQ3hWZnVqSUU2THVwRWZBIiwic2lkIjoiM0JFMzkzMTE3MDQ4ODJGQzIzMTk2Qjc3MUNBQzNBNjMiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNjA3NzA2MTA5LCJpZHAiOiJsb2NhbCIsImFtciI6WyJwd2QiXX0.d2gqXw - rKCP0Tfo7y50EB1C2mCif0VVZVmAcXACasm0X6UXiLj2wxLMAl7zcelzJg3blGxVS0LsRcrVUmLsZjjdWaYU0vaaRktqEjS7Q3KDHYZtMwjOD7Tb5x8wIpMW4baad7CzBXhUuhDwFyiwpl59OQcXlmAhZyiXE2XFr4p_3uHooqthTOjQzeEcrhv7s1st0 - Ey4dRxrpPPXe3yBXFzIbL1aql_5U5iBdl79zNPJ7yZxcHk8V1_FHqzC1B7MWJf776XypVzzAGNH_jooVyqxHNv_KalR5AN7F9iHDdd4ck - orQ_UiEb - gS7PF - QP0B5n9Az_uBrD - d7H - BIBAw
            .Token.refresh_token   = 178910982076120119E4DB6B626AAB930BE265B495612584E751EA8C731B9CDD
            .Token.token_type = Bearer
            .Token.expires_at  = 2020 - 12 - 11T19: 01:50.0000000 + 00:00
            */
            //burda dikkat etmen gereken sey su bu claim degil baska bir sey bunlar Authentication Verileri

            
            //artik guncelledigim yeni tokensleri bunlara guncellemem gerekiyor bu yuzden tokens bir listem
            //bu listenin icinde yeni token bilgilerim var burda propertiesimin icindekilerini guncelliyorum
            //hepsini silip yenisini eklemiyor sadece tokens in icindekilerini guncelliyor
            properties.StoreTokens(tokens);

            //cookie bilgilerimi guncellemem gerekiyor bu yuzden cookiyi guncelliyorum
            await HttpContext.SignInAsync("Cookies",authenticationResult.Principal,properties);

            //index sayfasina gonderiyorum (user/index)
            return RedirectToAction("Index");

        }


        [Authorize(Roles = "admin")]
        public IActionResult AdminAction()
        {
            return View();
        }


        [Authorize(Roles = "customer")]
        public IActionResult CustomerAction()
        {
            return View();
        }

    }
}