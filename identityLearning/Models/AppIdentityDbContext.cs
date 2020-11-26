using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identityLearning.Models
{
    public class AppIdentityDbContext : IdentityDbContext <AppUser,AppRole,string>
    {

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options){

                

        }   
        
    }
}