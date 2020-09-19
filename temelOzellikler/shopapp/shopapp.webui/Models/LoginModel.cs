using System.ComponentModel.DataAnnotations;

namespace shopapp.webui.Models
{
    public class LoginModel
    {
        //public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}