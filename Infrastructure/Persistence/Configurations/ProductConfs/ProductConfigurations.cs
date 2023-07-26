using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.ProductConfs;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID).HasColumnName("id").IsRequired().IsConcurrencyToken();
        builder.Property(x => x.Name).IsRequired().HasColumnName("name").HasMaxLength(64);
        builder.Property(x => x.CategoryID).IsRequired().HasColumnName("category_id");
        builder.Property(x => x.Image).IsRequired().HasColumnName("image");
        builder.Property(x => x.Description).IsRequired().HasColumnName("description").HasMaxLength(128);
        // builder.Property(x => x.FullDescriptionID).HasColumnName("full_description_id");

        builder.HasMany(x => x.ProductItems).WithOne(x => x.Product);
    }
}