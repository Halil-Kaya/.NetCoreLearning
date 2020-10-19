using System.ComponentModel.DataAnnotations;

namespace UdemyApiWithToken.Resources
{
    public class LoginResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}