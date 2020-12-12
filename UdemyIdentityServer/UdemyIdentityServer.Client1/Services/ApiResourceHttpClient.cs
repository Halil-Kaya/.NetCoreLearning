using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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



    }
}
