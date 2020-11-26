using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.models;
using UdemyNLayerProject.Data.Configurations;
using UdemyNLayerProject.Data.Seeds;

namespace UdemyNLayerProject.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(){

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}       

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;username=root;password=;database=test", x => x.ServerVersion("5.6.48-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[]{1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[]{1,2}));

            modelBuilder.Entity<Person>().HasKey(x => x.Id);

            modelBuilder.Entity<Person>().Property(x => x.Id).UseMySqlIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.SurName).HasMaxLength(100);

        }



    }
}