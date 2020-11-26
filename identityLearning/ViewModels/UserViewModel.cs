using System.ComponentModel.DataAnnotations;

namespace identityLearning.ViewModels
{
    public class UserViewModel
    {


        [Required(ErrorMessage = "Kullanici ismi gereklidir.")]
        [Display(Name = "Kullanici Adi")]
        public string UserName { get; set; }
        
        [Display(Name = "Tel No")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Email adresi gereklidir")]
        [Display(Name = "Email Adresiniz")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Şifreniz Gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}