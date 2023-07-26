using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.ProductConfs;

public class ProductItemConfigurations : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID).HasColumnName("id").IsRequired().IsConcurrencyToken();
        builder.Property(x => x.ProductID).HasColumnName("product_id");
        builder.Property(x => x.SKU).HasColumnName("sku").HasMaxLength(11000);
        builder.Property(x => x.Quantity).HasColumnName("quantity");
        builder.Property(x => x.Price).HasColumnName("price").HasColumnType("Money");


        builder.HasMany(x => x.ProductConfs).WithOne(x => x.ProductItem);
        builder.HasMany(x => x.CartItems).WithOne(x => x.ProductItem);
        builder.HasMany(x => x.OrderLines).WithOne(x => x.ProductItem);
        builder.HasMany(x => x.PromotionProducts).WithOne(x => x.ProductItem);
    }
}