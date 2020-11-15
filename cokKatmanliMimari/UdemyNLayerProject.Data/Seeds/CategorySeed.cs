using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {

        private readonly int[] _ids;

        public CategorySeed(int[] ids){
            this._ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasData(
                new Category{Id = this._ids[0], Name = "Kalemler"},
                new Category{Id = this._ids[1], Name = "Defterler"}
            );

        }
    }
}