using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyIdentityServer.AuthServer.Models
{
    public class CustomDbContext : DbContext
    {

        
        public DbSet<CustomUser> customUsers { get; set; }
        
        public CustomDbContext(DbContextOptions opts): base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomUser>().HasData(
                new CustomUser() { id = 1, Emai = "halil@gmail.com", Password = "password", City = "İstanbul", UserName = "halilKaya" },
                new CustomUser() { id = 2, Emai = "ahmet@gmail.com", Password = "password", City = "Ankara", UserName = "ahmetKaya" },
                new CustomUser() { id = 3, Emai = "mehmet@gmail.com", Password = "password", City = "Mardin", UserName = "mehmetKaya" }
                );



            base.OnModelCreating(modelBuilder);
        }


    }
}
