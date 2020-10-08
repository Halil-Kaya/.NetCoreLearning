using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);

        void RevokeRefreshToken(User user);

    }
}