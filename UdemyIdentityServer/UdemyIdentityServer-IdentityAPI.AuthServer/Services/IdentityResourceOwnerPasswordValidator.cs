using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyIdentityServer_IdentityAPI.AuthServer.Models;

namespace UdemyIdentityServer_IdentityAPI.AuthServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        /*
         Burda yaptığım iş şu normalde kullanıcı giriş yaparken kullanıcı adı ve şifre girmesi lazım ama ben maillede giriş
        yapmak istiyorum bu obje identityServerin kendi objesini eziyor
         
         */
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager) {
            this._userManager = userManager;
        }

        //giriş yapmaya çalışırken buraya geliyor
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //contexten kullanıcı adını alıyorum
            var userName = context.UserName;

            ApplicationUser user;

            //eğer @ işareti içeriyorsa demek ki maille giriş yapıyor o yüzden mailine göre kullanıcıyı getiriyorum
            //eğer yoksa demek ki kullanıcı adıyla giriş yapıyor o yüzden adına göre kişiyi getiriyorum
            if (userName.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(context.UserName);

            }
            else
            {
                user = await _userManager.FindByNameAsync(context.UserName);
            }


            //kullanıcı yoksa işlemi bitiriyorum
            if(user == null)
            {
                return;
            }

            //kullanıcının şifresini kontrol ediyorum
            var passwordCheck = await _userManager.CheckPasswordAsync(user,context.Password);

            if (passwordCheck == false)
            {
                return;
            }
            //eğer şifre doğruysa işlem başarılı

            context.Result = new GrantValidationResult(user.Id.ToString(),OidcConstants.AuthenticationMethods.Password);

        }
    }
}
