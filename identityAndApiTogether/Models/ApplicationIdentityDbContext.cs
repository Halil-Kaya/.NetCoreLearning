using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace againAndAgainWhenWillYouStop.Models
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {

        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options){}
        
    }
}