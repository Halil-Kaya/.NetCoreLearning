using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Domain.Repositories
{
    public class UserRepository :BaseRepository, IUserRepository
    {

        private readonly TokenOptions _tokenOptions;
        public UserRepository(UdemyApiWithTokenDBContext context,IOptions<TokenOptions> tokenOptions) : base(context){
            this._tokenOptions = tokenOptions.Value;
        }

        public void AddUser(User user)
        {
            this._dbContext.User.Add(user);
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            User user = this._dbContext.User.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return user;
        }

        public User FindById(int userId)
        {
            return this._dbContext.User.Find(userId);
        }

        public User GetUserWithRefreshToken(string refreshToken)
        {
            return this._dbContext.User.FirstOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(User user)
        {
            User newUser = this.FindById(user.Id);
            newUser.RefreshToken = null; 
            newUser.RefreshTokenEndDate = null;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newUser = this.FindById(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(this._tokenOptions.RefreshTokenExpiration);
        }
    }
}