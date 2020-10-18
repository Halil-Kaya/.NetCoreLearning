using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Responses
{
    public class UserResponse : BaseResponse
    {
        
        public User user { get; set; }

        private UserResponse(bool success,string message, User user):base(success,message){
            this.user = user;
        }

        public UserResponse(User user):this(true,string.Empty,user){
        }

        public UserResponse(string message):this(false,message,null){
        }

    }
}