using Microsoft.EntityFrameworkCore;
using shopapp.entity;
using shopapp.entity.obj;

namespace shopapp.data.Concrete.EfCore
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql("server=127.0.0.1;port=3305;username=root;password=;database=shop");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => new {c.CategoryId,c.ProductId});
        }

    }
}