using System.ComponentModel.DataAnnotations;

namespace identityLearning.ViewModels
{
    public class PasswordChangeViewModel
    {
        [Display(Name = "Eski Şifreniz")]
        [Required(ErrorMessage = "Eski Şifreniz Gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifreniz En Az 4 Karakterli Olmalıdır")]
        public string PasswordOld { get; set; }


        [Display(Name = "Yeni Şifreniz")]
        [Required(ErrorMessage = "Yeni Şifreniz Gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifreniz En Az 4 Karakterli Olmalıdır")]
        public string PasswordNew { get; set; }


        [Display(Name = "Onay Şifreniz")]
        [Required(ErrorMessage = "Onay Şifreniz Gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Şifreniz En Az 4 Karakterli Olmalıdır")]
        [Compare("PasswordNew",ErrorMessage = "yeni şifreniz ve onay şifreniz birbirinden farklıdır")]
        public string PasswordConfirm { get; set; }

    }
}