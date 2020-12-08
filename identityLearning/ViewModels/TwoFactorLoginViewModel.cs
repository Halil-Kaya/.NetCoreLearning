using System.ComponentModel.DataAnnotations;
using identityLearning.Enums;

namespace identityLearning.ViewModels
{
    public class TwoFactorLoginViewModel
    {
        
        [Display(Name = "Doğrulama kodunuz")]
        [Required(ErrorMessage = "Doğrulama kodu boş olamaz")]
        [StringLength(8,ErrorMessage = "Doğrulama kodunuz en fazla 8 haneli olabilir")]
        public string VerificationCode { get; set; }
        
        public bool isRememberMe { get; set; }

        public bool isRecoverCode { get; set; }
        
        public TwoFactor TwoFactorType { get; set; }

    }
}