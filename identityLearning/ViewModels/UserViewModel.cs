using System;
using System.ComponentModel.DataAnnotations;
using identityLearning.Enums;

namespace identityLearning.ViewModels
{
    public class UserViewModel
    {


        [Required(ErrorMessage = "Kullanici ismi gereklidir.")]
        [Display(Name = "Kullanici Adi")]
        public string UserName { get; set; }
        
        [Display(Name = "Tel No")]
        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$" , ErrorMessage = "Telefon Numarası Uygun formatta değil")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Email adresi gereklidir")]
        [Display(Name = "Email Adresiniz")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Şifreniz Gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }
        
        [Display(Name = "Profil Resmi")]
        public string Picture { get; set; }
        
        [Display(Name = "Şehir")]
        public string City { get; set; }
        
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }



    }
}