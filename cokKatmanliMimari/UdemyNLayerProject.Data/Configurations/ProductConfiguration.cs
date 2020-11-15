using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.models;

namespace UdemyNLayerProject.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            
            builder.Property(x => x.Stock).IsRequired();

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            
            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            builder.ToTable("Products");

        }
    }
}