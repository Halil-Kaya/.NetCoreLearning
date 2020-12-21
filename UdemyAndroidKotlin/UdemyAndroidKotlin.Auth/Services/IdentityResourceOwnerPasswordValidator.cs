using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAndroidKotlin.Auth.Models;

namespace UdemyAndroidKotlin.Auth.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        //eğerki client ResourceOwnerPassword kullanıyorsa bu yapıyı kullanması lazım kullanıcıyı kendimiz bulacaz



        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            //contexten kullanıcı adını alıyorum
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            
            if(existUser == null)
            {
                return;
            }

            //şifresini kontrol ediyorum
            var passwordCheck = await _userManager.CheckPasswordAsync(existUser,context.Password);

            if(passwordCheck == false)
            {
                return;
            }

            //islem basarili bu yuzden resulta kullanicinin id sini koyup akisinda resourceownerPasswordu koyuyorum bunun kisaltisi password
            context.Result = new GrantValidationResult(existUser.Id.ToString(),OidcConstants.AuthenticationMethods.Password);


        }

    }
}
