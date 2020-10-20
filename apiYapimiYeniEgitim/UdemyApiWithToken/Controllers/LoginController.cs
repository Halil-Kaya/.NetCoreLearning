using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Extensions;
using UdemyApiWithToken.Resources;
using UdemyApiWithToken.Security.Token;

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


            BaseResponse<AccessToken> accessTokenResponse = this._authenticationService.CreateAccessToken(loginResource.Email,loginResource.Password);
             

             if(accessTokenResponse.Success){


                return Ok(accessTokenResponse.Extra);
             }
             
             return BadRequest(accessTokenResponse.Message);

        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource){
            
            BaseResponse<AccessToken> accessTokenResponse = this._authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);


            if(accessTokenResponse.Success){

                return Ok(accessTokenResponse.Extra);
            }

            return BadRequest(accessTokenResponse.Message);
        }


        [HttpPost]
        public IActionResult RevokeRefreshToken(TokenResource tokenResource){

            BaseResponse<AccessToken> accessTokenResponse =  this._authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);

            if(accessTokenResponse.Success){
                return Ok(accessTokenResponse.Extra);
            }

            return BadRequest(accessTokenResponse.Message);
        }

    }
}