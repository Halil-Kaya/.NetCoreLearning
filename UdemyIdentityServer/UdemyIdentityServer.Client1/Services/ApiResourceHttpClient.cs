using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UdemyIdentityServer.Client1.Models;

namespace UdemyIdentityServer.Client1.Services
{
    public class ApiResourceHttpClient : IApiResourceHttpClient
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private HttpClient _client;


        public ApiResourceHttpClient(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._client = new HttpClient();
        }


        public async Task<HttpClient> GetHttpClient()
        {
            
            //cookiemden simdiki refresh tokenimi aliyorum
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);


            //tokeni güncelliyorum
            _client.SetBearerToken(accessToken);

            return _client;
        }

        public async Task<List<string>> SaveUserViewModel(UserSaveViewModel userSaveViewModel) {

            var disco = await _client.GetDiscoveryDocumentAsync("https://localhost:5001/");

            if (disco.IsError)
            {

            }

            var clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();


            clientCredentialsTokenRequest.ClientId = "Client1-ResourceOwner-Mvc";
            clientCredentialsTokenRequest.ClientSecret = "secret";
            clientCredentialsTokenRequest.Address = disco.TokenEndpoint;


            var token = await _client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);


            if (token.IsError)
            {



            }

            var stringContent = new StringContent(JsonConvert.SerializeObject(userSaveViewModel),Encoding.UTF8,"application/json");

            _client.SetBearerToken(token.AccessToken);

            var response = await _client.PostAsync("https://localhost:5001/api/user/SignUp",stringContent);

            if (!response.IsSuccessStatusCode)
            {

                var errorList = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());

                return errorList;
            }

            return null;
        
        }



    }
}
