using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace identityLearning.Models
{
    public class AppUser : IdentityUser
    {


        public string City { get; set; }
        [MaxLength(500)]
        public string Picture { get; set; }
        public DateTime? BirthDay { get; set; }
        public int Gender { get; set; }

        public sbyte? TwoFactor { get; set; }


    }
}