using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Domain.Responses
{
    public class AccessTokenResponse:BaseResponse
    {

        public AccessToken accesToken;

        public AccessTokenResponse(bool success,string message,AccessToken accessToken) : base(success,message){
            this.accesToken = accessToken;
        }
        

        public AccessTokenResponse(AccessToken accessToken): this(true,string.Empty,accessToken){

        }

        public AccessTokenResponse(string message): this(false,message,null){
            
        }

    }
}