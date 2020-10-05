using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Entities
{
    public partial class UdemyApiWithTokenDBContext : DbContext
    {
        public UdemyApiWithTokenDBContext()
        {
        }

        public UdemyApiWithTokenDBContext(DbContextOptions<UdemyApiWithTokenDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            //bunu burda koymuyorum normalde silmem lazım ama görmen için buraya bırakıyorum bunu burda yazmam güvenli değil bir nevi sistem açığı
            //veri tabanına bağlanmak için gerekli bilgileri appsettings.json dosyasına koydum startup kısmında ise dosya aracılığıyla veri tabanına
            //bağlantıyı gerçekleştirdim böylece daha güvenli oldu
            
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3305;username=root;database=UdemyApiWithTokenDB", x => x.ServerVersion("10.4.13-mariadb"));
            }
            
            


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Price).HasColumnType("decimal(10,0)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(8)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RefreshToken)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RefreshTokenEndDate).HasColumnType("datetime");

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
