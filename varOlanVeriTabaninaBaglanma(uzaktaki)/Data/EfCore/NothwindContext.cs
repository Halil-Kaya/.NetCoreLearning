using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace varOlanVeriTabaninaBaglanma.Data.EfCore
{
    public partial class NothwindContext : DbContext
    {
        public NothwindContext()
        {
        }

        public NothwindContext(DbContextOptions<NothwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Music> Music { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=win12p12-516.srvpanel.com;user=akust_emre;password=InovatifArge2020;database=akustikaraoke_com_database", x => x.ServerVersion("5.6.48-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>(entity =>
            {
                entity.ToTable("music");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Muzisyen)
                    .IsRequired()
                    .HasColumnName("muzisyen")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Tur)
                    .IsRequired()
                    .HasColumnName("tur")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
