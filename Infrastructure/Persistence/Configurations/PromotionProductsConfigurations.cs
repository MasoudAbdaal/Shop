using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.RepoConfigurations
{
    public class PromotionProductsConfigurations : IEntityTypeConfiguration<PromotionProducts>
  {
    public void Configure(EntityTypeBuilder<PromotionProducts> builder)
    {
      builder.HasKey(x => new { x.ProductItemID, x.PromotionID });
    }
  }
}