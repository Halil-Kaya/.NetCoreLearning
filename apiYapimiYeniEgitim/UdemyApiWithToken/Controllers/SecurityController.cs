using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Security.Hash;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string key){
            
            SecurityHash locker=new SecurityHash();
            string salt = locker.HashCreate();
            
            string encryptKey = locker.HashCreate(key, salt);

            string getEncryptKey = encryptKey.Split('æ')[0];
            string getSalt=encryptKey.Split('æ')[1];
            string result = locker.ValidateHash(key, getSalt, getEncryptKey).ToString();

            return new string[] { encryptKey, result, salt };
        }
        
    }
}