using System.Collections.Generic;
using System.Threading.Tasks;
using identityLearning.Models;
using Microsoft.AspNetCore.Identity;

namespace identityLearning.CustomValidation
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {

            List<IdentityError> errors = new List<IdentityError>();

            if(password.ToLower().Contains(user.UserName.ToLower())){

                errors.Add(new IdentityError(){Code = "PasswordContainsUserName",Description = "şifre kullanıcı adını içeremez"});

            }

            if(password.ToLower().Contains("1234")){

                errors.Add(new IdentityError(){Code = "PasswordContains1234",Description = "şifre ardaşık sayı içeremez"});

            }

            if(password.ToLower().Contains(user.Email.ToLower())){

                errors.Add(new IdentityError(){Code = "PasswordContainsEmail",Description = "şifre alanı email adresinizi içeremez"});

            }


            if(errors.Count == 0){
                return Task.FromResult(IdentityResult.Success);
            }


            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));


        }
    }
}