using System.ComponentModel.DataAnnotations;

namespace identityLearning.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Adresiniz")]
        [Required(ErrorMessage = "Email Alanı Gereklidir")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifre Alanı Gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifreniz en az 4 karakterli olmalı")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}