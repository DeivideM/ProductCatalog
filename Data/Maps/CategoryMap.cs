using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Entities;

namespace ProductCatalog.Data.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);
        }
    }
}
