using System.ComponentModel.DataAnnotations;

namespace webapplication.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanici ismi gerekli")]
        [Display(Name = "Kullanici Adi")]
        public string UserName { get; set; }
        
        [Display(Name = "Tel No:")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Email adresi gerekli")]
        [Display(Name = "Email adresiniz")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifreniz gerekli")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}