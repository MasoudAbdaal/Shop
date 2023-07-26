using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.PromotionConfs;

public class PromotionProductsConfigurations : IEntityTypeConfiguration<PromotionProducts>
{
    public void Configure(EntityTypeBuilder<PromotionProducts> builder)
    {
        builder.HasKey(x => new { x.ProductItemID, x.PromotionID });

        builder.Property(c => c.PromotionID).HasColumnName("promotion_id");
        builder.Property(c => c.ProductItemID).HasColumnName("product_item_id");
    }
}