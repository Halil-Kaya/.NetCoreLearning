using System;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserService _userService; 
        
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationService(IUserService userService,ITokenHandler tokenHandler){
            this._userService = userService;
            this._tokenHandler = tokenHandler;
        }

        public BaseResponse<AccessToken> CreateAccessToken(string email, string password)
        {

            BaseResponse<User> userResponse = this._userService.FindByEmailAndPassword(email,password);

            if(userResponse.Success){

                AccessToken accessToken = this._tokenHandler.CreateAccessToken(userResponse.Extra);
                
                this._userService.SaveRefreshToken(userResponse.Extra.Id,accessToken.RefreshToken);
                
                return new BaseResponse<AccessToken>(accessToken);

            }

            return new BaseResponse<AccessToken>(userResponse.Message);
        }

        public BaseResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken)
        {
            BaseResponse<User> userResponse = this._userService.GetUserWithRefreshToken(refreshToken);

            if(userResponse.Success){

                if(userResponse.Extra.RefreshTokenEndDate > DateTime.Now){

                    AccessToken accessToken = this._tokenHandler.CreateAccessToken(userResponse.Extra);
                    
                    this._userService.SaveRefreshToken(userResponse.Extra.Id,accessToken.RefreshToken);
                    
                    return new BaseResponse<AccessToken>(accessToken);
                }

                return new BaseResponse<AccessToken>("refresh tokenin suresi dolmus");

            }

            return new BaseResponse<AccessToken>("boyle bir kullanici yok");

        }

        public BaseResponse<AccessToken> RevokeRefreshToken(string refreshToken)
        {

            BaseResponse<User> userResponse = this._userService.GetUserWithRefreshToken(refreshToken);

            if(userResponse.Success){

                this._userService.RemoveRefreshToken(userResponse.Extra);
                return new BaseResponse<AccessToken>(new AccessToken());

            }

            return new BaseResponse<AccessToken>($"refresh token bulunamadi: {userResponse.Message}");
        }
    }
}