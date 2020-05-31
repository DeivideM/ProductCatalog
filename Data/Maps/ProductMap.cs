using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Entities;

namespace ProductCatalog.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.CreateDate).IsRequired();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(x => x.Image)
                .IsRequired()
                .HasMaxLength(1024)
                .IsUnicode(false);

            builder.Property(x => x.LastUpdateDate)
            .IsRequired();

            builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnType("money");

            builder.Property(x => x.Quantity)
            .IsRequired();

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);

            builder.HasOne(x => x.Category).WithMany(x => x.Products);
        }
    }
}
