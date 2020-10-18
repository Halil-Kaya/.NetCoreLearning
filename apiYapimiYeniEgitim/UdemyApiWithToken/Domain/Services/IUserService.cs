using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Responses;

namespace UdemyApiWithToken.Domain.Services
{
    public interface IUserService
    {

        UserResponse AddUser(User user);

        UserResponse FindById(int userId);

        UserResponse FindByEmailAndPassword(string email,string password);

        void SaveRefreshToken(int userId,string refreshToken);

        UserResponse GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);

    }
}