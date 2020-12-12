using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using UdemyIdentityServer.Client1.Models;

namespace UdemyIdentityServer.Client1.Controllers
{


    [Authorize]
    public class ProductsController : Controller
    {

        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration){
            this._configuration = configuration;
        }

        /*
        public async Task<IActionResult> Index(){

            //burda yaptigim sey su identity serverdan token aliyorum o token ile de API1 sunucusuna istek atıyorum

            HttpClient httpClient = new HttpClient();

            List<Product> products = new List<Product>();

            var disco = await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest {
                Address = "https://localhost:44372/",
                Policy =
                {
                    RequireHttps = false
                }
            });

            if(disco.IsError){
                //hata var
                //loglama yap
                System.Console.WriteLine(disco.Error);

            }

            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();

            clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];
            clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            clientCredentialsTokenRequest.Address = disco.TokenEndpoint;

            var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);

            if(token.IsError){
                
                //loglama yap

            }

            httpClient.SetBearerToken(token.AccessToken);
            
            var response = await httpClient.GetAsync("https://localhost:44303/api/product/GetProducts");

            if(response.IsSuccessStatusCode){

                var content = await response.Content.ReadAsStringAsync();

                products = JsonConvert.DeserializeObject<List<Product>>(content);

            }else{

                //loglama yap

            }

            return View(products);
        }
        */

        //buranın yukardakinden farkı şu öncekinde identityserver dan token alıyordum istek atıyordum ama artık
        //giriş yaptığım için tokenim cookiemin içinde var
        public async Task<IActionResult> Index()
        {


            HttpClient httpClient = new HttpClient();

            List<Product> products = new List<Product>();

            //cookiemin içindeki acces tokeni aliyorum
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            //tokeni güncelliyorum
            httpClient.SetBearerToken(accessToken);
            
            //istekte bulunuyorum
            var response = await httpClient.GetAsync("https://localhost:44303/api/product/GetProducts");

            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();

                products = JsonConvert.DeserializeObject<List<Product>>(content);

            }
            else
            {

                //loglama yap

            }

            return View(products);
        }




    }
}