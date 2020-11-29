using System.ComponentModel.DataAnnotations;

namespace identityLearning.ViewModels
{
    public class PasswordResetViewModel
    {
        [Display(Name = "Email Adresiniz")]
        [Required(ErrorMessage = "Email Alanı Gereklidir")]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Yeni Şifreniz")]
        [Required(ErrorMessage = "Şifre Alanı Gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifreniz en az 4 karakterli olmalı")]
        public string PasswordNew { get; set; }

    }
}