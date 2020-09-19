using System.ComponentModel.DataAnnotations;

namespace shopapp.webui.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set;}
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string RePassword { get; set; }
        
        public string Email { get; set; }

    }
}