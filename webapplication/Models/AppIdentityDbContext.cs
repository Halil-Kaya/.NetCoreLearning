using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webapplication.Models
{

    public class AppIdentityDbContext : IdentityDbContext<AppUser,AppRole,string>
    {


        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options){}
    

        
    }

}