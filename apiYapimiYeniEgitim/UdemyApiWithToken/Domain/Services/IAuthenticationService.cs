using UdemyApiWithToken.Domain.Responses;

namespace UdemyApiWithToken.Domain.Services
{
    public interface IAuthenticationService
    {
         
        AccessTokenResponse CreateAccessToken(string email,string password);

        AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken);

        AccessTokenResponse RevokeRefreshToken(string refreshToken);

    }
}