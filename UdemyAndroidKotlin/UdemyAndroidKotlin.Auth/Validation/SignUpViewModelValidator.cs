using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAndroidKotlin.Auth.Models;

namespace UdemyAndroidKotlin.Auth.Validation
{
    public class SignUpViewModelValidator : AbstractValidator<SignUpViewModel>
    {

        public SignUpViewModelValidator()
        {

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanici adi gereklidir");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alani gereklidir").EmailAddress().WithMessage("email adresi dogru formatta degil");
            RuleFor(x => x.Password).NotEmpty().WithMessage("sifre alani gereklidir");
            RuleFor(x => x.City).NotEmpty().WithMessage("Sehir Alani gereklidir");

        }

    }
}
