using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace UdemyApiWithToken.Security.Token
{
    public static class SignHandler
    {
        
        public static SecurityKey GetSecurityKey(string securityKey){
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

    }
}