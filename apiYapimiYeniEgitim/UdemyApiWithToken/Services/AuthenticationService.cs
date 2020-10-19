using System;
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

        public AccessTokenResponse CreateAccessToken(string email, string password)
        {

            UserResponse userResponse = this._userService.FindByEmailAndPassword(email,password);

            if(userResponse.Success){

                AccessToken accessToken = this._tokenHandler.CreateAccessToken(userResponse.user);
                
                this._userService.SaveRefreshToken(userResponse.user.Id,accessToken.RefreshToken);
                
                return new AccessTokenResponse(accessToken);

            }

            return new AccessTokenResponse(userResponse.Message);
        }

        public AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken)
        {
            UserResponse userResponse = this._userService.GetUserWithRefreshToken(refreshToken);

            if(userResponse.Success){

                if(userResponse.user.RefreshTokenEndDate > DateTime.Now){

                    AccessToken accessToken = this._tokenHandler.CreateAccessToken(userResponse.user);
                    
                    this._userService.SaveRefreshToken(userResponse.user.Id,accessToken.RefreshToken);
                    
                    return new AccessTokenResponse(accessToken);
                }

                return new AccessTokenResponse("refresh tokenin suresi dolmus");

            }

            return new AccessTokenResponse("boyle bir kullanici yok");

        }

        public AccessTokenResponse RevokeRefreshToken(string refreshToken)
        {

            UserResponse userResponse = this._userService.GetUserWithRefreshToken(refreshToken);

            if(userResponse.Success){

                this._userService.RemoveRefreshToken(userResponse.user);
                return new AccessTokenResponse(new AccessToken());

            }

            return new AccessTokenResponse($"refresh token bulunamadi: {userResponse.Message}");
        }
    }
}