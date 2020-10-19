using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Extensions;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService){
            this._authenticationService = authenticationService;
        }
        

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource){
            
            if(!ModelState.IsValid){
                

                return BadRequest(ModelState.GetErrorMessages());

            }


            AccessTokenResponse accessTokenResponse = this._authenticationService.CreateAccessToken(loginResource.Email,loginResource.Password);
             

             if(accessTokenResponse.Success){


                return Ok(accessTokenResponse.accesToken);
             }
             
             return BadRequest(accessTokenResponse.Message);

        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource){
            
            AccessTokenResponse accessTokenResponse = this._authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);


            if(accessTokenResponse.Success){

                return Ok(accessTokenResponse.accesToken);
            }

            return BadRequest(accessTokenResponse.Message);
        }


        [HttpPost]
        public IActionResult RevokeRefreshToken(TokenResource tokenResource){

            AccessTokenResponse accessTokenResponse =  this._authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);

            if(accessTokenResponse.Success){
                return Ok(accessTokenResponse.accesToken);
            }

            return BadRequest(accessTokenResponse.Message);
        }

    }
}